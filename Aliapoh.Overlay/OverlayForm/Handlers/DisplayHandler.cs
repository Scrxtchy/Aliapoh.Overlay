using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.Structs;
using System.Net;
using System.IO;
using System.Drawing;
using System.Diagnostics;

namespace Aliapoh.Overlay
{
    public class DisplayHandler : IDisplayHandler
    {
        public void OnAddressChanged(IWebBrowser browserControl, AddressChangedEventArgs addressChangedArgs)
        {

        }

        public bool OnAutoResize(IWebBrowser browserControl, IBrowser browser, CefSharp.Structs.Size newSize)
        {
            return true;
        }

        public bool OnConsoleMessage(IWebBrowser browserControl, ConsoleMessageEventArgs consoleMessageArgs)
        {
            return true;
        }

        public void OnFaviconUrlChange(IWebBrowser browserControl, IBrowser browser, IList<string> urls)
        {
            // TODO (it works?)
            var wc = new WebClient();
            var ptr = browserControl.GetBrowser().GetHost().GetWindowHandle();
            try
            {
                var bitmapico = wc.DownloadData(urls[0]);

                using (MemoryStream ms = new MemoryStream(bitmapico))
                {
                    var origin = Image.FromStream(ms);
                    var small = new Bitmap(16, 16);
                    var big = new Bitmap(32, 32);

                    using (Graphics g = Graphics.FromImage(small))
                    {
                        g.DrawImage(origin, new Rectangle(0, 0, 16, 16));
                    }

                    using (Graphics g = Graphics.FromImage(big))
                    {
                        g.DrawImage(origin, new Rectangle(0, 0, 32, 32));
                    }

                    NativeMethods.SendMessage(ptr, 0x80, 1, big.GetHicon());
                    NativeMethods.SendMessage(ptr, 0x80, 0, small.GetHicon());
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void OnFullscreenModeChange(IWebBrowser browserControl, IBrowser browser, bool fullscreen)
        {

        }

        public void OnStatusMessage(IWebBrowser browserControl, StatusMessageEventArgs statusMessageArgs)
        {

        }

        public void OnTitleChanged(IWebBrowser browserControl, TitleChangedEventArgs titleChangedArgs)
        {

        }

        public bool OnTooltipChanged(IWebBrowser browserControl, ref string text)
        {
            return false;
        }
    }
}
