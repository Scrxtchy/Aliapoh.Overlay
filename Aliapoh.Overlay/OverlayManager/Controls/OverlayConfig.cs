using Aliapoh.Overlay.OverlayManager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Aliapoh.Overlay
{
    public partial class OverlayConfig : UserControl
    {
        public string ShortcutModeNone = "None";
        public string ShortcutModeHide = "Hide";
        public string ShortcutModeClickthru = "Clickthru";
        public string ShortcutModeToggleLock = "Toggle Lock";
        public string ShortcutModeTakeScreenshot = "Take Screenshot";
        public bool IsInitialized = false;

        public Keys GlobalHotkey;
        public Keys GlobalHotkeyModifiers;
        public GlobalHotkeyType GlobalHotkeyType;
        public OverlayForm Overlay;
        public Stopwatch SW;
        public SettingObject SettingObject
        {
            get
            {
                return SettingExport();
            }
        }

        public OverlayConfig(string name)
        {
            var s = DefaultSetting.SettingObject;
            s.Name = name;
            Initializer(s);
        }

        public OverlayConfig(string name, string url)
        {
            var s = DefaultSetting.SettingObject;
            s.Name = name;
            s.Url = url;
            Initializer(s);
        }

        public OverlayConfig(SettingObject s)
        {
            Initializer(s);
        }

        new public void Dispose()
        {
            Overlay.Close();
            base.Dispose();
        }
        
        private void Initializer(SettingObject setting)
        {
            Name = setting.Name;
            InitializeComponent();

            OverlayName.Text = setting.Name;
            overlayGlobalHotkeyType.Items.Add(ShortcutModeNone);
            overlayGlobalHotkeyType.Items.Add(ShortcutModeHide);
            overlayGlobalHotkeyType.Items.Add(ShortcutModeClickthru);
            overlayGlobalHotkeyType.Items.Add(ShortcutModeToggleLock);
            overlayGlobalHotkeyType.Items.Add(ShortcutModeTakeScreenshot);

            OverlayWidth.ValueChanged += SaveSetting;
            OverlayHeight.ValueChanged += SaveSetting;
            OverlayX.ValueChanged += SaveSetting;
            OverlayY.ValueChanged += SaveSetting;
            OverlayNameChangeButton.Click += SaveSetting;
            OverlayLock.CheckedChanged += SaveSetting;
            OverlayClickthru.CheckedChanged += SaveSetting;
            OverlayShow.CheckedChanged += SaveSetting;
            OverlayFramerate.ValueChanged += SaveSetting;
            SiteURL.TextChanged += SaveSetting;
            overlayGlobalHotkeyType.SelectedIndexChanged += SaveSetting;

            SiteURL.Text = setting.Url;
            
            Overlay = new OverlayForm(setting.Url)
            {
                Framerate = setting.Framerate,
                Name = setting.Name,
                Text = setting.Name,
                ShowInTaskbar = false
            };

            if (!DesignMode)
                LanguageLoader.LanguagePatch(this);

            Overlay.LocationChanged += Overlay_LocationChanged;
            Overlay.SizeChanged += Overlay_SizeChanged;
            Overlay.Show();
            Overlay.Location = new Point(setting.Left, setting.Top);
            Overlay.Size = new Size(setting.Width, setting.Height);
            OverlayClickthru.Checked = setting.Clickthru;
            OverlayGlobalHotkey.Checked = setting.UseGlobalHotkey;
            OverlayLock.Checked = setting.Locked;
            OverlayEnableBeforeLogLineRead.Checked = setting.BeforeLogLineRead;

            GlobalHotkey = (Keys)setting.GlobalHotkey;
            GlobalHotkeyModifiers = (Keys)setting.GlobalHotkeyModifiers;
            OverlayGlobalHotkeyInput.Text = GetHotkeyString((Keys)setting.GlobalHotkeyModifiers, (Keys)setting.GlobalHotkey, "");

            OverlayFramerate.Value = setting.Framerate;
            OverlayUpdaterate.Value = setting.Updaterate;
            Overlay.OverlayTicTimer.Interval = setting.Updaterate;
            Overlay.Browser.BrowserInitialized += Browser_BrowserInitialized;
            IsInitialized = true;
        }

        private void Browser_BrowserInitialized(object sender, EventArgs e)
        {
            if (Overlay.Browser.IsBrowserInitialized)
                Overlay.Browser.Load(SiteURL.Text);
        }

        private void SaveSetting(object sender, EventArgs e)
        {
            if (!IsInitialized) return;
            OverlayController.OverlayConfigs[SettingObject.Name].Config = this;
            if (SettingManager.OverlaySettings == null)
                SettingManager.OverlaySettings = new List<SettingObject>();

            SettingManager.OverlaySettings.Clear();

            foreach (var i in OverlayController.OverlayConfigs)
            {
                SettingManager.OverlaySettings.Add(i.Value.Config.SettingExport());
            }

            SettingManager.GenerateSettingJSON();
        }

        private void Overlay_SizeChanged(object sender, EventArgs e)
        {
            OverlayWidth.Value = Overlay.Width;
            OverlayHeight.Value = Overlay.Height;
        }

        private void Overlay_LocationChanged(object sender, EventArgs e)
        {
            OverlayX.Value = Overlay.Left;
            OverlayY.Value = Overlay.Top;
        }

        private void TextboxPadderClicked(object sender, EventArgs e)
        {
            SiteURL.Focus();
        }

        private void OverlayShow_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
                Overlay.Show();
            else
                Overlay.Hide();
        }

        private void OverlayClickthru_CheckedChanged(object sender, EventArgs e)
        {
            Overlay.ClickthruChange(((CheckBox)sender).Checked);
        }

        private void OverlayLock_CheckedChanged(object sender, EventArgs e)
        {
            Overlay.IsBrowserLocked = ((CheckBox)sender).Checked;
        }

        private void OverlayFramerate_ValueChanged(object sender, EventArgs e)
        {
            Overlay.MainOverlay.GetHost().WindowlessFrameRate = (int)((NumericUpDown)sender).Value;
        }

        private void OverlayX_ValueChanged(object sender, EventArgs e)
        {
            Overlay.Left = (int)((NumericUpDown)sender).Value;
        }

        private void OverlayY_ValueChanged(object sender, EventArgs e)
        {
            Overlay.Top = (int)((NumericUpDown)sender).Value;
        }

        private void OverlayWidth_ValueChanged(object sender, EventArgs e)
        {
            Overlay.Width = (int)((NumericUpDown)sender).Value;
        }

        private void OverlayHeight_ValueChanged(object sender, EventArgs e)
        {
            Overlay.Height = (int)((NumericUpDown)sender).Value;
        }

        private void OverlayNameChange_Click(object sender, EventArgs e)
        {
            //TODO
        }
        
        private void OverlayGlobalHotkeyInput_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            var key = RemoveModifiers(e.KeyCode, e.Modifiers);
            GlobalHotkey = key;
            GlobalHotkeyModifiers = e.Modifiers;
            SaveSetting(sender, e);
        }

        private void OverlayGlobalHotkeyInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void OverlayGlobalHotkeyInput_KeyUp(object sender, KeyEventArgs e)
        {
            OverlayGlobalHotkeyInput.Text = GetHotkeyString(GlobalHotkeyModifiers, GlobalHotkey, "");
        }

        public SettingObject SettingExport()
        {
            var s = new SettingObject()
            {
                Url = SiteURL.Text,
                Name = OverlayName.Text,
                Show = OverlayShow.Checked,
                Clickthru = OverlayClickthru.Checked,
                Locked = OverlayLock.Checked,
                UseGlobalHotkey = OverlayGlobalHotkey.Checked,
                BeforeLogLineRead = OverlayEnableBeforeLogLineRead.Checked,
                Framerate = (int)OverlayFramerate.Value,
                Updaterate = (int)OverlayUpdaterate.Value,
                Width = (int)OverlayWidth.Value,
                Height = (int)OverlayHeight.Value,
                Left = (int)OverlayX.Value,
                Top = (int)OverlayY.Value,
                GlobalHotkey = (int)GlobalHotkey,
                GlobalHotkeyModifiers = (int)GlobalHotkeyModifiers,
                GlobalHotkeyType = overlayGlobalHotkeyType.SelectedIndex,
            };
            return s;
        }

        public static string GetHotkeyString(Keys modifier, Keys key, String defaultText = "")
        {
            var sbKeys = new StringBuilder();
            if ((modifier & Keys.Shift) == Keys.Shift)
            {
                sbKeys.Append("Shift + ");
            }
            if ((modifier & Keys.Control) == Keys.Control)
            {
                sbKeys.Append("Ctrl + ");
            }
            if ((modifier & Keys.Alt) == Keys.Alt)
            {
                sbKeys.Append("Alt + ");
            }
            if ((modifier & Keys.LWin) == Keys.LWin || (modifier & Keys.RWin) == Keys.RWin)
            {
                sbKeys.Append("Win + ");
            }
            sbKeys.Append(Enum.ToObject(typeof(Keys), key).ToString());
            return sbKeys.ToString();
        }

        public static Keys RemoveModifiers(Keys keyCode, Keys modifiers)
        {
            var key = keyCode;
            var modifierList = new List<Keys>() { Keys.ControlKey, Keys.LControlKey, Keys.Alt, Keys.ShiftKey, Keys.Shift, Keys.LShiftKey, Keys.RShiftKey, Keys.Control, Keys.LWin, Keys.RWin };
            foreach (var mod in modifierList)
            {
                if (key.HasFlag(mod))
                {
                    if (key == mod)
                        key &= ~mod;
                }
            }
            return key;
        }
    }
}
