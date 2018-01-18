using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliapoh.Overlay.GlobalHook
{
    public struct KeyHook
    {
        public int VKCode;
        public int ScanCode;
        public int Flags;
        public int time;
        public int DWExtraInfo;
    }
}
