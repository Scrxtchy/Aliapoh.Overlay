﻿using System;
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
            Overlay = new OverlayForm(url);
            InitializeComponent();
            siteURL.Text = url;
            Overlay.Show();

            Overlay.Location = new Point(10, 10);
            Overlay.Size = new Size(400, 400);

            Overlay.LocationChanged += Overlay_LocationChanged;
            Overlay.SizeChanged += Overlay_SizeChanged;

            Overlay.SettingLoad();
            Overlay.Name = name;
            Overlay.Text = name;
            Overlay.ShowInTaskbar = false;
            Overlay.Browser.BrowserInitialized += OverlayBrowserInitialized;
            overlayName.Text = name;
        }

        private void OverlayBrowserInitialized(object sender, EventArgs e)
        {
            // do somthing
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
    }
}
