using CefSharp;
using System;
using System.Diagnostics;
using System.IO;

namespace Aliapoh.Overlay
{
    public class CefLoader
    {
        public static void Initialize()
        {            
            var userAgent = "Mozilla/5.0 (Windows NT " + (Environment.Is64BitOperatingSystem ? "x64" : "x86") + ") AppleWebKit/537.36 (KHTML, like Gecko) Aliapoh.Overlay/Chrome/63.0.3239.109 Safari/537.36";

            CefLibraryHandle libloader = new CefLibraryHandle(Path.Combine(Program.CEFDIR, "libcef.dll"));

            Cef.EnableHighDPISupport();
            bool isValid = !libloader.IsInvalid;
            Debug.WriteLine($"LIBLOADERSTATUS: {isValid}");

            var setting = new CefSettings()
            {
                LocalesDirPath = Path.Combine(Program.CEFDIR, "locales"),
                UserDataPath = Path.Combine(Program.CEFDIR, "userdata"),
                CachePath = Path.Combine(Program.CEFDIR, "Cache"),
                BrowserSubprocessPath = Path.Combine(Program.CEFDIR, "CefSharp.BrowserSubprocess.exe"),
                Locale = LanguageLoader.CurrentCulture,
                ExternalMessagePump = false,
                MultiThreadedMessageLoop = true,
                WindowlessRenderingEnabled = true,
                FocusedNodeChangedEnabled = true,
                IgnoreCertificateErrors = true,
                RemoteDebuggingPort = 9994,
                UserAgent = userAgent,
                LogSeverity = LogSeverity.Disable,
            };

            setting.DisableGpuAcceleration();

            if (!Cef.Initialize(setting))
            {
                throw new Exception("Unable to Initialize Cef");
            }

            libloader.Dispose();
        }
    }
}
