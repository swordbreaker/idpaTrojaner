using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;
using System.Text;

namespace IdpaClient
{
    static class Program
    {
        // Create new stopwatch
        public static Stopwatch stopwatch = new Stopwatch();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //When there is no Logfile then return a Empty Logger Class
            //startAsyncTCPListener();

            while(true)
            {

            }

            //Console.WriteLine("\nHit enter to continue...");
            //Console.Read();
        }
    }
}
