using OpenCvSharp;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Naminari.Auto
{
    public class Utils
    {
        public static Bitmap GetScreenShot()
        {
            int width = 0;
            int height = 0;
            foreach (var screen in Screen.AllScreens)
            {
                width += screen.Bounds.Width;
                height = height < screen.Bounds.Height ? screen.Bounds.Height : height;
            }
            Bitmap bitmap = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.CopyFromScreen(new System.Drawing.Point(0, 0), new System.Drawing.Point(0, 0), bitmap.Size);
            graphics.Dispose();
            return bitmap;
        }

        public Bitmap CreateBitmapFromSelect(Mat image)
        {
            Bitmap bitmap = new Bitmap(image.Width, image.Height, PixelFormat.Format24bppRgb);
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, bitmap.PixelFormat);
            IntPtr bitmapPtr = bitmapData.Scan0;
            int imageSize = image.Width * image.Height;
            byte[] imageData = new byte[imageSize];
            Marshal.Copy(image.Data, imageData, 0, imageSize);
            Marshal.Copy(imageData, 0, bitmapPtr, imageSize);
            bitmap.UnlockBits(bitmapData);
            return bitmap;
        }

        public Bitmap CreateBitmapFromSelect(Mat image, Rect selection)
        {
            Mat selectedRegion = new Mat(image, selection);
            Bitmap bitmap = CreateBitmapFromSelect(selectedRegion);
            return bitmap;
        }
    }
}
