namespace IdpaClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabBar_Trojaner = new System.Windows.Forms.TabControl();
            this.overview = new System.Windows.Forms.TabPage();
            this.pcWindowsData = new System.Windows.Forms.Label();
            this.pcIPData = new System.Windows.Forms.Label();
            this.pcOnlineData = new System.Windows.Forms.Label();
            this.pcPingData = new System.Windows.Forms.Label();
            this.pcNameData = new System.Windows.Forms.Label();
            this.pcWindows = new System.Windows.Forms.Label();
            this.pcOnline = new System.Windows.Forms.Label();
            this.pcIP = new System.Windows.Forms.Label();
            this.pcPing = new System.Windows.Forms.Label();
            this.pcName = new System.Windows.Forms.Label();
            this.pcInfo = new System.Windows.Forms.Label();
            this.getData = new System.Windows.Forms.Button();
            this.adressinformation = new System.Windows.Forms.ListView();
            this.Computername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dataview = new System.Windows.Forms.TabPage();
            this.radioText = new System.Windows.Forms.RadioButton();
            this.radioWName = new System.Windows.Forms.RadioButton();
            this.radioAName = new System.Windows.Forms.RadioButton();
            this.radioDate = new System.Windows.Forms.RadioButton();
            this.keyLoggerDataView = new System.Windows.Forms.DataGridView();
            this.keyLoggerDataViewDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyLoggerDataViewAppName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyLoggerDataViewWindowName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyLoggerDataViewText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.search = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.screenshot = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.eventLog = new System.Windows.Forms.TextBox();
            this.adressInfo = new System.Windows.Forms.Timer(this.components);
            this.refreshLogFile = new System.Windows.Forms.Button();
            this.tabBar_Trojaner.SuspendLayout();
            this.overview.SuspendLayout();
            this.dataview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keyLoggerDataView)).BeginInit();
            this.screenshot.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // tabBar_Trojaner
            // 
            this.tabBar_Trojaner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabBar_Trojaner.Controls.Add(this.overview);
            this.tabBar_Trojaner.Controls.Add(this.dataview);
            this.tabBar_Trojaner.Controls.Add(this.screenshot);
            this.tabBar_Trojaner.Location = new System.Drawing.Point(12, 12);
            this.tabBar_Trojaner.Name = "tabBar_Trojaner";
            this.tabBar_Trojaner.SelectedIndex = 0;
            this.tabBar_Trojaner.Size = new System.Drawing.Size(875, 355);
            this.tabBar_Trojaner.TabIndex = 0;
            // 
            // overview
            // 
            this.overview.Controls.Add(this.pcWindowsData);
            this.overview.Controls.Add(this.pcIPData);
            this.overview.Controls.Add(this.pcOnlineData);
            this.overview.Controls.Add(this.pcPingData);
            this.overview.Controls.Add(this.pcNameData);
            this.overview.Controls.Add(this.pcWindows);
            this.overview.Controls.Add(this.pcOnline);
            this.overview.Controls.Add(this.pcIP);
            this.overview.Controls.Add(this.pcPing);
            this.overview.Controls.Add(this.pcName);
            this.overview.Controls.Add(this.pcInfo);
            this.overview.Controls.Add(this.getData);
            this.overview.Controls.Add(this.adressinformation);
            this.overview.Location = new System.Drawing.Point(4, 22);
            this.overview.Name = "overview";
            this.overview.Padding = new System.Windows.Forms.Padding(3);
            this.overview.Size = new System.Drawing.Size(867, 329);
            this.overview.TabIndex = 0;
            this.overview.Text = "Übersicht";
            this.overview.UseVisualStyleBackColor = true;
            // 
            // pcWindowsData
            // 
            this.pcWindowsData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pcWindowsData.AutoSize = true;
            this.pcWindowsData.Location = new System.Drawing.Point(657, 147);
            this.pcWindowsData.Name = "pcWindowsData";
            this.pcWindowsData.Size = new System.Drawing.Size(63, 13);
            this.pcWindowsData.TabIndex = 13;
            this.pcWindowsData.Text = "Windows 8 ";
            // 
            // pcIPData
            // 
            this.pcIPData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pcIPData.AutoSize = true;
            this.pcIPData.Location = new System.Drawing.Point(657, 78);
            this.pcIPData.Name = "pcIPData";
            this.pcIPData.Size = new System.Drawing.Size(64, 13);
            this.pcIPData.TabIndex = 12;
            this.pcIPData.Text = "15.220.88.2";
            // 
            // pcOnlineData
            // 
            this.pcOnlineData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pcOnlineData.AutoSize = true;
            this.pcOnlineData.Location = new System.Drawing.Point(657, 124);
            this.pcOnlineData.Name = "pcOnlineData";
            this.pcOnlineData.Size = new System.Drawing.Size(61, 13);
            this.pcOnlineData.TabIndex = 11;
            this.pcOnlineData.Text = "09.01.2015";
            // 
            // pcPingData
            // 
            this.pcPingData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pcPingData.AutoSize = true;
            this.pcPingData.Location = new System.Drawing.Point(657, 102);
            this.pcPingData.Name = "pcPingData";
            this.pcPingData.Size = new System.Drawing.Size(19, 13);
            this.pcPingData.TabIndex = 10;
            this.pcPingData.Text = "ok";
            // 
            // pcNameData
            // 
            this.pcNameData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pcNameData.AutoSize = true;
            this.pcNameData.Location = new System.Drawing.Point(657, 52);
            this.pcNameData.Name = "pcNameData";
            this.pcNameData.Size = new System.Drawing.Size(73, 13);
            this.pcNameData.TabIndex = 9;
            this.pcNameData.Text = "TestComputer";
            // 
            // pcWindows
            // 
            this.pcWindows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pcWindows.AutoSize = true;
            this.pcWindows.Location = new System.Drawing.Point(553, 147);
            this.pcWindows.Name = "pcWindows";
            this.pcWindows.Size = new System.Drawing.Size(57, 13);
            this.pcWindows.TabIndex = 8;
            this.pcWindows.Text = "Windows: ";
            // 
            // pcOnline
            // 
            this.pcOnline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pcOnline.AutoSize = true;
            this.pcOnline.Location = new System.Drawing.Point(553, 124);
            this.pcOnline.Name = "pcOnline";
            this.pcOnline.Size = new System.Drawing.Size(59, 13);
            this.pcOnline.TabIndex = 7;
            this.pcOnline.Text = "Online seit:";
            // 
            // pcIP
            // 
            this.pcIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pcIP.AutoSize = true;
            this.pcIP.Location = new System.Drawing.Point(553, 78);
            this.pcIP.Name = "pcIP";
            this.pcIP.Size = new System.Drawing.Size(20, 13);
            this.pcIP.TabIndex = 6;
            this.pcIP.Text = "IP:";
            // 
            // pcPing
            // 
            this.pcPing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pcPing.AutoSize = true;
            this.pcPing.Location = new System.Drawing.Point(553, 102);
            this.pcPing.Name = "pcPing";
            this.pcPing.Size = new System.Drawing.Size(31, 13);
            this.pcPing.TabIndex = 5;
            this.pcPing.Text = "Ping:";
            // 
            // pcName
            // 
            this.pcName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pcName.AutoSize = true;
            this.pcName.Location = new System.Drawing.Point(553, 52);
            this.pcName.Name = "pcName";
            this.pcName.Size = new System.Drawing.Size(38, 13);
            this.pcName.TabIndex = 4;
            this.pcName.Text = "Name:";
            // 
            // pcInfo
            // 
            this.pcInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pcInfo.AutoSize = true;
            this.pcInfo.Location = new System.Drawing.Point(553, 22);
            this.pcInfo.Name = "pcInfo";
            this.pcInfo.Size = new System.Drawing.Size(118, 13);
            this.pcInfo.TabIndex = 3;
            this.pcInfo.Text = "Computerinformationen:";
            // 
            // getData
            // 
            this.getData.Location = new System.Drawing.Point(317, 6);
            this.getData.Name = "getData";
            this.getData.Size = new System.Drawing.Size(187, 45);
            this.getData.TabIndex = 2;
            this.getData.Text = "Download Data";
            this.getData.UseVisualStyleBackColor = true;
            this.getData.Click += new System.EventHandler(this.getData_Click);
            // 
            // adressinformation
            // 
            this.adressinformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.adressinformation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Computername,
            this.IP});
            this.adressinformation.Location = new System.Drawing.Point(6, 6);
            this.adressinformation.MultiSelect = false;
            this.adressinformation.Name = "adressinformation";
            this.adressinformation.Size = new System.Drawing.Size(291, 317);
            this.adressinformation.TabIndex = 1;
            this.adressinformation.UseCompatibleStateImageBehavior = false;
            this.adressinformation.View = System.Windows.Forms.View.Details;
            // 
            // Computername
            // 
            this.Computername.Text = "Computername";
            this.Computername.Width = 146;
            // 
            // IP
            // 
            this.IP.Text = "IP";
            this.IP.Width = 139;
            // 
            // dataview
            // 
            this.dataview.Controls.Add(this.refreshLogFile);
            this.dataview.Controls.Add(this.radioText);
            this.dataview.Controls.Add(this.radioWName);
            this.dataview.Controls.Add(this.radioAName);
            this.dataview.Controls.Add(this.radioDate);
            this.dataview.Controls.Add(this.keyLoggerDataView);
            this.dataview.Controls.Add(this.search);
            this.dataview.Controls.Add(this.searchBox);
            this.dataview.Location = new System.Drawing.Point(4, 22);
            this.dataview.Name = "dataview";
            this.dataview.Padding = new System.Windows.Forms.Padding(3);
            this.dataview.Size = new System.Drawing.Size(867, 329);
            this.dataview.TabIndex = 1;
            this.dataview.Text = "Daten";
            this.dataview.UseVisualStyleBackColor = true;
            // 
            // radioText
            // 
            this.radioText.AutoSize = true;
            this.radioText.Checked = true;
            this.radioText.Location = new System.Drawing.Point(306, 9);
            this.radioText.Name = "radioText";
            this.radioText.Size = new System.Drawing.Size(46, 17);
            this.radioText.TabIndex = 10;
            this.radioText.TabStop = true;
            this.radioText.Text = "Text";
            this.radioText.UseVisualStyleBackColor = true;
            this.radioText.CheckedChanged += new System.EventHandler(this.radioText_CheckedChanged);
            // 
            // radioWName
            // 
            this.radioWName.AutoSize = true;
            this.radioWName.Location = new System.Drawing.Point(472, 9);
            this.radioWName.Name = "radioWName";
            this.radioWName.Size = new System.Drawing.Size(95, 17);
            this.radioWName.TabIndex = 9;
            this.radioWName.Text = "Window Name";
            this.radioWName.UseVisualStyleBackColor = true;
            this.radioWName.CheckedChanged += new System.EventHandler(this.radioWName_CheckedChanged);
            // 
            // radioAName
            // 
            this.radioAName.AutoSize = true;
            this.radioAName.Location = new System.Drawing.Point(358, 9);
            this.radioAName.Name = "radioAName";
            this.radioAName.Size = new System.Drawing.Size(108, 17);
            this.radioAName.TabIndex = 8;
            this.radioAName.Text = "Application Name";
            this.radioAName.UseVisualStyleBackColor = true;
            this.radioAName.CheckedChanged += new System.EventHandler(this.radioAName_CheckedChanged);
            // 
            // radioDate
            // 
            this.radioDate.AutoSize = true;
            this.radioDate.Location = new System.Drawing.Point(573, 9);
            this.radioDate.Name = "radioDate";
            this.radioDate.Size = new System.Drawing.Size(56, 17);
            this.radioDate.TabIndex = 7;
            this.radioDate.Text = "Datum";
            this.radioDate.UseVisualStyleBackColor = true;
            this.radioDate.CheckedChanged += new System.EventHandler(this.radioDate_CheckedChanged);
            // 
            // keyLoggerDataView
            // 
            this.keyLoggerDataView.AllowUserToAddRows = false;
            this.keyLoggerDataView.AllowUserToDeleteRows = false;
            this.keyLoggerDataView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keyLoggerDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.keyLoggerDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.keyLoggerDataViewDate,
            this.keyLoggerDataViewAppName,
            this.keyLoggerDataViewWindowName,
            this.keyLoggerDataViewText});
            this.keyLoggerDataView.Location = new System.Drawing.Point(6, 32);
            this.keyLoggerDataView.Name = "keyLoggerDataView";
            this.keyLoggerDataView.ReadOnly = true;
            this.keyLoggerDataView.Size = new System.Drawing.Size(855, 288);
            this.keyLoggerDataView.TabIndex = 6;
            // 
            // keyLoggerDataViewDate
            // 
            this.keyLoggerDataViewDate.HeaderText = "Datum";
            this.keyLoggerDataViewDate.Name = "keyLoggerDataViewDate";
            this.keyLoggerDataViewDate.ReadOnly = true;
            // 
            // keyLoggerDataViewAppName
            // 
            this.keyLoggerDataViewAppName.HeaderText = "Application Name";
            this.keyLoggerDataViewAppName.Name = "keyLoggerDataViewAppName";
            this.keyLoggerDataViewAppName.ReadOnly = true;
            this.keyLoggerDataViewAppName.Width = 200;
            // 
            // keyLoggerDataViewWindowName
            // 
            this.keyLoggerDataViewWindowName.HeaderText = "Window Name";
            this.keyLoggerDataViewWindowName.Name = "keyLoggerDataViewWindowName";
            this.keyLoggerDataViewWindowName.ReadOnly = true;
            this.keyLoggerDataViewWindowName.Width = 200;
            // 
            // keyLoggerDataViewText
            // 
            this.keyLoggerDataViewText.HeaderText = "Text";
            this.keyLoggerDataViewText.Name = "keyLoggerDataViewText";
            this.keyLoggerDataViewText.ReadOnly = true;
            this.keyLoggerDataViewText.Width = 300;
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(225, 6);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(75, 23);
            this.search.TabIndex = 1;
            this.search.Text = "Suchen";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // searchBox
            // 
            this.searchBox.AcceptsReturn = true;
            this.searchBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.searchBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.searchBox.Location = new System.Drawing.Point(6, 6);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(213, 20);
            this.searchBox.TabIndex = 0;
            this.searchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchBox_OnKeyDown);
            // 
            // screenshot
            // 
            this.screenshot.Controls.Add(this.tableLayoutPanel1);
            this.screenshot.Location = new System.Drawing.Point(4, 22);
            this.screenshot.Name = "screenshot";
            this.screenshot.Padding = new System.Windows.Forms.Padding(3);
            this.screenshot.Size = new System.Drawing.Size(867, 329);
            this.screenshot.TabIndex = 2;
            this.screenshot.Text = "Screenshots";
            this.screenshot.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.298F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.35101F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.35101F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox4, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(853, 317);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(571, 161);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(278, 153);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 5;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(287, 161);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(278, 153);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(278, 152);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(287, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(278, 152);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(571, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(278, 152);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(3, 161);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(278, 153);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // eventLog
            // 
            this.eventLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eventLog.BackColor = System.Drawing.Color.Black;
            this.eventLog.ForeColor = System.Drawing.Color.Lime;
            this.eventLog.Location = new System.Drawing.Point(12, 369);
            this.eventLog.Multiline = true;
            this.eventLog.Name = "eventLog";
            this.eventLog.ReadOnly = true;
            this.eventLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.eventLog.Size = new System.Drawing.Size(873, 106);
            this.eventLog.TabIndex = 14;
            // 
            // adressInfo
            // 
            this.adressInfo.Interval = 5000;
            this.adressInfo.Tick += new System.EventHandler(this.adressInfo_Tick);
            // 
            // refreshLogFile
            // 
            this.refreshLogFile.Location = new System.Drawing.Point(789, 3);
            this.refreshLogFile.Name = "refreshLogFile";
            this.refreshLogFile.Size = new System.Drawing.Size(75, 26);
            this.refreshLogFile.TabIndex = 11;
            this.refreshLogFile.Text = "Get Data";
            this.refreshLogFile.UseVisualStyleBackColor = true;
            this.refreshLogFile.Click += new System.EventHandler(this.refreshLogFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 482);
            this.Controls.Add(this.eventLog);
            this.Controls.Add(this.tabBar_Trojaner);
            this.Name = "Form1";
            this.Text = "IDPA Trojaner Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabBar_Trojaner.ResumeLayout(false);
            this.overview.ResumeLayout(false);
            this.overview.PerformLayout();
            this.dataview.ResumeLayout(false);
            this.dataview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keyLoggerDataView)).EndInit();
            this.screenshot.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabBar_Trojaner;
        private System.Windows.Forms.TabPage overview;
        private System.Windows.Forms.TabPage dataview;
        private System.Windows.Forms.ListView adressinformation;
        private System.Windows.Forms.ColumnHeader Computername;
        private System.Windows.Forms.ColumnHeader IP;
        private System.Windows.Forms.TabPage screenshot;
        private System.Windows.Forms.Button getData;
        private System.Windows.Forms.Label pcWindowsData;
        private System.Windows.Forms.Label pcIPData;
        private System.Windows.Forms.Label pcOnlineData;
        private System.Windows.Forms.Label pcPingData;
        private System.Windows.Forms.Label pcNameData;
        private System.Windows.Forms.Label pcWindows;
        private System.Windows.Forms.Label pcOnline;
        private System.Windows.Forms.Label pcIP;
        private System.Windows.Forms.Label pcPing;
        private System.Windows.Forms.Label pcName;
        private System.Windows.Forms.Label pcInfo;
        private System.Windows.Forms.TextBox eventLog;
        private System.Windows.Forms.Timer adressInfo;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.DataGridView keyLoggerDataView;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyLoggerDataViewDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyLoggerDataViewAppName;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyLoggerDataViewWindowName;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyLoggerDataViewText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.RadioButton radioText;
        private System.Windows.Forms.RadioButton radioWName;
        private System.Windows.Forms.RadioButton radioAName;
        private System.Windows.Forms.RadioButton radioDate;
        private System.Windows.Forms.Button refreshLogFile;

    }
}

