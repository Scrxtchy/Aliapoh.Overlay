using CefSharp;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Aliapoh.Overlay
{
    public class BrowserProcessHandler : IBrowserProcessHandler
    {
        protected const int MaxTimerDelay = 1000 / 30;  // 30fps
        void IBrowserProcessHandler.OnContextInitialized()
        {

        }

        void IBrowserProcessHandler.OnScheduleMessagePumpWork(long delay)
        {
            if (delay > MaxTimerDelay)
            {
                delay = MaxTimerDelay;
            }
            OnScheduleMessagePumpWork((int)delay);
        }

        protected virtual void OnScheduleMessagePumpWork(int delay)
        {

        }

        public virtual void Dispose()
        {

        }
    }
}
