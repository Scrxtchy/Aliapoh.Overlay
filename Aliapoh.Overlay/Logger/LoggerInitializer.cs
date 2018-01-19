namespace Aliapoh.Overlay.Logger
{
    public static class LOG
    {
        public static LoggerMain Logger { get; set; }

        public static void Initialize()
        {
            Logger = new LoggerMain();
        }
    }
}