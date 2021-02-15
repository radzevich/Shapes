namespace Shapes.Loggers
{
    public static class LoggerFactory
    {
        public static Logger CreateLogger(bool useFile)
        {
            if (useFile)
            {
                return new FileLogger();
            }
            else
            {
                return new ConsoleLogger();
            }
        }
    }
}