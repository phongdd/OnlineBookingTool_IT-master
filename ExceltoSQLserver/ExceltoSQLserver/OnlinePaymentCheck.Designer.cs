namespace ExceltoSQLserver
{
  partial class OnlinePaymentCheck
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      this.labTotalTransaction = new System.Windows.Forms.Label();
      this.labTotal = new System.Windows.Forms.Label();
      this.comOLRecPageInfo = new System.Windows.Forms.ComboBox();
      this.grpInfoSearch = new System.Windows.Forms.GroupBox();
      this.chk2014 = new System.Windows.Forms.CheckBox();
      this.btnImportExcelRefund = new System.Windows.Forms.Button();
      this.radLapTest = new System.Windows.Forms.RadioButton();
      this.btnRec = new System.Windows.Forms.Button();
      this.radOnePayVisa = new System.Windows.Forms.RadioButton();
      this.radOnePayATM = new System.Windows.Forms.RadioButton();
      this.rad123Pay = new System.Windows.Forms.RadioButton();
      this.dtpToDate = new System.Windows.Forms.DateTimePicker();
      this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
      this.label1 = new System.Windows.Forms.Label();
      this.labInfo = new System.Windows.Forms.Label();
      this.btnImportFromExcel = new System.Windows.Forms.Button();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.txtVistaTotalAmount = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.txtPayConnectorTotalAmout = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txtRefundInTime = new System.Windows.Forms.TextBox();
      this.txtRefundOutOfTime = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.dgrTransNotInVista = new System.Windows.Forms.DataGridView();
      this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.grpResult = new System.Windows.Forms.GroupBox();
      this.dgrOnlinePaymentRec = new System.Windows.Forms.DataGridView();
      this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.CMND = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.BookingInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.tabReconcilication = new System.Windows.Forms.TabControl();
      this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.grpInfoSearch.SuspendLayout();
      this.tabPage2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgrTransNotInVista)).BeginInit();
      this.tabPage1.SuspendLayout();
      this.grpResult.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgrOnlinePaymentRec)).BeginInit();
      this.tabReconcilication.SuspendLayout();
      this.SuspendLayout();
      // 
      // labTotalTransaction
      // 
      this.labTotalTransaction.AutoSize = true;
      this.labTotalTransaction.Location = new System.Drawing.Point(798, 148);
      this.labTotalTransaction.Name = "labTotalTransaction";
      this.labTotalTransaction.Size = new System.Drawing.Size(0, 13);
      this.labTotalTransaction.TabIndex = 19;
      // 
      // labTotal
      // 
      this.labTotal.AutoSize = true;
      this.labTotal.Location = new System.Drawing.Point(100, 170);
      this.labTotal.Name = "labTotal";
      this.labTotal.Size = new System.Drawing.Size(0, 13);
      this.labTotal.TabIndex = 18;
      // 
      // comOLRecPageInfo
      // 
      this.comOLRecPageInfo.DropDownHeight = 120;
      this.comOLRecPageInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comOLRecPageInfo.DropDownWidth = 55;
      this.comOLRecPageInfo.FormattingEnabled = true;
      this.comOLRecPageInfo.IntegralHeight = false;
      this.comOLRecPageInfo.Location = new System.Drawing.Point(1049, 143);
      this.comOLRecPageInfo.Name = "comOLRecPageInfo";
      this.comOLRecPageInfo.Size = new System.Drawing.Size(55, 21);
      this.comOLRecPageInfo.TabIndex = 17;
      this.comOLRecPageInfo.Visible = false;
      this.comOLRecPageInfo.SelectedIndexChanged += new System.EventHandler(this.comOLRecPageInfo_SelectedIndexChanged);
      // 
      // grpInfoSearch
      // 
      this.grpInfoSearch.Controls.Add(this.chk2014);
      this.grpInfoSearch.Controls.Add(this.btnImportExcelRefund);
      this.grpInfoSearch.Controls.Add(this.radLapTest);
      this.grpInfoSearch.Controls.Add(this.btnRec);
      this.grpInfoSearch.Controls.Add(this.radOnePayVisa);
      this.grpInfoSearch.Controls.Add(this.radOnePayATM);
      this.grpInfoSearch.Controls.Add(this.rad123Pay);
      this.grpInfoSearch.Controls.Add(this.dtpToDate);
      this.grpInfoSearch.Controls.Add(this.dtpFromDate);
      this.grpInfoSearch.Controls.Add(this.label1);
      this.grpInfoSearch.Controls.Add(this.labInfo);
      this.grpInfoSearch.Location = new System.Drawing.Point(84, 14);
      this.grpInfoSearch.Name = "grpInfoSearch";
      this.grpInfoSearch.Size = new System.Drawing.Size(960, 105);
      this.grpInfoSearch.TabIndex = 15;
      this.grpInfoSearch.TabStop = false;
      // 
      // chk2014
      // 
      this.chk2014.AutoSize = true;
      this.chk2014.Location = new System.Drawing.Point(799, 72);
      this.chk2014.Name = "chk2014";
      this.chk2014.Size = new System.Drawing.Size(50, 17);
      this.chk2014.TabIndex = 24;
      this.chk2014.Text = "2014";
      this.chk2014.UseVisualStyleBackColor = true;
      // 
      // btnImportExcelRefund
      // 
      this.btnImportExcelRefund.Location = new System.Drawing.Point(798, 33);
      this.btnImportExcelRefund.Name = "btnImportExcelRefund";
      this.btnImportExcelRefund.Size = new System.Drawing.Size(126, 23);
      this.btnImportExcelRefund.TabIndex = 22;
      this.btnImportExcelRefund.Text = "ImportExcelTest";
      this.btnImportExcelRefund.UseVisualStyleBackColor = true;
      this.btnImportExcelRefund.Click += new System.EventHandler(this.btnImportExcelRefund_Click);
      // 
      // radLapTest
      // 
      this.radLapTest.AutoSize = true;
      this.radLapTest.Checked = true;
      this.radLapTest.Location = new System.Drawing.Point(630, 72);
      this.radLapTest.Name = "radLapTest";
      this.radLapTest.Size = new System.Drawing.Size(91, 17);
      this.radLapTest.TabIndex = 21;
      this.radLapTest.TabStop = true;
      this.radLapTest.Text = "Giao dịch treo";
      this.radLapTest.UseVisualStyleBackColor = true;
      // 
      // btnRec
      // 
      this.btnRec.Location = new System.Drawing.Point(702, 33);
      this.btnRec.Name = "btnRec";
      this.btnRec.Size = new System.Drawing.Size(75, 23);
      this.btnRec.TabIndex = 14;
      this.btnRec.Text = "Đối soát";
      this.btnRec.UseVisualStyleBackColor = true;
      this.btnRec.Click += new System.EventHandler(this.btnRec_Click);
      // 
      // radOnePayVisa
      // 
      this.radOnePayVisa.AutoSize = true;
      this.radOnePayVisa.Location = new System.Drawing.Point(464, 72);
      this.radOnePayVisa.Name = "radOnePayVisa";
      this.radOnePayVisa.Size = new System.Drawing.Size(120, 17);
      this.radOnePayVisa.TabIndex = 18;
      this.radOnePayVisa.Text = "ONEPAY_VIS/MAS";
      this.radOnePayVisa.UseVisualStyleBackColor = true;
      // 
      // radOnePayATM
      // 
      this.radOnePayATM.AutoSize = true;
      this.radOnePayATM.Location = new System.Drawing.Point(305, 72);
      this.radOnePayATM.Name = "radOnePayATM";
      this.radOnePayATM.Size = new System.Drawing.Size(98, 17);
      this.radOnePayATM.TabIndex = 17;
      this.radOnePayATM.Text = "ONEPAY_ATM";
      this.radOnePayATM.UseVisualStyleBackColor = true;
      // 
      // rad123Pay
      // 
      this.rad123Pay.AutoSize = true;
      this.rad123Pay.Location = new System.Drawing.Point(189, 72);
      this.rad123Pay.Name = "rad123Pay";
      this.rad123Pay.Size = new System.Drawing.Size(64, 17);
      this.rad123Pay.TabIndex = 16;
      this.rad123Pay.Text = "123PAY";
      this.rad123Pay.UseVisualStyleBackColor = true;
      // 
      // dtpToDate
      // 
      this.dtpToDate.CustomFormat = "MM/dd/yyyy";
      this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtpToDate.Location = new System.Drawing.Point(554, 35);
      this.dtpToDate.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
      this.dtpToDate.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
      this.dtpToDate.Name = "dtpToDate";
      this.dtpToDate.Size = new System.Drawing.Size(113, 20);
      this.dtpToDate.TabIndex = 15;
      // 
      // dtpFromDate
      // 
      this.dtpFromDate.CustomFormat = "MM/dd/yyyy";
      this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtpFromDate.Location = new System.Drawing.Point(235, 36);
      this.dtpFromDate.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
      this.dtpFromDate.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
      this.dtpFromDate.Name = "dtpFromDate";
      this.dtpFromDate.Size = new System.Drawing.Size(113, 20);
      this.dtpFromDate.TabIndex = 14;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(513, 39);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(20, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "To";
      // 
      // labInfo
      // 
      this.labInfo.AutoSize = true;
      this.labInfo.Location = new System.Drawing.Point(187, 38);
      this.labInfo.Name = "labInfo";
      this.labInfo.Size = new System.Drawing.Size(30, 13);
      this.labInfo.TabIndex = 0;
      this.labInfo.Text = "From";
      // 
      // btnImportFromExcel
      // 
      this.btnImportFromExcel.Location = new System.Drawing.Point(84, 140);
      this.btnImportFromExcel.Name = "btnImportFromExcel";
      this.btnImportFromExcel.Size = new System.Drawing.Size(128, 23);
      this.btnImportFromExcel.TabIndex = 13;
      this.btnImportFromExcel.Text = "ImportFromExcel";
      this.btnImportFromExcel.UseVisualStyleBackColor = true;
      this.btnImportFromExcel.Click += new System.EventHandler(this.btnImportFromExcel_Click);
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.FileName = "openFileDialog1";
      // 
      // txtVistaTotalAmount
      // 
      this.txtVistaTotalAmount.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.txtVistaTotalAmount.Location = new System.Drawing.Point(937, 143);
      this.txtVistaTotalAmount.Name = "txtVistaTotalAmount";
      this.txtVistaTotalAmount.ReadOnly = true;
      this.txtVistaTotalAmount.Size = new System.Drawing.Size(106, 20);
      this.txtVistaTotalAmount.TabIndex = 20;
      this.txtVistaTotalAmount.TextChanged += new System.EventHandler(this.txtVistaTotalAmount_TextChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(853, 145);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(78, 13);
      this.label2.TabIndex = 21;
      this.label2.Text = "Số tiền từ Vista";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(609, 146);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(133, 13);
      this.label3.TabIndex = 23;
      this.label3.Text = "Số tiền từ cổng thanh toán";
      // 
      // txtPayConnectorTotalAmout
      // 
      this.txtPayConnectorTotalAmout.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.txtPayConnectorTotalAmout.Location = new System.Drawing.Point(747, 144);
      this.txtPayConnectorTotalAmout.Name = "txtPayConnectorTotalAmout";
      this.txtPayConnectorTotalAmout.ReadOnly = true;
      this.txtPayConnectorTotalAmout.Size = new System.Drawing.Size(100, 20);
      this.txtPayConnectorTotalAmout.TabIndex = 22;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(239, 146);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(42, 13);
      this.label4.TabIndex = 28;
      this.label4.Text = "Refund";
      // 
      // txtRefundInTime
      // 
      this.txtRefundInTime.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.txtRefundInTime.Location = new System.Drawing.Point(291, 143);
      this.txtRefundInTime.Name = "txtRefundInTime";
      this.txtRefundInTime.ReadOnly = true;
      this.txtRefundInTime.Size = new System.Drawing.Size(100, 20);
      this.txtRefundInTime.TabIndex = 27;
      // 
      // txtRefundOutOfTime
      // 
      this.txtRefundOutOfTime.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.txtRefundOutOfTime.Location = new System.Drawing.Point(397, 144);
      this.txtRefundOutOfTime.Name = "txtRefundOutOfTime";
      this.txtRefundOutOfTime.ReadOnly = true;
      this.txtRefundOutOfTime.Size = new System.Drawing.Size(106, 20);
      this.txtRefundOutOfTime.TabIndex = 25;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(418, 167);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(0, 13);
      this.label6.TabIndex = 24;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(319, 122);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(46, 13);
      this.label5.TabIndex = 29;
      this.label5.Text = "Cùng kỳ";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(425, 122);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(46, 13);
      this.label7.TabIndex = 30;
      this.label7.Text = "Khác kỳ";
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.dgrTransNotInVista);
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(952, 486);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Giao dịch treo (không có trong Vista)";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // dgrTransNotInVista
      // 
      this.dgrTransNotInVista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgrTransNotInVista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
      this.dgrTransNotInVista.Location = new System.Drawing.Point(18, 0);
      this.dgrTransNotInVista.Name = "dgrTransNotInVista";
      this.dgrTransNotInVista.Size = new System.Drawing.Size(916, 486);
      this.dgrTransNotInVista.TabIndex = 1;
      // 
      // dataGridViewTextBoxColumn1
      // 
      this.dataGridViewTextBoxColumn1.DataPropertyName = "No";
      this.dataGridViewTextBoxColumn1.HeaderText = "Thứ tự";
      this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
      // 
      // dataGridViewTextBoxColumn2
      // 
      this.dataGridViewTextBoxColumn2.DataPropertyName = "TransC_excel_strPaymentTransRef";
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle1;
      this.dataGridViewTextBoxColumn2.HeaderText = "Mã giao dịch";
      this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
      this.dataGridViewTextBoxColumn2.Width = 200;
      // 
      // dataGridViewTextBoxColumn3
      // 
      this.dataGridViewTextBoxColumn3.DataPropertyName = "TransC_excel_strType";
      this.dataGridViewTextBoxColumn3.HeaderText = "Loại giao dịch";
      this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
      this.dataGridViewTextBoxColumn3.Width = 200;
      // 
      // dataGridViewTextBoxColumn4
      // 
      this.dataGridViewTextBoxColumn4.DataPropertyName = "TransC_excel_dtmDateTime";
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle2;
      this.dataGridViewTextBoxColumn4.HeaderText = "Thời gian giao dịch";
      this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
      this.dataGridViewTextBoxColumn4.Width = 200;
      // 
      // dataGridViewTextBoxColumn5
      // 
      this.dataGridViewTextBoxColumn5.DataPropertyName = "TransC_excel_curValue";
      this.dataGridViewTextBoxColumn5.HeaderText = "Số tiền";
      this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
      this.dataGridViewTextBoxColumn5.Width = 150;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.grpResult);
      this.tabPage1.Location = new System.Drawing.Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(952, 486);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Đối soát";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // grpResult
      // 
      this.grpResult.Controls.Add(this.dgrOnlinePaymentRec);
      this.grpResult.Location = new System.Drawing.Point(-4, -22);
      this.grpResult.Name = "grpResult";
      this.grpResult.Size = new System.Drawing.Size(960, 531);
      this.grpResult.TabIndex = 17;
      this.grpResult.TabStop = false;
      this.grpResult.Text = "Kết quả";
      // 
      // dgrOnlinePaymentRec
      // 
      this.dgrOnlinePaymentRec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgrOnlinePaymentRec.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FirstName,
            this.CMND,
            this.Email,
            this.Phone,
            this.BookingInfo,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
      this.dgrOnlinePaymentRec.Location = new System.Drawing.Point(22, 28);
      this.dgrOnlinePaymentRec.Name = "dgrOnlinePaymentRec";
      this.dgrOnlinePaymentRec.Size = new System.Drawing.Size(916, 486);
      this.dgrOnlinePaymentRec.TabIndex = 0;
      // 
      // FirstName
      // 
      this.FirstName.DataPropertyName = "No";
      this.FirstName.HeaderText = "Thứ tự";
      this.FirstName.Name = "FirstName";
      this.FirstName.Width = 30;
      // 
      // CMND
      // 
      this.CMND.DataPropertyName = "TransC_excel_strPaymentTransRef";
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.CMND.DefaultCellStyle = dataGridViewCellStyle3;
      this.CMND.HeaderText = "Mã giao dịch";
      this.CMND.Name = "CMND";
      this.CMND.Width = 125;
      // 
      // Email
      // 
      this.Email.DataPropertyName = "TransC_excel_strType";
      this.Email.HeaderText = "Loại giao dịch";
      this.Email.Name = "Email";
      this.Email.Width = 70;
      // 
      // Phone
      // 
      this.Phone.DataPropertyName = "TransC_excel_dtmDateTime";
      dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.Phone.DefaultCellStyle = dataGridViewCellStyle4;
      this.Phone.HeaderText = "Thời gian giao dịch";
      this.Phone.Name = "Phone";
      this.Phone.Width = 120;
      // 
      // BookingInfo
      // 
      this.BookingInfo.DataPropertyName = "TransC_excel_curValue";
      this.BookingInfo.HeaderText = "Số tiền";
      this.BookingInfo.Name = "BookingInfo";
      this.BookingInfo.Width = 70;
      // 
      // Column1
      // 
      this.Column1.DataPropertyName = "TransC_strPaymentTransRef";
      this.Column1.HeaderText = "Vista_Mã GD";
      this.Column1.Name = "Column1";
      this.Column1.Width = 125;
      // 
      // Column2
      // 
      this.Column2.DataPropertyName = "TransC_strType";
      this.Column2.HeaderText = "Vista_Type";
      this.Column2.Name = "Column2";
      this.Column2.Width = 20;
      // 
      // Column3
      // 
      this.Column3.DataPropertyName = "TransC_dtmDateTime";
      this.Column3.HeaderText = "Vista_TG ghi nhận Report";
      this.Column3.Name = "Column3";
      this.Column3.Width = 120;
      // 
      // Column4
      // 
      this.Column4.DataPropertyName = "TransC_dtmRealTransTime";
      this.Column4.HeaderText = "Vista_TG giao dịch";
      this.Column4.Name = "Column4";
      this.Column4.Width = 120;
      // 
      // Column5
      // 
      this.Column5.DataPropertyName = "TransC_curValue";
      this.Column5.HeaderText = "Vista_Số tiền";
      this.Column5.Name = "Column5";
      this.Column5.Width = 70;
      // 
      // tabReconcilication
      // 
      this.tabReconcilication.Controls.Add(this.tabPage1);
      this.tabReconcilication.Controls.Add(this.tabPage2);
      this.tabReconcilication.Location = new System.Drawing.Point(85, 167);
      this.tabReconcilication.Name = "tabReconcilication";
      this.tabReconcilication.SelectedIndex = 0;
      this.tabReconcilication.Size = new System.Drawing.Size(960, 512);
      this.tabReconcilication.TabIndex = 1;
      // 
      // backgroundWorker1
      // 
      this.backgroundWorker1.WorkerReportsProgress = true;
      this.backgroundWorker1.WorkerSupportsCancellation = true;
      
      // 
      // timer1
      // 
      this.timer1.Enabled = true;
      this.timer1.Interval = 3600000;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // OnlinePaymentCheck
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1128, 691);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.txtRefundInTime);
      this.Controls.Add(this.txtRefundOutOfTime);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.tabReconcilication);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txtPayConnectorTotalAmout);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txtVistaTotalAmount);
      this.Controls.Add(this.labTotalTransaction);
      this.Controls.Add(this.btnImportFromExcel);
      this.Controls.Add(this.labTotal);
      this.Controls.Add(this.comOLRecPageInfo);
      this.Controls.Add(this.grpInfoSearch);
      this.MaximizeBox = false;
      this.Name = "OnlinePaymentCheck";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "OnlinePaymentReconciliation";
      this.Load += new System.EventHandler(this.OnlinePaymentReconciliation_Load);
      this.grpInfoSearch.ResumeLayout(false);
      this.grpInfoSearch.PerformLayout();
      this.tabPage2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgrTransNotInVista)).EndInit();
      this.tabPage1.ResumeLayout(false);
      this.grpResult.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgrOnlinePaymentRec)).EndInit();
      this.tabReconcilication.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    
    #endregion

    private System.Windows.Forms.Label labTotalTransaction;
    private System.Windows.Forms.Label labTotal;
    private System.Windows.Forms.ComboBox comOLRecPageInfo;
    private System.Windows.Forms.GroupBox grpInfoSearch;
    private System.Windows.Forms.Button btnImportFromExcel;
    private System.Windows.Forms.Button btnRec;
    private System.Windows.Forms.DateTimePicker dtpToDate;
    private System.Windows.Forms.DateTimePicker dtpFromDate;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label labInfo;
    private System.Windows.Forms.RadioButton radLapTest;
    private System.Windows.Forms.RadioButton radOnePayVisa;
    private System.Windows.Forms.RadioButton radOnePayATM;
    private System.Windows.Forms.RadioButton rad123Pay;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.TextBox txtVistaTotalAmount;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtPayConnectorTotalAmout;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtRefundInTime;
    private System.Windows.Forms.TextBox txtRefundOutOfTime;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Button btnImportExcelRefund;
    private System.Windows.Forms.CheckBox chk2014;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.DataGridView dgrTransNotInVista;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.GroupBox grpResult;
    private System.Windows.Forms.DataGridView dgrOnlinePaymentRec;
    private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
    private System.Windows.Forms.DataGridViewTextBoxColumn CMND;
    private System.Windows.Forms.DataGridViewTextBoxColumn Email;
    private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
    private System.Windows.Forms.DataGridViewTextBoxColumn BookingInfo;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    private System.Windows.Forms.TabControl tabReconcilication;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private System.Windows.Forms.Timer timer1;
  }
}