namespace ExceltoSQLserver
{
  partial class Inprogress
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
          this.labelMessage = new System.Windows.Forms.Label();
          this.progressBar1 = new System.Windows.Forms.ProgressBar();
          this.label1 = new System.Windows.Forms.Label();
          this.SuspendLayout();
          // 
          // labelMessage
          // 
          this.labelMessage.AutoSize = true;
          this.labelMessage.Location = new System.Drawing.Point(70, 17);
          this.labelMessage.Name = "labelMessage";
          this.labelMessage.Size = new System.Drawing.Size(155, 13);
          this.labelMessage.TabIndex = 0;
          this.labelMessage.Text = "Đang load BO các rạp về RAM";
          // 
          // progressBar1
          // 
          this.progressBar1.Location = new System.Drawing.Point(47, 77);
          this.progressBar1.Name = "progressBar1";
          this.progressBar1.Size = new System.Drawing.Size(204, 23);
          this.progressBar1.TabIndex = 1;
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Location = new System.Drawing.Point(44, 44);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(207, 13);
          this.label1.TabIndex = 2;
          this.label1.Text = "Thời gian từ 23/08/2015 đến 27/08/2015";
          // 
          // Inprogress
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(297, 120);
          this.ControlBox = false;
          this.Controls.Add(this.label1);
          this.Controls.Add(this.progressBar1);
          this.Controls.Add(this.labelMessage);
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "Inprogress";
          this.ShowIcon = false;
          this.ShowInTaskbar = false;
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          this.Text = "Processing";
          this.TopMost = true;
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
    }
}