using Advanced_Combat_Tracker;
using Aliapoh.Overlay;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Aliapoh
{
    public class PluginMain : IActPluginV1, IDisposable
    {
        public static string pluginDirectory;
        public PluginLoader PluginLoader;
        public AssemblyResolver AssemblyResolver;

        public PluginMain()
        {

        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool b)
        {
            AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
            AssemblyResolver.Dispose();
            PluginLoader.Dispose();
        }

        public void DeInitPlugin()
        {
            Dispose();
        }

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            pluginDirectory = GetPluginDirectory();
            foreach (var i in Directory.GetFiles(pluginDirectory))
            {
                if (i.ToLower().Contains("cefsharp"))
                    File.Delete(i);
            }

            AssemblyResolver = new AssemblyResolver(new List<string>() { pluginDirectory });
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            if (Environment.Is64BitProcess)
                Program.CEFDIR = GlobalVar.DIRDICT["CEFX64"];
            else
                Program.CEFDIR = GlobalVar.DIRDICT["CEFX86"];

            if(FxLoader.Initialize())
            {
                Initialize(pluginScreenSpace, pluginStatusText);
            }

            pluginScreenSpace.Text = $"Aliapoh Overlay {(Environment.Is64BitProcess ? "x64" : "x86")}";
            pluginStatusText.Text = "Aliapoh overlay successfully";
        }

        public void Initialize(TabPage tp, Label lbl)
        {
            if (Loader.InitializeMinimum())
            {
                PluginLoader = new PluginLoader(tp, lbl, pluginDirectory, this);
            }
        }

        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
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
    }
}