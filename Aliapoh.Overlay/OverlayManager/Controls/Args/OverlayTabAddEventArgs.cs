using System;

namespace Aliapoh.Overlays.OverlayManager
{
    public class OverlayTabAddEventArgs : EventArgs
    {
        public AliapohDefaultConfig Config { get; private set; }
        public OverlayTabAddEventArgs(AliapohDefaultConfig c)
        {
            Config = c;
        }
    }
}