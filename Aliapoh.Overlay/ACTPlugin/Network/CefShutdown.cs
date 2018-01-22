using CefSharp;

namespace Aliapoh.Overlay
{
    public class CefShutdown
    {
        public CefShutdown()
        {
            Cef.Shutdown();
        }
    }
}
