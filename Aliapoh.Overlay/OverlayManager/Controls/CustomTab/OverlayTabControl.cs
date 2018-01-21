using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Aliapoh.Overlay
{
    [System.ComponentModel.DesignerCategory("CODE")]
    public class OverlayTabControl : TabControl
    {
        private bool TabCollapsed;
        private System.ComponentModel.IContainer components = null;
        private StringFormat SB;
        private Font TabFont;
        private Font TabSelectedFont;
        public Panel TabHeaders;

        public OverlayTabControl()
        {
            SB = new StringFormat(StringFormatFlags.NoWrap)
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            TabFont = new Font("Microsoft Neogothic", 11f, FontStyle.Regular);
            TabSelectedFont = new Font("Microsoft Neogothic", 11f, FontStyle.Bold);

            TabCollapsed = false;
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ContainerControl, true);
            DoubleBuffered = true;

            Alignment = TabAlignment.Top;
            ItemSize = new Size(40, 32);
            SizeMode = TabSizeMode.Normal;
            Padding = new Point(32, 32);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.FromArgb(32, 32, 32));
            for(var i = 0; i < TabCount; i++)
            {
                var trect = GetTabRect(i);
                var top = trect.Top;
                var left = trect.Left;
                var width = trect.Width;
                var height = trect.Height;

                var highlight = new Rectangle(left, top, width, height);
                var mainText = new Rectangle(left + 10, top, width - 20, 32);

                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                if (SelectedIndex != -1)
                {
                    if (SelectedIndex == i)
                    {
                        e.Graphics.FillRectangle(Brushes.White, highlight);
                        e.Graphics.DrawString(TabPages[i].Text, TabFont, Brushes.Black, mainText, SB);
                    }
                    else
                    {
                        e.Graphics.DrawString(TabPages[i].Text, TabFont, Brushes.White, mainText, SB);
                    }
                }
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.Graphics.Clear(Color.FromArgb(32, 32, 32));
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 4904)
            {
                var rc = (RECT)m.GetLParam(typeof(RECT));
                rc.left -= 2;
                rc.right += 2;
                rc.top -= 2;
                rc.bottom += 2;
                Marshal.StructureToPtr(rc, m.LParam, true);
            }
            base.WndProc(ref m);
        }
    }
}
