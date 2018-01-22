using Aliapoh.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Aliapoh.Forms
{
    public partial class LoaderForm : Form
    {
        private Bitmap Background = Properties.Resources.frmimg;
        private Rectangle RenderRect = new Rectangle(8, 108, 284, 86);
        private StringFormat SF = new StringFormat(StringFormatFlags.FitBlackBox)
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };

        private Font RenderFont = new Font("Microsoft Neogothic", 9F, FontStyle.Bold);

        public LoaderForm()
        {
            StartPosition = FormStartPosition.Manual;
            InitializeComponent();
            Load += LoaderForm_Load;
        }

        private void LoaderForm_Load(object sender, EventArgs e)
        {
            ShowInTaskbar = false;

            var primaryArea = Screen.PrimaryScreen.Bounds;
            var workingArea = Screen.PrimaryScreen.WorkingArea;

            var SamePoint = new Padding(0, 0, 0, 0);

            if (primaryArea.Left != workingArea.Left)
                SamePoint.Left = Math.Abs(primaryArea.Left - workingArea.Left);
            if (primaryArea.Top != workingArea.Top)
                SamePoint.Top = Math.Abs(primaryArea.Top - workingArea.Top);
            if (primaryArea.Bottom != workingArea.Bottom)
                SamePoint.Bottom = Math.Abs(primaryArea.Bottom - workingArea.Bottom);
            if (primaryArea.Right != workingArea.Right)
                SamePoint.Right = Math.Abs(primaryArea.Right - workingArea.Right);

            Left = primaryArea.Width - 300 - SamePoint.Right;
            Top = primaryArea.Height - 200 - SamePoint.Bottom;

            NativeMethods.SetForegroundWindow(Handle);
        }

        public void Render(string text)
        {
            Bitmap bg = Background.Clone() as Bitmap;
            using (Graphics g = Graphics.FromImage(bg))
            {
                g.DrawString(text, RenderFont, Brushes.Black, RenderRect, SF);
            }
            SetBitmap(bg, this);
            bg = null;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var style = base.CreateParams;
                style.ClassStyle |= 200; // NoCloseBtn
                style.ExStyle |= 0x8; // TopMost
                style.ExStyle |= 0x20; // Clickthru
                style.ExStyle |= 0x80000; // Layered
                style.ExStyle |= 0x8000000; // NoActive
                return style;
            }
        }

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
    }
}
