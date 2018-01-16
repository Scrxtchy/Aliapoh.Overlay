using CefSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliapoh.Overlay
{
    public class CefManager
    {
        public static void Initialize()
        {
            Debug.WriteLine("Overlay Initialize");
            var setting = new CefSettings()
            {
                ExternalMessagePump = false,
                MultiThreadedMessageLoop = true,
                WindowlessRenderingEnabled = true,
                FocusedNodeChangedEnabled = true,
                RemoteDebuggingPort = 9994,
                CachePath = "Cache",
                LogSeverity = LogSeverity.Disable,
            };

            if (!Cef.Initialize(setting))
            {
                throw new Exception("Unable to Initialize Cef");
            }
        }
    }
}
