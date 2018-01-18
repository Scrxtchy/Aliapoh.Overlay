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

        private void Initializer(string name, string url)
        {
            Overlay = new OverlayForm(url)
            {
                Name = name,
                Text = name,
                ShowInTaskbar = false
            };

            InitializeComponent();

            Overlay.LocationChanged += Overlay_LocationChanged;
            Overlay.SizeChanged += Overlay_SizeChanged;
            Overlay.Browser.BrowserInitialized += OverlayBrowserInitialized;

            siteURL.Text = url;
            overlayName.Text = name;

            Overlay.SettingLoad();
            Overlay.Show();
            Overlay.Browser.Load(siteURL.Text);
            Overlay.Location = new Point(10, 10);
            Overlay.Size = new Size(400, 400);
        }

        private void OverlayBrowserInitialized(object sender, EventArgs e)
        {
            Overlay.Browser.Load(siteURL.Text);
        }

        private void Overlay_SizeChanged(object sender, EventArgs e)
        {
            overlayWidth.Value = Overlay.Width;
            overlayHeight.Value = Overlay.Height;
        }

        private void Overlay_LocationChanged(object sender, EventArgs e)
        {
            overlayX.Value = Overlay.Left;
            overlayY.Value = Overlay.Top;
        }

        private void TextboxPadderClicked(object sender, EventArgs e)
        {
            siteURL.Focus();
        }

        new public void Dispose()
        {
            Overlay.Close();
            base.Dispose();
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

        }

        public void SettingSave()
        {
            // Overlay Setting base
            var set = new Dictionary<string, object>()
            {
                { "Url", siteURL.Text },
                { "Show", overlayShow.Checked },
                { "Clickthru", overlayClickthru.Checked },
                { "Locked", overlayLock.Checked },
                { "UseGlobalHotkey", overlayGlobalHotkey.Checked },
                { "BeforeLogLineRead", overlayEnableBeforeLogLineRead.Checked },

                { "Framerate", overlayFramerate.Value },
                { "Updaterate", overlayUpdateRate.Value },

                { "Width", Overlay.Width },
                { "Height", Overlay.Height },

                { "Left", Overlay.Left },
                { "Top", Overlay.Top },

                { "GlobalHotkey", (int)GlobalHotkey },
                { "GlobalHotkeyModifiers", (int)GlobalHotkeyModifiers },
                { "GlobalHotkeyType", (int)GlobalHotkeyType }
            };
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
            overlayGlobalHotkeyInput.Text = GetHotkeyString(GlobalHotkeyModifiers, GlobalHotkey, "");
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
