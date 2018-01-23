using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Advanced_Combat_Tracker;
using Aliapoh.Overlay;
using System.IO;
using System.Reflection;
using Aliapoh.Overlay.OverlayManager;
using Aliapoh.Initializer;

namespace Aliapoh
{
    public class PluginMain : IActPluginV1
    {
        public static string PrimaryUser = "YOU";
        public static string pluginDirectory;
        public OverlayController OverlayController;
        public PluginLoader PluginLoader;

        public void DeInitPlugin()
        {
            AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
        }

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            if (Environment.Is64BitProcess)
                Program.CEFDIR = FxLoader.DIRDICT["CEFX64"];
            else
                Program.CEFDIR = FxLoader.DIRDICT["CEFX86"];

            FxLoader.Initialize();
            if(Loader.InitializeMinimum())
            {
                PluginLoader = new PluginLoader(pluginScreenSpace, pluginStatusText);
            }
        }

        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            // Binary Loader
            var binfiles = new List<string>()
            {
                "Aliapoh.Overlay"
            };

            string asmFile = (args.Name.Contains(",") ? args.Name.Substring(0, args.Name.IndexOf(",")) : args.Name);
            if (!binfiles.Contains(asmFile)) return null;
            try
            {
                return Assembly.LoadFile(Path.Combine(GetPluginDirectory(), asmFile + ".dll"));
            }
            catch { return null; }
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