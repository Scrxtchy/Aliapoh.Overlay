using Aliapoh.Overlay.Logger;
using Aliapoh.Overlay.OverlayManager;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace Aliapoh.Overlay
{
    internal class ScreenshotRenderer
    {
        public static void SaveScreenshot(Bitmap bitmap)
        {
            var Margin = SettingManager.GlobalSetting.ScreenshotMargin;
            if (SettingManager.GlobalSetting.AutoClipping)
                bitmap = AutoClipping(bitmap);

            using (bitmap)
                using (var src = new Bitmap(bitmap.Width + Margin * 2, bitmap.Height + Margin * 2, PixelFormat.Format32bppArgb))
                {
                    if (!string.IsNullOrWhiteSpace(SettingManager.GlobalSetting.BackgroundImagePath)
                        && File.Exists(SettingManager.GlobalSetting.BackgroundImagePath))
                    {
                        try
                        {
                            DrawBackground(src, SettingManager.GlobalSetting.BackgroundImagePath);
                        }
                        catch (Exception ex)
                        {
                            LOG.Logger.Log(LogLevel.Error, "Aliapoh Overlay Can't Take Screenshot: {0}", ex.ToString());
                        }
                    }

                    using (var g = Graphics.FromImage(src))
                    {
                        g.CompositingMode = CompositingMode.SourceOver;
                        g.DrawImageUnscaled(bitmap, Margin, Margin);
                    }

                    Directory.CreateDirectory(SettingManager.GlobalSetting.ScreenshotSavePath);

                    src.Save(
                        Path.Combine(SettingManager.GlobalSetting.ScreenshotSavePath,
                        DateTime.Now.ToString("'Screenshot_'yyyy-MM-dd_HH-mm-ss.fff'.png'")),
                        ImageFormat.Png);
                }
        }

        private static Bitmap AutoClipping(Bitmap bitmap)
        {
            var newHeight = bitmap.Height;

            BitmapData bmpData = null;
            try
            {
                bmpData = bitmap.LockBits(new Rectangle(Point.Empty, bitmap.Size), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

                var strideBuffer = new byte[bmpData.Stride];

                int x;
                bool skip;
                while (--newHeight >= 1)
                {
                    Marshal.Copy(bmpData.Scan0 + bmpData.Stride * newHeight, strideBuffer, 0, bmpData.Stride);

                    skip = true;
                    for (x = 0; x < bmpData.Width; ++x)
                    {
                        if (strideBuffer[x * 4 + 3] != 0)
                        {
                            skip = false;
                            break;
                        }
                    }

                    if (!skip)
                        break;
                }
            }
            finally
            {
                if (bmpData != null)
                    bitmap.UnlockBits(bmpData);
            }

            var newBitmap = new Bitmap(bitmap.Width, newHeight, PixelFormat.Format32bppArgb);
            using (var graphics = Graphics.FromImage(newBitmap))
            {
                graphics.DrawImage(
                    bitmap,
                    new Rectangle(Point.Empty, newBitmap.Size),
                    new Rectangle(0, 0, bitmap.Width, newHeight),
                    GraphicsUnit.Pixel);
            }

            bitmap.Dispose();

            return newBitmap;
        }

        private static void DrawBackground(Bitmap bmp, string path)
        {
            var mode = (ScreenshotBackgroundMode)SettingManager.GlobalSetting.BackgroundFillMode;

            if (!File.Exists(path)) return;
            if (mode == ScreenshotBackgroundMode.Hide || mode == ScreenshotBackgroundMode.None) return;

            using (var bg = Image.FromFile(path))
            {
                using (var g = Graphics.FromImage(bmp))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    switch (mode)
                    {
                        case ScreenshotBackgroundMode.Normal:
                            g.DrawImageUnscaled(bg, 0, 0);
                            return;
                        case ScreenshotBackgroundMode.Center:
                            g.DrawImageUnscaled(bg, (bmp.Width - bg.Width) / 2, (bmp.Height - bg.Height) / 2);
                            return;
                        case ScreenshotBackgroundMode.Fill:
                            g.DrawImage(bg,
                                new Rectangle(Point.Empty, bmp.Size),
                                new Rectangle(Point.Empty, bg.Size),
                                GraphicsUnit.Pixel);
                            return;
                        case ScreenshotBackgroundMode.Uniform:
                        case ScreenshotBackgroundMode.UniformToFill:
                            {
                                var scaleX = (double)bmp.Width / bg.Width;
                                var scaleY = (double)bmp.Height / bg.Height;
                                var scale = mode == ScreenshotBackgroundMode.Uniform ?
                                            Math.Min(scaleX, scaleY) :
                                            Math.Max(scaleX, scaleY);

                                var bg_w = (int)Math.Floor(bg.Width * scale);
                                var bg_h = (int)Math.Floor(bg.Height * scale);

                                var ss_x = (int)Math.Ceiling((bmp.Width - bg_w) / 2d);
                                var ss_y = (int)Math.Ceiling((bmp.Height - bg_h) / 2d);

                                g.DrawImage(
                                    bg,
                                    new Rectangle(ss_x, ss_y, bg_w, bg_h),
                                    new Rectangle(0, 0, bg.Width, bg.Height),
                                    GraphicsUnit.Pixel);
                            }
                            return;
                    }
                }
            }
        }
    }
}
