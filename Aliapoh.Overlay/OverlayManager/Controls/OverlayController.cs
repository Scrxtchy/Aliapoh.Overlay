using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.Threading;

namespace Aliapoh.Overlay.OverlayManager
{
    public partial class OverlayController : UserControl
    {
        private ChromiumWebBrowser issueBrowser;

        #region /_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/|        INITALIZER        |/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
        public OverlayController()
        {
            issueBrowser = new ChromiumWebBrowser("https://github.com/laiglinne-ff/Aliapoh.Overlay/issues")
            {
                Dock = DockStyle.Fill,
            };
            issueBrowser.BrowserSettings.WebGl = CefState.Disabled;

            InitializeComponent();
            issueBrowserPanel.Controls.Add(issueBrowser);

            overlayTabControl1.Dock = DockStyle.None;
            overlayTabControl1.Left = -2;
            overlayTabControl1.Top = -2;
            overlayTabControl1.Width = Width + 4;
            overlayTabControl1.Height = Height + 4;
            overlayTabControl1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            new Thread((ThreadStart)delegate
            {
                while (true)
                {
                    Thread.Sleep(15000);
                    GC.Collect(1);
                }
            }).Start();
        }
        #endregion
        #region /_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/|      OVERLAYCONTROL      |/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
        private void OverlayCreate(string name)
        {
            var TP = new OverlayTabPage()
            {
                Text = "OverlayTest"
            };

            overlayManageTabControl1.TabPages.Add(TP);
            SelectOverlayNameDisplay();
        }

        private bool CheckTabValidate()
        {
            if (overlayManageTabControl1.TabPages.Count == 0) return false;
            if (overlayManageTabControl1.SelectedIndex < 0) return false;
            return true;
        }

        private void SelectOverlayNameDisplay()
        {
            if (!CheckTabValidate()) return;
            overlayTitle.Text = overlayManageTabControl1.TabPages[overlayManageTabControl1.SelectedIndex].Text;
        }

        private void CloseSelectedOverlay()
        {
            if (!CheckTabValidate()) return;
            overlayManageTabControl1.TabPages.Remove(overlayManageTabControl1.TabPages[overlayManageTabControl1.SelectedIndex]);
        }
        #endregion

        private void overlayAddButton_Click(object sender, EventArgs e)
        {
            OverlayCreate("OverlayTest");
        }

        private void overlayManageTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectOverlayNameDisplay();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CloseSelectedOverlay();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!CheckTabValidate()) return;
            var otp = (OverlayTabPage)overlayManageTabControl1.TabPages[overlayManageTabControl1.SelectedIndex];
            otp.Overlay.Browser.Reload(); // Load(otp.Overlay.Overlay.Address);
        }
    }
}
