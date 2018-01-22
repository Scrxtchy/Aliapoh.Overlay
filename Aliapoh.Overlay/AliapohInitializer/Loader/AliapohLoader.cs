using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Threading;
using System.Reflection;
using Aliapoh.Overlay.AliapohInitializer;
using Aliapoh.Overlay.Logger;

namespace Aliapoh.Overlay
{
    public class AliapohLoader
    {
        public static Dictionary<string, string> DIRDICT = new Dictionary<string, string>()
        {
            { "LOCAL", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) },
            { "RESDIR", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Aliapoh") },
            { "BINDIR", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Aliapoh", "Bin") },
            { "CEFDIR", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Aliapoh", "CEF") },
            { "CEFX86", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Aliapoh", "CEF", "x86") },
            { "CEFX64", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Aliapoh", "CEF", "x64") },
            { "CEFX86LOC", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Aliapoh", "CEF", "x86", "locales") },
            { "CEFX64LOC", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Aliapoh", "CEF", "x64", "locales") },
            { "CEFX86SHD", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Aliapoh", "CEF", "x86", "swiftshader") },
            { "CEFX64SHD", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Aliapoh", "CEF", "x64", "swiftshader") },
        };

        public static string TargetCEFVER = "3.3239.1716";
        public static string TargetCEFTAG = "63.0.0-pre01";
        public static void Initialize()
        {
            LOG.Initialize();
            LOG.Logger.Log(LogLevel.Warning, "Aliapoh Overlay on " + (Environment.Is64BitProcess ? "x64" : "x86") + " Process");

            var loadfrm = new LoaderForm();
            loadfrm.Show();
            loadfrm.Refresh();
            loadfrm.Render("Initializing...");
            VersionManager.Initialize();
            LOG.Logger.Log(LogLevel.Info, "Initialize CEF");
            CefLoader.Initialize();
            Thread.Sleep(500);
            LOG.Logger.Log(LogLevel.Info, "Initialize Localization");
            LanguageLoader.Initialize();
            Thread.Sleep(500);
            LOG.Logger.Log(LogLevel.Info, "Successfully loaded Aliapoh");

            loadfrm.Close();
            loadfrm.Dispose();
        }
    }
}
