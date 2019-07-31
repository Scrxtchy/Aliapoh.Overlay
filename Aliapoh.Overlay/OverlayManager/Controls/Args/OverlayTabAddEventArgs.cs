using System;

namespace Aliapoh.Overlays.OverlayManager
{
    public class OverlayTabAddEventArgs : EventArgs
    {
        public OverlayConfig Config { get; private set; }
        public OverlayTabAddEventArgs(OverlayConfig c)
        {
            Config = c;
        }
    }
}