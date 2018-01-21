using System;

namespace Aliapoh.Overlay.Logger
{
    public class LogEntry
    {
        public string Message;
        public LogLevel Level;
        public DateTime Time;

        public LogEntry(LogLevel level, DateTime time, string message)
        {
            Message = message;
            Level = level;
            Time = time;
        }
    }
}
