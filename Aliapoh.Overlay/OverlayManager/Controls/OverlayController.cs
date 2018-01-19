using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.Diagnostics;
using Aliapoh.Overlay.Logger;
using System.Drawing;

namespace Aliapoh.Overlay.OverlayManager
{
    public partial class OverlayController : UserControl
    {
        public static string OverlayEmpty = "Click [ + ] to setup your first overlay";
        public static Dictionary<string, OverlayTabPage> OverlayConfigs = new Dictionary<string, OverlayTabPage>();
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

            if(!DesignMode)
                LanguageLoader.LanguagePatch(this);

            issueBrowserPanel.Controls.Add(issueBrowser);
            overlayTabControl1.Dock = DockStyle.None;
            overlayTabControl1.Left = -2;
            overlayTabControl1.Top = -2;
            overlayTabControl1.Width = Width + 4;
            overlayTabControl1.Height = Height + 4;
            overlayTabControl1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

            LOG.Logger.Logs.ListChanged += Logs_ListChanged;
        }

        private int lastidx = 0;
        private void LogReader()
        {
            Invoke((MethodInvoker)delegate
            {
                for (; lastidx < LOG.Logger.Logs.Count; lastidx++)
                {
                    var line = LOG.Logger.Logs[lastidx];
                    richTextBox1.SelectionColor = Color.Cyan;
                    richTextBox1.AppendText(line.Time.ToString("[yyyy-MM-dd HH:mm:ss]"));
                    richTextBox1.SelectionColor = richTextBox1.ForeColor;

                    switch (line.Level)
                    {
                        case LogLevel.Debug:
                        case LogLevel.Trace:
                            richTextBox1.SelectionColor = Color.Gray;
                            richTextBox1.AppendText(" [");
                            richTextBox1.AppendText(line.Level.ToString().ToUpper());
                            richTextBox1.AppendText("] ");
                            richTextBox1.SelectionFont = richTextBox1.Font;
                            richTextBox1.AppendText(line.Message);
                            richTextBox1.SelectionFont = richTextBox1.Font;
                            break;
                        case LogLevel.Browser:
                            richTextBox1.SelectionColor = Color.LightGreen;
                            richTextBox1.AppendText(" ");
                            richTextBox1.AppendText(line.Message);
                            richTextBox1.SelectionFont = richTextBox1.Font;
                            break;
                        case LogLevel.Info:
                            richTextBox1.SelectionColor = Color.LightGray;
                            richTextBox1.AppendText("  [");
                            richTextBox1.AppendText(line.Level.ToString().ToUpper());
                            richTextBox1.AppendText("] ");
                            richTextBox1.SelectionFont = richTextBox1.Font;
                            richTextBox1.AppendText(line.Message);
                            richTextBox1.SelectionFont = richTextBox1.Font;
                            break;
                        case LogLevel.Warning:
                            richTextBox1.SelectionColor = Color.Yellow;
                            richTextBox1.AppendText("  [");
                            richTextBox1.AppendText(line.Level.ToString().ToUpper().Substring(0, 4));
                            richTextBox1.AppendText("] ");
                            richTextBox1.SelectionColor = richTextBox1.ForeColor;
                            richTextBox1.SelectionColor = Color.FromArgb(255, 233, 127);
                            richTextBox1.SelectionFont = richTextBox1.Font;
                            richTextBox1.AppendText(line.Message);
                            richTextBox1.SelectionFont = richTextBox1.Font;
                            break;
                        case LogLevel.Error:
                            richTextBox1.SelectionColor = Color.Red;
                            richTextBox1.AppendText(" [");
                            richTextBox1.AppendText(line.Level.ToString().ToUpper());
                            richTextBox1.AppendText("] ");
                            richTextBox1.SelectionColor = Color.MistyRose;
                            richTextBox1.SelectionFont = richTextBox1.Font;
                            richTextBox1.AppendText(line.Message);
                            richTextBox1.SelectionFont = richTextBox1.Font;
                            break;
                    }

                    richTextBox1.SelectionColor = richTextBox1.ForeColor;
                    richTextBox1.AppendText("\n");
                }
            });
        }

        private void Logs_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            LogReader();
        }

        #endregion
        #region /_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/|      OVERLAYCONTROL      |/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
        private void OverlayCreate(string name)
        {
            var nod = new NewOverlayDialog();
            if(nod.ShowDialog() == DialogResult.OK)
            {
                var TP = new OverlayTabPage(nod.PrimaryName, nod.URL == "" ? "about:blank" : nod.URL);
                overlayManageTabControl1.TabPages.Add(TP);
                SelectOverlayNameDisplay();

                OverlayConfigs.Add(nod.PrimaryName, TP);
            }
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
            OverlayTitle.Text = overlayManageTabControl1.TabPages[overlayManageTabControl1.SelectedIndex].Text;
        }

        private void CloseSelectedOverlay()
        {
            if (!CheckTabValidate()) return;
            var tp = overlayManageTabControl1.TabPages[overlayManageTabControl1.SelectedIndex];
            foreach (var c in overlayManageTabControl1.TabPages[overlayManageTabControl1.SelectedIndex].Controls)
            {
                if (c.GetType() == typeof(OverlayConfig))
                    ((OverlayConfig)c).Overlay.Close();
                ((Control)c).Dispose();
            }
            OverlayConfigs.Remove(tp.Name);
            overlayManageTabControl1.TabPages.Remove(tp);

            if (overlayManageTabControl1.TabPages.Count == 0)
            {
                OverlayTitle.Text = "Please Select Overlay";
            }
        }
        #endregion

        private void OverlayAddButton_Click(object sender, EventArgs e)
        {
            OverlayCreate("OverlayTest");
        }

        private void OverlayManageTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectOverlayNameDisplay();
        }

        private void CloseSelectedOverlayButtonClicked(object sender, EventArgs e)
        {
            CloseSelectedOverlay();
        }

        private void ReloadSelectedOverlayButtonClicked(object sender, EventArgs e)
        {
            if (!CheckTabValidate()) return;
            var otp = (OverlayTabPage)overlayManageTabControl1.TabPages[overlayManageTabControl1.SelectedIndex];
            otp.Overlay.Browser.Load(otp.Config.siteURL.Text);
        }

        private void ShowDevToolsSelectedOverlayButtonClicked(object sender, EventArgs e)
        {
            if (!CheckTabValidate()) return;
            var otp = (OverlayTabPage)overlayManageTabControl1.TabPages[overlayManageTabControl1.SelectedIndex];
            otp.Overlay.ShowDevTools();
        }

        private void OverlayController_Load(object sender, EventArgs e)
        {
            LogReader();
        }
    }
}
