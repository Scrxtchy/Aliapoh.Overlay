﻿using System;

namespace Aliapoh.Overlays
{
    public class ExceptionOccuredEventArgs
    {
        public Exception Exception { get; set; }
        public ExceptionOccuredEventArgs(Exception exception)
        {
            this.Exception = exception;
        }
    }
}
