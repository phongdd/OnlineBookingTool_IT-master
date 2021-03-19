namespace OnlineBookingTool
{
  partial class OnlinePaymentReconciliation
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      this.labTotalTransaction = new System.Windows.Forms.Label();
      this.labTotal = new System.Windows.Forms.Label();
      this.comOLRecPageInfo = new System.Windows.Forms.ComboBox();
      this.grpResult = new System.Windows.Forms.GroupBox();
      this.dgrOnlinePaymentRec = new System.Windows.Forms.DataGridView();
      this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.CMND = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.BookingInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.OnePayOrderInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.BankTransaction = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.grpInfoSearch = new System.Windows.Forms.GroupBox();
      this.btnImportFromExcel = new System.Windows.Forms.Button();
      this.btnRec = new System.Windows.Forms.Button();
      this.dtpToDate = new System.Windows.Forms.DateTimePicker();
      this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
      this.label1 = new System.Windows.Forms.Label();
      this.labInfo = new System.Windows.Forms.Label();
      this.rad123Pay = new System.Windows.Forms.RadioButton();
      this.radOnePayATM = new System.Windows.Forms.RadioButton();
      this.radOnePayVisa = new System.Windows.Forms.RadioButton();
      this.radLapTest = new System.Windows.Forms.RadioButton();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.grpResult.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgrOnlinePaymentRec)).BeginInit();
      this.grpInfoSearch.SuspendLayout();
      this.SuspendLayout();
      // 
      // labTotalTransaction
      // 
      this.labTotalTransaction.AutoSize = true;
      this.labTotalTransaction.Location = new System.Drawing.Point(714, 131);
      this.labTotalTransaction.Name = "labTotalTransaction";
      this.labTotalTransaction.Size = new System.Drawing.Size(0, 13);
      this.labTotalTransaction.TabIndex = 19;
      // 
      // labTotal
      // 
      this.labTotal.AutoSize = true;
      this.labTotal.Location = new System.Drawing.Point(100, 151);
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
      this.comOLRecPageInfo.Location = new System.Drawing.Point(967, 125);
      this.comOLRecPageInfo.Name = "comOLRecPageInfo";
      this.comOLRecPageInfo.Size = new System.Drawing.Size(55, 21);
      this.comOLRecPageInfo.TabIndex = 17;
      // 
      // grpResult
      // 
      this.grpResult.Controls.Add(this.dgrOnlinePaymentRec);
      this.grpResult.Location = new System.Drawing.Point(84, 148);
      this.grpResult.Name = "grpResult";
      this.grpResult.Size = new System.Drawing.Size(960, 531);
      this.grpResult.TabIndex = 16;
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
            this.OnePayOrderInfo,
            this.BankTransaction});
      this.dgrOnlinePaymentRec.Location = new System.Drawing.Point(22, 28);
      this.dgrOnlinePaymentRec.Name = "dgrOnlinePaymentRec";
      this.dgrOnlinePaymentRec.Size = new System.Drawing.Size(916, 486);
      this.dgrOnlinePaymentRec.TabIndex = 0;
      // 
      // FirstName
      // 
      this.FirstName.DataPropertyName = "TransC_lgnNumber";
      this.FirstName.HeaderText = "TransactionNumber";
      this.FirstName.Name = "FirstName";
      this.FirstName.Width = 160;
      // 
      // CMND
      // 
      this.CMND.DataPropertyName = "TransC_strType";
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.CMND.DefaultCellStyle = dataGridViewCellStyle1;
      this.CMND.HeaderText = "TransC_strType";
      this.CMND.Name = "CMND";
      this.CMND.Width = 70;
      // 
      // Email
      // 
      this.Email.DataPropertyName = "TransC_dtmDateTime";
      this.Email.HeaderText = "TransC_dtmDateTime";
      this.Email.Name = "Email";
      this.Email.Width = 160;
      // 
      // Phone
      // 
      this.Phone.DataPropertyName = "TransC_curValue";
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.Phone.DefaultCellStyle = dataGridViewCellStyle2;
      this.Phone.HeaderText = "TransC_curValue";
      this.Phone.Name = "Phone";
      this.Phone.Width = 70;
      // 
      // BookingInfo
      // 
      this.BookingInfo.DataPropertyName = "TransC_strBKCardType";
      this.BookingInfo.HeaderText = "TransC_strBKCardType";
      this.BookingInfo.Name = "BookingInfo";
      this.BookingInfo.Width = 200;
      // 
      // OnePayOrderInfo
      // 
      this.OnePayOrderInfo.DataPropertyName = "TransC_strPaymentTransRef";
      this.OnePayOrderInfo.HeaderText = "TransC_strPaymentTransRef";
      this.OnePayOrderInfo.Name = "OnePayOrderInfo";
      this.OnePayOrderInfo.Width = 70;
      // 
      // BankTransaction
      // 
      this.BankTransaction.DataPropertyName = "CinOperator_strCode";
      this.BankTransaction.HeaderText = "CinOperator_strCode";
      this.BankTransaction.Name = "BankTransaction";
      this.BankTransaction.Width = 90;
      // 
      // grpInfoSearch
      // 
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
      // btnImportFromExcel
      // 
      this.btnImportFromExcel.Location = new System.Drawing.Point(84, 123);
      this.btnImportFromExcel.Name = "btnImportFromExcel";
      this.btnImportFromExcel.Size = new System.Drawing.Size(128, 23);
      this.btnImportFromExcel.TabIndex = 13;
      this.btnImportFromExcel.Text = "ImportFromExcel";
      this.btnImportFromExcel.UseVisualStyleBackColor = true;
      this.btnImportFromExcel.Click += new System.EventHandler(this.btnImportFromExcel_Click);
      // 
      // btnRec
      // 
      this.btnRec.Location = new System.Drawing.Point(667, 34);
      this.btnRec.Name = "btnRec";
      this.btnRec.Size = new System.Drawing.Size(75, 23);
      this.btnRec.TabIndex = 14;
      this.btnRec.Text = "Đối soát";
      this.btnRec.UseVisualStyleBackColor = true;
      // 
      // dtpToDate
      // 
      this.dtpToDate.CustomFormat = "MM/dd/yyyy HH:mm:ss tt";
      this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtpToDate.Location = new System.Drawing.Point(440, 35);
      this.dtpToDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
      this.dtpToDate.Name = "dtpToDate";
      this.dtpToDate.Size = new System.Drawing.Size(200, 20);
      this.dtpToDate.TabIndex = 15;
      // 
      // dtpFromDate
      // 
      this.dtpFromDate.CustomFormat = "MM/dd/yyyy HH:mm:ss tt";
      this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtpFromDate.Location = new System.Drawing.Point(150, 36);
      this.dtpFromDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
      this.dtpFromDate.Name = "dtpFromDate";
      this.dtpFromDate.Size = new System.Drawing.Size(200, 20);
      this.dtpFromDate.TabIndex = 14;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(414, 39);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(20, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "To";
      // 
      // labInfo
      // 
      this.labInfo.AutoSize = true;
      this.labInfo.Location = new System.Drawing.Point(114, 38);
      this.labInfo.Name = "labInfo";
      this.labInfo.Size = new System.Drawing.Size(30, 13);
      this.labInfo.TabIndex = 0;
      this.labInfo.Text = "From";
      // 
      // rad123Pay
      // 
      this.rad123Pay.AutoSize = true;
      this.rad123Pay.Location = new System.Drawing.Point(165, 72);
      this.rad123Pay.Name = "rad123Pay";
      this.rad123Pay.Size = new System.Drawing.Size(64, 17);
      this.rad123Pay.TabIndex = 16;
      this.rad123Pay.Text = "123PAY";
      this.rad123Pay.UseVisualStyleBackColor = true;
      // 
      // radOnePayATM
      // 
      this.radOnePayATM.AutoSize = true;
      this.radOnePayATM.Location = new System.Drawing.Point(281, 72);
      this.radOnePayATM.Name = "radOnePayATM";
      this.radOnePayATM.Size = new System.Drawing.Size(98, 17);
      this.radOnePayATM.TabIndex = 17;
      this.radOnePayATM.Text = "ONEPAY_ATM";
      this.radOnePayATM.UseVisualStyleBackColor = true;
      // 
      // radOnePayVisa
      // 
      this.radOnePayVisa.AutoSize = true;
      this.radOnePayVisa.Location = new System.Drawing.Point(440, 72);
      this.radOnePayVisa.Name = "radOnePayVisa";
      this.radOnePayVisa.Size = new System.Drawing.Size(120, 17);
      this.radOnePayVisa.TabIndex = 18;
      this.radOnePayVisa.Text = "ONEPAY_VIS/MAS";
      this.radOnePayVisa.UseVisualStyleBackColor = true;
      // 
      // radLapTest
      // 
      this.radLapTest.AutoSize = true;
      this.radLapTest.Checked = true;
      this.radLapTest.Location = new System.Drawing.Point(606, 72);
      this.radLapTest.Name = "radLapTest";
      this.radLapTest.Size = new System.Drawing.Size(45, 17);
      this.radLapTest.TabIndex = 21;
      this.radLapTest.TabStop = true;
      this.radLapTest.Text = "LAB";
      this.radLapTest.UseVisualStyleBackColor = true;
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.FileName = "openFileDialog1";
      // 
      // OnlinePaymentReconciliation
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1128, 691);
      this.Controls.Add(this.labTotalTransaction);
      this.Controls.Add(this.btnImportFromExcel);
      this.Controls.Add(this.labTotal);
      this.Controls.Add(this.comOLRecPageInfo);
      this.Controls.Add(this.grpResult);
      this.Controls.Add(this.grpInfoSearch);
      this.Name = "OnlinePaymentReconciliation";
      this.Text = "OnlinePaymentReconciliation";
      this.grpResult.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgrOnlinePaymentRec)).EndInit();
      this.grpInfoSearch.ResumeLayout(false);
      this.grpInfoSearch.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label labTotalTransaction;
    private System.Windows.Forms.Label labTotal;
    private System.Windows.Forms.ComboBox comOLRecPageInfo;
    private System.Windows.Forms.GroupBox grpResult;
    private System.Windows.Forms.DataGridView dgrOnlinePaymentRec;
    private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
    private System.Windows.Forms.DataGridViewTextBoxColumn CMND;
    private System.Windows.Forms.DataGridViewTextBoxColumn Email;
    private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
    private System.Windows.Forms.DataGridViewTextBoxColumn BookingInfo;
    private System.Windows.Forms.DataGridViewTextBoxColumn OnePayOrderInfo;
    private System.Windows.Forms.DataGridViewTextBoxColumn BankTransaction;
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
  }
}