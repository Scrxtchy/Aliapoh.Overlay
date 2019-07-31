using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Aliapoh.Overlays.Extender
{
    internal class FontMetricsImpl : FontMetrics
    {
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
        public static extern bool GetTextMetrics(IntPtr hdc, out TEXTMETRIC lptm);
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
        public static extern bool DeleteObject(IntPtr hdc);

        private TEXTMETRIC metrics;
        public override int Height { get { return this.metrics.tmHeight; } }
        public override int Ascent { get { return this.metrics.tmAscent; } }
        public override int Descent { get { return this.metrics.tmDescent; } }
        public override int InternalLeading { get { return this.metrics.tmInternalLeading; } }
        public override int ExternalLeading { get { return this.metrics.tmExternalLeading; } }
        public override int AverageCharacterWidth { get { return this.metrics.tmAveCharWidth; } }
        public override int MaximumCharacterWidth { get { return this.metrics.tmMaxCharWidth; } }
        public override int Weight { get { return this.metrics.tmWeight; } }
        public override int Overhang { get { return this.metrics.tmOverhang; } }
        public override int DigitizedAspectX { get { return this.metrics.tmDigitizedAspectX; } }
        public override int DigitizedAspectY { get { return this.metrics.tmDigitizedAspectY; } }

        [StructLayout(LayoutKind.Sequential)]
        public struct TEXTMETRIC
        {
            public int tmHeight;
            public int tmAscent;
            public int tmDescent;
            public int tmInternalLeading;
            public int tmExternalLeading;
            public int tmAveCharWidth;
            public int tmMaxCharWidth;
            public int tmWeight;
            public int tmOverhang;
            public int tmDigitizedAspectX;
            public int tmDigitizedAspectY;
            public char tmFirstChar;
            public char tmLastChar;
            public char tmDefaultChar;
            public char tmBreakChar;
            public byte tmItalic;
            public byte tmUnderlined;
            public byte tmStruckOut;
            public byte tmPitchAndFamily;
            public byte tmCharSet;
        }

        private TEXTMETRIC GenerateTextMetrics(Graphics graphics, Font font)
        {
            IntPtr hDC = IntPtr.Zero;
            TEXTMETRIC textMetric;
            IntPtr hFont = IntPtr.Zero;
            try
            {
                hDC = graphics.GetHdc();
                hFont = font.ToHfont();
                IntPtr hFontDefault = SelectObject(hDC, hFont);
                bool result = GetTextMetrics(hDC, out textMetric);
                SelectObject(hDC, hFontDefault);
            }
            finally
            {
                if (hFont != IntPtr.Zero) DeleteObject(hFont);
                if (hDC != IntPtr.Zero) graphics.ReleaseHdc(hDC);
            }
            return textMetric;
        }

        private FontMetricsImpl(Graphics graphics, Font font)
        {
            this.metrics = this.GenerateTextMetrics(graphics, font);
        }

        public static FontMetrics GetFontMetrics(Graphics graphics, Font font)
        {
            return new FontMetricsImpl(graphics, font);
        }
    }
}
