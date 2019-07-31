using CefSharp.OffScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Advanced_Combat_Tracker;

namespace Aliapoh.Overlays.ACTPlugin
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
            ActGlobals.oFormActMain.EndCombat(false);
        }

        public void TakeScreenshot()
        {

        }
    }
}