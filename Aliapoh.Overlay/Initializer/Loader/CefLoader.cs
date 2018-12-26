using Aliapoh.Overlay.Logger;
using CefSharp;
using CefSharp.OffScreen;
using System;
using System.IO;

namespace Aliapoh.Overlay
{
    public class CefLoader
    {
        public static void Initialize()
        {            
            var userAgent = "Mozilla/5.0 (Windows NT " + (Environment.Is64BitOperatingSystem ? "x64" : "x86") + ") AppleWebKit/537.36 (KHTML, like Gecko) Aliapoh.Overlay/" + Environment.Version.ToString() + " Chrome/" + Loader.TargetCEFTAG.Substring(0, 4) + "." + Loader.TargetCEFVER.Substring(2,4) + ".100 Safari/537.36";

            CefLibraryHandle libloader = new CefLibraryHandle(Path.Combine(Loader.CEFDIR, "libcef.dll"));
            Cef.EnableHighDPISupport();
            bool isValid = !libloader.IsInvalid;
            LOG.Logger.Log(LogLevel.Info, "CEF Libaray: " + (isValid ? "OK" : "Failed"));

            if(!isValid)
            {
                LOG.Logger.Log(LogLevel.Error, "Initialize Failed. CEF Binary is not valid");
            }

            var setting = new CefSettings()
            {
                LocalesDirPath = Path.Combine(Loader.CEFDIR, "locales"),
                UserDataPath = Path.Combine(Loader.CEFDIR, "userdata"),
                CachePath = Path.Combine(Loader.CEFDIR, "Cache"),
                BrowserSubprocessPath = Path.Combine(Loader.CEFDIR, "CefSharp.BrowserSubprocess.exe"),
                Locale = LanguageLoader.CurrentCulture,
                ExternalMessagePump = false,
                MultiThreadedMessageLoop = true,
                WindowlessRenderingEnabled = true,
                IgnoreCertificateErrors = true,
                RemoteDebuggingPort = 9994,
                UserAgent = userAgent,
                LogSeverity = LogSeverity.Disable,
            };

            if (!Cef.Initialize(setting))
                throw new Exception("Unable to Initialize Cef");

            libloader.Dispose();
        }
    }
}
