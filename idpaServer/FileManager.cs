using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idpaServer
{
    static class FileManager
    {
        public static bool SavePrintScreen(Bitmap bitmap, string printScreenSavePath)
        {
            try
            {
                bitmap.Save(printScreenSavePath, ImageFormat.Jpeg);
                Console.WriteLine("Print Screen Saved at {0}", printScreenSavePath);
            }
            catch
            {
                return false;
            }
           return true;
        }
    }
}
