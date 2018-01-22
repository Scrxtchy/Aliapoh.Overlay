using System;
using System.IO;
using System.Windows.Forms;

namespace Aliapoh
{
    static class Program
    {
        public static string APPDIR = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Aliapoh");
        public static string CEFDIR = "";
        public static bool fromMain = false;

        [STAThread]
        static void Main()
        {
            fromMain = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Environment.Is64BitProcess)
                CEFDIR = Loader.DIRDICT["CEFX64"];
            else
                CEFDIR = Loader.DIRDICT["CEFX86"];
            Loader.Initialize();
        }
    }
}
