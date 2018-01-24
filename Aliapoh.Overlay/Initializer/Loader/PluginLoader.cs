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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aliapoh.Initializer
{
    public class PluginLoader : IDisposable
    {
        private string updateStringCache;
        private DateTime updateStringCacheLastUpdate;

        public static string PluginDirectory;
        public static string CurrentUserName = "YOU";
        public static int CurrentZoneCode;

        public IActPluginV1 Plugin;
        public OverlayController OverlayController;
        public TabPage PluginTabPage;
        public Label PluginStatusLabel;

        public void Dispose()
        {
            // dispose OverlayController
            OverlayController.Dispose();
            // unregister handlers
            ActGlobals.oFormActMain.BeforeLogLineRead -= OFormActMain_BeforeLogLineRead;
            ActGlobals.oFormActMain.OnLogLineRead -= OFormActMain_OnLogLineRead;
            ActGlobals.oFormActMain.OnCombatEnd -= OFormActMain_OnCombatEnd;
            ActGlobals.oFormActMain.OnCombatStart -= OFormActMain_OnCombatStart;
            // shutdown CEF
            Cef.Shutdown();
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

        private void AddVariables()
        {
            // ACTColumnAdder Compatible
            AddEncounterData("CurrentRealUserName", (Data, Extra, Format) => { return CurrentUserName; });
            AddEncounterData("CurrentZoneRaw", (Data, Extra, Format) => { return CurrentZoneCode.ToString(); });
            // OverlayPlugin Compatible
            AddEncounterData("PrimaryUser", (Data, Extra, Format) => { return CurrentUserName; });

            AddCombatantData("overHeal", Overheal);
            AddCombatantData("damageShield", DamageShield);
            AddCombatantData("absorbHeal", AbsorbHeal);

            ActGlobals.oFormActMain.ValidateLists();
        }

        private void AddCombatantData(string key, CombatantData.ExportStringDataCallback act)
        {
            if(!CombatantData.ExportVariables.ContainsKey(key))
            {
                var formatter = new CombatantData.TextExportFormatter(key, key, key, act);
                CombatantData.ExportVariables.Add(key, formatter);
            }
        }

        private void AddEncounterData(string key, EncounterData.ExportStringDataCallback act)
        {
            if(!EncounterData.ExportVariables.ContainsKey(key))
            {
                var formatter = new EncounterData.TextExportFormatter(key, key, key, act);
                EncounterData.ExportVariables.Add(key, formatter);
            }
        }

        private string Overheal(CombatantData data, string format)
        {
            try
            {
                return data.Items[CombatantData.DamageTypeDataOutgoingHealing].Items.ToList()
                    .Where(x => x.Key == "All")
                    .Sum(x => x.Value.Items.ToList().Where(y => y.Tags.ContainsKey("overheal"))
                    .Sum(y => Convert.ToInt64(y.Tags["overheal"]))).ToString();
            }
            catch(Exception ex)
            {
                LOG.Logger.Log(LogLevel.Error, ex.Message);
                return "0";
            }
        }

        private string DamageShield(CombatantData data, string format)
        {
            try
            {
                return data.Items[CombatantData.DamageTypeDataOutgoingHealing].Items.ToList()
                    .Where(x => x.Key == "All")
                    .Sum(x => x.Value.Items.Where(y => { if (y.DamageType == "DamageShield") return true; else return false; })
                    .Sum(y => Convert.ToInt64(y.Damage))).ToString();
            }
            catch(Exception ex)
            {
                LOG.Logger.Log(LogLevel.Error, ex.Message);
                return "0";
            }
        }

        private string AbsorbHeal(CombatantData data, string format)
        {
            try
            {
                return data.Items[CombatantData.DamageTypeDataOutgoingHealing].Items.ToList()
                    .Where(x => x.Key == "All")
                    .Sum(x => x.Value.Items.Where(y => y.DamageType == "Absorb")
                    .Sum(y => Convert.ToInt64(y.Damage))).ToString();
            }
            catch(Exception ex)
            {
                LOG.Logger.Log(LogLevel.Error, ex.Message);
                return "0";
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

        }

        internal string CreateJsonData()
        {
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

        private Dictionary<string, string> Encounters(List<CombatantData> allies)
        {
            var dict = new Dictionary<string, string>();
            foreach(var kv in EncounterData.ExportVariables)
            {
                try
                {
                    if (kv.Key == "Last10DPS" ||
                        kv.Key == "Last30DPS" ||
                        kv.Key == "Last60DPS" ||
                        kv.Key == "Last180DPS")
                    {
                        if (!allies.All((ally) => ally.Items[CombatantData.DamageTypeDataOutgoingDamage].Items.ContainsKey("All")))
                        {
                            dict.Add(kv.Key, "");
                            continue;
                        }
                    }
                    var value = kv.Value.GetExportString(ActGlobals.oFormActMain.ActiveZone.ActiveEncounter, allies, "");
                    dict.Add(kv.Key, value);
                }
                catch
                {

                }
            }
            return dict;
        }

        private List<KeyValuePair<CombatantData,Dictionary<string,string>>> Combatants(List<CombatantData> allies)
        {
            var list = new List<KeyValuePair<CombatantData, Dictionary<string, string>>>();
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

                lock (list)
                {
                    list.Add(new KeyValuePair<CombatantData, Dictionary<string, string>>(ally, valueDict));
                }
            }
            );
            return list;
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

        private void InitializeComponent()
        {
            OverlayController = new OverlayController()
            {
                Dock = DockStyle.Fill
            };
            PluginTabPage.Controls.Add(OverlayController);
        }
    }
}