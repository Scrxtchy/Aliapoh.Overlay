using Advanced_Combat_Tracker;
using Aliapoh.Overlay;
using Aliapoh.Overlay.ACTPlugin;
using Aliapoh.Overlay.Logger;
using Aliapoh.Overlay.OverlayManager;
using CefSharp;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aliapoh
{
    public partial class PluginLoader : IDisposable
    {
        private string updateStringCache;
        private DateTime updateStringCacheLastUpdate;
        private static readonly TimeSpan updateStringCacheExpireInterval = new TimeSpan(0, 0, 0, 0, 250);

        public static string PluginDirectory;
        public static string CurrentUserName = "YOU";
        public static int CurrentZoneCode;

        public IActPluginV1 Plugin;
        public OverlayController OC;
        public TabPage PluginTabPage;
        public Label PluginStatusLabel;

        public void Dispose()
        {
            // shutdown CEF
            Cef.Shutdown();
            // dispose OverlayController
            OC.Dispose();
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
        }

        private void OC_OverlayTabAdd(object sender, OverlayTabAddEventArgs e)
        {
            try
            {
                e.Config.Overlay.OverlayTicTimer.Tick += TickEvent;
            }
            catch(Exception ex)
            {
                LOG.Logger.Log(LogLevel.Error, ex.Message);
            }
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

            OC.OverlayTabAdd += OC_OverlayTabAdd;
            PluginTabPage.Controls.Add(OC);

            foreach (var i in OverlayController.OverlayConfigs)
                i.Value.Overlay.OverlayTicTimer.Tick += TickEvent;
        }

        private void OFormActMain_BeforeLogLineRead(bool isImport, LogLineEventArgs logInfo)
        {
            var data = logInfo.logLine.Split('|');
            if(data.Length > 1)
            {
                switch((MessageType)int.Parse(data[0]))
                {
                    case MessageType.ChangePrimaryPlayer:
                        if (data.Length < 4) return;
                        CurrentUserName = data[3];
                        break;
                    case MessageType.ChangeZone:
                        if (data.Length < 3) return;
                        CurrentZoneCode = Convert.ToInt32(data[2], 16);
                        break;
                }
            }
        }

        private void OFormActMain_OnLogLineRead(bool isImport, LogLineEventArgs logInfo)
        {

        }

        private void OFormActMain_OnCombatStart(bool isImport, CombatToggleEventArgs encounterInfo)
        {

        }

        private void OFormActMain_OnCombatEnd(bool isImport, CombatToggleEventArgs encounterInfo)
        {

        }

        public void TickEvent(object sender, EventArgs e)
        {
            try
            {
                var timer = ((OTimer)sender);
                timer.Overlay.ExecuteJavascript("document.dispatchEvent(new CustomEvent('onOverlayDataUpdate', { detail: " + CreateJsonData() + " }));");
            }
            catch(Exception ex)
            {
                LOG.Logger.Log(LogLevel.Error, ex.Message);
            }
        }

        internal string CreateJsonData()
        {
            try
            {
                if (DateTime.Now - updateStringCacheLastUpdate < updateStringCacheExpireInterval)
                {
                    return updateStringCache;
                }

                if (!ActReady()) return "{}";

                var allies = ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.GetAllies();
                var encounter = new Dictionary<string, string>();
                var combatant = new List<KeyValuePair<CombatantData, Dictionary<string, string>>>();

                var encounterTask = Task.Run(() =>
                {
                    encounter = Encounters(allies);
                });
                var combatantTask = Task.Run(() =>
                {
                    combatant = Combatants(allies);
                });
                Task.WaitAll(encounterTask, combatantTask);

                var Data = new JObject();
                Data["Combatant"] = new JObject();
                Data["Encounter"] = JObject.FromObject(encounter);

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
                updateStringCache = result;
                updateStringCacheLastUpdate = DateTime.Now;
                return result;
            }
            catch(Exception ex)
            {
                LOG.Logger.Log(LogLevel.Error, ex.Message);
                return "{}";
            }
        }

        private Dictionary<string, string> Encounters(List<CombatantData> allies)
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

        private List<KeyValuePair<CombatantData,Dictionary<string,string>>> Combatants(List<CombatantData> allies)
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
            if (EncounterData.ExportVariables == null) return false;
            if (CombatantData.ExportVariables == null) return false;
            return true;
        }
    }
}