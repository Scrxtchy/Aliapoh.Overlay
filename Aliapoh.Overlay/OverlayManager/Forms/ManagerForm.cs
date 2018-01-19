using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aliapoh.Overlay.OverlayManager
{
    public partial class ManagerForm : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        public ManagerForm()
        {
            InitializeComponent();
            SetForegroundWindow(Handle);
        }
    }
}
