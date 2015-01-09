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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void GetKeyLoggerData()
        {
            logger = Serilizer.getDataFromFile(LOG_PATH, logger);
            string tempOutput;
            textBox1.Text = "";

            foreach (ApplicationLog app in logger.applicationLog)
            {
                tempOutput = app.processName + " (" + app.date + ") \r\n";
                textBox1.AppendText(tempOutput);

                foreach (string key in app.keyList)
                {
                    textBox1.AppendText(key + " ");
                }
                textBox1.AppendText("\r\n");
            }
        }
    }
}
