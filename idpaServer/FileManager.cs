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
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return false;
            }
        }

        public static bool SaveLogFile(string path, IdpaTools.Logger logger)
        {
            try
            {
                IdpaTools.Serilizer.writeDataToFile(path, logger);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return false;
            }
        }
    }
}
