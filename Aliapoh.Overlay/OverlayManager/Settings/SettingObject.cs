using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aliapoh.Overlay
{
    public class SettingObject
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public bool Show { get; set; }
        public bool Clickthru { get; set; }
        public bool Locked { get; set; }
        public bool UseGlobalHotkey { get; set; }
        public bool BeforeLogLineRead { get; set; }
        public int Framerate { get; set; }
        public int Updaterate { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public int GlobalHotkey { get; set; }
        public int GlobalHotkeyModifiers { get; set; }
        public int GlobalHotkeyType { get; set; }

        public SettingObject()
        {

        }

        public OverlayConfig CreateOverlayConfig()
        {
            var o = new OverlayConfig(this);
            return o;
        }
    }
}
