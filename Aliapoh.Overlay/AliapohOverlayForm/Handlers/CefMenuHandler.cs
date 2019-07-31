using CefSharp;

namespace Aliapoh.Overlays
{
    public class CefMenuHandler : IContextMenuHandler
    {
        public bool OnBeforeContextMenu(IWebBrowser browser)
        {
            return false;
        }

        public void OnBeforeContextMenu(IWebBrowser browserControl, 
            IBrowser browser, 
            IFrame frame, 
            IContextMenuParams parameters, 
            IMenuModel model)
        {

        }

        public bool OnContextMenuCommand(IWebBrowser browserControl, 
            IBrowser browser, 
            IFrame frame, 
            IContextMenuParams parameters, 
            CefMenuCommand commandId, 
            CefEventFlags eventFlags)
        {
            return true;
        }

        public void OnContextMenuDismissed(IWebBrowser browserControl, 
            IBrowser browser, 
            IFrame frame)
        {

        }

        public bool RunContextMenu(IWebBrowser browserControl, 
            IBrowser browser, 
            IFrame frame, 
            IContextMenuParams parameters, 
            IMenuModel model, 
            IRunContextMenuCallback callback)
        {
            return true;
        }
    }
}
