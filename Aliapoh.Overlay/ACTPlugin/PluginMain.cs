using Advanced_Combat_Tracker;
using System;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using Aliapoh.Overlay;

namespace Aliapoh
{
    public class PluginMain : IActPluginV1
    {
        public static string PrimaryUser = "YOU";
        public static string pluginDirectory;

        public void DeInitPlugin()
        {

        }

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            MessageBox.Show("Start");
            if (Environment.Is64BitProcess)
                Program.CEFDIR = Loader.DIRDICT["CEFX64"];
            else
                Program.CEFDIR = Loader.DIRDICT["CEFX86"];
            Loader.Initialize();
        }

        public string GetPluginDirectory()
        {
            var plugin = ActGlobals.oFormActMain.ActPlugins.Where(x => x.pluginObj == this).FirstOrDefault();
            if (plugin != null) return Path.GetDirectoryName(plugin.pluginFile.FullName);
            else throw new Exception();
        }

        private void BeforeLogLineRead(bool isImport, LogLineEventArgs logInfo)
        {
            if (logInfo.logLine.IndexOf("02:Changed") > -1)
            {
                PrimaryUser = logInfo.logLine;
                PrimaryUser = PrimaryUser.Replace("02:Changed primary player to ", "").Replace(".", "");
                PrimaryUser = PrimaryUser.Substring(PrimaryUser.IndexOf("]") + 2);
            }
        }

        public void AddExportVariable()
        {
            if (!EncounterData.ExportVariables.ContainsKey("PrimaryUser"))
            {
                EncounterData.ExportVariables.Add("PrimaryUser",
                new EncounterData.TextExportFormatter("PrimaryUser", "Primary Current Username", "Using ACT Current Charname 'YOU' almost get Current Username from User Input, but this Force Attach Current Username.", (Data, Extra, Format) => { return GetPrimaryUserName(); }));
            }
        }

        public string GetPrimaryUserName()
        {
            return PrimaryUser;
        }
    }
}