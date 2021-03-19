namespace ExceltoSQLserver
{
    partial class PaymentChecking
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
        this.grpInfoSearch = new System.Windows.Forms.GroupBox();
        this.btnRefreshData = new System.Windows.Forms.Button();
        this.label10 = new System.Windows.Forms.Label();
        this.txtPaymentBankRef = new System.Windows.Forms.TextBox();
        this.chkAutoChecking = new System.Windows.Forms.CheckBox();
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
        this.label2 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.txtPayConnectorTotalAmout = new System.Windows.Forms.TextBox();
        this.tabReconcilication = new System.Windows.Forms.TabControl();
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
        this.tabPage2 = new System.Windows.Forms.TabPage();
        this.dgrTransNotInVista = new System.Windows.Forms.DataGridView();
        this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.tabPage3 = new System.Windows.Forms.TabPage();
        this.dgrTransVistaNotInExcel = new System.Windows.Forms.DataGridView();
        this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.label6 = new System.Windows.Forms.Label();
        this.txtTotalRefundAmount = new System.Windows.Forms.TextBox();
        this.txtSheetName = new System.Windows.Forms.TextBox();
        this.label4 = new System.Windows.Forms.Label();
        this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
        this.timer1 = new System.Windows.Forms.Timer(this.components);
        this.grpInfoSearch.SuspendLayout();
        this.tabReconcilication.SuspendLayout();
        this.tabPage1.SuspendLayout();
        this.grpResult.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgrOnlinePaymentRec)).BeginInit();
        this.tabPage2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgrTransNotInVista)).BeginInit();
        this.tabPage3.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgrTransVistaNotInExcel)).BeginInit();
        this.SuspendLayout();
        // 
        // labTotalTransaction
        // 
        this.labTotalTransaction.AutoSize = true;
        this.labTotalTransaction.Location = new System.Drawing.Point(222, 146);
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
        // grpInfoSearch
        // 
        this.grpInfoSearch.Controls.Add(this.btnRefreshData);
        this.grpInfoSearch.Controls.Add(this.label10);
        this.grpInfoSearch.Controls.Add(this.txtPaymentBankRef);
        this.grpInfoSearch.Controls.Add(this.chkAutoChecking);
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
        // btnRefreshData
        // 
        this.btnRefreshData.Location = new System.Drawing.Point(824, 33);
        this.btnRefreshData.Name = "btnRefreshData";
        this.btnRefreshData.Size = new System.Drawing.Size(75, 23);
        this.btnRefreshData.TabIndex = 31;
        this.btnRefreshData.Text = "Refresh";
        this.btnRefreshData.UseVisualStyleBackColor = true;
        this.btnRefreshData.Click += new System.EventHandler(this.btnRefreshData_Click);
        // 
        // label10
        // 
        this.label10.AutoSize = true;
        this.label10.Location = new System.Drawing.Point(114, 39);
        this.label10.Name = "label10";
        this.label10.Size = new System.Drawing.Size(103, 13);
        this.label10.TabIndex = 30;
        this.label10.Text = "Mã cổng thanh toán";
        // 
        // txtPaymentBankRef
        // 
        this.txtPaymentBankRef.BackColor = System.Drawing.SystemColors.ButtonHighlight;
        this.txtPaymentBankRef.Location = new System.Drawing.Point(234, 37);
        this.txtPaymentBankRef.Name = "txtPaymentBankRef";
        this.txtPaymentBankRef.Size = new System.Drawing.Size(147, 20);
        this.txtPaymentBankRef.TabIndex = 27;
        // 
        // chkAutoChecking
        // 
        this.chkAutoChecking.AutoSize = true;
        this.chkAutoChecking.Checked = true;
        this.chkAutoChecking.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkAutoChecking.Location = new System.Drawing.Point(746, 73);
        this.chkAutoChecking.Name = "chkAutoChecking";
        this.chkAutoChecking.Size = new System.Drawing.Size(56, 17);
        this.chkAutoChecking.TabIndex = 26;
        this.chkAutoChecking.Text = "AUTO";
        this.chkAutoChecking.UseVisualStyleBackColor = true;
        // 
        // btnRec
        // 
        this.btnRec.Location = new System.Drawing.Point(743, 33);
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
        this.radOnePayVisa.Location = new System.Drawing.Point(585, 72);
        this.radOnePayVisa.Name = "radOnePayVisa";
        this.radOnePayVisa.Size = new System.Drawing.Size(120, 17);
        this.radOnePayVisa.TabIndex = 18;
        this.radOnePayVisa.Text = "ONEPAY_VIS/MAS";
        this.radOnePayVisa.UseVisualStyleBackColor = true;
        // 
        // radOnePayATM
        // 
        this.radOnePayATM.AutoSize = true;
        this.radOnePayATM.Location = new System.Drawing.Point(396, 72);
        this.radOnePayATM.Name = "radOnePayATM";
        this.radOnePayATM.Size = new System.Drawing.Size(98, 17);
        this.radOnePayATM.TabIndex = 17;
        this.radOnePayATM.Text = "ONEPAY_ATM";
        this.radOnePayATM.UseVisualStyleBackColor = true;
        // 
        // rad123Pay
        // 
        this.rad123Pay.AutoSize = true;
        this.rad123Pay.Checked = true;
        this.rad123Pay.Location = new System.Drawing.Point(230, 72);
        this.rad123Pay.Name = "rad123Pay";
        this.rad123Pay.Size = new System.Drawing.Size(64, 17);
        this.rad123Pay.TabIndex = 16;
        this.rad123Pay.TabStop = true;
        this.rad123Pay.Text = "123PAY";
        this.rad123Pay.UseVisualStyleBackColor = true;
        // 
        // dtpToDate
        // 
        this.dtpToDate.CustomFormat = "MM/dd/yyyy";
        this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        this.dtpToDate.Location = new System.Drawing.Point(595, 35);
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
        this.dtpFromDate.Location = new System.Drawing.Point(435, 36);
        this.dtpFromDate.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
        this.dtpFromDate.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
        this.dtpFromDate.Name = "dtpFromDate";
        this.dtpFromDate.Size = new System.Drawing.Size(113, 20);
        this.dtpFromDate.TabIndex = 14;
        this.dtpFromDate.Value = new System.DateTime(2015, 8, 26, 0, 0, 0, 0);
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(554, 39);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(20, 13);
        this.label1.TabIndex = 3;
        this.label1.Text = "To";
        // 
        // labInfo
        // 
        this.labInfo.AutoSize = true;
        this.labInfo.Location = new System.Drawing.Point(387, 38);
        this.labInfo.Name = "labInfo";
        this.labInfo.Size = new System.Drawing.Size(30, 13);
        this.labInfo.TabIndex = 0;
        this.labInfo.Text = "From";
        // 
        // btnImportFromExcel
        // 
        this.btnImportFromExcel.Location = new System.Drawing.Point(948, 137);
        this.btnImportFromExcel.Name = "btnImportFromExcel";
        this.btnImportFromExcel.Size = new System.Drawing.Size(97, 23);
        this.btnImportFromExcel.TabIndex = 13;
        this.btnImportFromExcel.Text = "ImportFromExcel";
        this.btnImportFromExcel.UseVisualStyleBackColor = true;
        this.btnImportFromExcel.Click += new System.EventHandler(this.btnImportFromExcel_Click);
        // 
        // openFileDialog1
        // 
        this.openFileDialog1.FileName = "openFileDialog1";
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(325, 145);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(133, 13);
        this.label2.TabIndex = 21;
        this.label2.Text = "Tổng số tiền giao dịch treo";
        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(82, 145);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(111, 13);
        this.label3.TabIndex = 23;
        this.label3.Text = "Tổng số tiền file Excel";
        // 
        // txtPayConnectorTotalAmout
        // 
        this.txtPayConnectorTotalAmout.BackColor = System.Drawing.SystemColors.ButtonHighlight;
        this.txtPayConnectorTotalAmout.Location = new System.Drawing.Point(203, 142);
        this.txtPayConnectorTotalAmout.Name = "txtPayConnectorTotalAmout";
        this.txtPayConnectorTotalAmout.ReadOnly = true;
        this.txtPayConnectorTotalAmout.Size = new System.Drawing.Size(100, 20);
        this.txtPayConnectorTotalAmout.TabIndex = 22;
        // 
        // tabReconcilication
        // 
        this.tabReconcilication.Controls.Add(this.tabPage1);
        this.tabReconcilication.Controls.Add(this.tabPage2);
        this.tabReconcilication.Controls.Add(this.tabPage3);
        this.tabReconcilication.Location = new System.Drawing.Point(85, 167);
        this.tabReconcilication.Name = "tabReconcilication";
        this.tabReconcilication.SelectedIndex = 0;
        this.tabReconcilication.Size = new System.Drawing.Size(960, 512);
        this.tabReconcilication.TabIndex = 1;
        // 
        // tabPage1
        // 
        this.tabPage1.Controls.Add(this.grpResult);
        this.tabPage1.Location = new System.Drawing.Point(4, 22);
        this.tabPage1.Name = "tabPage1";
        this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage1.Size = new System.Drawing.Size(952, 486);
        this.tabPage1.TabIndex = 0;
        this.tabPage1.Text = "Giao dịch ghi nhận Vista";
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
        dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.CMND.DefaultCellStyle = dataGridViewCellStyle1;
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
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.Phone.DefaultCellStyle = dataGridViewCellStyle2;
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
        // tabPage2
        // 
        this.tabPage2.Controls.Add(this.dgrTransNotInVista);
        this.tabPage2.Location = new System.Drawing.Point(4, 22);
        this.tabPage2.Name = "tabPage2";
        this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage2.Size = new System.Drawing.Size(952, 486);
        this.tabPage2.TabIndex = 1;
        this.tabPage2.Text = "Giao dịch không ghi nhận vào Vista";
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
        dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle3;
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
        dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle4;
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
        // tabPage3
        // 
        this.tabPage3.Controls.Add(this.dgrTransVistaNotInExcel);
        this.tabPage3.Location = new System.Drawing.Point(4, 22);
        this.tabPage3.Name = "tabPage3";
        this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage3.Size = new System.Drawing.Size(952, 486);
        this.tabPage3.TabIndex = 2;
        this.tabPage3.Text = "Giao dịch Vista không nằm trong file excel";
        this.tabPage3.UseVisualStyleBackColor = true;
        // 
        // dgrTransVistaNotInExcel
        // 
        this.dgrTransVistaNotInExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgrTransVistaNotInExcel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column10,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column11});
        this.dgrTransVistaNotInExcel.Location = new System.Drawing.Point(18, 0);
        this.dgrTransVistaNotInExcel.Name = "dgrTransVistaNotInExcel";
        this.dgrTransVistaNotInExcel.Size = new System.Drawing.Size(916, 480);
        this.dgrTransVistaNotInExcel.TabIndex = 1;
        // 
        // Column6
        // 
        this.Column6.DataPropertyName = "TransC_strPaymentTransRef";
        this.Column6.HeaderText = "Vista_Mã giao dịch";
        this.Column6.Name = "Column6";
        this.Column6.Width = 150;
        // 
        // Column10
        // 
        this.Column10.DataPropertyName = "TransC_lgnNumber";
        this.Column10.HeaderText = "Vista_ Số transaction";
        this.Column10.Name = "Column10";
        this.Column10.Width = 110;
        // 
        // Column7
        // 
        this.Column7.DataPropertyName = "TransC_dtmDateTime";
        this.Column7.HeaderText = "Vista_TG ghi nhận Report";
        this.Column7.Name = "Column7";
        this.Column7.Width = 180;
        // 
        // Column8
        // 
        this.Column8.DataPropertyName = "TransC_dtmRealTransTime";
        this.Column8.HeaderText = "Vista_TG giao dịch";
        this.Column8.Name = "Column8";
        this.Column8.Width = 180;
        // 
        // Column9
        // 
        this.Column9.DataPropertyName = "TransC_curValue";
        this.Column9.HeaderText = "Vista_Số tiền";
        this.Column9.Name = "Column9";
        // 
        // Column11
        // 
        this.Column11.DataPropertyName = "CinOperator_strCode";
        this.Column11.HeaderText = "Vista_Cụm rạp";
        this.Column11.Name = "Column11";
        this.Column11.Width = 130;
        // 
        // label6
        // 
        this.label6.AutoSize = true;
        this.label6.Location = new System.Drawing.Point(418, 167);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(0, 13);
        this.label6.TabIndex = 24;
        // 
        // txtTotalRefundAmount
        // 
        this.txtTotalRefundAmount.BackColor = System.Drawing.SystemColors.ButtonHighlight;
        this.txtTotalRefundAmount.Location = new System.Drawing.Point(464, 142);
        this.txtTotalRefundAmount.Name = "txtTotalRefundAmount";
        this.txtTotalRefundAmount.ReadOnly = true;
        this.txtTotalRefundAmount.Size = new System.Drawing.Size(96, 20);
        this.txtTotalRefundAmount.TabIndex = 31;
        // 
        // txtSheetName
        // 
        this.txtSheetName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
        this.txtSheetName.Location = new System.Drawing.Point(755, 139);
        this.txtSheetName.Name = "txtSheetName";
        this.txtSheetName.Size = new System.Drawing.Size(187, 20);
        this.txtSheetName.TabIndex = 34;
        // 
        // label4
        // 
        this.label4.AutoSize = true;
        this.label4.Location = new System.Drawing.Point(669, 142);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(78, 13);
        this.label4.TabIndex = 35;
        this.label4.Text = "Name of Sheet";
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
        // PaymentChecking
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1128, 691);
        this.Controls.Add(this.label4);
        this.Controls.Add(this.txtSheetName);
        this.Controls.Add(this.txtTotalRefundAmount);
        this.Controls.Add(this.label6);
        this.Controls.Add(this.tabReconcilication);
        this.Controls.Add(this.label3);
        this.Controls.Add(this.txtPayConnectorTotalAmout);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.labTotalTransaction);
        this.Controls.Add(this.btnImportFromExcel);
        this.Controls.Add(this.labTotal);
        this.Controls.Add(this.grpInfoSearch);
        this.MaximizeBox = false;
        this.Name = "PaymentChecking";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "PaymentChecking";
        this.Load += new System.EventHandler(this.OnlinePaymentReconciliation_Load);
        this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PaymentChecking_FormClosed);
        this.grpInfoSearch.ResumeLayout(false);
        this.grpInfoSearch.PerformLayout();
        this.tabReconcilication.ResumeLayout(false);
        this.tabPage1.ResumeLayout(false);
        this.grpResult.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgrOnlinePaymentRec)).EndInit();
        this.tabPage2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgrTransNotInVista)).EndInit();
        this.tabPage3.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgrTransVistaNotInExcel)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    
    #endregion

    private System.Windows.Forms.Label labTotalTransaction;
    private System.Windows.Forms.Label labTotal;
    private System.Windows.Forms.GroupBox grpInfoSearch;
    private System.Windows.Forms.Button btnImportFromExcel;
    private System.Windows.Forms.Button btnRec;
    private System.Windows.Forms.DateTimePicker dtpToDate;
    private System.Windows.Forms.DateTimePicker dtpFromDate;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label labInfo;
    private System.Windows.Forms.RadioButton radOnePayVisa;
    private System.Windows.Forms.RadioButton radOnePayATM;
    private System.Windows.Forms.RadioButton rad123Pay;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtPayConnectorTotalAmout;
    private System.Windows.Forms.TabControl tabReconcilication;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.GroupBox grpResult;
    private System.Windows.Forms.DataGridView dgrOnlinePaymentRec;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.DataGridView dgrTransNotInVista;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.DataGridView dgrTransVistaNotInExcel;
    private System.Windows.Forms.Label label6;
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
    private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
    private System.Windows.Forms.TextBox txtTotalRefundAmount;
    private System.Windows.Forms.CheckBox chkAutoChecking;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.TextBox txtPaymentBankRef;
    private System.Windows.Forms.Button btnRefreshData;
    private System.Windows.Forms.TextBox txtSheetName;
    private System.Windows.Forms.Label label4;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private System.Windows.Forms.Timer timer1;
  }
}