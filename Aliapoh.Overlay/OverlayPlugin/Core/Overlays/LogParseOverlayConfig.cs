using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliapoh.OverlayPlugin.Core.Overlays
{
    [Serializable]
    public class LogParseOverlayConfig : OverlayConfigBase
    {
        public LogParseOverlayConfig(string name) : base(name)
        {

        }

        // XmlSerializer用
        private LogParseOverlayConfig() : base(null)
        {

        }

        public override Type OverlayType => typeof(LogParseOverlay);
    }
}
