using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Advanced_Combat_Tracker;
using Aliapoh.Overlay;
using Aliapoh.Overlay.IPlugin;

namespace MiniparsePlugin
{
    public class PluginMain : IPlugin
    {
        private OverlayForm Form { get; set; }

        public string Name
        {
            get { return "MiniparsePlugin"; }
        }

        public string Author
        {
            get { return "Laighlinne"; }
        }

        public string JavascriptFunctionName
        {
            get { return "Miniparse"; }
        }

        public string Version
        {
            get { return "1.0.0.0"; }
        }

        public bool CamelCase
        {
            get { return true; }
        }

        public void Initializer(OverlayForm form)
        {
            Form = form;
            ActGlobals.oFormActMain.BeforeLogLineRead += OFormActMain_BeforeLogLineRead;
        }

        private void OFormActMain_BeforeLogLineRead(bool isImport, LogLineEventArgs logInfo)
        {

        }
    }
}
