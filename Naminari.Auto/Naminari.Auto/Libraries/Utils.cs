using Microsoft.VisualBasic.ApplicationServices;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using static OpenCvSharp.FileStorage;
using static System.Formats.Asn1.AsnWriter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Text.RegularExpressions;

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

        public static Bitmap GetImageFromSelect(Rectangle area)
        {
            IntPtr hdcSrc = GetDC(IntPtr.Zero);
            IntPtr hdcDest = CreateCompatibleDC(hdcSrc);
            IntPtr hBitmap = CreateCompatibleBitmap(hdcSrc, area.Width, area.Height);
            IntPtr hOld = SelectObject(hdcDest, hBitmap);
            BitBlt(hdcDest, 0, 0, area.Width, area.Height, hdcSrc, area.X, area.Y, 0xCC0020);
            SelectObject(hdcDest, hOld);
            DeleteObject(hdcDest);
            ReleaseDC(IntPtr.Zero, hdcSrc);
            Bitmap bmp = Bitmap.FromHbitmap(hBitmap);
            DeleteObject(hBitmap);
            return bmp;
        }

        public static System.Drawing.Point FindImagePosition(Bitmap smallImage, Bitmap bigImage, bool centerImage = true)
        {
            Mat smallBitmap = BitmapConverter.ToMat(smallImage);
            Mat bigBitmap = BitmapConverter.ToMat(bigImage);

            // Create a result matrix to store the match scores
            Mat result = new Mat();
            int resultCols = bigBitmap.Cols - smallBitmap.Cols + 1;
            int resultRows = bigBitmap.Rows - smallBitmap.Rows + 1;
            result.Create(resultRows, resultCols, MatType.CV_32FC1);

            Cv2.MatchTemplate(bigBitmap, smallBitmap, result, TemplateMatchModes.CCoeffNormed);
            Cv2.MinMaxLoc(result, out _, out double maxVal, out _, out OpenCvSharp.Point maxLoc);

            // Check if the match is above a certain threshold (e.g. 0.8)
            if (maxVal > 0.8)
            {
                // The small bitmap was found in the big bitmap
                if (centerImage)
                {
                    return new System.Drawing.Point(maxLoc.X + smallBitmap.Width / 2, maxLoc.Y + smallBitmap.Height / 2);
                }

                return new System.Drawing.Point(maxLoc.X, maxLoc.Y);
            }
            else
            {
                // The small bitmap was not found in the big bitmap
                return new System.Drawing.Point(-1, -1);
            }
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

        #region Import
        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        private static extern bool ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

        [DllImport("gdi32.dll")]
        private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [DllImport("gdi32.dll")]
        private static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int wDest, int hDest, IntPtr hdcSrc, int xSrc, int ySrc, int rop);

        [DllImport("gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hdc);
        #endregion Import
    }
}
