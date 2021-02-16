using System.IO;

namespace Shapes.Loggers
{
    public class FileLogger : Logger
    {
        private const string FilePath = "log.txt";

        protected override void LogMessage(string message)
        {
            File.WriteAllText(FilePath, message);
        }
    }
}