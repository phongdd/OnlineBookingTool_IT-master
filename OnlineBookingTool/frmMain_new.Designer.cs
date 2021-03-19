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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labInfo = new System.Windows.Forms.Label();
            this.txtInfoSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.grpInfoSearch = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpResult = new System.Windows.Forms.GroupBox();
            this.dgrResult = new System.Windows.Forms.DataGridView();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookingInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OnePayOrderInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BankTransaction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaidStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApproveStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comPageInfo = new System.Windows.Forms.ComboBox();
            this.labPageInfo = new System.Windows.Forms.Label();
            this.labTotal = new System.Windows.Forms.Label();
            this.labTotalTransaction = new System.Windows.Forms.Label();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grpInfoSearch.SuspendLayout();
            this.grpResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrResult)).BeginInit();
            this.SuspendLayout();
            // 
            // labInfo
            // 
            this.labInfo.AutoSize = true;
            this.labInfo.Location = new System.Drawing.Point(104, 37);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(77, 13);
            this.labInfo.TabIndex = 0;
            this.labInfo.Text = "Nhập thông tin";
            // 
            // txtInfoSearch
            // 
            this.txtInfoSearch.Location = new System.Drawing.Point(383, 36);
            this.txtInfoSearch.Name = "txtInfoSearch";
            this.txtInfoSearch.Size = new System.Drawing.Size(120, 20);
            this.txtInfoSearch.TabIndex = 1;
            this.txtInfoSearch.Leave += new System.EventHandler(this.txtInfoSearch_Leave);
            this.txtInfoSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInfoSearch_KeyPress);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(750, 32);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // grpInfoSearch
            // 
            this.grpInfoSearch.Controls.Add(this.label5);
            this.grpInfoSearch.Controls.Add(this.label4);
            this.grpInfoSearch.Controls.Add(this.txtOrderID);
            this.grpInfoSearch.Controls.Add(this.label3);
            this.grpInfoSearch.Controls.Add(this.label2);
            this.grpInfoSearch.Controls.Add(this.txtEmailAddress);
            this.grpInfoSearch.Controls.Add(this.label1);
            this.grpInfoSearch.Controls.Add(this.txtInfoSearch);
            this.grpInfoSearch.Controls.Add(this.btnSearch);
            this.grpInfoSearch.Controls.Add(this.labInfo);
            this.grpInfoSearch.Location = new System.Drawing.Point(29, 12);
            this.grpInfoSearch.Name = "grpInfoSearch";
            this.grpInfoSearch.Size = new System.Drawing.Size(960, 76);
            this.grpInfoSearch.TabIndex = 3;
            this.grpInfoSearch.TabStop = false;
            this.grpInfoSearch.Enter += new System.EventHandler(this.grpInfoSearch_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(587, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Nhập email đặt vé";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(379, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Số CMND, Số điện thoại,...";
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.Location = new System.Drawing.Point(559, 35);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(150, 20);
            this.txtEmailAddress.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(515, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hoặc";
            // 
            // grpResult
            // 
            this.grpResult.Controls.Add(this.dgrResult);
            this.grpResult.Location = new System.Drawing.Point(29, 122);
            this.grpResult.Name = "grpResult";
            this.grpResult.Size = new System.Drawing.Size(960, 538);
            this.grpResult.TabIndex = 4;
            this.grpResult.TabStop = false;
            this.grpResult.Text = "Kết quả";
            this.grpResult.Enter += new System.EventHandler(this.grpResult_Enter);
            // 
            // dgrResult
            // 
            this.dgrResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FirstName,
            this.CMND,
            this.Email,
            this.Phone,
            this.BookingInfo,
            this.OnePayOrderInfo,
            this.BankTransaction,
            this.PaidStatus,
            this.ApproveStatus});
            this.dgrResult.Location = new System.Drawing.Point(22, 28);
            this.dgrResult.Name = "dgrResult";
            this.dgrResult.Size = new System.Drawing.Size(916, 486);
            this.dgrResult.TabIndex = 0;
            // 
            // FirstName
            // 
            this.FirstName.DataPropertyName = "FullName";
            this.FirstName.HeaderText = "Họ tên";
            this.FirstName.Name = "FirstName";
            this.FirstName.Width = 160;
            // 
            // CMND
            // 
            this.CMND.DataPropertyName = "CMND";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CMND.DefaultCellStyle = dataGridViewCellStyle5;
            this.CMND.HeaderText = "CMND";
            this.CMND.Name = "CMND";
            this.CMND.Width = 70;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.Width = 160;
            // 
            // Phone
            // 
            this.Phone.DataPropertyName = "Phone";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Phone.DefaultCellStyle = dataGridViewCellStyle6;
            this.Phone.HeaderText = "Di động";
            this.Phone.Name = "Phone";
            this.Phone.Width = 70;
            // 
            // BookingInfo
            // 
            this.BookingInfo.DataPropertyName = "BookingInfo";
            this.BookingInfo.HeaderText = "Thông tin đặt vé";
            this.BookingInfo.Name = "BookingInfo";
            this.BookingInfo.Width = 200;
            // 
            // OnePayOrderInfo
            // 
            this.OnePayOrderInfo.DataPropertyName = "OnePayOrderInfo";
            this.OnePayOrderInfo.HeaderText = "Mã đơn hàng";
            this.OnePayOrderInfo.Name = "OnePayOrderInfo";
            this.OnePayOrderInfo.Width = 70;
            // 
            // BankTransaction
            // 
            this.BankTransaction.DataPropertyName = "BankTransaction";
            this.BankTransaction.HeaderText = "Mã cổng thanh toán";
            this.BankTransaction.Name = "BankTransaction";
            this.BankTransaction.Width = 90;
            // 
            // PaidStatus
            // 
            this.PaidStatus.DataPropertyName = "PaidStatus";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PaidStatus.DefaultCellStyle = dataGridViewCellStyle7;
            this.PaidStatus.HeaderText = "P";
            this.PaidStatus.Name = "PaidStatus";
            this.PaidStatus.Width = 20;
            // 
            // ApproveStatus
            // 
            this.ApproveStatus.DataPropertyName = "ApproveStatus";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ApproveStatus.DefaultCellStyle = dataGridViewCellStyle8;
            this.ApproveStatus.HeaderText = "A";
            this.ApproveStatus.Name = "ApproveStatus";
            this.ApproveStatus.Width = 20;
            // 
            // comPageInfo
            // 
            this.comPageInfo.DropDownHeight = 120;
            this.comPageInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comPageInfo.DropDownWidth = 55;
            this.comPageInfo.FormattingEnabled = true;
            this.comPageInfo.IntegralHeight = false;
            this.comPageInfo.Location = new System.Drawing.Point(912, 95);
            this.comPageInfo.Name = "comPageInfo";
            this.comPageInfo.Size = new System.Drawing.Size(55, 21);
            this.comPageInfo.TabIndex = 9;
            this.comPageInfo.SelectedIndexChanged += new System.EventHandler(this.comPageInfo_SelectedIndexChanged);
            // 
            // labPageInfo
            // 
            this.labPageInfo.AutoSize = true;
            this.labPageInfo.Location = new System.Drawing.Point(871, 98);
            this.labPageInfo.Name = "labPageInfo";
            this.labPageInfo.Size = new System.Drawing.Size(35, 13);
            this.labPageInfo.TabIndex = 10;
            this.labPageInfo.Text = "Trang";
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
            this.labTotalTransaction.Location = new System.Drawing.Point(771, 98);
            this.labTotalTransaction.Name = "labTotalTransaction";
            this.labTotalTransaction.Size = new System.Drawing.Size(0, 13);
            this.labTotalTransaction.TabIndex = 12;
            // 
            // txtOrderID
            // 
            this.txtOrderID.Location = new System.Drawing.Point(200, 36);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.Size = new System.Drawing.Size(120, 20);
            this.txtOrderID.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(337, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Hoặc";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(185, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = " Mã ngân hàng, Mã đơn hàng";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 648);
            this.Controls.Add(this.labTotalTransaction);
            this.Controls.Add(this.labTotal);
            this.Controls.Add(this.labPageInfo);
            this.Controls.Add(this.comPageInfo);
            this.Controls.Add(this.grpResult);
            this.Controls.Add(this.grpInfoSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Online Booking";
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

        private System.Windows.Forms.Label labInfo;
        private System.Windows.Forms.TextBox txtInfoSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox grpInfoSearch;
        private System.Windows.Forms.GroupBox grpResult;
        private System.Windows.Forms.DataGridView dgrResult;
        private System.Windows.Forms.ComboBox comPageInfo;
        private System.Windows.Forms.Label labPageInfo;
        private System.Windows.Forms.Label labTotal;
        private System.Windows.Forms.TextBox txtEmailAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labTotalTransaction;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMND;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookingInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn OnePayOrderInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BankTransaction;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaidStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApproveStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOrderID;
    }
}

