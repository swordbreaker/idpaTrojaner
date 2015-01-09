using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace idpaServer
{
    static class PrintScreen
    {
        private static Bitmap bitmap;
        private static Graphics graphics;
        private static int screenWidth, screenHeight;

        public static Bitmap GetScreenshot()
        {
            screenWidth = Screen.PrimaryScreen.Bounds.Width;
            screenHeight = Screen.PrimaryScreen.Bounds.Height;
            bitmap = new Bitmap(screenWidth, screenHeight);
            graphics = Graphics.FromImage(bitmap as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);

            Console.WriteLine("PrintScreen taken");

            return bitmap;
        }
    }
}
