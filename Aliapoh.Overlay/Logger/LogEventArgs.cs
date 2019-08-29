using System;

namespace Aliapoh.Overlays.Logger
{
    public class LogEventArgs : EventArgs
    {
        public string Message { get; private set; }
        public LogLevel Level { get; private set; }
        public LogEventArgs(LogLevel level, string message)
        {
            Message = message;
            Level = level;
        }
    }
}
