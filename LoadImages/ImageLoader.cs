using System.IO;

namespace LoadImages
{
    public static class ImageLoader
    { 
        public static byte[] LoadImage (string imagePath)
        {
            return File.ReadAllBytes (imagePath);
        }
    }
}
