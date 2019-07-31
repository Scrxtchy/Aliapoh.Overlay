using CefSharp;

namespace Aliapoh.Overlays
{
    public class CefShutdown
    {
        public CefShutdown()
        {
            Cef.Shutdown();
        }
    }
}
