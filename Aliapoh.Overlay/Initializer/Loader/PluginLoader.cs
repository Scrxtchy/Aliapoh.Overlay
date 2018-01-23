using Advanced_Combat_Tracker;
using Aliapoh.Overlay;
using Aliapoh.Overlay.OverlayManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aliapoh.Initializer
{
    public class PluginLoader
    {
        public OverlayController OverlayController;
        public IActPluginV1 Plugin;

        public PluginLoader(TabPage tp, Label lbl, IActPluginV1 plugin)
        {
            OverlayController = new OverlayController()
            {
                Dock = DockStyle.Fill
            };
            tp.Controls.Add(OverlayController);
        }
    }
}