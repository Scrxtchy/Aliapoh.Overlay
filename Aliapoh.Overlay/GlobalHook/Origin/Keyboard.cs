using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliapoh.Overlay.GlobalHook
{
    // TODO
    public class Keyboard : IDisposable
    {
        public delegate int KeyBoardHookProc(int keys, int wparam, ref KeyHook lparam);
        public const int WH_KEYBOARD_LL = 0x0D;

        public void Dispose()
        {

        }
    }
}
