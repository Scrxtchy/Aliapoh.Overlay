using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Reflection;
using Aliapoh.Overlays.Initializer;
using Aliapoh.Overlays.Logger;
using System.Globalization;
using Microsoft.Win32;

namespace Aliapoh.Overlays
{
    public class Loader
    {
        public static string APPDIR = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Aliapoh");
        public static string CEFDIR = "";

        public static AssemblyResolver asmResolver;

        public static string DefaultFont = "맑은 고딕";

        public static bool InitializeMinimum()
        {
            string PDN = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName", "").ToString();
            if (CultureInfo.CurrentCulture.Name.StartsWith("ko"))
            {
                DefaultFont = "맑은 고딕";
                if(PDN.StartsWith("Windows 10"))
                {
                    DefaultFont = "맑은 고딕 Semilight";
                }
            }
            else if (CultureInfo.CurrentCulture.Name.StartsWith("ja"))
            {
                DefaultFont = "Meiryo";
            }
            else
            {
                DefaultFont = "Microsoft Sans Serif";
            }

            LOG.Initialize();
            LOG.Logger.Log(LogLevel.Warning, "Aliapoh Overlay on " + (Environment.Is64BitProcess ? "x64" : "x86") + " Process");

            if (Environment.Is64BitProcess)
                CEFDIR = GlobalVariables.DIRDICT["CEFX64"];
            else
                CEFDIR = GlobalVariables.DIRDICT["CEFX86"];

            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            var Directories = new List<string>()
            {
                APPDIR,
                CEFDIR,
                GlobalVariables.DIRDICT["BINDIR"]
            };

            asmResolver = new AssemblyResolver(Directories);
            asmResolver.ExceptionOccured += (o, e) => LOG.Logger.Log(LogLevel.Error, "AssemblyResolver: Error: {0}", e.Exception);
            asmResolver.AssemblyLoaded += (o, e) => LOG.Logger.Log(LogLevel.Debug, "AssemblyResolver: Loaded: {0}", e.LoadedAssembly.FullName);
            
            VersionManager.Initialize();
            Thread.Sleep(20);
            LOG.Logger.Log(LogLevel.Info, "Initialize CEF");

            CefLoader.Initialize();
            Thread.Sleep(20);
            LOG.Logger.Log(LogLevel.Info, "Initialize Localization");

            LanguageLoader.Initialize();
            Thread.Sleep(20);
            LOG.Logger.Log(LogLevel.Info, "Successfully loaded Aliapoh");

            return true;
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            // Binary Loader
            var binfiles = new List<string>()
            {
                "CefSharp",
                "CefSharp.Core",
                "CefSharp.OffScreen",
                "CefSharp.WinForms",
                "Newtonsoft.Json"
            };

            var dicts = new Dictionary<string, string>()
            {
                { "Newtonsoft.Json", Path.Combine(APPDIR, "Bin", "Newtonsoft.json.10.0.3", "lib", "net45") }
            };

            string asmFile = (args.Name.Contains(",") ? args.Name.Substring(0, args.Name.IndexOf(",")) : args.Name);
            if (!binfiles.Contains(asmFile)) return null;
            try
            {
                if (asmFile.Contains("CefSharp"))
                    return Assembly.LoadFile(Path.Combine(CEFDIR, asmFile + ".dll"));
                else
                    return Assembly.LoadFile(Path.Combine(dicts[asmFile], asmFile + ".dll"));
            }
            catch { return null; }
        }

        public static void MKDIR(string dir)
        {
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
        }
    }
}
