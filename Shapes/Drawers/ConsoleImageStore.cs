using System;

namespace Shapes.Drawers
{
    public class ConsoleImageStore : IImageStore
    {
        public void Draw(string image)
        {
            Console.WriteLine(image);
        }
    }
}