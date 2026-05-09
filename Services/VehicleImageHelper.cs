using System.Drawing;
using System.IO;

namespace RentXpress.Services
{
    public static class VehicleImageHelper
    {
        public static byte[] ReadImageFile(string imagePath)
        {
            return string.IsNullOrWhiteSpace(imagePath) ? null : File.ReadAllBytes(imagePath);
        }

        public static Image ImageFromBytes(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;

            using (var ms = new MemoryStream(imageData))
            using (var img = Image.FromStream(ms))
            {
                return new Bitmap(img);
            }
        }
    }
}

