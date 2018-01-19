using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliapoh.Overlay.Logger
{
    public static class LoggerInitializer
    {
        public static LoggerMain Logger { get; set; }

        public static void Initialize()
        {
            Logger = new LoggerMain();
        }
    }
}
