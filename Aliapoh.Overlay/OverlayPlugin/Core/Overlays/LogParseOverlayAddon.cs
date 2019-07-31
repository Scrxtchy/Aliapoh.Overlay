using Aliapoh.Overlays.Common;
using System;

namespace Aliapoh.OverlayPlugin.Core.Overlays
{
    class LogParseOverlayAddon : IOverlayAddon
    {
        public string Name => "Log Parse";
        public string Description => "Miniparse + Full Log Access";
        public Type OverlayType => typeof(LogParseOverlay);
        public Type OverlayConfigType => typeof(LogParseOverlayConfig);
        public Type OverlayConfigControlType => typeof(LogParseConfigPanel);

        public IOverlay CreateOverlayInstance(IOverlayConfig config)
        {
            return new LogParseOverlay((LogParseOverlayConfig)config);
        }

        public IOverlayConfig CreateOverlayConfigInstance(string name)
        {
            return new LogParseOverlayConfig(name);
        }

        public System.Windows.Forms.Control CreateOverlayConfigControlInstance(IOverlay overlay)
        {
            return new LogParseConfigPanel((LogParseOverlay)overlay);
        }

        public void Dispose()
        {

        }
    }
}
