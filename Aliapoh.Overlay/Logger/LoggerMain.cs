using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliapoh.Overlay.Logger
{
    public class LoggerMain
    {
        public BindingList<LogEntry> Logs { get; private set; }

        public LoggerMain()
        {
            Logs = new BindingList<LogEntry>();
        }
        
        public void Log(LogLevel level, string message)
        {
#if !DEBUG
            if (level == LogLevel.Trace || level == LogLevel.Debug)
            {
                return;
            }
#endif
#if DEBUG
            System.Diagnostics.Trace.WriteLine(string.Format("{0}: {1}: {2}", level, DateTime.Now, message));
#endif
            Logs.Add(new LogEntry(level, DateTime.Now, message));
        }
        
        public void Log(LogLevel level, string format, params object[] args)
        {
            Log(level, string.Format(format, args));
        }
    }
}
