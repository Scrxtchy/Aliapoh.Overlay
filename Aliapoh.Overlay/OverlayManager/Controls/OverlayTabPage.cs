using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Aliapoh.Overlay
{
    [System.ComponentModel.DesignerCategory("CODE")]
    class OverlayTabPage : TabPage
    {
        public OverlayConfig Config { get; set; }
        public OverlayForm Overlay
        {
            get
            {
                return Config.Overlay;
            }
        }

        public OverlayTabPage()
        {
            Config = new OverlayConfig()
            {
                Dock = DockStyle.Fill
            };

            BackColor = Color.FromArgb(255, 255, 255);
            Controls.Add(Config);
        }
    }
}
