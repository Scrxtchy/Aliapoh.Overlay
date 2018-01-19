using System;

namespace Aliapoh.Overlay.Logger
{
    public class LogEntry
    {
        public string Message { get; set; }
        public LogLevel Level { get; set; }
        public DateTime Time { get; set; }

        public LogEntry(LogLevel level, DateTime time, string message)
        {
            Message = message;
            Level = level;
            Time = time;
        }
    }
}
