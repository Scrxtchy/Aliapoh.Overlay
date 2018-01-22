using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aliapoh.Overlay.Initializer
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
            InitializeComponent();
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
            OverlayForm.SetBitmap(bg, this);
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
    }
}
