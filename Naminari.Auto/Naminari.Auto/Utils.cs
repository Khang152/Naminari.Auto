using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
