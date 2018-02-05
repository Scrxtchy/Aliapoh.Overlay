using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OverlayTest
{
    public partial class Form1 : Form
    {
        private CefSharp.OffScreen.ChromiumWebBrowser browser;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            browser = new CefSharp.OffScreen.ChromiumWebBrowser("https://amethyst.ffxiv.io/unstable/");
            browser.OnPaint += Browser_OnPaint;
            browser.BrowserInitialized += Browser_BrowserInitialized;
            browser.Size = Size;
            rect();
        }
        private void Browser_BrowserInitialized(object sender, EventArgs e)
        {
            browser.GetBrowser().GetHost().ShowDevTools();
        }
        private void Browser_OnPaint(object sender, CefSharp.OnPaintEventArgs e)
        {
            var b = (CefSharp.OffScreen.ChromiumWebBrowser)sender;
            if(b.Bitmap != null)
            {
                var bmp = (Bitmap)b.Bitmap.Clone();
                SetBitmap(bmp, this);
            }
        }
        private void rect()
        {
            var rect = new Rectangle(0, 0, Width, Height);
            var bmp = new Bitmap(Width, Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                g.DrawRectangle(new Pen(Brushes.White, 2f), new Rectangle(1, 1, Width - 2, Height - 2));
            }
            SetBitmap(bmp, this);
        }
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
        public static void SetBitmap(Bitmap bitmap, Form frm)
        {
            IntPtr screenDc = NativeMethods.GetDC(IntPtr.Zero);
            IntPtr compatibleMemoryDc = NativeMethods.CreateCompatibleDC(screenDc);
            IntPtr hgdiBitmap = IntPtr.Zero;
            IntPtr hgdiOldBitmap = IntPtr.Zero;

            try
            {
                try
                { hgdiBitmap = bitmap.GetHbitmap(Color.FromArgb(0)); } catch { return; }
                hgdiOldBitmap = NativeMethods.SelectObject(compatibleMemoryDc, hgdiBitmap);
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
                    NativeMethods.UpdateLayeredWindow(frm.Handle, screenDc, ref topPoint, ref size, compatibleMemoryDc, ref sourcePoint, 0, ref blend, 2 /* ULW_ALPHA */);
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
    internal class NativeMethods
    {
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        [DllImport("user32.dll", SetLastError = true)]
        public extern static bool UpdateLayeredWindow(IntPtr handle, IntPtr hdcDst, ref PointStruct pptDst, ref SizeStruct pSize, IntPtr hDc, ref PointStruct pptSrc, int crKey, ref BlendFunctionStruct pBlend, int dwFlags);
        [DllImport("user32.dll", ExactSpelling = false, SetLastError = true)]
        public extern static IntPtr SetWindowLong(IntPtr handle, IntPtr index, IntPtr dwNewLong);
        [DllImport("user32.dll", ExactSpelling = false, SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll", SetLastError = true)]
        public extern static IntPtr GetDC(IntPtr handle);
        [DllImport("user32.dll", SetLastError = false)]
        public extern static IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDc);
        [DllImport("gdi32.dll", SetLastError = true)]
        public extern static IntPtr CreateCompatibleDC(IntPtr hDc);
        [DllImport("gdi32.dll", SetLastError = true)]
        public extern static bool DeleteDC(IntPtr hDc);
        [DllImport("gdi32.dll", SetLastError = false)]
        public extern static IntPtr SelectObject(IntPtr hDc, IntPtr hgdiObject);
        [DllImport("gdi32.dll", SetLastError = true)]
        public extern static bool DeleteObject(IntPtr hgdiObject);
        public struct PointStruct { public int X; public int Y; }
        public struct SizeStruct { public int X; public int Y; }
        public struct BlendFunctionStruct { public byte BlendOp; public byte BlendFlags; public byte SourceConstantAlpha; public byte AlphaFormat; }
    }
}