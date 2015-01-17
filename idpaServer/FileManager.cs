using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idpaServer
{
    static class FileManager
    {
        public static bool SavePrintScreen(Bitmap bitmap, string printScreenFolder, string printScreenName)
        {
            try
            {
                string printScreenSavePath = printScreenFolder + printScreenName + Controller.PrintScreenCount + ".jpg";
                Controller.PrintScreenCount++;
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

        public static bool ZipUserData(string userDataPath, string savePath)
        {
            ZipFile.CreateFromDirectory(userDataPath, savePath);
            return true;
        }
    }
}
