using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Threading;
using System.Reflection;
using Aliapoh.Overlay.Initializer;
using Aliapoh.Overlay.Logger;
using System.Globalization;
using Microsoft.Win32;

namespace Aliapoh.Overlay
{
    public class Loader
    {
        public static string CEFVERNAME = "CEF71";
        public static string APPDIR = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Aliapoh");
        public static string CEFDIR = "";

        public static Dictionary<string, string> DIRDICT = new Dictionary<string, string>()
        {
            { "LOCAL", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) },
            { "RESDIR", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Aliapoh") },
            { "BINDIR", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Aliapoh", "Bin") },
            { "CEFDIR", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Aliapoh", CEFVERNAME) },
            { "CEFX86", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Aliapoh", CEFVERNAME, "x86") },
            { "CEFX64", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Aliapoh", CEFVERNAME, "x64") },
            { "CEFX86LOC", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Aliapoh", CEFVERNAME, "x86", "locales") },
            { "CEFX64LOC", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Aliapoh", CEFVERNAME, "x64", "locales") },
            { "CEFX86SHD", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Aliapoh", CEFVERNAME, "x86", "swiftshader") },
            { "CEFX64SHD", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Aliapoh", CEFVERNAME, "x64", "swiftshader") },
        };

        public static AssemblyResolver asmResolver;
        public static string TargetCEFVER = "3.3578.1863";
        public static string TargetCEFTAG = "71.0.0";
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
                CEFDIR = DIRDICT["CEFX64"];
            else
                CEFDIR = DIRDICT["CEFX86"];

            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            var Directories = new List<string>()
            {
                APPDIR,
                CEFDIR,
                DIRDICT["BINDIR"]
            };

            asmResolver = new AssemblyResolver(Directories);
            asmResolver.ExceptionOccured += (o, e) => LOG.Logger.Log(LogLevel.Error, "AssemblyResolver: Error: {0}", e.Exception);
            asmResolver.AssemblyLoaded += (o, e) => LOG.Logger.Log(LogLevel.Debug, "AssemblyResolver: Loaded: {0}", e.LoadedAssembly.FullName);
            
            VersionManager.Initialize();
            Thread.Sleep(50);
            LOG.Logger.Log(LogLevel.Info, "Initialize CEF");

            CefLoader.Initialize();
            Thread.Sleep(50);
            LOG.Logger.Log(LogLevel.Info, "Initialize Localization");

            LanguageLoader.Initialize();
            Thread.Sleep(50);
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
