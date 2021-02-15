using System.IO;

namespace Shapes.Loggers
{
    public class FileLogger : Logger
    {
        protected override void LogMessage(string message)
        {
            File.WriteAllText("log.txt", message);
        }
    }
}