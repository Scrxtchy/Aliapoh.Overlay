using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CefSharp;
using CefSharp.OffScreen;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Aliapoh.Overlay
{
    public partial class OverlayForm : Form
    {
        private bool D_ALT { get; set; }
        private bool D_CTRL { get; set; }
        private bool D_SHIFT { get; set; }

        public bool IsBrowserInitialized { get; private set; }

        public string OverlayName { get; set; }
        public string OverlayVersion { get; private set; }

        public ChromiumWebBrowser Overlay;
        public BrowserProcessHandler browserHandler;

        public IBrowser MainOverlay;
        public Bitmap ScreenShot;

        public OverlayForm()
        {
            IsBrowserInitialized = false;
            TopMost = true;
            Debug.WriteLine("Overlay Load");
            InitializeComponent();
            OverlayInit(browserHandler = new BrowserProcessHandler());

            new Thread((ThreadStart)delegate
            {
                while(true)
                {
                    Thread.Sleep(5000);
                    GC.Collect();
                }
            }).Start();
        }

        public void OverlayInit(IBrowserProcessHandler bh)
        {
            Debug.WriteLine("Overlay Initialize");
            var setting = new CefSettings()
            {
                ExternalMessagePump = false,
                MultiThreadedMessageLoop = true,
                WindowlessRenderingEnabled = true,
                FocusedNodeChangedEnabled = true,
                RemoteDebuggingPort = 9994,
                CachePath = "Cache",
                LogSeverity = LogSeverity.Disable
            };
            
            if (!Cef.Initialize(setting, false, bh))
            {
                throw new Exception("Unable to Initialize Cef");
            }

            var browser = new BrowserSettings()
            {
                WindowlessFrameRate = 30,
                WebGl = CefState.Disabled,
                BackgroundColor = 0
            };
            
            Overlay = new ChromiumWebBrowser("http://kangax.github.io/compat-table/es6/", browser);
            Overlay.BrowserInitialized += Overlay_BrowserInitialized;
            Overlay.NewScreenshot += Overlay_NewScreenshot;
        }

        private void Overlay_NewScreenshot(object sender, EventArgs e)
        {
            ScreenShot = Overlay.ScreenshotOrNull(PopupBlending.Main);
            if (ScreenShot != null)
                SetBitmap(ScreenShot);
            GC.Collect(0);
        }

        private void Overlay_BrowserInitialized(object sender, EventArgs e)
        {
            Overlay.Load("http://kangax.github.io/compat-table/es6/");

            MainOverlay = Overlay.GetBrowser();
            Overlay.Size = new Size(Width, Height);
            IsBrowserInitialized = true;
        }

        private void OnKeyEvent(ref Message m)
        {

        }

        private CefEventFlags Modifier()
        {
            var cef = CefEventFlags.None;
            if (D_ALT) cef |= CefEventFlags.AltDown;
            if (D_CTRL) cef |= CefEventFlags.ControlDown;
            if (D_SHIFT) cef |= CefEventFlags.ShiftDown;

            return cef;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            var btn = MouseButtonType.Left;

            if (e.Button == MouseButtons.Middle) btn = MouseButtonType.Middle;
            else if (e.Button == MouseButtons.Right) btn = MouseButtonType.Right;

            MainOverlay.GetHost().SendMouseClickEvent(e.X, e.Y, btn, false, 1, Modifier());
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            var btn = MouseButtonType.Left;

            if (e.Button == MouseButtons.Middle) btn = MouseButtonType.Middle;
            else if (e.Button == MouseButtons.Right) btn = MouseButtonType.Right;

            MainOverlay.GetHost().SendMouseClickEvent(e.X, e.Y, btn, true, 1, Modifier());
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            MainOverlay.GetHost().SendMouseMoveEvent(e.X, e.Y, false, Modifier());
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            MainOverlay.GetHost().SendMouseWheelEvent(e.X, e.Y, 0, e.Delta, D_SHIFT ? CefEventFlags.ShiftDown : CefEventFlags.None);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            D_ALT = e.Alt;
            D_CTRL = e.Control;
            D_SHIFT = e.Shift;
            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            D_ALT = e.Alt;
            D_CTRL = e.Control;
            D_SHIFT = e.Shift;
            base.OnKeyUp(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (IsBrowserInitialized)
                Overlay.Size = new Size(Width, Height);
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 10;

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

                        if ((int)m.Result == 0x01/*HTCLIENT*/)
                        {
                            Point screenPoint = new Point(m.LParam.ToInt32());
                            Point clientPoint = this.PointToClient(screenPoint);

                            Rectangle ResizeHand = new Rectangle(Width - 24, Height - 24, 24, 24);

                            if(ResizeHand.Contains(clientPoint))
                            {
                                // Return ResizeHandle
                                m.Result = new IntPtr(0x11);
                            }
                        }
                    }
                    return;
            }

            base.WndProc(ref m);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var style = base.CreateParams;
                style.ClassStyle |= 200;
                style.ExStyle |= 0x80000;
                //style.ExStyle |= 0x200;
                //style.ExStyle |= 0x20;
                return style;
            }
        }

        public void SetBitmap(Bitmap bitmap)
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
                    X = Left,
                    Y = Top
                };

                NativeMethods.BlendFunctionStruct blend = new NativeMethods.BlendFunctionStruct()
                {
                    BlendOp = 255 /* opacity */,
                    BlendFlags = 0x00 /* AC_SRC_OVER */,
                    AlphaFormat = 0x01 /* AC_SRC_ALPHA */,
                    SourceConstantAlpha = byte.MaxValue
                };

                Invoke((MethodInvoker)delegate
                {
                    NativeMethods.UpdateLayeredWindow(Handle, screenDc, ref topPoint, ref size, compatibleMemoryDc,
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
    }
}
