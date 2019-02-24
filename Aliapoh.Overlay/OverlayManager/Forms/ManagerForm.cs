using System;
using System.Windows.Forms;

namespace Aliapoh.Overlay.OverlayManager
{
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();
            NativeMethods.SetForegroundWindow(Handle);

            TopMost = true;
        }

        protected override void OnLoad(EventArgs e)
        {
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

            Left = workingArea.Width / 2 - (Width / 2);
            Top = workingArea.Height / 2 - (Height / 2);
        }
    }
}
