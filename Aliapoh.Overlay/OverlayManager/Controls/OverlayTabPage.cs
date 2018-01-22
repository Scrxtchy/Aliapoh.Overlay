using System.Drawing;
using System.Windows.Forms;

namespace Aliapoh.Overlay
{
    [System.ComponentModel.DesignerCategory("CODE")]
    public class OverlayTabPage : TabPage
    {
        public OverlayConfig Config;
        public OverlayForm Overlay
        {
            get
            {
                return Config.Overlay;
            }
        }

        public void Initializer(OverlayConfig oc)
        {
            Config = oc;
            Dock = DockStyle.Fill;

            Text = oc.Name;
            Name = oc.Name;

            BackColor = Color.FromArgb(255, 255, 255);
            Controls.Add(Config);
        }

        public void Initializer(string name, string url)
        {
            Config = new OverlayConfig(name, url)
            {
                Dock = DockStyle.Fill
            };

            Text = name;
            Name = name;

            BackColor = Color.FromArgb(255, 255, 255);
            Controls.Add(Config);
        }

        public OverlayTabPage(OverlayConfig oc)
        {
            Initializer(oc);
        }

        public OverlayTabPage(string name, string url)
        {
            Initializer(name, url);
        }

        public OverlayTabPage(string name)
        {
            Initializer(name, "about:blank");
        }
    }
}
