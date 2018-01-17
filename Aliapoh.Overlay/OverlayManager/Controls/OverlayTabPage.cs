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
    public class OverlayTabPage : TabPage
    {
        public OverlayConfig Config { get; set; }
        public OverlayForm Overlay
        {
            get
            {
                return Config.Overlay;
            }
        }

        public OverlayTabPage(string name)
        {
            Config = new OverlayConfig(name)
            {
                Dock = DockStyle.Fill
            };

            Text = name;
            Name = name;
            BackColor = Color.FromArgb(255, 255, 255);
            Controls.Add(Config);
        }
    }
}
