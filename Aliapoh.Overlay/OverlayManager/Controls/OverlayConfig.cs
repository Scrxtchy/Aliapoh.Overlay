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
        public OverlayForm Overlay { get; set; }

        public OverlayConfig()
        {
            Overlay = new OverlayForm();
            InitializeComponent();
            Overlay.Show();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            siteURL.Focus();
        }

        new public void Dispose()
        {
            Overlay.Close();
            base.Dispose();
        }

        private void overlayShow_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
                Overlay.Show();
            else
                Overlay.Hide();
        }

        private void overlayClickthru_CheckedChanged(object sender, EventArgs e)
        {
            Overlay.ClickthruChange(((CheckBox)sender).Checked);
        }

        private void overlayLock_CheckedChanged(object sender, EventArgs e)
        {
            Overlay.IsBrowserLocked = ((CheckBox)sender).Checked;
        }

        private void overlayFramerate_ValueChanged(object sender, EventArgs e)
        {
            Overlay.Browser.BrowserSettings.WindowlessFrameRate = (int)((NumericUpDown)sender).Value;
        }
    }
}
