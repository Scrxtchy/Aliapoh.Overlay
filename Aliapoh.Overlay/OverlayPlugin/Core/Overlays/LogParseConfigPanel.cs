using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aliapoh.Overlays;

namespace Aliapoh.OverlayPlugin.Core.Overlays
{
    public partial class LogParseConfigPanel : UserControl
    {
        private LogParseOverlayConfig config;
        private LogParseOverlay Overlay;

        static readonly List<KeyValuePair<string, GlobalHotkeyType>> hotkeyTypeDict = new List<KeyValuePair<string, GlobalHotkeyType>>()
        {
            new KeyValuePair<string, GlobalHotkeyType>(Localization.GetText(TextItem.ToggleVisible), GlobalHotkeyType.ToggleVisible),
            new KeyValuePair<string, GlobalHotkeyType>(Localization.GetText(TextItem.ToggleClickthru), GlobalHotkeyType.ToggleClickthru),
            new KeyValuePair<string, GlobalHotkeyType>(Localization.GetText(TextItem.ToggleLock), GlobalHotkeyType.ToggleLock)
        };

        public LogParseConfigPanel(LogParseOverlay overlay)
        {
            InitializeComponent();

            Overlay = overlay;
            config = overlay.Config;

            SetupControlProperties();
            SetupConfigEventHandlers();
        }

        private void SetupControlProperties()
        {
            checkMiniParseVisible.Checked = config.IsVisible;
            checkMiniParseClickthru.Checked = config.IsClickThru;
            checkLock.Checked = config.IsLocked;
            textLogParseUrl.Text = config.Url;
            nudMaxFrameRate.Value = config.MaxFrameRate;
            checkEnableGlobalHotkey.Checked = config.GlobalHotkeyEnabled;
            textGlobalHotkey.Enabled = checkEnableGlobalHotkey.Checked;
            textGlobalHotkey.Text = Util.GetHotkeyString(config.GlobalHotkeyModifiers, config.GlobalHotkey);
            comboHotkeyType.DisplayMember = "Key";
            comboHotkeyType.ValueMember = "Value";
            comboHotkeyType.DataSource = hotkeyTypeDict;
            comboHotkeyType.SelectedValue = config.GlobalHotkeyType;
            comboHotkeyType.SelectedIndexChanged += ComboHotkeyMode_SelectedIndexChanged;
        }

        private void SetupConfigEventHandlers()
        {
            config.VisibleChanged += (o, e) =>
            {
                InvokeIfRequired(() =>
                {
                    checkMiniParseVisible.Checked = e.IsVisible;
                });
            };
            config.ClickThruChanged += (o, e) =>
            {
                InvokeIfRequired(() =>
                {
                    checkMiniParseClickthru.Checked = e.IsClickThru;
                });
            };
            config.UrlChanged += (o, e) =>
            {
                InvokeIfRequired(() =>
                {
                    textLogParseUrl.Text = e.NewUrl;
                });
            };
            config.MaxFrameRateChanged += (o, e) =>
            {
                InvokeIfRequired(() =>
                {
                    nudMaxFrameRate.Value = e.NewFrameRate;
                });
            };
            config.GlobalHotkeyEnabledChanged += (o, e) =>
            {
                InvokeIfRequired(() =>
                {
                    checkEnableGlobalHotkey.Checked = e.NewGlobalHotkeyEnabled;
                    textGlobalHotkey.Enabled = checkEnableGlobalHotkey.Checked;
                });
            };
            config.GlobalHotkeyChanged += (o, e) =>
            {
                InvokeIfRequired(() =>
                {
                    textGlobalHotkey.Text = Util.GetHotkeyString(config.GlobalHotkeyModifiers, e.NewHotkey);
                });
            };
            config.GlobalHotkeyModifiersChanged += (o, e) =>
            {
                InvokeIfRequired(() =>
                {
                    textGlobalHotkey.Text = Util.GetHotkeyString(e.NewHotkey, config.GlobalHotkey);
                });
            };
            config.LockChanged += (o, e) =>
            {
                InvokeIfRequired(() =>
                {
                    checkLock.Checked = e.IsLocked;
                });
            };
            config.GlobalHotkeyTypeChanged += (o, e) =>
            {
                InvokeIfRequired(() =>
                {
                    comboHotkeyType.SelectedValue = e.NewHotkeyType;
                });
            };
        }

        private void InvokeIfRequired(Action action)
        {
            if (InvokeRequired)
            {
                Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void checkWindowVisible_CheckedChanged(object sender, EventArgs e)
        {
            config.IsVisible = checkMiniParseVisible.Checked;
        }

        private void checkMouseClickthru_CheckedChanged(object sender, EventArgs e)
        {
            config.IsClickThru = checkMiniParseClickthru.Checked;
        }

        private void textUrl_TextChanged(object sender, EventArgs e)
        {
            //config.Url = textLogParseUrl.Text;
        }

        private void textLogParseUrl_Leave(object sender, EventArgs e)
        {
            config.Url = textLogParseUrl.Text;
        }

        private void ComboHotkeyMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            var value = (GlobalHotkeyType)comboHotkeyType.SelectedValue;
            config.GlobalHotkeyType = value;
        }

        private void nudMaxFrameRate_ValueChanged(object sender, EventArgs e)
        {
            config.MaxFrameRate = (int)nudMaxFrameRate.Value;
        }

        private void buttonReloadBrowser_Click(object sender, EventArgs e)
        {
            Overlay.Navigate(config.Url);
        }

        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                config.Url = new Uri(ofd.FileName).ToString();
            }
        }

        private void buttonLogParseOpenDevTools_Click(object sender, EventArgs e)
        {
            Overlay.Overlay.ShowDevTools();
        }

        private void buttonLogParseOpenDevTools_RClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                Overlay.Overlay.ShowDevTools();
        }

        private void buttonCopyActXiv_Click(object sender, EventArgs e)
        {
            var json = Overlay.CreateJsonData();
            if (!string.IsNullOrWhiteSpace(json))
            {
                Clipboard.SetText(json);
            }
        }

        private void checkBoxEnableGlobalHotkey_CheckedChanged(object sender, EventArgs e)
        {
            config.GlobalHotkeyEnabled = checkEnableGlobalHotkey.Checked;
            textGlobalHotkey.Enabled = config.GlobalHotkeyEnabled;
        }

        private void textBoxGlobalHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            var key = Util.RemoveModifiers(e.KeyCode, e.Modifiers);
            config.GlobalHotkey = key;
            config.GlobalHotkeyModifiers = e.Modifiers;
        }

        private void checkLock_CheckedChanged(object sender, EventArgs e)
        {
            config.IsLocked = checkLock.Checked;
        }
    }
}
