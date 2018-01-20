using System;
using System.Windows.Forms;
using Advanced_Combat_Tracker;
using CefSharp;
using System.Linq;
using System.IO;

namespace Aliapoh.Overlay.ACTPlugin
{
    public class Aliapoh : IActPluginV1
    {
        public static string PrimaryUser = "YOU";
        public static string pluginDirectory;

        public void DeInitPlugin()
        {
            Cef.Shutdown();
        }

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            if (Environment.Is64BitProcess)
                Program.CEFDIR = AliapohLoader.DIRDICT["CEFX64"];
            else
                Program.CEFDIR = AliapohLoader.DIRDICT["CEFX86"];

            AliapohLoader.Initialize();
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