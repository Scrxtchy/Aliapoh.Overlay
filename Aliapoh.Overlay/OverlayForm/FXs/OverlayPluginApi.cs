using CefSharp.OffScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliapoh.Overlay
{
    public class OverlayAPI
    {
        private string version = "0.3.4.0"; // for OverlayPlugin Commpatible
        private OverlayForm Overlay { get; set; }

        public OverlayAPI(OverlayForm o)
        {
            Overlay = o;
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
                return Overlay.Name;
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
