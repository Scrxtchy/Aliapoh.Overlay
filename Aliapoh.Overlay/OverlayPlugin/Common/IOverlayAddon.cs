using System;
using System.Windows.Forms;

namespace Aliapoh.Overlays.Common
{
    public interface IOverlayAddon
    {
        string Name { get; }
        string Description { get; }
        Type OverlayType { get; }
        Type OverlayConfigType { get; }
        Type OverlayConfigControlType { get; }
        IOverlay CreateOverlayInstance(IOverlayConfig config);
        IOverlayConfig CreateOverlayConfigInstance(string name);
        Control CreateOverlayConfigControlInstance(IOverlay overlay);
    }
}
