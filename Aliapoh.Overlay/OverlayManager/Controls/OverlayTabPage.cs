using System.Drawing;
using System.Windows.Forms;

namespace Aliapoh.Overlays
{
    [System.ComponentModel.DesignerCategory("CODE")]
    public class OverlayTabPage : TabPage
    {
        public AliapohDefaultConfig Config;
        public OverlayForm Overlay
        {
            get
            {
                return Config.Overlay;
            }
        }

        public void Initializer(AliapohDefaultConfig oc)
        {
            Config = oc;
            oc.Dock = DockStyle.Fill;

            Text = oc.SettingObject.Name;
            Name = oc.SettingObject.Name;

            BackColor = Color.FromArgb(255, 255, 255);
            Controls.Add(oc);
        }

        public void Initializer(string name, string url)
        {
            Config = new AliapohDefaultConfig(name, url)
            {
                Dock = DockStyle.Fill
            };

            Text = name;
            Name = name;

            BackColor = Color.FromArgb(255, 255, 255);
            Controls.Add(Config);
        }

        public OverlayTabPage(AliapohDefaultConfig oc)
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
