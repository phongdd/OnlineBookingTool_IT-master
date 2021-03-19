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
    public partial class FrmPushData : Form
    {
        List<Cinema> CinList = new List<Cinema>();
        List<Cinema> CinList_HO = new List<Cinema>();

        private string HOConnectionString = "Data Source=10.10.115.10;Initial Catalog=VISTAHOFROMCIN;User Id=sa;Password=GaLaXyNDNTTB126;";
        private string HOStagingConnectionString = "Data Source=192.168.115.1;Initial Catalog=VISTAHO;User Id=sa;Password=GaLaXyNDNTTB126;";
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
        private string bmt_BOConnectionString = "Data Source=192.168.142.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";

        public FrmPushData()
        {
            InitializeComponent();
            LoadData();
        }

        //---------------------Classes---------------------//
        public class Cinema
        {
            public string Name { get; set; }
            public string Connectstring { get; set; }
        }

        //---------------------Functions---------------------//
        private void LoadData()
        {
            //CinList.Add(new Cinema() { Name = "NguyenDu", Connectstring = nd_BOConnectionString });
            //CinList.Add(new Cinema() { Name = "TanBinh", Connectstring = tb_BOConnectionString });
            CinList.Add(new Cinema() { Name = "KinhDuongVuong", Connectstring = kdv_BOConnectionString });
            //CinList.Add(new Cinema() { Name = "QuangTrung", Connectstring = qt_BOConnectionString });
            //CinList.Add(new Cinema() { Name = "BenTre", Connectstring = bt_BOConnectionString });
            //CinList.Add(new Cinema() { Name = "Mipec", Connectstring = mipec_BOConnectionString });
            CinList.Add(new Cinema() { Name = "DaNang", Connectstring = danang_BOConnectionString });
            //CinList.Add(new Cinema() { Name = "CaMau", Connectstring = cm_BOConnectionString });
            //CinList.Add(new Cinema() { Name = "TrungChanh", Connectstring = tc_BOConnectionString });
            //CinList.Add(new Cinema() { Name = "PhamVanChi", Connectstring = pvc_BOConnectionString });
            //CinList.Add(new Cinema() { Name = "HuynhTanPhat", Connectstring = htp_BOConnectionString });
            //CinList.Add(new Cinema() { Name = "Vinh", Connectstring = vinh_BOConnectionString });
            //CinList.Add(new Cinema() { Name = "HaiPhong", Connectstring = hp_BOConnectionString });
            //CinList.Add(new Cinema() { Name = "NguyenVanQua", Connectstring = nvq_BOConnectionString });
            //CinList.Add(new Cinema() { Name = "TrangThi", Connectstring = tt_BOConnectionString });
            //CinList.Add(new Cinema() { Name = "BuonMaThuot", Connectstring = bmt_BOConnectionString });

            CinList_HO.Add(new Cinema() { Name = "HO", Connectstring = HOStagingConnectionString });
        }

        private void writeLog(string log)
        {
            string filename = "SQLLog_" + DateTime.Now.ToString("ddMMyyyy") + ".txt";
            string path = Path.GetDirectoryName(Application.ExecutablePath); // HttpContext.Current.Server.MapPath("~/bin");
            var fullPath = Path.Combine(path, filename);
            System.IO.File.AppendAllText(fullPath, DateTime.Now.ToLongDateString() + " - " + DateTime.Now.ToLongTimeString() + Environment.NewLine);
            System.IO.File.AppendAllText(fullPath, log + Environment.NewLine);
            System.IO.File.AppendAllText(fullPath, "------------------------------------------------------------------------------------------" + Environment.NewLine);
        }

        //0
        private string GetFromDate(String cinName)
        {
            string LastDate = string.Empty;
            string sql = string.Format("SELECT TOP 1 FromDate FROM tbl_ACC_Config_PushData WHERE Cin = '{0}' ORDER BY ID DESC ", cinName);
            using (SqlConnection conn = new SqlConnection(HOConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    LastDate = (string)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    string mess = string.Format("Cin: {0} \n Message: {1}", cinName, ex.Message);
                    writeLog(mess);
                    MessageBox.Show(mess);
                }
            }
            return LastDate;
        }

        private void InsertBulk(string FromDate, string ToDate, Cinema Cin)
        {
            SqlConnection sourceConnection = new SqlConnection(Cin.Connectstring);
            string whereString = string.Empty;
            switch (Cin.Name)
            {
                case "Mipec":
                    whereString = string.Format(" WHERE TransC_dtmDateTime > '{0}' AND TransC_dtmDateTime <= '{1}' AND TransC_strType in ('R', '0000000014') ", FromDate, ToDate);
                    break;
                case "BenTre":
                case "QuangTrung":
                case "CaMau":
                case "DaNang":
                    whereString = string.Format(" WHERE TransC_dtmDateTime > '{0}' AND TransC_dtmDateTime <= '{1}' AND TransC_strType in ('R', '0000000013') ", FromDate, ToDate);
                    break;
                case "NguyenDu":
                case "TanBinh":
                case "KinhDuongVuong":
                case "TrungChanh":
                case "PhamVanChi":
                case "HuynhTanPhat":
                case "Vinh":
                case "HaiPhong":
                case "NguyenVanQua":
                case "TrangThi":
                case "BuonMaThuot":
                    whereString = string.Format(" WHERE TransC_dtmDateTime > '{0}' AND TransC_dtmDateTime <= '{1}' AND TransC_strType in ('R') ", FromDate, ToDate);
                    break;
            }

            string selectQuery = string.Format(@" SELECT newid() AS UID
                    , [TransC_lgnNumber]
                    ,[TransC_strType]
                    ,[TransC_dtmDateTime]
                    ,[TransC_curValue]
                    ,[TransC_strBKCardType]
                    ,[TransC_strPaymentTransRef]
                    ,[TransC_dtmRealTransTime]
                    ,[TransC_strBKCardNo]
                    ,[CinOperator_strCode]
                FROM tblTrans_Cash {0} ", whereString);
            using (sourceConnection)
            {
                sourceConnection.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(selectQuery, sourceConnection);
                da.SelectCommand.CommandType = CommandType.Text;
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
                        bulkCopy.DestinationTableName = "dbo.tbl_Trans_Cash_2019";
                        try
                        {
                            // Write from the source to the destination.
                            bulkCopy.WriteToServer(dt);
                            writeLog(selectQuery + "\n" + Cin.Name + ".....Done with " + dt.Rows.Count.ToString() + "row(s) and " + "from " + FromDate + "to " + ToDate);
                        }
                        catch (Exception exception)
                        {
                            writeLog(selectQuery + "\n" + Cin.Name + ".....insert error with details: " + exception.Message);
                        }
                    }
                }
            }
        }

        private void UpdateFromDate(string curDate, Cinema cin)
        {
            string sql = string.Format("INSERT INTO [tbl_ACC_Config_PushData] (Cin, FromDate) VALUES ('{0}', '{1}')", cin.Name, curDate);
            using (SqlConnection conn = new SqlConnection(HOConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    string mess = string.Format("Cin: {0} \n curDate: {1} \n Message: {2}", cin.Name, curDate, ex.Message);
                    writeLog(mess);
                    MessageBox.Show(mess);
                }
            }
        }

        //1
        private string GetFromDate1(String cinName)
        {
            string LastDate = string.Empty;
            string sql = string.Format("SELECT TOP 1 FromDate FROM tbl_CRM_Config_PushData WHERE Cin = '{0}' ORDER BY ID DESC ", cinName);
            using (SqlConnection conn = new SqlConnection(HOConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    LastDate = (string)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    string mess = string.Format("Cin: {0} \n Message: {1}", cinName, ex.Message);
                    writeLog(mess);
                    MessageBox.Show(mess);
                }
            }
            return LastDate;
        }

        private void InsertBulk1(string fromDate, string toDate, Cinema cin)
        {
            SqlConnection sourceConnection = new SqlConnection(cin.Connectstring);
            string whereString = string.Empty;
            whereString = string.Format(" where vwBookingH_dtmDateBooked > = '{0}' AND vwBookingH_dtmDateBooked < '{1}' ", fromDate, toDate);

            string selectQuery = string.Format(@" Select [vwBookingH_intNextBookingNo]
	                                ,[vwBookingD_intSequence]
	                                ,[vwBookingH_strBookingId]
	                                ,[vwBookingH_strName]
	                                ,[vwBookingH_strPhone]
	                                ,[vwBookingH_curAmountPaid]
	                                ,[vwBookingH_strStatus]
	                                ,[vwTransC_dtmDateTime]
	                                ,[vwBookingH_dtmDateBooked]
	                                ,[vwBookingH_strRemoteBooking]
	                                ,[vwBookingH_strSource]
	                                ,[vwBookingH_strSourceDesc]
	                                ,[vwBookingH_strCardNo]
	                                ,[vwBookingH_strCardType]
	                                ,[vwBookingH_curValueOfBooking]
	                                ,[vwSession_lngSessionId]
	                                ,[vwPGroup_strCode]
                                    ,[vwPrice_strCode] 
	                                ,[vwBookingD_curValue]
	                                ,[vwBookingD_intNoOfSeats]
	                                ,[vwCinema]
	                                ,[vwSessionScreeningTime]
	                                ,[vwSessionStatus]
	                                ,[vwFilm]
	                                ,[vwFilmCode]
                                    ,[vwFilmHOCode]
	                                ,[vwBookingG_intParentBookingNo]
                                    ,[vwTransC_lgnNumber] 
                                FROM [dbo].[viewCabBooking] {0}", whereString);
            using (sourceConnection)
            {
                sourceConnection.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(selectQuery, sourceConnection);
                da.SelectCommand.CommandType = CommandType.Text;
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
                        bulkCopy.DestinationTableName = "dbo.Bookings";
                        try
                        {
                            // Write from the source to the destination.
                            bulkCopy.WriteToServer(dt);
                            writeLog(selectQuery + "\n" + cin.Name + ".....Done with " + dt.Rows.Count.ToString() + "row(s) and " + "from " + fromDate + "to " + toDate);
                        }
                        catch (Exception exception)
                        {
                            writeLog(selectQuery + "\n" + cin.Name + ".....insert error with details: " + exception.Message);
                        }
                    }
                }
            }
        }

        private void UpdateFromDate1(string curDate, Cinema cin)
        {
            string sql = string.Format("INSERT INTO [tbl_CRM_Config_PushData] (Cin, FromDate) VALUES ('{0}', '{1}')", cin.Name, curDate);
            using (SqlConnection conn = new SqlConnection(HOConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    string mess = string.Format("Cin: {0} \n curDate: {1} \n Message: {2}", cin.Name, curDate, ex.Message);
                    writeLog(mess);
                    MessageBox.Show(mess);
                }
            }
        }

        //2
        private string GetFromDate2(String cinName)
        {
            string LastDate = string.Empty;
            string sql = string.Format("SELECT TOP 1 FromDate FROM tbl_MKT_Config_PushData WHERE Cin = '{0}' ORDER BY ID DESC ", cinName);
            using (SqlConnection conn = new SqlConnection(HOConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    LastDate = (string)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    string mess = string.Format("Cin: {0} \n Message: {1}", cinName, ex.Message);
                    writeLog(mess);
                    MessageBox.Show(mess);
                }
            }
            return LastDate;
        }

        private void InsertBulk2(string fromDate, string toDate, Cinema cin)
        {
            SqlConnection sourceConnection = new SqlConnection(cin.Connectstring);
            string whereString = string.Empty;
            whereString = string.Format(" where TransC_strBKCardType = 'APPMOMO' AND TransC_dtmDateTime > = '{0}' AND TransC_dtmDateTime < '{1}' ", fromDate, toDate);

            string selectQuery = string.Format(@" Select * FROM tblTrans_Cash_HO {0}", whereString);
            using (sourceConnection)
            {
                sourceConnection.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(selectQuery, sourceConnection);
                da.SelectCommand.CommandType = CommandType.Text;
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
                        bulkCopy.DestinationTableName = "tblTrans_Cash_HO";
                        try
                        {
                            // Write from the source to the destination.
                            bulkCopy.WriteToServer(dt);
                            writeLog(selectQuery + "\n" + cin.Name + ".....Done with " + dt.Rows.Count.ToString() + "row(s) and " + "from " + fromDate + "to " + toDate);
                        }
                        catch (Exception exception)
                        {
                            writeLog(selectQuery + "\n" + cin.Name + ".....insert error with details: " + exception.Message);
                        }
                    }
                }
            }
        }

        private void UpdateFromDate2(string curDate, Cinema cin)
        {
            string sql = string.Format("INSERT INTO tbl_MKT_Config_PushData (Cin, FromDate) VALUES ('{0}', '{1}')", cin.Name, curDate);
            using (SqlConnection conn = new SqlConnection(HOConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    string mess = string.Format("Cin: {0} \n curDate: {1} \n Message: {2}", cin.Name, curDate, ex.Message);
                    writeLog(mess);
                    MessageBox.Show(mess);
                }
            }
        }

        //3
        private string GetFromDate3(String cinName)
        {
            string LastDate = string.Empty;
            string sql = string.Format("SELECT TOP 1 FromDate FROM tbl_OPR_Config_PushData WHERE Cin = '{0}' ORDER BY ID DESC ", cinName);
            using (SqlConnection conn = new SqlConnection(HOConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    LastDate = (string)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    string mess = string.Format("Cin: {0} \n Message: {1}", cinName, ex.Message);
                    writeLog(mess);
                    MessageBox.Show(mess);
                }
            }
            return LastDate;
        }

        private void InsertBulk3(string fromDate, string toDate, Cinema cin)
        {
            SqlConnection sourceConnection = new SqlConnection(cin.Connectstring);
            string selectQuery = "spGLXCOBO";

            using (sourceConnection)
            {
                sourceConnection.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(selectQuery, sourceConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add(new SqlParameter("@fromdate", fromDate));
                da.SelectCommand.Parameters.Add(new SqlParameter("@todate", toDate));
                da.SelectCommand.CommandTimeout = 120000;

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
                        bulkCopy.DestinationTableName = "tblCOBO"; //tblTrans_Cash_Ticket_Inv_Temp
                        try
                        {
                            // Write from the source to the destination.
                            bulkCopy.WriteToServer(dt);
                            writeLog(selectQuery + "\n" + cin.Name + ".....Done with " + dt.Rows.Count.ToString() + "row(s) and " + "from " + fromDate + "to " + toDate);
                        }
                        catch (Exception exception)
                        {
                            writeLog(selectQuery + "\n" + cin.Name + ".....insert error with details: " + exception.Message);
                        }
                    }
                }
            }
        }

        private void UpdateFromDate3(string curDate, Cinema cin)
        {
            string sql = string.Format("INSERT INTO tbl_OPR_Config_PushData (Cin, FromDate) VALUES ('{0}', '{1}')", cin.Name, curDate);
            using (SqlConnection conn = new SqlConnection(HOConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    string mess = string.Format("Cin: {0} \n curDate: {1} \n Message: {2}", cin.Name, curDate, ex.Message);
                    writeLog(mess);
                    MessageBox.Show(mess);
                }
            }
        }

        //---------------------Events---------------------//
        //0
        private void btnInsertDuLieuDoiSoat_Click(object sender, EventArgs e)
        {
            string ToDate = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
            foreach (Cinema Cin in CinList)
            {
                string FromDate = GetFromDate(Cin.Name);
                if (FromDate == null) FromDate = "2019-01-01 00:00:00";
                InsertBulk(FromDate, ToDate, Cin);
                UpdateFromDate(ToDate, Cin);
            }
        }

        //1
        private void btnInsertDuLieuThanhToanOnline_Click(object sender, EventArgs e)
        {
            string ToDate = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
            foreach (Cinema Cin in CinList)
            {
                string FromDate = GetFromDate1(Cin.Name);
                if (FromDate == null) FromDate = "2019-01-01 00:00:00";
                InsertBulk1(FromDate, ToDate, Cin);
                UpdateFromDate1(ToDate, Cin);
            }
        }

        //2
        private void btnInsertDuLieuAPPMOMO_Click(object sender, EventArgs e)
        {
            string ToDate = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
            foreach (Cinema Cin in CinList_HO)
            {
                string FromDate = GetFromDate2(Cin.Name);
                if (FromDate == null) FromDate = "2019-01-01 00:00:00";
                InsertBulk2(FromDate, ToDate, Cin);
                UpdateFromDate2(ToDate, Cin);
            }
        }

        //3
        private void btnInsertDuLieuMuaBOCO_Click(object sender, EventArgs e)
        {
            //string ToDate = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
            string ToDate = "2019-09-01 06:00:00";
            foreach (Cinema Cin in CinList)
            {
                string FromDate = null; // GetFromDate3(Cin.Name);
                if (FromDate == null) FromDate = "2019-08-01 06:00:00";
                InsertBulk3(FromDate, ToDate, Cin);
                //UpdateFromDate3(ToDate, Cin);
            }
        }
    }
}
