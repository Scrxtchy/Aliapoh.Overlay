using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aliapoh.Overlay
{
    static class Program
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
                CEFDIR = Loader.DIRDICT["CEFX64"];
            else
                CEFDIR = Loader.DIRDICT["CEFX86"];
            Loader.Initialize();
            Application.Run(new OverlayManager.ManagerForm());
        }

        public static string APPDIR = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Aliapoh");
        public static string CEFDIR = "";
    }
}
