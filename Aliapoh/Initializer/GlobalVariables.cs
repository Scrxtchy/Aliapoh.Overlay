using System;
using System.Collections.Generic;
using System.IO;

namespace Aliapoh
{
    public static class GlobalVar
    {
        private static readonly string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static readonly string NUGET = "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe";
        public static readonly string CEFVERNAME = "CEF73";
        public static readonly string TargetCEFVER = "73.1.13";
        public static readonly string TargetCEFTAG = "73.1.130";
        public static readonly Dictionary<string, string> DIRDICT = new Dictionary<string, string>()
        {
            { "LOCAL", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) },
            { "RESDIR", Path.Combine(AppData, "Aliapoh") },
            { "BINDIR", Path.Combine(AppData, "Aliapoh", "Bin") },
            { "CEFDIR", Path.Combine(AppData, "Aliapoh", CEFVERNAME) },
            { "CEFX86", Path.Combine(AppData, "Aliapoh", CEFVERNAME, "x86") },
            { "CEFX64", Path.Combine(AppData, "Aliapoh", CEFVERNAME, "x64") },
            { "CEFX86LOC", Path.Combine(AppData, "Aliapoh", CEFVERNAME, "x86", "locales") },
            { "CEFX64LOC", Path.Combine(AppData, "Aliapoh", CEFVERNAME, "x64", "locales") },
            { "CEFX86SHD", Path.Combine(AppData, "Aliapoh", CEFVERNAME, "x86", "swiftshader") },
            { "CEFX64SHD", Path.Combine(AppData, "Aliapoh", CEFVERNAME, "x64", "swiftshader") },
        };
    }
}
