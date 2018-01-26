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
