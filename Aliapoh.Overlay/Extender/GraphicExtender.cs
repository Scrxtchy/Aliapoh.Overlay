﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Aliapoh.Overlays.Extender
{
    static class GraphicExtender
    {
        public static void Clear(this Graphics gp, int a, int r, int g, int b)
        {
            gp.Clear(Color.FromArgb(a, r, g, b));
        }

        public static void Clear(this Graphics gp, int r, int g, int b)
        {
            gp.Clear(Color.FromArgb(r, g, b));
        }

        private static GraphicsPath GenerateRoundedRectangle(this Graphics graphics, RectangleF rectangle, float radius, RectangleEdgeFilter filter)
        {
            float diameter;
            GraphicsPath path = new GraphicsPath();
            if (radius <= 0.0F || filter == RectangleEdgeFilter.None)
            {
                path.AddRectangle(rectangle);
                path.CloseFigure();
                return path;
            }
            else
            {
                if (radius >= (Math.Min(rectangle.Width, rectangle.Height)) / 2.0)
                    return graphics.GenerateCapsule(rectangle);
                diameter = radius * 2.0F;
                SizeF sizeF = new SizeF(diameter, diameter);
                RectangleF arc = new RectangleF(rectangle.Location, sizeF);
                if ((RectangleEdgeFilter.TopLeft & filter) == RectangleEdgeFilter.TopLeft)
                    path.AddArc(arc, 180, 90);
                else
                {
                    path.AddLine(arc.X, arc.Y + arc.Height, arc.X, arc.Y);
                    path.AddLine(arc.X, arc.Y, arc.X + arc.Width, arc.Y);
                }
                arc.X = rectangle.Right - diameter;
                if ((RectangleEdgeFilter.TopRight & filter) == RectangleEdgeFilter.TopRight)
                    path.AddArc(arc, 270, 90);
                else
                {
                    path.AddLine(arc.X, arc.Y, arc.X + arc.Width, arc.Y);
                    path.AddLine(arc.X + arc.Width, arc.Y + arc.Height, arc.X + arc.Width, arc.Y);
                }
                arc.Y = rectangle.Bottom - diameter;
                if ((RectangleEdgeFilter.BottomRight & filter) == RectangleEdgeFilter.BottomRight)
                    path.AddArc(arc, 0, 90);
                else
                {
                    path.AddLine(arc.X + arc.Width, arc.Y, arc.X + arc.Width, arc.Y + arc.Height);
                    path.AddLine(arc.X, arc.Y + arc.Height, arc.X + arc.Width, arc.Y + arc.Height);
                }
                arc.X = rectangle.Left;
                if ((RectangleEdgeFilter.BottomLeft & filter) == RectangleEdgeFilter.BottomLeft)
                    path.AddArc(arc, 90, 90);
                else
                {
                    path.AddLine(arc.X + arc.Width, arc.Y + arc.Height, arc.X, arc.Y + arc.Height);
                    path.AddLine(arc.X, arc.Y + arc.Height, arc.X, arc.Y);
                }
                path.CloseFigure();
            }
            return path;
        }

        private static GraphicsPath GenerateCapsule(this Graphics graphics, RectangleF rectangle)
        {
            float diameter;
            RectangleF arc;
            GraphicsPath path = new GraphicsPath();
            try
            {
                if (rectangle.Width > rectangle.Height)
                {
                    diameter = rectangle.Height;
                    SizeF sizeF = new SizeF(diameter, diameter);
                    arc = new RectangleF(rectangle.Location, sizeF);
                    path.AddArc(arc, 90, 180);
                    arc.X = rectangle.Right - diameter;
                    path.AddArc(arc, 270, 180);
                }
                else if (rectangle.Width < rectangle.Height)
                {
                    diameter = rectangle.Width;
                    SizeF sizeF = new SizeF(diameter, diameter);
                    arc = new RectangleF(rectangle.Location, sizeF);
                    path.AddArc(arc, 180, 180);
                    arc.Y = rectangle.Bottom - diameter;
                    path.AddArc(arc, 0, 180);
                }
                else path.AddEllipse(rectangle);
            }
            catch { path.AddEllipse(rectangle); }
            finally { path.CloseFigure(); }
            return path;
        }

        public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, float x, float y, float width, float height, float radius, RectangleEdgeFilter filter)
        {
            RectangleF rectangle = new RectangleF(x, y, width, height);
            GraphicsPath path = graphics.GenerateRoundedRectangle(rectangle, radius, filter);
            SmoothingMode old = graphics.SmoothingMode;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.DrawPath(pen, path);
            graphics.SmoothingMode = old;
        }

        public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, float x, float y, float width, float height, float radius)
        {
            graphics.DrawRoundedRectangle(pen, x, y, width, height, radius, RectangleEdgeFilter.All);
        }

        public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, int x, int y, int width, int height, int radius)
        {
            graphics.DrawRoundedRectangle(pen, Convert.ToSingle(x), Convert.ToSingle(y), Convert.ToSingle(width), Convert.ToSingle(height), Convert.ToSingle(radius));
        }

        public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, Rectangle rectangle, int radius, RectangleEdgeFilter filter)
        {
            graphics.DrawRoundedRectangle(pen, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, radius, filter);
        }

        public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, Rectangle rectangle, int radius)
        {
            graphics.DrawRoundedRectangle(pen, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, radius, RectangleEdgeFilter.All);
        }

        public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, RectangleF rectangle, int radius, RectangleEdgeFilter filter)
        {
            graphics.DrawRoundedRectangle(pen, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, radius, filter);
        }

        public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, RectangleF rectangle, int radius)
        {
            graphics.DrawRoundedRectangle(pen, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, radius, RectangleEdgeFilter.All);
        }

        public static void FillRoundedRectangle(this Graphics graphics, Brush brush, float x, float y, float width, float height, float radius, RectangleEdgeFilter filter)
        {
            RectangleF rectangle = new RectangleF(x, y, width, height);
            GraphicsPath path = graphics.GenerateRoundedRectangle(rectangle, radius, filter);
            SmoothingMode old = graphics.SmoothingMode;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.FillPath(brush, path);
            graphics.SmoothingMode = old;
        }

        public static void FillRoundedRectangle(this Graphics graphics, Brush brush, float x, float y, float width, float height, float radius)
        {
            graphics.FillRoundedRectangle(brush, x, y, width, height, radius, RectangleEdgeFilter.All);
        }

        public static void FillRoundedRectangle(this Graphics graphics, Brush brush, int x, int y, int width, int height, int radius)
        {
            graphics.FillRoundedRectangle(brush, Convert.ToSingle(x), Convert.ToSingle(y), Convert.ToSingle(width), Convert.ToSingle(height), Convert.ToSingle(radius));
        }

        public static void FillRoundedRectangle(this Graphics graphics, Brush brush, Rectangle rectangle, int radius, RectangleEdgeFilter filter)
        {
            graphics.FillRoundedRectangle(brush, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, radius, filter);
        }

        public static void FillRoundedRectangle(this Graphics graphics, Brush brush, Rectangle rectangle, int radius)
        {
            graphics.FillRoundedRectangle(brush, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, radius, RectangleEdgeFilter.All);
        }

        public static void FillRoundedRectangle(this Graphics graphics, Brush brush, RectangleF rectangle, int radius, RectangleEdgeFilter filter)
        {
            graphics.FillRoundedRectangle(brush, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, radius, filter);
        }

        public static void FillRoundedRectangle(this Graphics graphics, Brush brush, RectangleF rectangle, int radius)
        {
            graphics.FillRoundedRectangle(brush, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, radius, RectangleEdgeFilter.All);
        }

        public static FontMetrics GetFontMetrics(this Graphics graphics, Font font)
        {
            return FontMetricsImpl.GetFontMetrics(graphics, font);
        }
    }
}
