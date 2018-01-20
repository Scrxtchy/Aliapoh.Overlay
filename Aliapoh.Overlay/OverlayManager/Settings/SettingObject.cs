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
        public string Url;
        public string Name;
        public bool Show;
        public bool Clickthru;
        public bool Locked;
        public bool UseGlobalHotkey;
        public bool BeforeLogLineRead;
        public int Framerate;
        public int Updaterate;
        public int Width;
        public int Height;
        public int Left;
        public int Top;
        public int GlobalHotkey;
        public int GlobalHotkeyModifiers;
        public int GlobalHotkeyType;

        public SettingObject()
        {
            // Do Somthing
        }

        public OverlayConfig CreateOverlayConfig()
        {
            var o = new OverlayConfig(this);
            return o;
        }
    }
}
