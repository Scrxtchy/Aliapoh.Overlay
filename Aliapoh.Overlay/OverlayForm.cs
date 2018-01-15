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
        public ChromiumWebBrowser Overlay;
        public BrowserProcessHandler browserHandler;
        public Bitmap ScreenShot;

        public OverlayForm()
        {
            TopMost = true;
            Debug.WriteLine("Overlay Load");
            InitializeComponent();
            OverlayInit(browserHandler = new BrowserProcessHandler());
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
            
            Overlay = new ChromiumWebBrowser("http://amethyst.ffxiv.io/", browser);
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

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            try
            {
                Overlay.Size = new Size(Width, Height);
            }
            catch { }
        }

        private void Overlay_BrowserInitialized(object sender, EventArgs e)
        {
            Overlay.Load("http://amethyst.ffxiv.io/");
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg)
            {
                case 0x201:
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point e = this.PointToClient(screenPoint);
                        Debug.WriteLine("Fired OnMouseDown");
                        Overlay.GetBrowser().GetHost().SendMouseClickEvent(e.X, e.Y, MouseButtonType.Left, false, 1, CefEventFlags.None);
                        return;
                    }
                case 0x202:
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point e = this.PointToClient(screenPoint);
                        Debug.WriteLine("Fired OnMouseUp");
                        Overlay.GetBrowser().GetHost().SendMouseClickEvent(e.X, e.Y, MouseButtonType.Left, true, 1, CefEventFlags.None);
                        return;
                    }
                case 0x0084/*NCHITTEST*/ :
                    {
                        base.WndProc(ref m);

                        if ((int)m.Result == 0x01/*HTCLIENT*/)
                        {
                            Point screenPoint = new Point(m.LParam.ToInt32());
                            Point clientPoint = this.PointToClient(screenPoint);
                            if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                            {
                                if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                    m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
                                else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                    m.Result = (IntPtr)12/*HTTOP*/ ;
                                else
                                    m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
                            }
                            else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                            {
                                if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                    m.Result = (IntPtr)10/*HTLEFT*/ ;
                                else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                    m.Result = (IntPtr)2/*HTCAPTION*/ ;
                                else
                                    m.Result = (IntPtr)11/*HTRIGHT*/ ;
                            }
                            else
                            {
                                if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                    m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
                                else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                    m.Result = (IntPtr)15/*HTBOTTOM*/ ;
                                else
                                    m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
                            }
                        }
                        return;
                    }
            }

            base.WndProc(ref m);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var style = base.CreateParams;
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

    public enum WM : uint
    {
        KEYDOWN = 0x100,
        KEYUP = 0x101,
        CHAR = 0x102,
        SYSKEYDOWN = 0x104,
        SYSKEYUP = 0x105,
        SYSCHAR = 0x106,
        IME_CHAR = 0x286,
    }

    internal class NativeMethods
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll", SetLastError = true)]
        public extern static bool UpdateLayeredWindow(IntPtr handle, IntPtr hdcDst, ref PointStruct pptDst,
            ref SizeStruct pSize, IntPtr hDc, ref PointStruct pptSrc, int crKey, ref BlendFunctionStruct pBlend, int dwFlags);

        [DllImport("user32.dll", ExactSpelling = false, SetLastError = true)]
        public extern static long SetWindowLong(IntPtr handle, int index, long dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        public extern static IntPtr GetDC(IntPtr handle);

        [DllImport("user32.dll", SetLastError = false)]
        public extern static int ReleaseDC(IntPtr hWnd, IntPtr hDc);

        [DllImport("gdi32.dll", SetLastError = true)]
        public extern static IntPtr CreateCompatibleDC(IntPtr hDc);

        [DllImport("gdi32.dll", SetLastError = true)]
        public extern static bool DeleteDC(IntPtr hDc);

        [DllImport("gdi32.dll", SetLastError = false)]
        public extern static IntPtr SelectObject(IntPtr hDc, IntPtr hgdiObject);

        [DllImport("gdi32.dll", SetLastError = true)]
        public extern static bool DeleteObject(IntPtr hgdiObject);

        public struct PointStruct
        {
            public int X;
            public int Y;
        }

        public struct SizeStruct
        {
            public int X;
            public int Y;
        }

        public struct BlendFunctionStruct
        {
            public byte BlendOp;
            public byte BlendFlags;
            public byte SourceConstantAlpha;
            public byte AlphaFormat;
        }
    }
}
