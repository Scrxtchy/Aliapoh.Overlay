using System;
using System.IO;
using System.Windows.Forms;

namespace Aliapoh.Overlay
{
    internal static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            if (Environment.Is64BitProcess)
                Loader.CEFDIR = Loader.DIRDICT["CEFX64"];
            else
                Loader.APPDIR = Loader.DIRDICT["CEFX86"];

            Loader.Initialize();
            Application.Run(new OverlayManager.ManagerForm());
        }
    }
}
