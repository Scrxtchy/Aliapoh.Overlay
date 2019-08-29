using Advanced_Combat_Tracker;
using Aliapoh.Overlays.Logger;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aliapoh.OverlayPlugin.Core.Overlays
{
    public partial class LogParseOverlay : OverlayBase<LogParseOverlayConfig>
    {
        private string prevEncounterId { get; set; }
        private DateTime prevEndDateTime { get; set; }
        private bool prevEncounterActive { get; set; }

        private static string updateStringCache = "";
        private static DateTime updateStringCacheLastUpdate;
        private static readonly TimeSpan updateStringCacheExpireInterval = new TimeSpan(0, 0, 0, 0, 500); // 500 msec

        public LogParseOverlay(LogParseOverlayConfig config) : base(config, config.Name)
        {
            // Part of ACT.SpecialSpellTimer: https://github.com/anoyetta/ACT.SpecialSpellTimer/blob/master/ACT.SpecialSpellTimer/LogBuffer.cs
            // Copyright (c) 2014 anoyetta; Licensed under BSD-3-Clause license.
            try
            {
                var fi = ActGlobals.oFormActMain.GetType().GetField(
                    "BeforeLogLineRead",
                    BindingFlags.NonPublic |
                    BindingFlags.Instance |
                    BindingFlags.GetField |
                    BindingFlags.Public |
                    BindingFlags.Static);

                Delegate beforeLogLineReadDelegate =
                    fi.GetValue(ActGlobals.oFormActMain)
                    as Delegate;

                if (beforeLogLineReadDelegate != null)
                {
                    var handlers = beforeLogLineReadDelegate.GetInvocationList();

                    // 全てのイベントハンドラを一度解除する
                    foreach (var handler in handlers)
                    {
                        ActGlobals.oFormActMain.BeforeLogLineRead -= (LogLineEventDelegate)handler;
                    }

                    // スペスペのイベントハンドラを最初に登録する
                    ActGlobals.oFormActMain.BeforeLogLineRead += LogLineReader;

                    // 解除したイベントハンドラを登録し直す
                    foreach (var handler in handlers)
                    {
                        ActGlobals.oFormActMain.BeforeLogLineRead += (LogLineEventDelegate)handler;
                    }
                }
            }
            catch (Exception ex)
            {
                LOG.Logger.Log(LogLevel.Error, "AddOnBeforeLogLineRead error:", ex);
            }
        }

        public override void Navigate(string url)
        {
            base.Navigate(url);

            prevEncounterId = null;
            prevEndDateTime = DateTime.MinValue;
        }

        protected override void Update()
        {
            if (CheckIsActReady())
            {
                if (prevEncounterId == ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.EncId &&
                    prevEndDateTime == ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.EndTime &&
                    prevEncounterActive == ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.Active)
                {
                    return;
                }

                prevEncounterId = ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.EncId;
                prevEndDateTime = ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.EndTime;
                prevEncounterActive = ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.Active;

                var updateScript = CreateEventDispatcherScript();

                if (Overlay != null &&
                    Overlay != null &&
                    Overlay.Browser != null)
                {
                    Overlay.ExecuteScript(updateScript);
                }
            }
        }

        private string CreateEventDispatcherScript()
        {
            return "document.dispatchEvent(new CustomEvent('onOverlayDataUpdate', { detail: " + CreateJsonData() + " }));";
        }

        internal string CreateJsonData()
        {
            if (DateTime.Now - updateStringCacheLastUpdate < updateStringCacheExpireInterval)
            {
                return updateStringCache;
            }

            if (!CheckIsActReady())
            {
                return "{}";
            }

#if DEBUG
            var stopwatch = new Stopwatch();
            stopwatch.Start();
#endif

            var allies = ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.GetAllies();
            Dictionary<string, string> encounter = null;
            List<KeyValuePair<CombatantData, Dictionary<string, string>>> combatant = null;

            var encounterTask = Task.Run(() =>
            {
                encounter = GetEncounterDictionary(allies);
            });
            var combatantTask = Task.Run(() =>
            {
                combatant = GetCombatantList(allies);
            });
            Task.WaitAll(encounterTask, combatantTask);

            JObject obj = new JObject
            {
                ["Encounter"] = JObject.FromObject(encounter),
                ["Combatant"] = new JObject()
            };

            foreach (var pair in combatant)
            {
                JObject value = new JObject();
                foreach (var pair2 in pair.Value)
                {
                    value.Add(pair2.Key, Util.ReplaceNaNString(pair2.Value, "---"));
                }

                obj["Combatant"][pair.Key.Name] = value;
            }

            obj["isActive"] = ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.Active ? "true" : "false";

#if DEBUG
            stopwatch.Stop();
            LOG.Logger.Log(LogLevel.Trace, "CreateUpdateScript: {0} msec", stopwatch.Elapsed.TotalMilliseconds);
#endif

            var result = obj.ToString();
            updateStringCache = result;
            updateStringCacheLastUpdate = DateTime.Now;

            return result;
        }

        private List<KeyValuePair<CombatantData, Dictionary<string, string>>> GetCombatantList(List<CombatantData> allies)
        {
#if DEBUG
            var stopwatch = new Stopwatch();
            stopwatch.Start();
#endif

            var combatantList = new List<KeyValuePair<CombatantData, Dictionary<string, string>>>();
            Parallel.ForEach(allies, (ally) =>
            {
                var valueDict = new Dictionary<string, string>();
                foreach (var exportValuePair in CombatantData.ExportVariables)
                {
                    try
                    {
                        if (exportValuePair.Key == "NAME")
                        {
                            continue;
                        }

                        if (exportValuePair.Key == "Last10DPS" ||
                            exportValuePair.Key == "Last30DPS" ||
                            exportValuePair.Key == "Last60DPS")
                        {
                            if (!ally.Items[CombatantData.DamageTypeDataOutgoingDamage].Items.ContainsKey("All"))
                            {
                                valueDict.Add(exportValuePair.Key, "");
                                continue;
                            }
                        }

                        var value = exportValuePair.Value.GetExportString(ally, "");
                        valueDict.Add(exportValuePair.Key, value);
                    }
                    catch (Exception e)
                    {
                        LOG.Logger.Log(LogLevel.Debug, "GetCombatantList: {0}: {1}: {2}", ally.Name, exportValuePair.Key, e);
                        continue;
                    }
                }

                lock (combatantList)
                {
                    combatantList.Add(new KeyValuePair<CombatantData, Dictionary<string, string>>(ally, valueDict));
                }
            }
            );

#if DEBUG
            stopwatch.Stop();
            LOG.Logger.Log(LogLevel.Trace, "GetCombatantList: {0} msec", stopwatch.Elapsed.TotalMilliseconds);
#endif

            return combatantList;
        }

        private Dictionary<string, string> GetEncounterDictionary(List<CombatantData> allies)
        {
#if DEBUG
            var stopwatch = new Stopwatch();
            stopwatch.Start();
#endif

            var encounterDict = new Dictionary<string, string>();
            foreach (var exportValuePair in EncounterData.ExportVariables)
            {
                try
                {
                    if (exportValuePair.Key == "Last10DPS" ||
                        exportValuePair.Key == "Last30DPS" ||
                        exportValuePair.Key == "Last60DPS")
                    {
                        if (!allies.All((ally) => ally.Items[CombatantData.DamageTypeDataOutgoingDamage].Items.ContainsKey("All")))
                        {
                            encounterDict.Add(exportValuePair.Key, "");
                            continue;
                        }
                    }

                    var value = exportValuePair.Value.GetExportString(
                        ActGlobals.oFormActMain.ActiveZone.ActiveEncounter,
                        allies,
                        "");
                    encounterDict.Add(exportValuePair.Key, value);
                }
                catch (Exception e)
                {
                    LOG.Logger.Log(LogLevel.Debug, "GetEncounterDictionary: {0}: {1}", exportValuePair.Key, e);
                }
            }
            //);

#if DEBUG
            stopwatch.Stop();
            LOG.Logger.Log(LogLevel.Trace, "GetEncounterDictionary: {0} msec", stopwatch.Elapsed.TotalMilliseconds);
#endif

            return encounterDict;
        }

        private static bool CheckIsActReady()
        {
            if (ActGlobals.oFormActMain != null &&
                ActGlobals.oFormActMain.ActiveZone != null &&
                ActGlobals.oFormActMain.ActiveZone.ActiveEncounter != null &&
                EncounterData.ExportVariables != null &&
                CombatantData.ExportVariables != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
