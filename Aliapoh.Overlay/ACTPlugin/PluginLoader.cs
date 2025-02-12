﻿using Advanced_Combat_Tracker;
using Aliapoh.Overlays;
using Aliapoh.Overlays.ACTPlugin;
using Aliapoh.Overlays.Logger;
using Aliapoh.Overlays.OverlayManager;
using CefSharp;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aliapoh
{
    public partial class PluginLoader : IDisposable
    {
        private static readonly TimeSpan updateStringCacheExpireInterval = new TimeSpan(0, 0, 0, 0, 250);

        public static string PluginDirectory;
        public static string CurrentUserName = "YOU";
        public static int CurrentZoneCode;

        public IActPluginV1 Plugin;
        public OverlayController OC;
        public TabPage PluginTabPage;
        public Label PluginStatusLabel;
        public bool ZoneActive = false;

        public void Dispose()
        {
            foreach(OverlayTabPage i in OC.overlayManageTabControl1.TabPages)
            {
                i.Overlay.Close();
            }
            // dispose OverlayController
            OC.Dispose();
            // shutdown CEF
            Cef.Shutdown();
            // unregister handlers
            ActGlobals.oFormActMain.BeforeLogLineRead -= OFormActMain_BeforeLogLineRead;
            ActGlobals.oFormActMain.OnLogLineRead -= OFormActMain_OnLogLineRead;
            ActGlobals.oFormActMain.OnCombatEnd -= OFormActMain_OnCombatEnd;
            ActGlobals.oFormActMain.OnCombatStart -= OFormActMain_OnCombatStart;
        }

        public PluginLoader(TabPage tp, Label lbl, string pluginDirectory, IActPluginV1 plugin)
        {
            PluginDirectory = pluginDirectory;
            PluginTabPage = tp;
            PluginStatusLabel = lbl;
            AttachBeforeLogLineRead();
            ActGlobals.oFormActMain.OnLogLineRead += OFormActMain_OnLogLineRead;
            ActGlobals.oFormActMain.OnCombatEnd += OFormActMain_OnCombatEnd;
            ActGlobals.oFormActMain.OnCombatStart += OFormActMain_OnCombatStart;

            InitializeComponent();
            new Thread((ThreadStart)delegate
            {
                try
                {
                    while (!Process.GetCurrentProcess().HasExited)
                    {
                        if (!ActReady()) continue;

                        var text = "document.dispatchEvent(new CustomEvent('onOverlayDataUpdate', {detail: " + CreateJsonData() + "}));";

                        OC.overlayManageTabControl1.Invoke((MethodInvoker)delegate
                        {
                            try
                            {
                                foreach (OverlayTabPage i in OC.overlayManageTabControl1.TabPages)
                                {
                                    if (i.Overlay.Handle != null)
                                        i.Overlay.ExecuteJavascript(text);
                                }
                            }
                            catch (Exception ex)
                            {
                                LOG.Logger.Log(LogLevel.Error, ex.Message);
                            }
                        });
                        Thread.Sleep(500);
                    }
                }
                catch { }
            }).Start();
        }

        private void OFormActMain_OnLogLineRead(bool isImport, LogLineEventArgs logInfo)
        {

        }

        private void AttachBeforeLogLineRead()
        {
            try
            {
                var Fields = ActGlobals.oFormActMain.GetType().GetField("BeforeLogLineRead", (BindingFlags)(4 | 8 | 16 | 32 | 1024));
                var oDelegate = (Delegate)Fields.GetValue(ActGlobals.oFormActMain);
                if (oDelegate != null)
                {
                    var Handlers = oDelegate.GetInvocationList();
                    foreach (var h in Handlers) ActGlobals.oFormActMain.BeforeLogLineRead -= (LogLineEventDelegate)h;
                    ActGlobals.oFormActMain.BeforeLogLineRead += OFormActMain_BeforeLogLineRead;
                    foreach (var h in Handlers) ActGlobals.oFormActMain.BeforeLogLineRead += (LogLineEventDelegate)h;
                }
            }
            catch(Exception ex)
            {
                LOG.Logger.Log(LogLevel.Error, ex.Message);
            }
        }

        private void InitializeComponent()
        {
            OC = new OverlayController()
            {
                Dock = DockStyle.Fill,
            };

            PluginTabPage.Controls.Add(OC);
        }

        private void OFormActMain_BeforeLogLineRead(bool isImport, LogLineEventArgs logInfo)
        {
            var data = logInfo.logLine.Split('|');
            if(data.Length > 1)
            {
                JObject details = new JObject();

                if (data.Length >= 3)
                {
                    details = new JObject
                    {
                        ["detail"] = new JObject()
                        {
                            ["opcode"] = int.Parse(data[0]),
                            ["timestamp"] = data[1],
                            ["payload"] = JArray.FromObject(data.Skip(2)),
                        }
                    };
                }

                switch ((MessageType)int.Parse(data[0]))
                {
                    case MessageType.ChangePrimaryPlayer:
                        {
                            if (data.Length < 4) return;
                            CurrentUserName = data[3];
                            var val = new JObject()
                            {
                                ["detail"] = new JObject
                                {
                                    ["name"] = CurrentUserName
                                }
                            };
                            var text = $"document.dispatchEvent(new CustomEvent('onChangePrimaryPlayer', {val.ToString()}));";
                            var old = $"document.dispatchEvent(new CustomEvent('onLogLine',{details.ToString()}));";

                            foreach (OverlayTabPage i in OC.overlayManageTabControl1.TabPages)
                            {
                                try
                                {
                                    if (i.Overlay.Handle != null)
                                    {
                                        i.Overlay.ExecuteJavascript(text);
                                        // OverlayPlugin LogLine Support
                                        i.Overlay.ExecuteJavascript(old);
                                    }
                                }
                                catch { }
                            }
                        }
                        break;
                    case MessageType.ChangeZone:
                        if (data.Length < 3) return;
                        CurrentZoneCode = Convert.ToInt32(data[2], 16);
                        break;
                    case MessageType.LogLine:

                        break;
                    default:
                        {
                            if (data.Length < 3) return;
                            var text = $"document.dispatchEvent(new CustomEvent('onLogLine',{details.ToString()}));";

                            foreach (OverlayTabPage i in OC.overlayManageTabControl1.TabPages)
                            {
                                if (i.Overlay.Handle != null && i.Config.OverlayEnableBeforeLogLineRead.Checked)
                                    i.Overlay.ExecuteJavascript(text);
                            }
                        }
                        break;
                }
            }
        }

        private void OFormActMain_OnCombatStart(bool isImport, CombatToggleEventArgs encounterInfo)
        {

        }

        private void OFormActMain_OnCombatEnd(bool isImport, CombatToggleEventArgs encounterInfo)
        {

        }

        internal string CreateJsonData()
        {
            try
            {
                if (!ActReady())
                {
                    return new JObject().ToString();
                }

                var allies = ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.GetAllies();
                var encounter = new Dictionary<string, string>();
                var combatant = new List<KeyValuePair<CombatantData, Dictionary<string, string>>>();

                var encounterTask = Task.Run(() =>
                {
                    encounter = GetEncounterDictionary(allies);
                });
                var combatantTask = Task.Run(() =>
                {
                    combatant = GetCombatantList(allies);
                });

                Task.WaitAll(encounterTask, combatantTask);
                var Data = new JObject
                {
                    ["Encounter"] = JObject.FromObject(encounter),
                    ["Combatant"] = new JObject()
                };

                foreach (var pair in combatant)
                {
                    var value = new JObject();
                    foreach (var pair2 in pair.Value)
                    {
                        value.Add(pair2.Key, pair2.Value.Replace(double.NaN.ToString(), "0"));
                    }
                    Data["Combatant"][pair.Key.Name] = value;
                }

                Data["isActive"] = ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.Active ? "true" : "false";
                var result = Data.ToString();
                return result;
            }
            catch(Exception ex)
            {
                LOG.Logger.Log(LogLevel.Error, ex.GetBaseException().ToString());
                return "{}";
            }
        }

        public List<KeyValuePair<CombatantData, Dictionary<string, string>>>
            GetCombatantList(List<CombatantData> allies)
        {
            var combatantList = new List<KeyValuePair<CombatantData, Dictionary<string, string>>>();
            Parallel.ForEach(allies, (ally) =>
            {
                var valueDict = new Dictionary<string, string>();
                bool FindOverheal = false;
                foreach (var exportValuePair in CombatantData.ExportVariables)
                {
                    try
                    {
                        if (exportValuePair.Key.StartsWith("NAME"))
                        {
                            continue;
                        }

                        if ((exportValuePair.Key == "Last10DPS" ||
                            exportValuePair.Key == "Last30DPS" ||
                            exportValuePair.Key == "Last60DPS" ||
                            exportValuePair.Key == "Last180DPS") && !ally.Items[CombatantData.DamageTypeDataOutgoingDamage].Items.ContainsKey("All"))
                        {
                            valueDict.Add(exportValuePair.Key, "");
                            continue;
                        }

                        var value = exportValuePair.Value.GetExportString(ally, "");
                        valueDict.Add(exportValuePair.Key, value);
                    }
                    catch (Exception ex)
                    {
                        LOG.Logger.Log(LogLevel.Error, ex.GetBaseException().ToString());
                        continue;
                    }

                    if (exportValuePair.Key == "overHeal") FindOverheal = true;
                }

                if (!FindOverheal)
                {
                    valueDict.Add("overHeal", "0");
                }

                lock (combatantList)
                {
                    combatantList.Add(new KeyValuePair<CombatantData, Dictionary<string, string>>(ally, valueDict));
                }
            });
            return combatantList;
        }

        public Dictionary<string, string> 
            GetEncounterDictionary(List<CombatantData> allies)
        {
            bool FindOverheal = false;
            var encounterDict = new Dictionary<string, string>();
            foreach (var exportValuePair in EncounterData.ExportVariables)
            {
                try
                {
                    if ((exportValuePair.Key == "Last10DPS" ||
                        exportValuePair.Key == "Last30DPS" ||
                        exportValuePair.Key == "Last60DPS" ||
                        exportValuePair.Key == "Last180DPS") && !allies.All((ally) => ally.Items[CombatantData.DamageTypeDataOutgoingDamage].Items.ContainsKey("All")))
                    {
                        encounterDict.Add(exportValuePair.Key, "");
                        continue;
                    }

                    var value = exportValuePair.Value.GetExportString(
                        ActGlobals.oFormActMain.ActiveZone.ActiveEncounter,
                        allies,
                        "");
                    encounterDict.Add(exportValuePair.Key, value);
                }
                catch (Exception ex)
                {
                    LOG.Logger.Log(LogLevel.Error, ex.GetBaseException().ToString());
                }
                if (exportValuePair.Key == "overHeal") FindOverheal = true;
            }

            if (!FindOverheal)
            {
                encounterDict.Add("overHeal", "0");
            }
            return encounterDict;
        }

        private Dictionary<string, string> 
            Encounters(List<CombatantData> allies)
        {
            try
            {
                var dict = new Dictionary<string, string>();
                foreach (var kv in EncounterData.ExportVariables)
                {
                    try
                    {
                        if (!allies.All((ally) => ally.Items[CombatantData.DamageTypeDataOutgoingDamage].Items.ContainsKey("All")))
                        {
                            dict.Add(kv.Key, "");
                            continue;
                        }

                        var value = kv.Value.GetExportString(ActGlobals.oFormActMain.ActiveZone.ActiveEncounter, allies, "");
                        dict.Add(kv.Key, value);
                    }
                    catch (Exception ex)
                    {
                        LOG.Logger.Log(LogLevel.Error, ex.Message);
                        dict.Add(kv.Key, "");
                        continue;
                    }
                }
                return dict;
            }
            catch(Exception ex)
            {
                LOG.Logger.Log(LogLevel.Error, ex.Message);
                return null;
            }
        }

        private List<KeyValuePair<CombatantData,Dictionary<string,string>>> 
            Combatants(List<CombatantData> allies)
        {
            try
            {
                var list = new List<KeyValuePair<CombatantData, Dictionary<string, string>>>();
                CombatantData[] allies_cp = new CombatantData[allies.Count];
                allies.CopyTo(allies_cp);
                foreach(var ally in allies_cp)
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

                            if (ally.Items != null)
                            {
                                if (ally.Items[CombatantData.DamageTypeDataOutgoingDamage].Items == null)
                                {
                                    valueDict.Add(exportValuePair.Key, "");
                                    continue;
                                }

                                if (!ally.Items[CombatantData.DamageTypeDataOutgoingDamage].Items.ContainsKey("All"))
                                {
                                    valueDict.Add(exportValuePair.Key, "");
                                    continue;
                                }
                                var value = exportValuePair.Value.GetExportString(ally, "");
                                valueDict.Add(exportValuePair.Key, value);
                            }
                            else
                            {
                                valueDict.Add(exportValuePair.Key, "");
                            }
                        }
                        catch (Exception e)
                        {
                            LOG.Logger.Log(LogLevel.Debug, "GetCombatantList: {0}: {1}: {2}", ally.Name, exportValuePair.Key, e);
                            continue;
                        }
                    }

                    lock (list)
                    {
                        list.Add(new KeyValuePair<CombatantData, Dictionary<string, string>>(ally, valueDict));
                    }
                }

                allies_cp = null;
                return list;
            }
            catch(Exception ex)
            {
                LOG.Logger.Log(LogLevel.Error, ex.Message);
                return null;
            }
        }

        private bool ActReady()
        {
            if (ActGlobals.oFormActMain == null) return false;
            if (ActGlobals.oFormActMain.ActiveZone == null) return false;
            if (ActGlobals.oFormActMain.ActiveZone.ActiveEncounter == null) return false;
            return true;
        }
    }
}