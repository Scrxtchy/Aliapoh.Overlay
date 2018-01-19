using System;
using System.Windows.Forms;
using Advanced_Combat_Tracker;
using CefSharp;

namespace Aliapoh.Overlay.ACTPlugin
{
    public class Aliapoh : IActPluginV1
    {
        public void DeInitPlugin()
        {
            Cef.Shutdown();
        }

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            if (Environment.Is64BitProcess)
                Program.CEFDIR = AliapohLoader.DIRDICT["CEFX64"];
            else
                Program.CEFDIR = AliapohLoader.DIRDICT["CEFX86"];

            AliapohLoader.Initialize();
        }
    }
}