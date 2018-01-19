using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

using CefSharp;
using CefSharp.OffScreen;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Aliapoh.Overlay.Logger;

namespace Aliapoh.Overlay
{
    public partial class OverlayForm : Form
    {
        #region /_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/|        Variables         |/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
        public bool IsBrowserLocked { get; set; }
        public bool IsBrowserInitialized { get; private set; }
        public string OverlayName { get; set; }
        public int Framerate { get; set; }

        public ChromiumWebBrowser Browser;
        public IBrowser MainOverlay;
        public Bitmap ScreenShot;
        #endregion

        private bool IsBrowserLockedInternal { get; set; }
        private bool D_ALT { get; set; }
        private bool D_CTRL { get; set; }
        private bool D_SHIFT { get; set; }
        private CefMenuHandler CefMenu { get; set; }

        private ACTPlugin.OverlayPluginApi OverlayAPI { get; set; }

        public OverlayForm()
        {
            Initalizer("about:blank");
        }

        public OverlayForm(string Url)
        {
            Initalizer(Url);
        }

        public void SettingLoad()
        {

        }

        public void ClickthruChange(bool enabled)
        {
            if (enabled) EnableMouseClickThru();
            else DisableMouseClickThru();
        }

        public void ExecuteJavascript(string script)
        {
            if (IsBrowserInitialized)
                Browser.GetMainFrame().ExecuteJavaScriptAsync(script);
        }

        public void ShowDevTools()
        {
            MainOverlay.ShowDevTools();
        }

        public void CloseDevTools()
        {
            MainOverlay.CloseDevTools();
        }

        private void Initalizer(string URL)
        {
            try
            {
                LOG.Logger.Log(LogLevel.Info, "Browser Initializing...");
                IsBrowserInitialized = false;
                TopMost = true;
                var fr = 30;
                if (Framerate != 0)
                    fr = Framerate;

                var browser = new BrowserSettings()
                {
                    WindowlessFrameRate = fr,
                    WebGl = CefState.Disabled, // Why?: A: Spectre attack issue, google suggest turn on WebGL Feature.
                    BackgroundColor = 0,
                };

                CefMenu = new CefMenuHandler();
                Browser = new ChromiumWebBrowser(URL, browser)
                {
                    MenuHandler = CefMenu,
                };

                OverlayAPI = new ACTPlugin.OverlayPluginApi(this);
                Browser.RegisterAsyncJsObject("OverlayPluginApi", OverlayAPI, new BindingOptions { CamelCaseJavascriptNames = false });
                Browser.DisplayHandler = new DisplayHandler();
                Browser.BrowserInitialized += Overlay_BrowserInitialized;
                Browser.NewScreenshot += Overlay_NewScreenshot;
                Browser.ConsoleMessage += Overlay_ConsoleMessage;
                new Thread((ThreadStart)delegate
                {
                    while (true)
                    {
                        Thread.Sleep(5000);
                        GC.Collect(1);
                    }
                }).Start();
                InitializeComponent();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void Overlay_ConsoleMessage(object sender, ConsoleMessageEventArgs e)
        {
            LOG.Logger.Log(LogLevel.Browser, string.Format("{0}: {1}", Name, e.Message));
        }

        private void EnableMouseClickThru()
        {
            NativeMethods.SetWindowLong(Handle, new IntPtr(-20), new IntPtr(NativeMethods.GetWindowLong(Handle, -20) | 0x20));
        }

        private void DisableMouseClickThru()
        {
            NativeMethods.SetWindowLong(Handle, new IntPtr(-20), new IntPtr(NativeMethods.GetWindowLong(Handle, -20) & ~0x20));
        }

        private void Overlay_NewScreenshot(object sender, EventArgs e)
        {
            ScreenShot = Browser.ScreenshotOrNull(PopupBlending.Main);
            if (ScreenShot != null) SetBitmap(ScreenShot, this);
            GC.Collect(1);
        }

        private void Overlay_BrowserInitialized(object sender, EventArgs e)
        {
            LOG.Logger.Log(LogLevel.Info, Name + " Browser Initialized");
            MainOverlay = Browser.GetBrowser();
            Browser.Size = new Size(Width, Height);
            IsBrowserInitialized = true;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Browser.Dispose();
            base.OnFormClosed(e);
        }

        // 별로 건들 일 없어서 내려놓음

        #region /_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/|          Resize          |/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (IsBrowserInitialized)
                Browser.Size = new Size(Width, Height);
        }
        #endregion
        #region /_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/|          WndProc         |/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case (int)WM.CHAR:
                case (int)WM.IME_CHAR:
                case (int)WM.KEYDOWN:
                case (int)WM.KEYUP:
                case (int)WM.SYSCHAR:
                case (int)WM.SYSKEYDOWN:
                case (int)WM.SYSKEYUP:
                    OnKeyEvent(ref m);
                    break;
                case 0x0084/*NCHITTEST*/ :
                    {
                        base.WndProc(ref m);
                        if ((int)m.Result == 0x01 && !IsBrowserLocked)
                        {
                            var clientPoint = PointToClient(new Point(m.LParam.ToInt32()));
                            Rectangle ResizeHand = new Rectangle(Width - 24, Height - 24, 24, 24);
                            if (ResizeHand.Contains(clientPoint)) m.Result = new IntPtr(0x11);
                        }
                    }
                    return;
            }

            base.WndProc(ref m);
        }
        #endregion
        #region /_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/|      Keyboard Event      |/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
        private List<int> SysKeys = new List<int>()
        {
            (int)WM.SYSCHAR,
            (int)WM.SYSKEYDOWN,
            (int)WM.SYSKEYUP
        };

        private List<Keys> NumPadKeys = new List<Keys>()
        {
            Keys.NumLock,
            Keys.NumPad0,
            Keys.NumPad1,
            Keys.NumPad2,
            Keys.NumPad3,
            Keys.NumPad4,
            Keys.NumPad5,
            Keys.NumPad6,
            Keys.NumPad7,
            Keys.NumPad8,
            Keys.NumPad9,
            Keys.Divide,
            Keys.Multiply,
            Keys.Subtract,
            Keys.Add,
            Keys.Decimal,
            Keys.Clear
        };

        private List<Keys> ExtendKeyPads = new List<Keys>()
        {
            Keys.Insert,
            Keys.Delete,
            Keys.Home,
            Keys.End,
            Keys.Prior,
            Keys.Next,
            Keys.Up,
            Keys.Down,
            Keys.Left,
            Keys.Right
        };

        private void OnKeyEvent(ref Message m)
        {
            var key = (Keys)m.WParam.ToInt32();
            try
            {
                if (CultureInfo.CurrentCulture.Name == "ko-KR" && key == Keys.KanaMode)
                    key = Keys.HangulMode;
                var keyEvent = new KeyEvent()
                {
                    WindowsKeyCode = (int)key,
                    NativeKeyCode = (int)m.LParam.ToInt64(),
                    IsSystemKey = (m.Msg == (int)WM.SYSCHAR || m.Msg == (int)WM.SYSKEYDOWN || m.Msg == (int)WM.SYSKEYUP)
                };
                if (m.Msg == (int)WM.KEYDOWN || m.Msg == (int)WM.SYSKEYDOWN)
                    keyEvent.Type = KeyEventType.RawKeyDown;
                else if (m.Msg == (int)WM.KEYUP || m.Msg == (int)WM.SYSKEYUP)
                    keyEvent.Type = KeyEventType.KeyUp;
                else
                    keyEvent.Type = KeyEventType.Char;
                if (IsKeyDown(Keys.Shift)) keyEvent.Modifiers |= CefEventFlags.ShiftDown;
                if (IsKeyDown(Keys.Control)) keyEvent.Modifiers |= CefEventFlags.ControlDown;
                if (IsKeyDown(Keys.Alt)) keyEvent.Modifiers |= CefEventFlags.AltDown;
                if (IsKeyToggled(Keys.Capital)) keyEvent.Modifiers |= CefEventFlags.CapsLockOn;
                if (IsKeyToggled(Keys.NumLock)) keyEvent.Modifiers |= CefEventFlags.NumLockOn;
                if (((m.LParam.ToInt64() >> 48) & 0x100) != 0 && key == Keys.Return)
                    keyEvent.Modifiers |= CefEventFlags.IsKeyPad;
                if (((m.LParam.ToInt64() >> 48) & 0x100) == 0 && ExtendKeyPads.Contains((Keys)m.WParam.ToInt32()))
                    keyEvent.Modifiers |= CefEventFlags.IsKeyPad;
                if (NumPadKeys.Contains((Keys)m.WParam.ToInt32()))
                    keyEvent.Modifiers |= CefEventFlags.IsKeyPad;
                if (key == Keys.Shift)
                    keyEvent.Modifiers |= IsLeftKey(key) ? CefEventFlags.IsLeft : CefEventFlags.IsRight;
                if (key == Keys.Control)
                    keyEvent.Modifiers |= IsLeftKey(key) ? CefEventFlags.IsLeft : CefEventFlags.IsRight;
                if (key == Keys.Alt)
                    keyEvent.Modifiers |= IsLeftKey(key) ? CefEventFlags.IsLeft : CefEventFlags.IsRight;
                if (key == Keys.LWin)
                    keyEvent.Modifiers |= CefEventFlags.IsLeft;
                if (key == Keys.RWin)
                    keyEvent.Modifiers |= CefEventFlags.IsRight;
                if (IsBrowserInitialized)
                    MainOverlay.GetHost().SendKeyEvent(keyEvent);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private CefEventFlags Modifier()
        {
            var cef = CefEventFlags.None;
            if (D_ALT) cef |= CefEventFlags.AltDown;
            if (D_CTRL) cef |= CefEventFlags.ControlDown;
            if (D_SHIFT) cef |= CefEventFlags.ShiftDown;

            return cef;
        }

        private bool IsLeftKey(Keys key)
        {
            if (IsKeyDown(Keys.LShiftKey)) return true;
            else if (IsKeyDown(Keys.LMenu)) return true;
            else if (IsKeyDown(Keys.LControlKey)) return true;
            else return false;
        }

        private bool IsKeyDown(Keys key)
        {
            return (NativeMethods.GetKeyState((int)key) & 0x8000) != 0;
        }

        private bool IsKeyToggled(Keys key)
        {
            return (NativeMethods.GetKeyState((int)key) & 1) == 1;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            D_ALT = e.Alt;
            D_CTRL = e.Control;
            D_SHIFT = e.Shift;
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            D_ALT = e.Alt;
            D_CTRL = e.Control;
            D_SHIFT = e.Shift;
        }
        #endregion
        #region /_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/|       Mouse Events       |/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
        private bool IsDragging = false;
        private Point Offset;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            var btn = MouseButtonType.Left;

            if (e.Button == MouseButtons.Middle) btn = MouseButtonType.Middle;
            else if (e.Button == MouseButtons.Right) btn = MouseButtonType.Right;

            MainOverlay.GetHost().SendMouseClickEvent(e.X, e.Y, btn, false, 1, Modifier());

            if (!IsBrowserLocked)
            {
                IsDragging = true;
                Offset = e.Location;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            var btn = MouseButtonType.Left;

            if (e.Button == MouseButtons.Middle) btn = MouseButtonType.Middle;
            else if (e.Button == MouseButtons.Right) btn = MouseButtonType.Right;

            MainOverlay.GetHost().SendMouseClickEvent(e.X, e.Y, btn, true, 1, Modifier());
            IsDragging = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (IsDragging)
            {
                var s = PointToScreen(e.Location);
                Location = new Point(s.X - Offset.X, s.Y - Offset.Y);
            }
            else
            {
                MainOverlay.GetHost().SendMouseMoveEvent(e.X, e.Y, false, Modifier());
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            MainOverlay.GetHost().SendMouseWheelEvent(e.X, e.Y, 0, e.Delta, D_SHIFT ? CefEventFlags.ShiftDown : CefEventFlags.None);
        }
        #endregion
        #region /_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/|       CreateParams       |/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
        protected override CreateParams CreateParams
        {
            get
            {
                var style = base.CreateParams;
                style.ClassStyle |= 200; // NoCloseBtn
                style.ExStyle |= 0x8; // TopMost
                style.ExStyle |= 0x80000; // Layered
                style.ExStyle |= 0x8000000; // NoActive
                return style;
            }
        }
        #endregion
        #region /_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/| Set Layered Window Image |/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
        public static void SetBitmap(Bitmap bitmap, Form frm)
        {
            // retrieve current screen device context
            IntPtr screenDc = NativeMethods.GetDC(IntPtr.Zero);

            // create a memory device context compatible with the screen 
            IntPtr compatibleMemoryDc = NativeMethods.CreateCompatibleDC(screenDc);

            IntPtr hgdiBitmap = IntPtr.Zero;
            IntPtr hgdiOldBitmap = IntPtr.Zero;

            try
            {
                hgdiBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
                // select a bitmap object into the memory device context created above
                hgdiOldBitmap = NativeMethods.SelectObject(compatibleMemoryDc, hgdiBitmap);

                // ++ prepare structures we need in order to call UpdateLayeredWindow ++
                NativeMethods.SizeStruct size = new NativeMethods.SizeStruct()
                {
                    X = bitmap.Width,
                    Y = bitmap.Height
                };

                NativeMethods.PointStruct sourcePoint = new NativeMethods.PointStruct();
                NativeMethods.PointStruct topPoint = new NativeMethods.PointStruct()
                {
                    X = frm.Left,
                    Y = frm.Top
                };

                NativeMethods.BlendFunctionStruct blend = new NativeMethods.BlendFunctionStruct()
                {
                    BlendOp = 255 /* opacity */,
                    BlendFlags = 0x00 /* AC_SRC_OVER */,
                    AlphaFormat = 0x01 /* AC_SRC_ALPHA */,
                    SourceConstantAlpha = byte.MaxValue
                };

                frm.Invoke((MethodInvoker)delegate
                {
                    NativeMethods.UpdateLayeredWindow(frm.Handle, screenDc, ref topPoint, ref size, compatibleMemoryDc,
                        ref sourcePoint, 0, ref blend, 2 /* ULW_ALPHA */);
                });
            }
            finally
            {
                if (screenDc != IntPtr.Zero)
                {
                    NativeMethods.ReleaseDC(IntPtr.Zero, screenDc);
                }

                if (hgdiBitmap != IntPtr.Zero)
                {
                    NativeMethods.SelectObject(compatibleMemoryDc, hgdiOldBitmap);
                    NativeMethods.DeleteObject(hgdiBitmap);
                }

                NativeMethods.DeleteDC(compatibleMemoryDc);
            }
        }
        #endregion

        private void OverlayForm_Load(object sender, EventArgs e)
        {
            NativeMethods.SetForegroundWindow(Handle);
        }
    }
}
