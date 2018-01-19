using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Aliapoh.Overlay.OverlayManager;

namespace Aliapoh.Overlay
{
    [System.ComponentModel.DesignerCategory("CODE")]
    public class OverlayManageTabControl : TabControl
    {
        private bool TabCollapsed { get; set; }
        private System.ComponentModel.IContainer components = null;
        private StringFormat SB;
        private Font TabFont;
        private Font TabSelectedFont;
        public Panel TabHeaders;

        public OverlayManageTabControl()
        {
            SB = new StringFormat(StringFormatFlags.NoWrap)
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            };

            TabFont = new Font("Microsoft Neogothic", 11f, FontStyle.Regular);
            TabSelectedFont = new Font("Microsoft Neogothic", 11f, FontStyle.Bold);

            TabCollapsed = false;
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ContainerControl, true);
            DoubleBuffered = true;

            Alignment = TabAlignment.Left;
            ItemSize = new Size(48, 220);
            SizeMode = TabSizeMode.Fixed;
            Padding = new Point(32, 32);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            if(TabPages.Count == 0)
            {

            }
        }

        new public TabPageCollection TabPages
        {
            get
            {
                return base.TabPages;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var rrect = new Rectangle(2, 2, Width - 4, Height - 4);

            e.Graphics.Clear(Color.FromArgb(255, 255, 255));
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(224, 224, 224)), rrect);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            if (TabCount == 0)
            {
                var RSB = new StringFormat(StringFormatFlags.NoWrap)
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                var EmptyFont = new Font("Microsoft Neogothic", 18f, FontStyle.Bold);

                e.Graphics.DrawString(OverlayController.OverlayEmpty, EmptyFont, Brushes.Black, rrect, RSB);
            }
            else
            {
                for (var i = 0; i < TabCount; i++)
                {
                    var trect = GetTabRect(i);
                    var top = trect.Top;
                    var left = trect.Left;
                    var width = trect.Width;
                    var height = trect.Height;

                    var highlight = new Rectangle(left + 2, top + 2, width - 4, height - 4);
                    var mainText = new Rectangle(left + 10, top, width - 20, 32);
                    
                    if (SelectedIndex != -1)
                    {
                        if (SelectedIndex == i)
                        {
                            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 148, 255)), highlight);
                            e.Graphics.DrawString(TabPages[i].Text, TabSelectedFont, Brushes.White, mainText, SB);
                        }
                        else
                        {
                            e.Graphics.DrawString(TabPages[i].Text, TabFont, Brushes.Gray, mainText, SB);
                        }
                    }
                }
            }
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
