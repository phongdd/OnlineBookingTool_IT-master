namespace PushDataFromCinToHO
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
            this.btnInsertToHO = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dateTimeFromDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimeToDate = new System.Windows.Forms.DateTimePicker();
            this.btnDelete = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // btnInsertToHO
            // 
            this.btnInsertToHO.Location = new System.Drawing.Point(188, 35);
            this.btnInsertToHO.Name = "btnInsertToHO";
            this.btnInsertToHO.Size = new System.Drawing.Size(75, 23);
            this.btnInsertToHO.TabIndex = 0;
            this.btnInsertToHO.Text = "Insert to HO";
            this.btnInsertToHO.UseVisualStyleBackColor = true;
            this.btnInsertToHO.Click += new System.EventHandler(this.btnInsertToHO_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // dateTimeFromDate
            // 
            this.dateTimeFromDate.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            this.dateTimeFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeFromDate.Location = new System.Drawing.Point(12, 12);
            this.dateTimeFromDate.Name = "dateTimeFromDate";
            this.dateTimeFromDate.Size = new System.Drawing.Size(170, 20);
            this.dateTimeFromDate.TabIndex = 1;
            this.dateTimeFromDate.Value = new System.DateTime(2019, 6, 7, 6, 0, 0, 0);
            // 
            // dateTimeToDate
            // 
            this.dateTimeToDate.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            this.dateTimeToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeToDate.Location = new System.Drawing.Point(12, 38);
            this.dateTimeToDate.Name = "dateTimeToDate";
            this.dateTimeToDate.Size = new System.Drawing.Size(170, 20);
            this.dateTimeToDate.TabIndex = 2;
            this.dateTimeToDate.Value = new System.DateTime(2019, 6, 7, 6, 0, 0, 0);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(269, 35);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Nguyễn Du",
            "Tân Bình",
            "Kinh Dương Vương",
            "Quang Trung",
            "Bến Tre",
            "Long Biên",
            "Đà Nẵng",
            "Cà Cau",
            "Trung Chánh",
            "Phạm Văn Chí",
            "Huỳnh Tấn Phát",
            "Vinh",
            "Hải Phòng",
            "Nguyễn Văn Quá",
            "Tràng Thi"});
            this.checkedListBox1.Location = new System.Drawing.Point(13, 65);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(169, 244);
            this.checkedListBox1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 319);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dateTimeToDate);
            this.Controls.Add(this.dateTimeFromDate);
            this.Controls.Add(this.btnInsertToHO);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Insert BO & CO To HO";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInsertToHO;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DateTimePicker dateTimeFromDate;
        private System.Windows.Forms.DateTimePicker dateTimeToDate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}

