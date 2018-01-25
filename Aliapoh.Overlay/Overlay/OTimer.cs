using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aliapoh.Overlay
{
    public class OTimer : Timer
    {
        public OverlayForm Overlay { get; private set; }

        public OTimer(OverlayForm of)
        {
            Overlay = of;
        }
    }
}
