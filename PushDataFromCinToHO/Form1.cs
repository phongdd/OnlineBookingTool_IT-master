using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PushDataFromCinToHO
{
    public partial class Form1 : Form
    {
        private string HOConnectionString = "Data Source=10.10.115.10;Initial Catalog=VISTAHOFROMCIN;User Id=sa;Password=GaLaXyNDNTTB126;";
        private string nd_BOConnectionString = "Data Source=192.168.116.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
        private string tb_BOConnectionString = "Data Source=192.168.118.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
        private string kdv_BOConnectionString = "Data Source=192.168.119.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
        private string qt_BOConnectionString = "Data Source=192.168.120.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
        private string bt_BOConnectionString = "Data Source=192.168.130.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
        private string mipec_BOConnectionString = "Data Source=192.168.132.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
        private string danang_BOConnectionString = "Data Source=192.168.133.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
        private string cm_BOConnectionString = "Data Source=192.168.134.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
        private string tc_BOConnectionString = "Data Source=192.168.135.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
        private string pvc_BOConnectionString = "Data Source=192.168.136.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
        private string htp_BOConnectionString = "Data Source=192.168.137.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
        private string vinh_BOConnectionString = "Data Source=192.168.138.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
        private string hp_BOConnectionString = "Data Source=192.168.139.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
        private string nvq_BOConnectionString = "Data Source=192.168.140.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
        private string tt_BOConnectionString = "Data Source=192.168.141.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
        List<string> listCin = new List<string>();
        Inprogress progress;
        string insertCurCin;


        public Form1()
        {
            InitializeComponent();
        }

        public void InsertBulk(string CinConnectionString, string HOConnectionString)
        {
            if (checkedListBox1.CheckedItems.Count != 0)
            {
                for (int x = 0; x < checkedListBox1.CheckedItems.Count; x++)
                {
                    switch (checkedListBox1.CheckedItems[x].ToString())
                    {
                        case "Nguyễn Du":
                            listCin.Add(nd_BOConnectionString);
                            break;
                        case "Tân Bình":
                            listCin.Add(tb_BOConnectionString);
                            break;
                        case "Kinh Dương Vương":
                            listCin.Add(kdv_BOConnectionString);
                            break;
                        case "Quang Trung":
                            listCin.Add(qt_BOConnectionString);
                            break;
                        case "Bến Tre":
                            listCin.Add(bt_BOConnectionString);
                            break;
                        case "Long Biên":
                            listCin.Add(mipec_BOConnectionString);
                            break;
                        case "Đà Nẵng":
                            listCin.Add(danang_BOConnectionString);
                            break;
                        case "Cà Cau":
                            listCin.Add(cm_BOConnectionString);
                            break;
                        case "Trung Chánh":
                            listCin.Add(tc_BOConnectionString);
                            break;
                        case "Phạm Văn Chí":
                            listCin.Add(pvc_BOConnectionString);
                            break;
                        case "Huỳnh Tấn Phát":
                            listCin.Add(htp_BOConnectionString);
                            break;
                        case "Vinh":
                            listCin.Add(vinh_BOConnectionString);
                            break;
                        case "Hải Phòng":
                            listCin.Add(hp_BOConnectionString);
                            break;
                        case "Nguyễn Văn Quá":
                            listCin.Add(nvq_BOConnectionString);
                            break;
                        case "Tràng Thi":
                            listCin.Add(tt_BOConnectionString);
                            break;
                    }
                }
            }

            DateTime fd = dateTimeFromDate.Value;
            DateTime td = dateTimeToDate.Value;

            using (SqlConnection sourceConnection = new SqlConnection(CinConnectionString))
            {
                insertCurCin = sourceConnection.DataSource;
                sourceConnection.Open();

                string selectQuery = "spGLXCOBO";
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(selectQuery, sourceConnection);

                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add(new SqlParameter("@fromdate", fd));
                da.SelectCommand.Parameters.Add(new SqlParameter("@todate", td));
                da.SelectCommand.CommandTimeout = 1200;

                DataTable dt = new DataTable();
                da.Fill(dt);

                // Open the destination connection. In the real world you would 
                // not use SqlBulkCopy to move data from one table to the other 
                // in the same database. This is for demonstration purposes only.
                using (SqlConnection destinationConnection = new SqlConnection(HOConnectionString))
                {
                    destinationConnection.Open();

                    // Set up the bulk copy object. 
                    // Note that the column positions in the source
                    // data reader match the column positions in 
                    // the destination table so there is no need to
                    // map columns.
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection))
                    {
                        bulkCopy.DestinationTableName = "dbo.tblCOBO";

                        try
                        {
                            // Write from the source to the destination.
                            bulkCopy.WriteToServer(dt);
                            writeLog(sourceConnection.DataSource + ".....Done with " + dt.Rows.Count.ToString() + "row(s)");
                        }
                        catch (Exception exception)
                        {
                            writeLog(exception.Message);
                        }
                    }
                }
            }
        }

        public void DeleteData()
        {
            DateTime fd = dateTimeFromDate.Value;
            DateTime td = dateTimeToDate.Value;

            try
            {
                using (SqlConnection destinationConnection = new SqlConnection(HOConnectionString))
                {
                    destinationConnection.Open();

                    SqlCommand commandRowCount = new SqlCommand("DELETE FROM tblCOBO WHERE dtmDateTime >= @fromdate AND dtmDateTime < @todate", destinationConnection);
                    commandRowCount.CommandType = CommandType.Text;
                    commandRowCount.Parameters.Add(new SqlParameter("@fromdate", fd));
                    commandRowCount.Parameters.Add(new SqlParameter("@todate", td));
                    commandRowCount.CommandTimeout = 2000;

                    long countStart = System.Convert.ToInt32(commandRowCount.ExecuteNonQuery());
                    writeLog(string.Format("Deleted {0} row(s) at 10.10.115.10 form {1} to {2}", countStart, fd, td));
                }
            }
            catch (Exception mess)
            {
                writeLog("10.10.115.10. " + mess.Message);
            }
            
        }

        private void writeLog(string log)
        {
            string filename = "SQLLog.txt";
            string path = Application.StartupPath;
            var fullPath = Path.Combine(path, filename);
            System.IO.File.AppendAllText(fullPath, DateTime.Now.ToLongDateString() + " - " + DateTime.Now.ToLongTimeString() + Environment.NewLine);
            System.IO.File.AppendAllText(fullPath, log + Environment.NewLine);
            System.IO.File.AppendAllText(fullPath, "------------------------------------------------------------------------------------------" + Environment.NewLine);
        }

        private void btnInsertToHO_Click(object sender, EventArgs e)
        {
            DeleteData();
            StartBackgroundWorker();
        }

        private void StartBackgroundWorker()
        {
            if (backgroundWorker1.IsBusy != true)
            {
                // create a new instance of the alert form
                progress = new Inprogress();
                Form1 RC = new Form1();

                // event handler for the Cancel button in AlertForm
                progress.Canceled += new EventHandler<EventArgs>(buttonCancel_Click);
                progress.Show();
                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync(RC);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorker1.CancelAsync();
                // Close the AlertForm
                progress.Close();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int percentProgress = 0;
            BackgroundWorker worker = sender as BackgroundWorker;
            worker.ReportProgress(percentProgress);

            foreach (string cin in listCin)
            {
                try
                {
                    InsertBulk(cin, HOConnectionString);
                    percentProgress += 7;
                    if (percentProgress >= 100)
                        worker.ReportProgress(100);
                    else
                        worker.ReportProgress(percentProgress);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string fromDate = string.Format("{0:MM/dd/yyyy}", dateTimeFromDate.Value);
            string toDate = string.Format("{0:MM/dd/yyyy}", dateTimeToDate.Value);
            progress.Message1 = string.Format("Đang insert dữ liệu. Thời gian từ {0} đến {1}....", fromDate, toDate);
            progress.Message2 = string.Format("Cin: {0}.", insertCurCin);
            progress.ProgressValue = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                MessageBox.Show("Canceled!");
            }
            else if (e.Error != null)
            {
                MessageBox.Show(string.Format("Error: {0}", e.Error.Message));
            }
            progress.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }
    }
}
