using Advanced_Combat_Tracker;
using Aliapoh.Overlay.Logger;
using System;
using System.Linq;

namespace Aliapoh
{
    public partial class PluginLoader
    {
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
            var formatter = new CombatantData.TextExportFormatter(key, key, key, act);
            if (!CombatantData.ExportVariables.ContainsKey(key))
                CombatantData.ExportVariables.Add(key, formatter);
        }

        private void AddEncounterData(string key, EncounterData.ExportStringDataCallback act)
        {
            var formatter = new EncounterData.TextExportFormatter(key, key, key, act);
            if (!EncounterData.ExportVariables.ContainsKey(key))
                EncounterData.ExportVariables.Add(key, formatter);
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
            catch (Exception ex)
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
            catch (Exception ex)
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
            catch (Exception ex)
            {
                LOG.Logger.Log(LogLevel.Error, ex.Message);
                return "0";
            }
        }
    }
}
