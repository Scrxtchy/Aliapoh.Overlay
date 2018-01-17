using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aliapoh.Overlay.OverlayManager
{
    public partial class NewOverlayDialog : Form
    {
        public string PrimaryName { get; set; }
        public string URL { get; set; }
        public int FPS { get; set; }

        public NewOverlayDialog()
        {
            InitializeComponent();
        }

        private void CheckValidateOverlayName(object sender, EventArgs e)
        {
            if (OverlayName.Text.Trim() == "")
            {
                MessageBox.Show("Overlay name is Absolute value. please input overlay name", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (OverlayController.OverlayConfigs.ContainsKey(OverlayName.Text))
            {
                MessageBox.Show("Overlay name is Primary value", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OverlayName.ForeColor = Color.DarkRed;
                return;
            }

            PrimaryName = OverlayName.Text;
            URL = OverlayURL.Text;
            FPS = (int)OverlayFramerate.Value;

            DialogResult = DialogResult.OK;
        }

        private void OverlayName_KeyPress(object sender, KeyPressEventArgs e)
        {
            OverlayName.ForeColor = Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
