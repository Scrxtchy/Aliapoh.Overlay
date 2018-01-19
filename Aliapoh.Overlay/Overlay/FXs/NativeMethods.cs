using System;
using System.Runtime.InteropServices;

namespace Aliapoh.Overlay
{
    internal class NativeMethods
    {
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll", SetLastError = true)]
        public extern static bool UpdateLayeredWindow(IntPtr handle, IntPtr hdcDst, ref PointStruct pptDst,
            ref SizeStruct pSize, IntPtr hDc, ref PointStruct pptSrc, int crKey, ref BlendFunctionStruct pBlend, int dwFlags);

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

        [DllImport("user32.dll")]
        public static extern short GetKeyState(int nVirtKey);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hwnd, int message, IntPtr wParam, IntPtr lParam);

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
