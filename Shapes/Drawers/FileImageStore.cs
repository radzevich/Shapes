using System.IO;

namespace Shapes.Drawers
{
    public class FileImageStore : IImageStore
    {
        private const string FilePath = "log.txt";

        public void Draw(string image)
        {
            var streamWriter = new StreamWriter(FilePath, append: false);

            try
            {
                streamWriter.WriteLine(image);
            }
            finally
            {
                streamWriter.Dispose(); // closing stream writer explicitly
            }
        }
    }
}