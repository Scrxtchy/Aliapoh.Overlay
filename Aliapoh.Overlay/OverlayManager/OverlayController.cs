using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aliapoh.Overlay.OverlayManager
{
    public partial class OverlayController : UserControl
    {
        public OverlayController()
        {
            InitializeComponent();

            overlayTabControl1.Dock = DockStyle.None;
            overlayTabControl1.Left = -2;
            overlayTabControl1.Top = -2;
            overlayTabControl1.Width = Width + 4;
            overlayTabControl1.Height = Height + 4;
            overlayTabControl1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
        }
    }
}
