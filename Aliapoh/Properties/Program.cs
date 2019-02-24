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
            foreach (var i in Directory.GetFiles(Environment.CurrentDirectory))
            {
                if (i.ToLower().Contains("cefsharp"))
                    File.Delete(i);
            }
            if (Environment.Is64BitProcess)
                CEFDIR = GlobalVar.DIRDICT["CEFX64"];
            else
                CEFDIR = GlobalVar.DIRDICT["CEFX86"];
            FxLoader.Initialize();
        }
    }
}
