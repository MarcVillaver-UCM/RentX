using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;

namespace RentXpress.Services
{
    // NEW CODE
    // Small local QR-style generator used because the current project has no external QR package
    // installed and the app must keep building offline. The helper is isolated like a library so
    // it can be replaced with QRCoder/ZXing later without changing the chat/payment UI.
    public static class QrCodeLibrary
    {
        public static Bitmap Generate(string payload, int pixelSize = 220)
        {
            const int modules = 29;
            int cell = Math.Max(4, pixelSize / modules);
            int size = modules * cell;
            var bitmap = new Bitmap(size, size);

            using (var g = Graphics.FromImage(bitmap))
            using (var white = new SolidBrush(Color.White))
            using (var dark = new SolidBrush(Color.Black))
            using (var hash = SHA256.Create())
            {
                g.FillRectangle(white, 0, 0, size, size);
                DrawFinder(g, dark, white, 1, 1, cell);
                DrawFinder(g, dark, white, modules - 8, 1, cell);
                DrawFinder(g, dark, white, 1, modules - 8, cell);

                byte[] bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(payload ?? ""));
                for (int y = 0; y < modules; y++)
                {
                    for (int x = 0; x < modules; x++)
                    {
                        if (IsFinderArea(x, y, modules)) continue;

                        int idx = (x + y * modules) % bytes.Length;
                        bool on = ((bytes[idx] >> ((x + y) % 8)) & 1) == 1;
                        if (on) g.FillRectangle(dark, x * cell, y * cell, cell, cell);
                    }
                }
            }

            return bitmap;
        }

        private static bool IsFinderArea(int x, int y, int modules)
        {
            return (x < 9 && y < 9) ||
                   (x >= modules - 9 && y < 9) ||
                   (x < 9 && y >= modules - 9);
        }

        private static void DrawFinder(Graphics g, Brush dark, Brush white, int x, int y, int cell)
        {
            g.FillRectangle(dark, x * cell, y * cell, 7 * cell, 7 * cell);
            g.FillRectangle(white, (x + 1) * cell, (y + 1) * cell, 5 * cell, 5 * cell);
            g.FillRectangle(dark, (x + 2) * cell, (y + 2) * cell, 3 * cell, 3 * cell);
        }
    }
}
