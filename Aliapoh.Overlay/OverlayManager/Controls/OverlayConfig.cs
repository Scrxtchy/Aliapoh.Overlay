using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aliapoh.Overlay
{
    public partial class OverlayConfig : UserControl
    {
        public OverlayConfig()
        {
            InitializeComponent();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            siteURL.Focus();
        }
    }
}
