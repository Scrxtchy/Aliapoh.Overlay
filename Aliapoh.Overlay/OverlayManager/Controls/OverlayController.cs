using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.Diagnostics;
using Aliapoh.Overlay;
using Aliapoh.Overlay.Logger;
using System.Drawing;

namespace Aliapoh.Overlay.OverlayManager
{
    public partial class OverlayController : UserControl
    {
        #region /_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/|         VARIABLE         |/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
        public static string OverlayEmpty = "Click [ + ] to setup your first overlay";
        public static string BackgroundModeNone = "None";
        public static string BackgroundModeNormal = "Normal";
        public static string BackgroundModeCenter = "Center";
        public static string BackgroundModeFill = "Fill";
        public static string BackgroundModeUniform = "Uniform";
        public static string BackgroundModeUniformToFill = "Uniform to fill";

        public event EventHandler<OverlayTabAddEventArgs> OverlayTabAdd;
        public static Dictionary<string, OverlayTabPage> OverlayConfigs = new Dictionary<string, OverlayTabPage>();
        private ChromiumWebBrowser IssueBrowser;
        #endregion
        #region /_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/|        INITALIZER        |/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
        public OverlayController()
        {
            /// setting load start
            SettingManager.LoadSettingJSON();
            /// setting load end
            InitializeUI();
            LOG.Logger.Logs.ListChanged += Logs_ListChanged;
        }

        private void InitializeUI()
        {
            InitializeComponent();

            foreach(var i in OverlayConfigs)
            {
                overlayManageTabControl1.TabPages.Add(i.Value);
                SelectOverlayNameDisplay();
            }

            if (!DesignMode)
                LanguageLoader.LanguagePatch(this);

            ScreenshotBackgroundFillModeComboBox.Items.Add(BackgroundModeNone);
            ScreenshotBackgroundFillModeComboBox.Items.Add(BackgroundModeNormal);
            ScreenshotBackgroundFillModeComboBox.Items.Add(BackgroundModeCenter);
            ScreenshotBackgroundFillModeComboBox.Items.Add(BackgroundModeFill);
            ScreenshotBackgroundFillModeComboBox.Items.Add(BackgroundModeUniform);
            ScreenshotBackgroundFillModeComboBox.Items.Add(BackgroundModeUniformToFill);

            IssueBrowser = new ChromiumWebBrowser("https://github.com/laiglinne-ff/Aliapoh.Overlay/issues")
            {
                Dock = DockStyle.Fill,
            };

            IssueBrowser.BrowserSettings.WebGl = CefState.Disabled;
            issueBrowserPanel.Controls.Add(IssueBrowser);

            // main tab page setting
            OverlayControlTabPage.Dock = DockStyle.None;
            OverlayControlTabPage.Location = new Point(-2, -2);
            OverlayControlTabPage.Size = new Size(Width + 4, Height + 4);
            OverlayControlTabPage.Anchor = (AnchorStyles)( 1 | 2 | 4 | 8 );
        }
        #endregion
        #region /_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/|      OVERLAY LOGGER      |/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
        private int lastidx = 0;
        private void LogReader()
        {
            Invoke((MethodInvoker)delegate
            {
                for (; lastidx < LOG.Logger.Logs.Count; lastidx++)
                {
                    var line = LOG.Logger.Logs[lastidx];
                    richTextBox1.SelectionColor = Color.Yellow;
                    richTextBox1.AppendText("[");
                    richTextBox1.SelectionColor = Color.Cyan;
                    richTextBox1.AppendText(line.Time.ToString("yyyy-MM-dd HH:mm:ss"));
                    richTextBox1.SelectionColor = Color.Yellow;
                    richTextBox1.AppendText("]");
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

                OnOverlayCreate(TP.Config);
                OverlayConfigs.Add(nod.PrimaryName, TP);
                SaveSetting();
            }
        }

        private void OnOverlayCreate(OverlayConfig c)
        {
            OverlayTabAdd?.Invoke(this, new OverlayTabAddEventArgs(c));
        }

        private void SaveSetting()
        {
            if (SettingManager.OverlaySettings == null)
                SettingManager.OverlaySettings = new List<SettingObject>();

            SettingManager.OverlaySettings.Clear();

            foreach(var i in OverlayConfigs)
            {
                SettingManager.OverlaySettings.Add(i.Value.Config.SettingExport());
            }

            SettingManager.GlobalSetting = SettingExport();
            SettingManager.GenerateSettingJSON();
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
        #region /_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/|      SETTING EXPORT      |/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
        public GlobalSettingObject SettingExport()
        {
            return new GlobalSettingObject()
            {
                VersionAutoCheck = VersionAutoCheckCheckBox.Checked,
                AutoHide = AutoHideCheckBox.Checked,
                AutoClipping = AutoClippingCheckBox.Checked,
                ScreenshotSavePath = ScreenshotSavePathTextBox.Text,
                BackgroundImagePath = ScreenshotBackgroundImagePathTextBox.Text,
                DetectProcessName = DetectProcessNameTextBox.Text,
                BackgroundFillMode = ScreenshotBackgroundFillModeComboBox.SelectedIndex,
                ScreenshotMargin = (int)ScreenshotMargin.Value
            };
        }
        #endregion
        #region /_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/|        UI ACTIONS        |/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
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
            otp.Overlay.Browser.Load(otp.Config.SiteURL.Text);
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
            SettingManager.GlobalSetting = SettingExport();
        }
        #endregion

        private void SettingChangeSaver(object sender, EventArgs e)
        {
            SaveSetting();
        }
    }
}
