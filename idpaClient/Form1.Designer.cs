﻿namespace IdpaClient
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
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "TestComputer",
            " 15.220.88.2"}, -1);
            this.tabBar_Trojaner = new System.Windows.Forms.TabControl();
            this.overview = new System.Windows.Forms.TabPage();
            this.getData = new System.Windows.Forms.Button();
            this.adressinformation = new System.Windows.Forms.ListView();
            this.Computername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dataview = new System.Windows.Forms.TabPage();
            this.screenshot = new System.Windows.Forms.TabPage();
            this.pcInfo = new System.Windows.Forms.Label();
            this.pcName = new System.Windows.Forms.Label();
            this.pcPing = new System.Windows.Forms.Label();
            this.pcIP = new System.Windows.Forms.Label();
            this.pcOnline = new System.Windows.Forms.Label();
            this.pcWindows = new System.Windows.Forms.Label();
            this.pcNameData = new System.Windows.Forms.Label();
            this.pcPingData = new System.Windows.Forms.Label();
            this.pcOnlineData = new System.Windows.Forms.Label();
            this.pcIPData = new System.Windows.Forms.Label();
            this.pcWindowsData = new System.Windows.Forms.Label();
            this.eventLog = new System.Windows.Forms.TextBox();
            this.adressInfo = new System.Windows.Forms.Timer(this.components);
            this.searchBox = new System.Windows.Forms.TextBox();
            this.search = new System.Windows.Forms.Button();
            this.searchDate = new System.Windows.Forms.CheckBox();
            this.searchAppName = new System.Windows.Forms.CheckBox();
            this.searchWindowsName = new System.Windows.Forms.CheckBox();
            this.searchText = new System.Windows.Forms.CheckBox();
            this.keyLoggerDataView = new System.Windows.Forms.DataGridView();
            this.keyLoggerDataViewDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyLoggerDataViewAppName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyLoggerDataViewWindowName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyLoggerDataViewText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabBar_Trojaner.SuspendLayout();
            this.overview.SuspendLayout();
            this.dataview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keyLoggerDataView)).BeginInit();
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
            this.tabBar_Trojaner.Size = new System.Drawing.Size(875, 369);
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
            this.overview.Size = new System.Drawing.Size(867, 343);
            this.overview.TabIndex = 0;
            this.overview.Text = "Übersicht";
            this.overview.UseVisualStyleBackColor = true;
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
            this.adressinformation.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem3});
            this.adressinformation.Location = new System.Drawing.Point(6, 6);
            this.adressinformation.MultiSelect = false;
            this.adressinformation.Name = "adressinformation";
            this.adressinformation.Size = new System.Drawing.Size(291, 331);
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
            this.dataview.Controls.Add(this.keyLoggerDataView);
            this.dataview.Controls.Add(this.searchText);
            this.dataview.Controls.Add(this.searchWindowsName);
            this.dataview.Controls.Add(this.searchAppName);
            this.dataview.Controls.Add(this.searchDate);
            this.dataview.Controls.Add(this.search);
            this.dataview.Controls.Add(this.searchBox);
            this.dataview.Location = new System.Drawing.Point(4, 22);
            this.dataview.Name = "dataview";
            this.dataview.Padding = new System.Windows.Forms.Padding(3);
            this.dataview.Size = new System.Drawing.Size(867, 343);
            this.dataview.TabIndex = 1;
            this.dataview.Text = "Daten";
            this.dataview.UseVisualStyleBackColor = true;
            // 
            // screenshot
            // 
            this.screenshot.Location = new System.Drawing.Point(4, 22);
            this.screenshot.Name = "screenshot";
            this.screenshot.Padding = new System.Windows.Forms.Padding(3);
            this.screenshot.Size = new System.Drawing.Size(867, 343);
            this.screenshot.TabIndex = 2;
            this.screenshot.Text = "Screenshots";
            this.screenshot.UseVisualStyleBackColor = true;
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
            // eventLog
            // 
            this.eventLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eventLog.BackColor = System.Drawing.Color.Black;
            this.eventLog.ForeColor = System.Drawing.Color.Lime;
            this.eventLog.Location = new System.Drawing.Point(12, 383);
            this.eventLog.Multiline = true;
            this.eventLog.Name = "eventLog";
            this.eventLog.ReadOnly = true;
            this.eventLog.Size = new System.Drawing.Size(873, 106);
            this.eventLog.TabIndex = 14;
            // 
            // adressInfo
            // 
            this.adressInfo.Tick += new System.EventHandler(this.adressInfo_Tick);
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(6, 6);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(213, 20);
            this.searchBox.TabIndex = 0;
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
            // searchDate
            // 
            this.searchDate.AutoSize = true;
            this.searchDate.Checked = true;
            this.searchDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.searchDate.Location = new System.Drawing.Point(318, 10);
            this.searchDate.Name = "searchDate";
            this.searchDate.Size = new System.Drawing.Size(57, 17);
            this.searchDate.TabIndex = 2;
            this.searchDate.Text = "Datum";
            this.searchDate.UseVisualStyleBackColor = true;
            // 
            // searchAppName
            // 
            this.searchAppName.AutoSize = true;
            this.searchAppName.Checked = true;
            this.searchAppName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.searchAppName.Location = new System.Drawing.Point(381, 10);
            this.searchAppName.Name = "searchAppName";
            this.searchAppName.Size = new System.Drawing.Size(109, 17);
            this.searchAppName.TabIndex = 3;
            this.searchAppName.Text = "Application Name";
            this.searchAppName.UseVisualStyleBackColor = true;
            // 
            // searchWindowsName
            // 
            this.searchWindowsName.AutoSize = true;
            this.searchWindowsName.Checked = true;
            this.searchWindowsName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.searchWindowsName.Location = new System.Drawing.Point(496, 10);
            this.searchWindowsName.Name = "searchWindowsName";
            this.searchWindowsName.Size = new System.Drawing.Size(96, 17);
            this.searchWindowsName.TabIndex = 4;
            this.searchWindowsName.Text = "Window Name";
            this.searchWindowsName.UseVisualStyleBackColor = true;
            // 
            // searchText
            // 
            this.searchText.AutoSize = true;
            this.searchText.Checked = true;
            this.searchText.CheckState = System.Windows.Forms.CheckState.Checked;
            this.searchText.Location = new System.Drawing.Point(598, 10);
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(47, 17);
            this.searchText.TabIndex = 5;
            this.searchText.Text = "Text";
            this.searchText.UseVisualStyleBackColor = true;
            // 
            // keyLoggerDataView
            // 
            this.keyLoggerDataView.AllowUserToAddRows = false;
            this.keyLoggerDataView.AllowUserToDeleteRows = false;
            this.keyLoggerDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.keyLoggerDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.keyLoggerDataViewDate,
            this.keyLoggerDataViewAppName,
            this.keyLoggerDataViewWindowName,
            this.keyLoggerDataViewText});
            this.keyLoggerDataView.Location = new System.Drawing.Point(6, 32);
            this.keyLoggerDataView.Name = "keyLoggerDataView";
            this.keyLoggerDataView.Size = new System.Drawing.Size(855, 302);
            this.keyLoggerDataView.TabIndex = 6;
            // 
            // keyLoggerDataViewDate
            // 
            this.keyLoggerDataViewDate.HeaderText = "Datum";
            this.keyLoggerDataViewDate.Name = "keyLoggerDataViewDate";
            // 
            // keyLoggerDataViewAppName
            // 
            this.keyLoggerDataViewAppName.HeaderText = "Application Name";
            this.keyLoggerDataViewAppName.Name = "keyLoggerDataViewAppName";
            this.keyLoggerDataViewAppName.Width = 200;
            // 
            // keyLoggerDataViewWindowName
            // 
            this.keyLoggerDataViewWindowName.HeaderText = "Window Name";
            this.keyLoggerDataViewWindowName.Name = "keyLoggerDataViewWindowName";
            this.keyLoggerDataViewWindowName.Width = 200;
            // 
            // keyLoggerDataViewText
            // 
            this.keyLoggerDataViewText.HeaderText = "Text";
            this.keyLoggerDataViewText.Name = "keyLoggerDataViewText";
            this.keyLoggerDataViewText.Width = 300;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 496);
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
        private System.Windows.Forms.CheckBox searchText;
        private System.Windows.Forms.CheckBox searchWindowsName;
        private System.Windows.Forms.CheckBox searchAppName;
        private System.Windows.Forms.CheckBox searchDate;
        private System.Windows.Forms.DataGridView keyLoggerDataView;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyLoggerDataViewDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyLoggerDataViewAppName;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyLoggerDataViewWindowName;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyLoggerDataViewText;

    }
}

