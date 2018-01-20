using CefSharp.OffScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aliapoh.Overlay.ACTPlugin
{
    public class OverlayPluginApi
    {
        private string version = Application.ProductVersion.ToString();
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