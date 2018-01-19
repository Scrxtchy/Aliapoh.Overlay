using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using Aliapoh.Overlay.OverlayManager;
using System.Globalization;
using System.Reflection;

namespace Aliapoh.Overlay
{
    public static class LanguageLoader
    {
        public static string CurrentCulture { get; set; }
        public static JObject JSON { get; set; }
        public static Dictionary<string, byte[]> LanguageFiles { get; private set; }
        public static void Initialize()
        {
            CurrentCulture = CultureInfo.CurrentCulture.Name;
            LanguageFiles = new Dictionary<string, byte[]>()
            {
                { "ko-KR", Properties.Resources.LanguageFile_ko_KR }
            };
            if (LanguageFiles.ContainsKey(CurrentCulture))
            {
                var lang = Encoding.UTF8.GetString(LanguageFiles[CurrentCulture]);
                lang = lang.Trim();
                JSON = JObject.Parse(lang, new JsonLoadSettings
                { LineInfoHandling = LineInfoHandling.Ignore, CommentHandling = CommentHandling.Ignore });
            }
        }

        public static void LanguagePatch(Control ctrl)
        {
            if (!LanguageFiles.ContainsKey(CurrentCulture)) return;

            var bind = BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic;
            var flag = "";
            
            if (typeof(OverlayConfig) == ctrl.GetType())
                flag = "OverlayConfig";
            else if (typeof(OverlayController) == ctrl.GetType())
                flag = "OverlayController";
            else if (typeof(NewOverlayDialog) == ctrl.GetType())
                flag = "NewOverlayDialog";

            foreach(JProperty i in JSON[flag])
            {
                if (i.Value != null)
                {
                    if (ctrl.Controls.Find(i.Name, true).Length > 0)
                    {
                        ctrl.Controls.Find(i.Name, true)[0].Text = i.Value.Value<string>();
                    }
                }
            }

            foreach(FieldInfo field in ctrl.GetType().GetFields(bind))
            {
                Debug.WriteLine(field.Name + " find...");
                foreach (JProperty i in JSON["Strings"])
                {
                    Debug.WriteLine("Setting Value " + field.Name + "(" + field.FieldType + ") to " + i.Name);
                    if (field.FieldType == typeof(string) && field.Name == i.Name)
                    {
                        ctrl.GetType().GetField(field.Name, bind).SetValue(ctrl, i.Value.ToString());
                    }
                }
            }

            ctrl.Refresh();
        }
    }
}