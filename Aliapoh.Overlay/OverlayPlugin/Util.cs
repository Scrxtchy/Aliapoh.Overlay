using Aliapoh.Overlays;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aliapoh.OverlayPlugin
{
    internal static class Util
    {
        public static string CreateJsonSafeString(string str)
        {
            return str
                .Replace("\"", "\\\"")
                .Replace("'", "\\'")
                .Replace("\r", "\\r")
                .Replace("\n", "\\n")
                .Replace("\t", "\\t");
        }

        public static string ReplaceNaNString(string str, string replace)
        {
            return str.Replace(double.NaN.ToString(), replace);
        }

        public static bool IsOnScreen(Form form)
        {
            var screens = Screen.AllScreens;
            foreach (Screen screen in screens)
            {
                var formRectangle = new Rectangle(form.Left, form.Top, form.Width, form.Height);

                // 少しでもスクリーンと被っていればセーフ
                if (screen.WorkingArea.IntersectsWith(formRectangle))
                {
                    return true;
                }
            }

            return false;
        }

        public static void HidePreview(Form form)
        {
            int ex = NativeMethods.GetWindowLong(form.Handle, NativeMethods.GWL_EXSTYLE);
            ex |= NativeMethods.WS_EX_TOOLWINDOW;
            NativeMethods.SetWindowLongA(form.Handle, NativeMethods.GWL_EXSTYLE, (IntPtr)ex);
        }

        public static string GetHotkeyString(Keys modifier, Keys key, string defaultText = "")
        {
            StringBuilder sbKeys = new StringBuilder();
            if ((modifier & Keys.Shift) == Keys.Shift)
            {
                sbKeys.Append("Shift + ");
            }
            if ((modifier & Keys.Control) == Keys.Control)
            {
                sbKeys.Append("Ctrl + ");
            }
            if ((modifier & Keys.Alt) == Keys.Alt)
            {
                sbKeys.Append("Alt + ");
            }
            if ((modifier & Keys.LWin) == Keys.LWin || (modifier & Keys.RWin) == Keys.RWin)
            {
                sbKeys.Append("Win + ");
            }
            sbKeys.Append(Enum.ToObject(typeof(Keys), key).ToString());
            return sbKeys.ToString();
        }

        public static Keys RemoveModifiers(Keys keyCode, Keys modifiers)
        {
            var key = keyCode;
            var modifierList = new List<Keys>() { Keys.ControlKey, Keys.LControlKey, Keys.Alt, Keys.ShiftKey, Keys.Shift, Keys.LShiftKey, Keys.RShiftKey, Keys.Control, Keys.LWin, Keys.RWin };
            foreach (var mod in modifierList)
            {
                if (key.HasFlag(mod))
                {
                    if (key == mod)
                        key &= ~mod;
                }
            }
            return key;
        }
    }
}
