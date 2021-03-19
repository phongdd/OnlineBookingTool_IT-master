namespace OnlineBookingTool
{
    partial class frmMain
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.grpInfoSearch = new System.Windows.Forms.GroupBox();
            this.radDN = new System.Windows.Forms.RadioButton();
            this.radQ12 = new System.Windows.Forms.RadioButton();
            this.radMipecHN = new System.Windows.Forms.RadioButton();
            this.radBT = new System.Windows.Forms.RadioButton();
            this.chkRefund = new System.Windows.Forms.CheckBox();
            this.rad2014 = new System.Windows.Forms.RadioButton();
            this.radLapTest = new System.Windows.Forms.RadioButton();
            this.btnInserData = new System.Windows.Forms.Button();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.radQT = new System.Windows.Forms.RadioButton();
            this.radKDV = new System.Windows.Forms.RadioButton();
            this.radTB = new System.Windows.Forms.RadioButton();
            this.radNT = new System.Windows.Forms.RadioButton();
            this.radND = new System.Windows.Forms.RadioButton();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.labInfo = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.grpResult = new System.Windows.Forms.GroupBox();
            this.dgrResult = new System.Windows.Forms.DataGridView();
            this.comPageInfo = new System.Windows.Forms.ComboBox();
            this.labTotal = new System.Windows.Forms.Label();
            this.labTotalTransaction = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.grpInfoSearch.SuspendLayout();
            this.grpResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrResult)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(29, 121);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // grpInfoSearch
            // 
            this.grpInfoSearch.Controls.Add(this.radDN);
            this.grpInfoSearch.Controls.Add(this.radQ12);
            this.grpInfoSearch.Controls.Add(this.radMipecHN);
            this.grpInfoSearch.Controls.Add(this.radBT);
            this.grpInfoSearch.Controls.Add(this.chkRefund);
            this.grpInfoSearch.Controls.Add(this.rad2014);
            this.grpInfoSearch.Controls.Add(this.radLapTest);
            this.grpInfoSearch.Controls.Add(this.btnInserData);
            this.grpInfoSearch.Controls.Add(this.btnLoadData);
            this.grpInfoSearch.Controls.Add(this.radQT);
            this.grpInfoSearch.Controls.Add(this.radKDV);
            this.grpInfoSearch.Controls.Add(this.radTB);
            this.grpInfoSearch.Controls.Add(this.radNT);
            this.grpInfoSearch.Controls.Add(this.radND);
            this.grpInfoSearch.Controls.Add(this.dtpToDate);
            this.grpInfoSearch.Controls.Add(this.dtpFromDate);
            this.grpInfoSearch.Controls.Add(this.label1);
            this.grpInfoSearch.Controls.Add(this.labInfo);
            this.grpInfoSearch.Location = new System.Drawing.Point(29, 12);
            this.grpInfoSearch.Name = "grpInfoSearch";
            this.grpInfoSearch.Size = new System.Drawing.Size(960, 105);
            this.grpInfoSearch.TabIndex = 3;
            this.grpInfoSearch.TabStop = false;
            this.grpInfoSearch.Enter += new System.EventHandler(this.grpInfoSearch_Enter);
            // 
            // radDN
            // 
            this.radDN.AutoSize = true;
            this.radDN.Enabled = false;
            this.radDN.Location = new System.Drawing.Point(526, 72);
            this.radDN.Name = "radDN";
            this.radDN.Size = new System.Drawing.Size(41, 17);
            this.radDN.TabIndex = 27;
            this.radDN.Text = "DN";
            this.radDN.UseVisualStyleBackColor = true;
            // 
            // radQ12
            // 
            this.radQ12.AutoSize = true;
            this.radQ12.Enabled = false;
            this.radQ12.Location = new System.Drawing.Point(575, 72);
            this.radQ12.Name = "radQ12";
            this.radQ12.Size = new System.Drawing.Size(48, 17);
            this.radQ12.TabIndex = 26;
            this.radQ12.Text = "Q 12";
            this.radQ12.UseVisualStyleBackColor = true;
            // 
            // radMipecHN
            // 
            this.radMipecHN.AutoSize = true;
            this.radMipecHN.Location = new System.Drawing.Point(443, 72);
            this.radMipecHN.Name = "radMipecHN";
            this.radMipecHN.Size = new System.Drawing.Size(77, 17);
            this.radMipecHN.TabIndex = 25;
            this.radMipecHN.Text = "MIPEC HN";
            this.radMipecHN.UseVisualStyleBackColor = true;
            this.radMipecHN.CheckedChanged += new System.EventHandler(this.radMipecHN_CheckedChanged);
            // 
            // radBT
            // 
            this.radBT.AutoSize = true;
            this.radBT.Location = new System.Drawing.Point(394, 72);
            this.radBT.Name = "radBT";
            this.radBT.Size = new System.Drawing.Size(39, 17);
            this.radBT.TabIndex = 24;
            this.radBT.Text = "BT";
            this.radBT.UseVisualStyleBackColor = true;
            // 
            // chkRefund
            // 
            this.chkRefund.AutoSize = true;
            this.chkRefund.Location = new System.Drawing.Point(731, 72);
            this.chkRefund.Name = "chkRefund";
            this.chkRefund.Size = new System.Drawing.Size(61, 17);
            this.chkRefund.TabIndex = 23;
            this.chkRefund.Text = "Refund";
            this.chkRefund.UseVisualStyleBackColor = true;
            // 
            // rad2014
            // 
            this.rad2014.AutoSize = true;
            this.rad2014.Location = new System.Drawing.Point(803, 72);
            this.rad2014.Name = "rad2014";
            this.rad2014.Size = new System.Drawing.Size(49, 17);
            this.rad2014.TabIndex = 22;
            this.rad2014.Text = "2014";
            this.rad2014.UseVisualStyleBackColor = true;
            // 
            // radLapTest
            // 
            this.radLapTest.AutoSize = true;
            this.radLapTest.Checked = true;
            this.radLapTest.Location = new System.Drawing.Point(635, 72);
            this.radLapTest.Name = "radLapTest";
            this.radLapTest.Size = new System.Drawing.Size(45, 17);
            this.radLapTest.TabIndex = 21;
            this.radLapTest.TabStop = true;
            this.radLapTest.Text = "LAB";
            this.radLapTest.UseVisualStyleBackColor = true;
            // 
            // btnInserData
            // 
            this.btnInserData.Location = new System.Drawing.Point(771, 33);
            this.btnInserData.Name = "btnInserData";
            this.btnInserData.Size = new System.Drawing.Size(75, 23);
            this.btnInserData.TabIndex = 13;
            this.btnInserData.Text = "Insert data";
            this.btnInserData.UseVisualStyleBackColor = true;
            this.btnInserData.Click += new System.EventHandler(this.btnInserData_Click);
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(690, 34);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(75, 23);
            this.btnLoadData.TabIndex = 14;
            this.btnLoadData.Text = "Load";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // radQT
            // 
            this.radQT.AutoSize = true;
            this.radQT.Location = new System.Drawing.Point(334, 72);
            this.radQT.Name = "radQT";
            this.radQT.Size = new System.Drawing.Size(40, 17);
            this.radQT.TabIndex = 20;
            this.radQT.Text = "QT";
            this.radQT.UseVisualStyleBackColor = true;
            // 
            // radKDV
            // 
            this.radKDV.AutoSize = true;
            this.radKDV.Location = new System.Drawing.Point(276, 72);
            this.radKDV.Name = "radKDV";
            this.radKDV.Size = new System.Drawing.Size(47, 17);
            this.radKDV.TabIndex = 19;
            this.radKDV.Text = "KDV";
            this.radKDV.UseVisualStyleBackColor = true;
            // 
            // radTB
            // 
            this.radTB.AutoSize = true;
            this.radTB.Location = new System.Drawing.Point(224, 72);
            this.radTB.Name = "radTB";
            this.radTB.Size = new System.Drawing.Size(39, 17);
            this.radTB.TabIndex = 18;
            this.radTB.Text = "TB";
            this.radTB.UseVisualStyleBackColor = true;
            // 
            // radNT
            // 
            this.radNT.AutoSize = true;
            this.radNT.Location = new System.Drawing.Point(171, 72);
            this.radNT.Name = "radNT";
            this.radNT.Size = new System.Drawing.Size(40, 17);
            this.radNT.TabIndex = 17;
            this.radNT.Text = "NT";
            this.radNT.UseVisualStyleBackColor = true;
            // 
            // radND
            // 
            this.radND.AutoSize = true;
            this.radND.Location = new System.Drawing.Point(123, 72);
            this.radND.Name = "radND";
            this.radND.Size = new System.Drawing.Size(41, 17);
            this.radND.TabIndex = 16;
            this.radND.Text = "ND";
            this.radND.UseVisualStyleBackColor = true;
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "MM/dd/yyyy HH:mm:ss tt";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(471, 35);
            this.dtpToDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(200, 20);
            this.dtpToDate.TabIndex = 15;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "MM/dd/yyyy HH:mm:ss tt";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(156, 36);
            this.dtpFromDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(200, 20);
            this.dtpFromDate.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(445, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "To";
            // 
            // labInfo
            // 
            this.labInfo.AutoSize = true;
            this.labInfo.Location = new System.Drawing.Point(120, 38);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(30, 13);
            this.labInfo.TabIndex = 0;
            this.labInfo.Text = "From";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(110, 121);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 13;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grpResult
            // 
            this.grpResult.Controls.Add(this.dgrResult);
            this.grpResult.Location = new System.Drawing.Point(29, 149);
            this.grpResult.Name = "grpResult";
            this.grpResult.Size = new System.Drawing.Size(960, 511);
            this.grpResult.TabIndex = 4;
            this.grpResult.TabStop = false;
            this.grpResult.Text = "Kết quả";
            this.grpResult.Enter += new System.EventHandler(this.grpResult_Enter);
            // 
            // dgrResult
            // 
            this.dgrResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrResult.Location = new System.Drawing.Point(22, 28);
            this.dgrResult.Name = "dgrResult";
            this.dgrResult.Size = new System.Drawing.Size(916, 486);
            this.dgrResult.TabIndex = 0;
            this.dgrResult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrResult_CellContentClick);
            // 
            // comPageInfo
            // 
            this.comPageInfo.DropDownHeight = 120;
            this.comPageInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comPageInfo.DropDownWidth = 55;
            this.comPageInfo.FormattingEnabled = true;
            this.comPageInfo.IntegralHeight = false;
            this.comPageInfo.Location = new System.Drawing.Point(912, 123);
            this.comPageInfo.Name = "comPageInfo";
            this.comPageInfo.Size = new System.Drawing.Size(55, 21);
            this.comPageInfo.TabIndex = 9;
            this.comPageInfo.SelectedIndexChanged += new System.EventHandler(this.comPageInfo_SelectedIndexChanged);
            // 
            // labTotal
            // 
            this.labTotal.AutoSize = true;
            this.labTotal.Location = new System.Drawing.Point(45, 149);
            this.labTotal.Name = "labTotal";
            this.labTotal.Size = new System.Drawing.Size(0, 13);
            this.labTotal.TabIndex = 11;
            // 
            // labTotalTransaction
            // 
            this.labTotalTransaction.AutoSize = true;
            this.labTotalTransaction.Location = new System.Drawing.Point(659, 129);
            this.labTotalTransaction.Name = "labTotalTransaction";
            this.labTotalTransaction.Size = new System.Drawing.Size(0, 13);
            this.labTotalTransaction.TabIndex = 12;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3600000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 648);
            this.Controls.Add(this.labTotalTransaction);
            this.Controls.Add(this.labTotal);
            this.Controls.Add(this.comPageInfo);
            this.Controls.Add(this.grpResult);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.grpInfoSearch);
            this.Controls.Add(this.btnSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Electronic Payments Import Tool";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.grpInfoSearch.ResumeLayout(false);
            this.grpInfoSearch.PerformLayout();
            this.grpResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

             

        

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox grpInfoSearch;
        private System.Windows.Forms.GroupBox grpResult;
        private System.Windows.Forms.DataGridView dgrResult;
        private System.Windows.Forms.ComboBox comPageInfo;
        private System.Windows.Forms.Label labTotal;
        private System.Windows.Forms.Label labTotalTransaction;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labInfo;
        private System.Windows.Forms.Button btnInserData;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radQT;
        private System.Windows.Forms.RadioButton radKDV;
        private System.Windows.Forms.RadioButton radTB;
        private System.Windows.Forms.RadioButton radNT;
        private System.Windows.Forms.RadioButton radND;
        private System.Windows.Forms.RadioButton radLapTest;
        private System.Windows.Forms.RadioButton rad2014;
        private System.Windows.Forms.CheckBox chkRefund;
        private System.Windows.Forms.RadioButton radQ12;
        private System.Windows.Forms.RadioButton radMipecHN;
        private System.Windows.Forms.RadioButton radBT;
        private System.Windows.Forms.RadioButton radDN;
    }
}

