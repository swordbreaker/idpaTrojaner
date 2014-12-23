using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace idpaServer
{
    /**
     * FileScanner
     * Scanns files and creates a Zip File
     * Tobias Bolliner & Thierry Girod
     */
    static class FileScanner
    {
        private const string SCAN_PATH = @"C:\Users"; //Scanned folder
        private const string APP_PATH = @"C:\Temp"; //Path in which the application stores Data

        static public void startCopy()
        {
            DirectoryCopy(SCAN_PATH, APP_PATH, true);
            zipFolder(APP_PATH);
        }

        //Scanns the Folder and output the result in the console
        //The Application need to be a Console Application to show the Console prompts
        public static void startFileScan()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            if (Directory.Exists(SCAN_PATH))
                ProcessDirectory(SCAN_PATH);
            else
                Console.WriteLine("{0} is not a valid file or directory.", SCAN_PATH);

            Console.ReadKey(true);
        }

        // Process all files in the directory passed in, recurse on any directories  
        // that are found, and process the files they contain. 
        private static void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory. 
            string[] fileEntries = Directory.GetFiles(targetDirectory);

            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            if (targetDirectory.Contains("Pictures") || targetDirectory.Contains("Documents") || targetDirectory.Contains("Contacts"))
            {
                string[] splittedDirectory = targetDirectory.Split('\\');
                string pathName = splittedDirectory[splittedDirectory.Length - 1];
                DirectoryCopy(targetDirectory, APP_PATH + @"\" + pathName, true);
            }

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
            {
                try
                {
                    ProcessDirectory(subdirectory);
                }
                catch (UnauthorizedAccessException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Acces denied for '{0}'", subdirectory);
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }
        }

        // Insert logic for processing found files here. 
        private static void ProcessFile(string path)
        {
            if (path.Contains("Pictures") || path.Contains("Documents") || path.Contains("Contacts"))
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
            }
            Console.WriteLine("Processed file '{0}'.", path);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        private static void zipFolder(string folder)
        {
            string zipPath = @"C:\temp.zip";

            ZipFile.CreateFromDirectory(folder, zipPath);
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
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
        }
    }
}
