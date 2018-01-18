using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Aliapoh.Overlay.GlobalHook
{
    /**
     * Code from OverlayPlugin KeyboardHook.cs
     */
    public sealed class KeyboardHook : IDisposable
    {
        public event EventHandler<KeyPressedEventArgs> KeyPressed;

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private int CurrentID { get; set; }
        private Window Window = new Window();

        public KeyboardHook()
        {
            Window.KeyPressed += Window_KeyPressed;
        }

        public void RegisterHotKey(ModifierKeys mod, Keys key)
        {
            CurrentID++;

            if (!RegisterHotKey(Window.Handle, CurrentID, (uint)mod, (uint)key))
                throw new InvalidOperationException("Couldn’t register the hot key.");
        }

        private void Window_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            KeyPressed?.Invoke(this, e);
        }

        public void Dispose()
        {
            for (var i = CurrentID; i > 0; i--)
            {
                UnregisterHotKey(Window.Handle, i);
            }
            Window.Dispose();
        }
    }
}
