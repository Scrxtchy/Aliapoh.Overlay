using System;
using System.Runtime.InteropServices;

namespace Aliapoh.Overlays
{
    internal class NativeMethods
    {
        public const int GWL_EXSTYLE = -20;
        public const int WS_EX_TRANSPARENT = 0x00000020;
        public const int WS_EX_TOOLWINDOW = 0x00000080;

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

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

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr", SetLastError = true)]
        public static extern IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("kernel32.dll", EntryPoint = "SetLastError")]
        public static extern void SetLastError(int dwErrorCode);

        private static int ToIntPtr32(IntPtr intPtr)
        {
            return unchecked((int)intPtr.ToInt64());
        }

        public static IntPtr SetWindowLongA(IntPtr hWnd, int nIndex, IntPtr dwNewLong)
        {
            int error = 0;
            IntPtr result = IntPtr.Zero;

            SetLastError(0);

            if (IntPtr.Size == 4)
            {
                IntPtr result32 = SetWindowLong(hWnd, (IntPtr)nIndex, dwNewLong);
                error = Marshal.GetLastWin32Error();
                result = result32;
            }
            else
            {
                result = SetWindowLongPtr(hWnd, nIndex, dwNewLong);
                error = Marshal.GetLastWin32Error();
            }

            if ((result == IntPtr.Zero) && (error != 0))
            {
                throw new System.ComponentModel.Win32Exception(error);
            }

            return result;
        }

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
