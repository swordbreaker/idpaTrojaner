using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IdpaTools;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace IdpaClient
{
    public partial class Form1 : Form
    {
        private const string LOG_PATH = @"C:\Temp\log.xml";
        private Logger logger;

        public Form1()
        {
            InitializeComponent();
            logger = new Logger();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            adressInfo.Start();
        }

        
        private void GetKeyLoggerData()
        {
            //logger = Serilizer.getDataFromFile(LOG_PATH, logger);
            //string tempOutput;
            //textBox1.Text = "";

            //foreach (ApplicationLog app in logger.applicationLog)
            //{
            //    tempOutput = app.processName + " (" + app.date + ") \r\n";
            //    textBox1.AppendText(tempOutput);

            //    foreach (string key in app.keyList)
            //    {
            //        textBox1.AppendText(key + " ");
            //    }
            //    textBox1.AppendText("\r\n");
        }

        private void getData_Click(object sender, EventArgs e)
        {
            eventLog.Text += "Starting download... \r\n";
            Program.SendCommand("127.0.0.1", "ping");
            eventLog.AppendText("Ping: " + Program.stopwatch.Elapsed.Milliseconds + "\r\n");
            Program.stopwatch.Reset();
        }

        private void adressInfo_Tick(object sender, EventArgs e)
        {
            adressInfo.Stop();
        }

        private void search_Click(object sender, EventArgs e)
        {
            eventLog.Text += "Starting search of '" + searchBox.Text + "'... \r\n";
            eventLog.Text += "Search finished \r\n";
        }
    }
}

