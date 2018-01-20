using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Aliapoh.Overlay
{
    public partial class OverlayConfig : UserControl
    {
        public Keys GlobalHotkey { get; set; }
        public Keys GlobalHotkeyModifiers { get; set; }
        public GlobalHotkeyType GlobalHotkeyType { get; set; }
        public OverlayForm Overlay { get; set; }

        public OverlayConfig(string name)
        {
            Initializer(name, "about:blank");
        }

        public OverlayConfig(string name, string url)
        {
            Initializer(name, url);
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

        private void Initializer(string name, string url)
        {
            Overlay = new OverlayForm(url)
            {
                Name = name,
                Text = name,
                ShowInTaskbar = false
            };

            InitializeComponent();
            if (!DesignMode)
                LanguageLoader.LanguagePatch(this);

            Overlay.LocationChanged += Overlay_LocationChanged;
            Overlay.SizeChanged += Overlay_SizeChanged;
            Overlay.Browser.BrowserInitialized += OverlayBrowserInitialized;

            SiteURL.Text = url;
            OverlayName.Text = name;
            
            Overlay.Show();
            Overlay.Browser.Load(SiteURL.Text);
            Overlay.Location = new Point(10, 10);
            Overlay.Size = new Size(400, 400);
        }

        private void Initializer(SettingObject setting)
        {
            SiteURL.Text = setting.Url;
            OverlayName.Text = setting.Name;

            Overlay = new OverlayForm(setting.Url)
            {
                Framerate = setting.Framerate,
                Name = setting.Name,
                Text = setting.Name,
                ShowInTaskbar = false
            };

            InitializeComponent();

            if (!DesignMode)
                LanguageLoader.LanguagePatch(this);
            
            Overlay.LocationChanged += Overlay_LocationChanged;
            Overlay.SizeChanged += Overlay_SizeChanged;
            Overlay.Browser.BrowserInitialized += OverlayBrowserInitialized;

            Overlay.Show();
            Overlay.Browser.Load(SiteURL.Text);
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
        }

        private void OverlayBrowserInitialized(object sender, EventArgs e)
        {
            Overlay.Browser.Load(SiteURL.Text);
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
            Overlay.Browser.BrowserSettings.WindowlessFrameRate = (int)((NumericUpDown)sender).Value;
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
                Name = Name,
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
                GlobalHotkeyType = (int)GlobalHotkeyType,
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
