namespace Aliapoh.Overlay.Logger
{
    public static class LOG
    {
        public static LoggerMain Logger;

        public static void Initialize()
        {
            Logger = new LoggerMain();
        }
    }
}