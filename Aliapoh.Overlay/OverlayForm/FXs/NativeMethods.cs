using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Aliapoh.Overlay
{
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
