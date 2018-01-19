using CefSharp.OffScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliapoh.Overlay.ACTPlugin
{
    public class OverlayPluginApi
    {
        private string version = "1.0.0.0";
        private OverlayForm Form { get; set; }

        public OverlayPluginApi(OverlayForm o)
        {
            Form = o;
        }

        public string OverlayVersion
        {
            get
            {
                return version;
            }
        }

        public string OverlayName
        {
            get
            {
                return Form.Name;
            }
        }

        public void EndEncounter()
        {

        }

        public void TakeScreenshot()
        {

        }
    }
}
