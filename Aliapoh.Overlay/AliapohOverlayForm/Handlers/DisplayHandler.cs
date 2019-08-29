using System;
using System.Collections.Generic;
using CefSharp;
using System.Net;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using CefSharp.Structs;

namespace Aliapoh.Overlays
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

                    NativeMethods.SendMessage(ptr, 0x80, new IntPtr(1), big.GetHicon());
                    NativeMethods.SendMessage(ptr, 0x80, new IntPtr(0), small.GetHicon());
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

        void IDisplayHandler.OnAddressChanged(IWebBrowser chromiumWebBrowser, AddressChangedEventArgs addressChangedArgs)
        {

        }

        bool IDisplayHandler.OnAutoResize(IWebBrowser chromiumWebBrowser, IBrowser browser, CefSharp.Structs.Size newSize)
        {
            return true;
        }

        bool IDisplayHandler.OnConsoleMessage(IWebBrowser chromiumWebBrowser, ConsoleMessageEventArgs consoleMessageArgs)
        {
            return true;
        }

        void IDisplayHandler.OnFaviconUrlChange(IWebBrowser chromiumWebBrowser, IBrowser browser, IList<string> urls)
        {

        }

        void IDisplayHandler.OnFullscreenModeChange(IWebBrowser chromiumWebBrowser, IBrowser browser, bool fullscreen)
        {

        }

        void IDisplayHandler.OnLoadingProgressChange(IWebBrowser chromiumWebBrowser, IBrowser browser, double progress)
        {

        }

        void IDisplayHandler.OnStatusMessage(IWebBrowser chromiumWebBrowser, StatusMessageEventArgs statusMessageArgs)
        {

        }

        void IDisplayHandler.OnTitleChanged(IWebBrowser chromiumWebBrowser, TitleChangedEventArgs titleChangedArgs)
        {

        }

        bool IDisplayHandler.OnTooltipChanged(IWebBrowser chromiumWebBrowser, ref string text)
        {
            return true;
        }
    }
}
