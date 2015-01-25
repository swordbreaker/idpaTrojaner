using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
            string tempFolder = Path.GetTempPath() + @"idpaUser/";

            if (File.Exists(savePath))
                File.Delete(savePath);

            if (Directory.Exists(tempFolder))
                Directory.Delete(tempFolder, true);

            Directory.CreateDirectory(tempFolder);
            Directory.CreateDirectory(tempFolder + @"\User");
            Directory.CreateDirectory(tempFolder + @"\ScreenShots");

            DirectoryCopy(userDataPath, tempFolder + @"\User", true);
            DirectoryCopy(Controller.PRINTSCREEN_PATH, tempFolder + @"\ScreenShots", true);
            
            Console.WriteLine("Start Zipping the Directory");
            ZipFile.CreateFromDirectory(tempFolder, savePath);
            return true;
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            Console.WriteLine("Start Copy Form Directory");
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory doesn't exist, create it. 
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                try
                {
                    file.CopyTo(temppath, false);
                }
                catch { }
            }

            // If copying subdirectories, copy them and their contents to new location. 
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    try
                    {
                        DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                    }
                    catch { }
                }
            }
            Console.WriteLine("End of Copy Form Directory");
        }
    }
}
