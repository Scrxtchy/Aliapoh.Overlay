using Aliapoh.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Aliapoh
{
    public class FxLoader
    {
        public static string CEFVERNAME = "CEF71";

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

        public static bool Initialize()
        {
            var loadfrm = new LoaderForm();
            loadfrm.Show();
            loadfrm.Refresh();

            foreach (var i in DIRDICT)
            {
                loadfrm.Render("Directory Check...\n" + i);
                MKDIR(i.Value);
            }

            WebClient wc = new WebClient();
            if (!File.Exists(DIRDICT["BINDIR"] + "\\nuget.exe"))
                wc.DownloadFile("https://dist.nuget.org/win-x86-commandline/latest/nuget.exe", DIRDICT["BINDIR"] + "\\nuget.exe");
            else
            {
                FileInfo fi = new FileInfo(DIRDICT["BINDIR"] + "\\nuget.exe");
                if (fi.Length < 1024)
                    wc.DownloadFile("https://dist.nuget.org/win-x86-commandline/latest/nuget.exe", DIRDICT["BINDIR"] + "\\nuget.exe");
            }

            loadfrm.Render("Get Nuget Package...\n");

            var nupkgs = new List<string>()
            {
                "install cefsharp.winforms -version " + TargetCEFTAG,
                "install cefsharp.offscreen -version " + TargetCEFTAG,
                "install newtonsoft.json -version 10.0.3",
            };

            foreach (var bin in nupkgs)
            {
                loadfrm.Render(bin);
                var p = new Process()
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        WorkingDirectory = DIRDICT["BINDIR"],
                        WindowStyle = ProcessWindowStyle.Hidden,
                        Arguments = bin,
                        CreateNoWindow = true,
                        FileName = DIRDICT["BINDIR"] + "\\nuget.exe"
                    }
                };
                p.Start();

                while (!p.HasExited)
                    Thread.Sleep(100);
            }

            loadfrm.Render("Arrange Nuget Package...\n");

            var dirs = new List<string>()
            {
                "cef.redist.x64." + TargetCEFVER + "\\CEF",
                "cef.redist.x86." + TargetCEFVER + "\\CEF",
                "cef.redist.x64." + TargetCEFVER + "\\CEF\\locales",
                "cef.redist.x86." + TargetCEFVER + "\\CEF\\locales",
                "cef.redist.x64." + TargetCEFVER + "\\CEF\\swiftshader",
                "cef.redist.x86." + TargetCEFVER + "\\CEF\\swiftshader",
                "CefSharp.Common." + TargetCEFTAG + "\\CefSharp\\x86",
                "CefSharp.Common." + TargetCEFTAG + "\\CefSharp\\x64",
                "CefSharp.OffScreen." + TargetCEFTAG + "\\CefSharp\\x86",
                "CefSharp.OffScreen." + TargetCEFTAG + "\\CefSharp\\x64",
                "CefSharp.WinForms." + TargetCEFTAG + "\\CefSharp\\x86",
                "CefSharp.WinForms." + TargetCEFTAG + "\\CefSharp\\x64",
            };

            foreach (var d in dirs)
            {
                var bin = Path.Combine(DIRDICT["BINDIR"], d);
                var x = "x86";
                var dest = "";
                if (d.Contains("x64")) x = "x64";

                if (d.Contains("cef.redist"))
                    dest = Path.Combine(DIRDICT["CEFDIR"], x, d // <- for once working ->
                    .Replace("cef.redist.x86." + TargetCEFVER + "\\CEF", "")
                    .Replace("cef.redist.x64." + TargetCEFVER + "\\CEF", "")
                    .Replace("\\", ""));
                else
                    dest = Path.Combine(DIRDICT["CEFDIR"], x);

                foreach (var file in Directory.GetFiles(bin))
                {
                    if (file.Contains(".pdb")) continue;
                    var f = Path.Combine(dest, Path.GetFileName(file));
                    if (!File.Exists(f)) File.Copy(file, f);
                }
            }

            foreach (var i in Directory.GetFiles(Environment.CurrentDirectory))
            {
                if (i.Contains("cefsharp"))
                    File.Delete(i);
            }

            loadfrm.Render("Initializing...");
            Thread.Sleep(500);
            if(!loadfrm.IsDisposed)
                loadfrm.Dispose();

            if (Program.fromMain) // run to exe
            {
                Overlay.Loader.InitializeMinimum();
                Application.Run(new Overlay.OverlayManager.ManagerForm());
            }
            else
            {

            }

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
                { "Newtonsoft.Json", Path.Combine(Program.APPDIR, "Bin", "Newtonsoft.json.10.0.3", "lib", "net45") }
            };

            string asmFile = (args.Name.Contains(",") ? args.Name.Substring(0, args.Name.IndexOf(",")) : args.Name);
            if (!binfiles.Contains(asmFile)) return null;
            try
            {
                if (asmFile.Contains("CefSharp"))
                    return Assembly.LoadFile(Path.Combine(Program.CEFDIR, asmFile + ".dll"));
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
