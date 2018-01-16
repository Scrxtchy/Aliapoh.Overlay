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

namespace Aliapoh.Overlay.OverlayManager
{
    public partial class OverlayController : UserControl
    {
        private ChromiumWebBrowser issueBrowser;

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
        }

        private void overlayAddButton_Click(object sender, EventArgs e)
        {
            var TP = new TabPage()
            {
                Text = "OverlayTest",
                BackColor = Color.White
            };

            overlayManageTabControl1.TabPages.Add(TP);
        }
    }
}
