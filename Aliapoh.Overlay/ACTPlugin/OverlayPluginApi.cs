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
        private OverlayForm Form;

        public OverlayPluginApi(OverlayForm o)
        {
            Form = o;
        }

        public string OverlayVersion { get; } = Application.ProductVersion.ToString();

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