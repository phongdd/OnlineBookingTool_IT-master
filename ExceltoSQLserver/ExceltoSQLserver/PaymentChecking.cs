using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;

namespace ExceltoSQLserver
{
  public partial class PaymentChecking : Form
  {
      public PaymentChecking()
    {
      InitializeComponent();
      this.tblReconciliationMatch = new DataTable("tblReconciliationMatch");
      this.tblExcelRefundTrans = new DataTable("tblExcelRefundTrans");
      this.tblExcelRefundTransNotInTime = new DataTable("tblExcelRefundTransNotInTime");
      this.tbl_Temp_Trans_Refund = new DataTable("tbl_Temp_Trans_Refund");
      this.tblBO_DBTransTicketRefund = new DataTable("tblBO_DBTransTicketRefund");
      this.tblExcelTrans = new DataTable("tblExcelTrans");
      this.tblBO_DBTrans = new DataTable("tblBO_DBTrans");
      this.tblTemp_BO_DBTrans = new DataTable("tblTemp_BO_DBTrans");
      this.tblVISTAIT_OLTrans = new DataTable("tblVISTAIT_OLTrans");
      this.tblBO_DBTransNotInExcel = new DataTable("tblBO_DBTransNotInExcel");
      this.tblReconciliationNotMatch = new DataTable("tblReconciliationNotMatch");
      this.con = new SqlConnection();
      //17/12/2015: Vien chinh sua vi server 116.201 dang off
      //this.OpenConnection(this.lab_connectionString_OPTR);
      this.adapter = new SqlDataAdapter();
      this.CreatTable();
    }

    #region Fields
    private AlertForm alert;
    private Inprogress progress;
    private DataTable tblReconciliationMatch;
    private DataTable tbl_Temp_Trans_Refund;
    private DataTable tblExcelRefundTrans;
    private DataTable tblExcelRefundTransNotInTime;
    private DataTable tblExcelTrans;
    private DataTable tblBO_DBTrans;
    private DataTable tblTemp_BO_DBTrans;
    private DataTable tblBO_DBTransTicketRefund;
    private DataTable tblVISTAIT_OLTrans;
    private DataTable tblReconciliationNotMatch;
    private DataTable tblBO_DBTransNotInExcel;
    DataSet ds = new DataSet("DataSet");
    private SqlConnection con;
    private bool isDuplicate = false;
    private bool importExcel = false;
    private bool reconciliation = false;
    private bool importExcelRefund = false;
    private static readonly Regex ShortDate = new Regex(@"^\d{6}$");
    private static readonly Regex LongDate = new Regex(@"^\d{8}$");


    ////live connection string

    private string lab_connectionString_OPTR = "Data Source=192.168.116.201;Initial Catalog=OPTR;User Id=sa;Password=GaLaXyNDNTTB126;";
    //private string connectionString_VISTAIT = "Data Source=192.168.116.5;Initial Catalog=VISTAIT_41;User Id=sa;Password=GaLaXyNDNTTB126;";
    private string nd_BOConnectionString = "Data Source=192.168.116.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
    private string nt_BOConnectionString = "Data Source=192.168.117.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
    private string tb_BOConnectionString = "Data Source=192.168.118.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;Connection Timeout=120;";
    private string kdv_BOConnectionString = "Data Source=192.168.119.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
    private string qt_BOConnectionString = "Data Source=192.168.120.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
    private string bt_BOConnectionString = "Data Source=192.168.130.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
    private string mipecHN_BOConnectionString = "Data Source=192.168.132.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
    private string dn_BOConnectionString = "Data Source=192.168.133.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
    private string q12_BOConnectionString = "Data Source=192.168.134.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
    private SqlDataAdapter adapter;
    //private SqlCommand command;

    #endregion Fields

    #region Properties

    string Lab_connectionString_OPTR
    {
      get
      {
        return this.lab_connectionString_OPTR;
      }
      set
      {
        this.lab_connectionString_OPTR = value;
      }
    }

    #endregion Properties.

    #region Methods


    private void OpenConnection(string conString)
    {
      if (this.con.State == ConnectionState.Open)
      {
        this.con.Close();
      }
      this.con.ConnectionString = conString;
      this.con.Open();
    }
    private void CloseConnection()
    {
      if (this.con.State == ConnectionState.Open)
        this.con.Close();
    }


    private void CreatTable()
    {
      this.tblReconciliationMatch.Columns.Add("No", typeof(string));
      this.tblReconciliationMatch.Columns.Add("TransC_excel_strPaymentTransRef", typeof(string));
      this.tblReconciliationMatch.Columns.Add("TransC_excel_strType", typeof(string));
      this.tblReconciliationMatch.Columns.Add("TransC_excel_dtmDateTime", typeof(DateTime));
      this.tblReconciliationMatch.Columns.Add("TransC_excel_curValue", typeof(string));
      this.tblReconciliationMatch.Columns.Add("TransC_strPaymentTransRef", typeof(string));
      this.tblReconciliationMatch.Columns.Add("TransC_strType", typeof(string));
      this.tblReconciliationMatch.Columns.Add("TransC_dtmDateTime", typeof(DateTime));
      this.tblReconciliationMatch.Columns.Add("TransC_dtmRealTransTime", typeof(DateTime));
      this.tblReconciliationMatch.Columns.Add("TransC_curValue", typeof(string));

      this.tblReconciliationNotMatch.Columns.Add("No", typeof(string));
      this.tblReconciliationNotMatch.Columns.Add("TransC_excel_strPaymentTransRef", typeof(string));
      this.tblReconciliationNotMatch.Columns.Add("TransC_excel_strType", typeof(string));
      this.tblReconciliationNotMatch.Columns.Add("TransC_excel_dtmDateTime", typeof(DateTime));
      this.tblReconciliationNotMatch.Columns.Add("TransC_excel_curValue", typeof(string));
      this.tblReconciliationNotMatch.Columns.Add("TransC_strPaymentTransRef", typeof(string));
      this.tblReconciliationNotMatch.Columns.Add("TransC_strType", typeof(string));
      this.tblReconciliationNotMatch.Columns.Add("TransC_dtmDateTime", typeof(DateTime));
      this.tblReconciliationNotMatch.Columns.Add("TransC_dtmRealTransTime", typeof(DateTime));
      this.tblReconciliationNotMatch.Columns.Add("TransC_curValue", typeof(string));



      this.tblExcelRefundTrans.Columns.Add("No", typeof(string));
      this.tblExcelRefundTrans.Columns.Add("TransC_excel_strPaymentTransRef", typeof(string));
      this.tblExcelRefundTrans.Columns.Add("TransC_excel_strType", typeof(string));
      this.tblExcelRefundTrans.Columns.Add("TransC_excel_dtmDateTime", typeof(string));
      this.tblExcelRefundTrans.Columns.Add("TransC_excel_curValue", typeof(string));

      this.tblExcelRefundTransNotInTime.Columns.Add("No", typeof(string));
      this.tblExcelRefundTransNotInTime.Columns.Add("TransC_excel_strPaymentTransRef", typeof(string));
      this.tblExcelRefundTransNotInTime.Columns.Add("TransC_excel_strType", typeof(string));
      this.tblExcelRefundTransNotInTime.Columns.Add("TransC_excel_dtmDateTime", typeof(string));
      this.tblExcelRefundTransNotInTime.Columns.Add("TransC_excel_curValue", typeof(string));


      this.tblExcelTrans.Columns.Add("No", typeof(string));
      this.tblExcelTrans.Columns.Add("TransC_excel_strPaymentTransRef", typeof(string));
      this.tblExcelTrans.Columns.Add("TransC_excel_strType", typeof(string));
      this.tblExcelTrans.Columns.Add("TransC_excel_dtmDateTime", typeof(string));
      this.tblExcelTrans.Columns.Add("TransC_excel_curValue", typeof(string));
      this.tblExcelTrans.Columns.Add("TransC_strPaymentTransRef", typeof(string));
      this.tblExcelTrans.Columns.Add("TransC_strType", typeof(string));
      this.tblExcelTrans.Columns.Add("TransC_dtmDateTime", typeof(DateTime));
      this.tblExcelTrans.Columns.Add("TransC_dtmRealTransTime", typeof(DateTime));
      this.tblExcelTrans.Columns.Add("TransC_curValue", typeof(string));
      //this.tblExcelTrans.PrimaryKey = new DataColumn[] { this.tblExcelTrans.Columns["TransC_excel_strPaymentTransRef"] };


      this.tblBO_DBTrans.Columns.Add("TransC_lgnNumber", typeof(string));
      this.tblBO_DBTrans.Columns.Add("TransC_strType", typeof(string));
      this.tblBO_DBTrans.Columns.Add("TransC_dtmDateTime", typeof(DateTime));
      this.tblBO_DBTrans.Columns.Add("TransC_dtmRealTransTime", typeof(DateTime));
      this.tblBO_DBTrans.Columns.Add("TransC_curValue", typeof(string));
      this.tblBO_DBTrans.Columns.Add("TransC_strBKCardType", typeof(string));
      this.tblBO_DBTrans.Columns.Add("TransC_strPaymentTransRef", typeof(string));
      this.tblBO_DBTrans.Columns.Add("CinOperator_strCode", typeof(string));

      this.tblTemp_BO_DBTrans.Columns.Add("TransC_lgnNumber", typeof(string));
      this.tblTemp_BO_DBTrans.Columns.Add("TransC_strType", typeof(string));
      this.tblTemp_BO_DBTrans.Columns.Add("TransC_dtmDateTime", typeof(DateTime));
      this.tblTemp_BO_DBTrans.Columns.Add("TransC_dtmRealTransTime", typeof(DateTime));
      this.tblTemp_BO_DBTrans.Columns.Add("TransC_curValue", typeof(string));
      this.tblTemp_BO_DBTrans.Columns.Add("TransC_strBKCardType", typeof(string));
      this.tblTemp_BO_DBTrans.Columns.Add("TransC_strPaymentTransRef", typeof(string));
      this.tblTemp_BO_DBTrans.Columns.Add("CinOperator_strCode", typeof(string));
      //this.tblBO_DBTrans.PrimaryKey = new DataColumn[] { this.tblBO_DBTrans.Columns["TransC_strPaymentTransRef"] };

      this.tbl_Temp_Trans_Refund.Columns.Add("TransC_lgnNumber", typeof(string));
      this.tbl_Temp_Trans_Refund.Columns.Add("TransC_strType", typeof(string));
      this.tbl_Temp_Trans_Refund.Columns.Add("TransC_dtmDateTime", typeof(DateTime));
      this.tbl_Temp_Trans_Refund.Columns.Add("TransC_dtmRealTransTime", typeof(DateTime));
      this.tbl_Temp_Trans_Refund.Columns.Add("TransC_curValue", typeof(string));
      this.tbl_Temp_Trans_Refund.Columns.Add("TransC_strBKCardType", typeof(string));
      this.tbl_Temp_Trans_Refund.Columns.Add("TransC_strPaymentTransRef", typeof(string));
      this.tbl_Temp_Trans_Refund.Columns.Add("CinOperator_strCode", typeof(string));

      this.tblBO_DBTransTicketRefund.Columns.Add("TransC_lgnNumber", typeof(string));
      this.tblBO_DBTransTicketRefund.Columns.Add("TransC_strType", typeof(string));
      this.tblBO_DBTransTicketRefund.Columns.Add("TransC_dtmDateTime", typeof(DateTime));
      this.tblBO_DBTransTicketRefund.Columns.Add("TransC_dtmRealTransTime", typeof(DateTime));
      this.tblBO_DBTransTicketRefund.Columns.Add("TransC_curValue", typeof(string));
      this.tblBO_DBTransTicketRefund.Columns.Add("TransC_strBKCardType", typeof(string));
      this.tblBO_DBTransTicketRefund.Columns.Add("TransC_strPaymentTransRef", typeof(string));
      this.tblBO_DBTransTicketRefund.Columns.Add("CinOperator_strCode", typeof(string));
      /*
      this.tblBO_DBTransTicketRefund.Columns.Add("TransT_lgnNumber", typeof(string));
      this.tblBO_DBTransTicketRefund.Columns.Add("TransT_curValueEach", typeof(string));
      this.tblBO_DBTransTicketRefund.Columns.Add("TransT_strType", typeof(string));
      this.tblBO_DBTransTicketRefund.Columns.Add("TransT_strStatus", typeof(string));
      this.tblBO_DBTransTicketRefund.Columns.Add("TransT_dtmRealTransTime", typeof(DateTime));
      this.tblBO_DBTransTicketRefund.Columns.Add("CinOperator_strCode", typeof(string));
      */

      this.tblVISTAIT_OLTrans.Columns.Add("WebPayTN_lngPayTransNumber", typeof(string));
      this.tblVISTAIT_OLTrans.Columns.Add("WebPayH_strBankRef", typeof(string));
      //this.tblVISTAIT_OLTrans.Columns.Add("OrderH_strBookingRef", typeof(string));
      this.tblVISTAIT_OLTrans.Columns.Add("OrderH_intVistaBookingNumber", typeof(string));
      this.tblVISTAIT_OLTrans.Columns.Add("OrderH_dtmLastUpdated", typeof(DateTime));

      this.tblBO_DBTransNotInExcel.Columns.Add("TransC_lgnNumber", typeof(string));
      this.tblBO_DBTransNotInExcel.Columns.Add("TransC_strType", typeof(string));
      this.tblBO_DBTransNotInExcel.Columns.Add("TransC_dtmDateTime", typeof(DateTime));
      this.tblBO_DBTransNotInExcel.Columns.Add("TransC_dtmRealTransTime", typeof(DateTime));
      this.tblBO_DBTransNotInExcel.Columns.Add("TransC_curValue", typeof(string));
      this.tblBO_DBTransNotInExcel.Columns.Add("TransC_strBKCardType", typeof(string));
      this.tblBO_DBTransNotInExcel.Columns.Add("TransC_strPaymentTransRef", typeof(string));
      this.tblBO_DBTransNotInExcel.Columns.Add("CinOperator_strCode", typeof(string));
      //this.tblBO_DBTransNotInExcel.PrimaryKey = new DataColumn[] { this.tblBO_DBTransNotInExcel.Columns["TransC_strPaymentTransRef"] };     
    }
    private void ClearAllTables()
    {
      this.tblReconciliationMatch.Rows.Clear();
      this.tblReconciliationNotMatch.Rows.Clear();
      this.tblExcelRefundTrans.Rows.Clear();
      this.tblExcelRefundTransNotInTime.Rows.Clear();
      this.tblExcelTrans.Rows.Clear();
      //this.tblBO_DBTrans.Rows.Clear();
      this.tblBO_DBTransNotInExcel.Rows.Clear();

      this.tblVISTAIT_OLTrans.Rows.Clear();
    }
    private void RefreshData()
    {
      this.labTotalTransaction.Text = string.Empty;
      this.StartBackgroundWorker();
    }
    private void DataCaching(System.ComponentModel.BackgroundWorker worker, System.ComponentModel.DoWorkEventArgs e, string fromDate, string toDate)
    {
      //int elapsedTime = 20;
      DateTime lastReportDateTime = DateTime.Now;
      this.tblBO_DBTrans.Rows.Clear();
      string selectString = string.Empty;
      string fromString = string.Empty;
      string orderByString = string.Empty;
      string sqlCommandString = selectString + fromString + orderByString;
      string whereString = string.Empty;

      selectString = "SELECT TransC_lgnNumber, TransC_strType, TransC_dtmDateTime, TransC_dtmRealTransTime, TransC_curValue, TransC_strBKCardType, TransC_strPaymentTransRef, CinOperator_strCode";
      fromString = " FROM tblTrans_Cash";
      orderByString = " ORDER BY TransC_dtmRealTransTime ASC";
      whereString = string.Format(" WHERE (TransC_dtmRealTransTime BETWEEN '{0}' AND '{1}') AND (TransC_strType = 'R' OR TransC_strType = '0000000013') AND TransC_strBKCardType <> '123PHIM' ", fromDate, toDate);

      sqlCommandString = selectString + fromString + whereString + orderByString;
      //NGUYEN DU LOADING
      this.OpenConnection(this.nd_BOConnectionString);
      this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
      this.adapter.SelectCommand.CommandType = CommandType.Text;
      this.adapter.SelectCommand.CommandTimeout = 0;
      this.tblTemp_BO_DBTrans.Rows.Clear();

      this.adapter.Fill(this.tblTemp_BO_DBTrans);
      
      TimeSpan t = DateTime.Now - lastReportDateTime;
      //worker.ReportProgress((int)(t.TotalSeconds * 100 / 180));
      
        
      this.AddRowToTables(this.tblTemp_BO_DBTrans);
      worker.ReportProgress(20);
      //NGUYEN TRAI LOADING
      this.OpenConnection(this.nt_BOConnectionString);
      this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
      this.adapter.SelectCommand.CommandType = CommandType.Text;
      this.adapter.SelectCommand.CommandTimeout = 0;
      this.tblTemp_BO_DBTrans.Rows.Clear();
      this.adapter.Fill(this.tblTemp_BO_DBTrans);
      t = DateTime.Now - lastReportDateTime;
      //worker.ReportProgress((int)(t.TotalSeconds * 100 / 180));
      

      this.AddRowToTables(this.tblTemp_BO_DBTrans);
      worker.ReportProgress(40);
      //TAN BINH LOADING
      this.OpenConnection(this.tb_BOConnectionString);
      this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
      this.adapter.SelectCommand.CommandType = CommandType.Text;
      this.adapter.SelectCommand.CommandTimeout = 0;
      this.tblTemp_BO_DBTrans.Rows.Clear();
      this.adapter.Fill(this.tblTemp_BO_DBTrans);

      t = DateTime.Now - lastReportDateTime;
      //worker.ReportProgress((int)(t.TotalSeconds * 100 / 180));
      
      this.AddRowToTables(this.tblTemp_BO_DBTrans);
      worker.ReportProgress(60);
      //KDV LOADING
      this.OpenConnection(this.kdv_BOConnectionString);
      this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
      this.adapter.SelectCommand.CommandType = CommandType.Text;
      this.adapter.SelectCommand.CommandTimeout = 0;
      this.tblTemp_BO_DBTrans.Rows.Clear();
      this.adapter.Fill(this.tblTemp_BO_DBTrans);
      t = DateTime.Now - lastReportDateTime;
      //worker.ReportProgress((int)(t.TotalSeconds * 100 / 180));

      this.AddRowToTables(this.tblTemp_BO_DBTrans);
      worker.ReportProgress(80);
      //QUANG TRUNG LOADING
      this.OpenConnection(this.qt_BOConnectionString);
      this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
      this.adapter.SelectCommand.CommandType = CommandType.Text;
      this.adapter.SelectCommand.CommandTimeout = 0;
      this.tblTemp_BO_DBTrans.Rows.Clear();
      this.adapter.Fill(this.tblTemp_BO_DBTrans);
      t = DateTime.Now - lastReportDateTime;
      int finalPercent = (int)(t.TotalSeconds * 100 / 180);

      if (finalPercent < 100 || finalPercent > 100)
        finalPercent = 100;

      //worker.ReportProgress(finalPercent);

      this.AddRowToTables(this.tblTemp_BO_DBTrans);
      worker.ReportProgress(100);
      //END LOADING
      this.tblTemp_BO_DBTrans.Rows.Clear();

      long totalTranscMoney = 0;
      for (int i = 0; i < this.tblBO_DBTrans.Rows.Count; i++)
      {
        string[] tmpMoney = ((string)this.tblBO_DBTrans.Rows[i]["TransC_curValue"]).Split('.');
        if (tmpMoney.Length > 0)
          if (IsNumeric(tmpMoney[0]))
            totalTranscMoney += long.Parse(tmpMoney[0]);
      }

      string sFormat = string.Format("#{0}###", ",");
      //this.txtVistaTotalAmount.Text = (totalTranscMoney * 1000).ToString(sFormat);
      //worker.ReportProgress(100);
    }
    private void DataCaching(string fromDate, string toDate)
    {
      //int elapsedTime = 20;
      DateTime lastReportDateTime = DateTime.Now;
      this.tblBO_DBTrans.Rows.Clear();
      string selectString = string.Empty;
      string fromString = string.Empty;
      string orderByString = string.Empty;
      string sqlCommandString = selectString + fromString + orderByString;
      string whereString = string.Empty;

      selectString = "SELECT TransC_lgnNumber, TransC_strType, TransC_dtmDateTime, TransC_dtmRealTransTime, TransC_curValue, TransC_strBKCardType, TransC_strPaymentTransRef, CinOperator_strCode";
      fromString = " FROM tblTrans_Cash";
      orderByString = " ORDER BY TransC_dtmRealTransTime ASC";
      whereString = string.Format(" WHERE (TransC_dtmRealTransTime BETWEEN '{0}' AND '{1}') AND (TransC_strType = 'R' OR TransC_strType = '0000000013') AND TransC_strBKCardType <> '123PHIM' ", fromDate, toDate);

      sqlCommandString = selectString + fromString + whereString + orderByString;
      //NGUYEN DU LOADING
      this.OpenConnection(this.nd_BOConnectionString);
      this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
      this.adapter.SelectCommand.CommandType = CommandType.Text;
      this.adapter.SelectCommand.CommandTimeout = 0;
      this.tblTemp_BO_DBTrans.Rows.Clear();

      this.adapter.Fill(this.tblTemp_BO_DBTrans);

      TimeSpan t = DateTime.Now - lastReportDateTime;
      //worker.ReportProgress((int)(t.TotalSeconds * 100 / 180));


      this.AddRowToTables(this.tblTemp_BO_DBTrans);
      //worker.ReportProgress(20);
      //NGUYEN TRAI LOADING
      this.OpenConnection(this.nt_BOConnectionString);
      this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
      this.adapter.SelectCommand.CommandType = CommandType.Text;
      this.adapter.SelectCommand.CommandTimeout = 0;
      this.tblTemp_BO_DBTrans.Rows.Clear();
      this.adapter.Fill(this.tblTemp_BO_DBTrans);
      t = DateTime.Now - lastReportDateTime;
      //worker.ReportProgress((int)(t.TotalSeconds * 100 / 180));


      this.AddRowToTables(this.tblTemp_BO_DBTrans);
      //worker.ReportProgress(40);
      //TAN BINH LOADING
      this.OpenConnection(this.tb_BOConnectionString);
      this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
      this.adapter.SelectCommand.CommandType = CommandType.Text;
      this.adapter.SelectCommand.CommandTimeout = 0;
      this.tblTemp_BO_DBTrans.Rows.Clear();
      this.adapter.Fill(this.tblTemp_BO_DBTrans);

      t = DateTime.Now - lastReportDateTime;
      //worker.ReportProgress((int)(t.TotalSeconds * 100 / 180));

      this.AddRowToTables(this.tblTemp_BO_DBTrans);
      //worker.ReportProgress(60);
      //KDV LOADING
      this.OpenConnection(this.kdv_BOConnectionString);
      this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
      this.adapter.SelectCommand.CommandType = CommandType.Text;
      this.adapter.SelectCommand.CommandTimeout = 0;
      this.tblTemp_BO_DBTrans.Rows.Clear();
      this.adapter.Fill(this.tblTemp_BO_DBTrans);
      t = DateTime.Now - lastReportDateTime;
      //worker.ReportProgress((int)(t.TotalSeconds * 100 / 180));

      this.AddRowToTables(this.tblTemp_BO_DBTrans);
      //worker.ReportProgress(80);
      //QUANG TRUNG LOADING
      this.OpenConnection(this.qt_BOConnectionString);
      this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
      this.adapter.SelectCommand.CommandType = CommandType.Text;
      this.adapter.SelectCommand.CommandTimeout = 0;
      this.tblTemp_BO_DBTrans.Rows.Clear();
      this.adapter.Fill(this.tblTemp_BO_DBTrans);
      t = DateTime.Now - lastReportDateTime;
      int finalPercent = (int)(t.TotalSeconds * 100 / 180);

      if (finalPercent < 100 || finalPercent > 100)
        finalPercent = 100;

      //worker.ReportProgress(finalPercent);

      this.AddRowToTables(this.tblTemp_BO_DBTrans);
      //worker.ReportProgress(100);
      //END LOADING
      this.tblTemp_BO_DBTrans.Rows.Clear();

      long totalTranscMoney = 0;
      for (int i = 0; i < this.tblBO_DBTrans.Rows.Count; i++)
      {
        string[] tmpMoney = ((string)this.tblBO_DBTrans.Rows[i]["TransC_curValue"]).Split('.');
        if (tmpMoney.Length > 0)
          if (IsNumeric(tmpMoney[0]))
            totalTranscMoney += long.Parse(tmpMoney[0]);
      }

      string sFormat = string.Format("#{0}###", ",");
      //this.txtVistaTotalAmount.Text = (totalTranscMoney * 1000).ToString(sFormat);
      //worker.ReportProgress(100);
    }
    private void AddRowToTables(DataTable tblSource)
    {

      foreach (DataRow dr in tblSource.Rows)
      {
        DataRow row = this.tblBO_DBTrans.NewRow();
        row["TransC_lgnNumber"] = dr["TransC_lgnNumber"];
        row["TransC_strType"] = dr["TransC_strType"];
        row["TransC_dtmDateTime"] = dr["TransC_dtmDateTime"];
        row["TransC_dtmRealTransTime"] = dr["TransC_dtmRealTransTime"];
        row["TransC_curValue"] = dr["TransC_curValue"];
        row["TransC_strBKCardType"] = dr["TransC_strBKCardType"];
        row["TransC_strPaymentTransRef"] = dr["TransC_strPaymentTransRef"];
        row["CinOperator_strCode"] = dr["CinOperator_strCode"];
        this.tblBO_DBTrans.Rows.Add(row);
      }
    }
    private void ClearAllOptionValue()
    {
      this.importExcel = false;
      this.importExcelRefund = false;
      this.reconciliation = false;
    }

    private void CombineTable()
    {
      long totalMoneyAfterCombine = 0;
      long totalMoneyExcelNotInVista = 0;
      long totalMoneyVistaNotInExcel = 0;
      //ds.Clear();
      this.tblReconciliationMatch.Rows.Clear();
      this.tblReconciliationNotMatch.Rows.Clear();

      //OPTION 2
      string whereString = string.Empty;
      try
      {
        foreach (DataRow dr in this.tblExcelTrans.Rows)
        {

          whereString = string.Format("TransC_strPaymentTransRef = '{0}'", dr["TransC_excel_strPaymentTransRef"]);
          DataRow[] dataRowList = this.tblBO_DBTrans.Select(whereString);
          if (dataRowList.Length > 0)
          {
            DataRow parentRow = dataRowList[0];
            DataRow row = this.tblReconciliationMatch.NewRow();
            row["No"] = dr["No"];
            row["TransC_excel_strPaymentTransRef"] = dr["TransC_excel_strPaymentTransRef"];
            row["TransC_excel_strType"] = dr["TransC_excel_strType"];
            row["TransC_excel_dtmDateTime"] = dr["TransC_excel_dtmDateTime"];
            row["TransC_excel_curValue"] = dr["TransC_excel_curValue"];
            row["TransC_strPaymentTransRef"] = parentRow["TransC_strPaymentTransRef"];
            row["TransC_strType"] = parentRow["TransC_strType"];
            row["TransC_dtmDateTime"] = parentRow["TransC_dtmDateTime"];
            row["TransC_dtmRealTransTime"] = parentRow["TransC_dtmRealTransTime"];
            row["TransC_curValue"] = parentRow["TransC_curValue"];

            string[] tmpMoney = ((string)parentRow["TransC_curValue"]).Split('.');
            if ((tmpMoney.Length > 0) && IsNumeric(tmpMoney[0]))
              totalMoneyAfterCombine += long.Parse(tmpMoney[0]);
            this.tblReconciliationMatch.Rows.Add(row);
          }
          else
          {
            DataRow row = this.tblReconciliationNotMatch.NewRow();
            row["No"] = dr["No"];
            row["TransC_excel_strPaymentTransRef"] = dr["TransC_excel_strPaymentTransRef"];
            row["TransC_excel_strType"] = dr["TransC_excel_strType"];
            row["TransC_excel_dtmDateTime"] = dr["TransC_excel_dtmDateTime"];
            row["TransC_excel_curValue"] = dr["TransC_excel_curValue"];

            string[] tmpMoney = ((string)dr["TransC_excel_curValue"]).Split(',');
            string transValue = string.Empty;
            if (tmpMoney.Length > 0)
              for (int index = 0; index < tmpMoney.Length; index++)
              {
                transValue = transValue + tmpMoney[index];
              }
            if (IsNumeric(transValue))
              totalMoneyExcelNotInVista += long.Parse(transValue);
            this.tblReconciliationNotMatch.Rows.Add(row);
          }
        }

        string sFormat = string.Format("#{0}###", ",");

        DataRow sumRow = this.tblReconciliationMatch.NewRow();
        sumRow["TransC_excel_strPaymentTransRef"] = "TỔNG SỐ TIỀN:";
        sumRow["TransC_excel_curValue"] = (totalMoneyAfterCombine * 1000).ToString(sFormat);
        this.tblReconciliationMatch.Rows.Add(sumRow);

        this.FillDataGrid(this.tblReconciliationMatch);

        sumRow = this.tblReconciliationNotMatch.NewRow();
        sumRow["TransC_excel_strPaymentTransRef"] = "TỔNG SỐ TIỀN:";
        sumRow["TransC_excel_curValue"] = (totalMoneyExcelNotInVista).ToString(sFormat);
        this.tblReconciliationNotMatch.Rows.Add(sumRow);

        this.dgrTransNotInVista.DataSource = this.tblReconciliationNotMatch;

        foreach (DataRow dr in this.tblBO_DBTrans.Rows)
        {

          whereString = string.Format("TransC_excel_strPaymentTransRef = '{0}'", dr["TransC_strPaymentTransRef"]);
          DataRow[] dataRowList = this.tblExcelTrans.Select(whereString);
          if (dataRowList.Length == 0)
          {
            DataRow row = this.tblBO_DBTransNotInExcel.NewRow();
            row["TransC_lgnNumber"] = dr["TransC_lgnNumber"];
            row["TransC_strType"] = dr["TransC_strType"];
            row["TransC_dtmDateTime"] = dr["TransC_dtmDateTime"];
            row["TransC_dtmRealTransTime"] = dr["TransC_dtmRealTransTime"];
            row["TransC_curValue"] = dr["TransC_curValue"];
            row["TransC_strBKCardType"] = dr["TransC_strBKCardType"];
            row["TransC_strPaymentTransRef"] = dr["TransC_strPaymentTransRef"];
            row["CinOperator_strCode"] = dr["CinOperator_strCode"];

            string[] tmpMoney = ((string)dr["TransC_curValue"]).Split('.');
            if ((tmpMoney.Length > 0) && IsNumeric(tmpMoney[0]))
              totalMoneyVistaNotInExcel += long.Parse(tmpMoney[0]);

            this.tblBO_DBTransNotInExcel.Rows.Add(row);
          }
        }
        sumRow = this.tblBO_DBTransNotInExcel.NewRow();
        sumRow["TransC_lgnNumber"] = "TỔNG SỐ TIỀN:";
        sumRow["TransC_curValue"] = (totalMoneyVistaNotInExcel * 1000).ToString(sFormat);
        this.tblBO_DBTransNotInExcel.Rows.Add(sumRow);

        this.dgrTransVistaNotInExcel.DataSource = this.tblBO_DBTransNotInExcel;
        //string sFormat = string.Format("#{0}###", ",");
        this.txtTotalRefundAmount.Text = (totalMoneyExcelNotInVista).ToString(sFormat);
        this.txtPayConnectorTotalAmout.Text = (totalMoneyAfterCombine * 1000).ToString(sFormat);
        //this.dgrVistaRefund.DataSource = this.tblBO_DBTransTicketRefund;
      }
      catch (Exception exp)
      {
        MessageBox.Show(string.Format("Định dạng file Excel hoặc ngày tháng dữ liệu trong file không chính xác. SYSTEM ERROR MESSAGE: {0}", exp.Message));
      }

    }

    private void LoadDataFromVistaBO(int option)
    {
      //this.tblBO_DBTrans.Rows.Clear();
      try
      {
        switch (option)
        {
          case 1:
            this.CombineTable();
            break;
          case 2:
            this.ClearAllTables();
            string whereString = string.Format("TransC_strPaymentTransRef = '{0}'", this.txtPaymentBankRef.Text);
            DataRow[] dataRowList = this.tblBO_DBTrans.Select(whereString);
            if (dataRowList.Length > 0)
            {
              DataRow parentRow = dataRowList[0];
              DataRow row = this.tblReconciliationMatch.NewRow();

              row["TransC_excel_strPaymentTransRef"] = this.txtPaymentBankRef.Text;

              row["TransC_strPaymentTransRef"] = parentRow["TransC_strPaymentTransRef"];
              row["TransC_strType"] = parentRow["TransC_strType"];
              row["TransC_dtmDateTime"] = parentRow["TransC_dtmDateTime"];
              row["TransC_dtmRealTransTime"] = parentRow["TransC_dtmRealTransTime"];
              row["TransC_curValue"] = parentRow["TransC_curValue"];

              this.tblReconciliationMatch.Rows.Add(row);
            }
            else
            {
              DataRow row = this.tblReconciliationNotMatch.NewRow();

              row["TransC_excel_strPaymentTransRef"] = this.txtPaymentBankRef.Text;

              this.tblReconciliationNotMatch.Rows.Add(row);
            }
            this.dgrTransNotInVista.DataSource = this.tblReconciliationNotMatch;
            this.dgrOnlinePaymentRec.DataSource = this.tblReconciliationMatch;

            break;

          default:
            break;
        }
      }
      catch (Exception exp)
      {
        MessageBox.Show(string.Format("Hệ thống phát sinh lỗi: {0}", exp.Message));
      }

    }

    private void StartBackgroundWorker()
    {
      if (backgroundWorker1.IsBusy != true)
      {
        // create a new instance of the alert form
        progress = new Inprogress();
        PaymentChecking RC = new PaymentChecking();

        // event handler for the Cancel button in AlertForm
        progress.Canceled += new EventHandler<EventArgs>(buttonCancel_Click);
        progress.Show();
        // Start the asynchronous operation.
        backgroundWorker1.RunWorkerAsync(RC);
      }
    }


    private void CancelBackgroundWorker()
    {
      if (backgroundWorker1.WorkerSupportsCancellation == true)
      {
        // Cancel the asynchronous operation.
        backgroundWorker1.CancelAsync();
        // Close the AlertForm
        progress.Close();
      }
    }
    private void FillDataGrid()
    {
      //this.dgrOnlinePaymentRec.Columns.
      this.dgrOnlinePaymentRec.DataSource = this.tblExcelTrans;
    }
    private void FillDataGrid(DataTable tblSource)
    {
      this.dgrOnlinePaymentRec.DataSource = tblSource;
    }

    public static string OpenExcelFile(string fPath)
    {
      try
      {
        string connectionstring = String.Empty;
        string[] splitdot = fPath.Split(new char[1] { '.' });
        string dot = splitdot[splitdot.Length - 1].ToLower();
        if (dot == "xls")
        {
          //tao chuoi ket noi voi Excel 2003
          connectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fPath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
        }
        else if (dot == "xlsx")
        {
          //tao chuoi ket noi voi Excel 2007
          connectionstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fPath + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
        }
        return connectionstring;
      }
      catch (Exception exp)
      {
        MessageBox.Show(string.Format("Hệ thống phát sinh lỗi: {0}. Vui lòng chụp màn hình và báo Mr. Viễn để check. Thành thật xin lỗi vì sự bất tiện này!", exp.Message));
        return string.Empty;
      }
    }
    public static DataSet GetDataExcel(string fPath, string sheetname)
    {
      try
      {
        DataSet ds = new DataSet();
        string connectionstring = OpenExcelFile(fPath);
        string query = "SELECT * FROM [" + sheetname + "$]";
        using (OleDbConnection cnn = new OleDbConnection(connectionstring))
        {
          cnn.Open();
          OleDbDataAdapter oleAdapter = new OleDbDataAdapter(query, cnn);
          oleAdapter.Fill(ds, sheetname);
          oleAdapter.Dispose();
          cnn.Close();
          cnn.Dispose();
        }
        return ds;
      }
      catch (Exception exp)
      {
        MessageBox.Show(string.Format("Hệ thống phát sinh lỗi: {0}. Vui lòng chụp màn hình và báo Mr. Viễn để check. Thành thật xin lỗi vì sự bất tiện này!", exp.Message));
        return null;
      }
    }
    public bool IsNumeric(string value)
    {
      string number = "0123456789";
      bool isNum = true;
      if (value.Length > 0)
      {
        for (int i = 0; i < value.Length; i++)
        {
          if (number.IndexOf(value[i], 0) < 0)
          {
            isNum = false;
            break;
          }
        }
      }
      else isNum = false;

      return isNum;
    }

    public bool IsDateTime(string value)
    {
      //msg = null;
      string s = value.Trim();
      if (s.Length == 0)
      {
        return false;
      }
      else
      {
        if (ShortDate.Match(s).Success)
        {
          s = s.Substring(0, 2) + "/" + s.Substring(2, 2) + "/" + s.Substring(4, 2);
        }
        if (LongDate.Match(s).Success)
        {
          s = s.Substring(0, 2) + "/" + s.Substring(2, 2) + "/" + s.Substring(4, 4);
        }
        DateTime d = DateTime.MinValue;
        if (DateTime.TryParse(s, out d))
        {
          return true;
        }
        else
        {
          return false;
        }
      }

    }

    private void ImportFromExcel()
    {
      this.txtPayConnectorTotalAmout.Text = string.Empty;
      if (this.rad123Pay.Checked)
      {
        Int64 totalTranscMoney = 0;
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
          this.ClearAllTables();
          alert = new AlertForm();
          alert.Show();
          try
          {
            int indexNumber = 0;
            string[] a = new string[50];
            DataSet ds = new DataSet();
            string sheetname = "123PAY";
            if (this.txtSheetName.Text.Length > 0)
              sheetname = this.txtSheetName.Text;
            ds = GetDataExcel(openFileDialog1.FileName, sheetname);// Goi chuong trinh GetDataExcel phia tren luu vao Dataset ds        
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++) //Dong
            {
              for (int j = 0; j < ds.Tables[0].Columns.Count; j++)//Cot 
              {
                a[j] = ds.Tables[0].Rows[i].ItemArray[j].ToString().Trim();
              };

              DataRow row;

              {
                if (a[2].Length > 0)
                {
                  indexNumber++;
                  row = this.tblExcelTrans.NewRow();
                  row["No"] = indexNumber;
                  row["TransC_excel_strPaymentTransRef"] = a[2];
                  row["TransC_excel_strType"] = a[1];
                  if (IsDateTime(a[3]))
                    row["TransC_excel_dtmDateTime"] = a[3];

                  row["TransC_excel_curValue"] = a[9];
                  string[] temptValue = a[9].Split(',');
                  string transValue = string.Empty;
                  if (temptValue.Length > 0)
                  {
                    for (int index = 0; index < temptValue.Length; index++)
                    {
                      transValue = transValue + temptValue[index];
                    }
                    if (IsNumeric(transValue))
                      totalTranscMoney += int.Parse(transValue);
                  }
                  this.tblExcelTrans.Rows.Add(row);
                }

              }

            }

            FillDataGrid(this.tblExcelTrans);

            string sFormat = string.Format("#{0}###", ",");

            this.txtPayConnectorTotalAmout.Text = (totalTranscMoney).ToString(sFormat);

          }
          catch (Exception exp)
          {
            MessageBox.Show(string.Format("Định dạng file Excel hoặc ngày tháng dữ liệu trong file không chính xác. SYSTEM ERROR MESSAGE: {0}", exp.Message));
          }
          alert.Close();
        }
      }
      else if (this.radOnePayATM.Checked)
      {
        Int64 totalTranscMoney = 0;

        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
          this.ClearAllTables();
          alert = new AlertForm();
          alert.Show();
          try
          {

            string[] a = new string[50];
            DataSet ds = new DataSet();
            string sheetname = "sheetname";
            if (this.txtSheetName.Text.Length > 0)
              sheetname = this.txtSheetName.Text;

            ds = GetDataExcel(openFileDialog1.FileName, sheetname);// Goi chuong trinh GetDataExcel phia tren luu vao Dataset ds        
            for (int i = 7; i < ds.Tables[0].Rows.Count; i++) //Dong
            {
              for (int j = 0; j < ds.Tables[0].Columns.Count; j++)//Cot 
              {
                a[j] = ds.Tables[0].Rows[i].ItemArray[j].ToString().Trim();
              };

              DataRow row;

              {
                if (a[2].Length > 0)
                {
                  row = this.tblExcelTrans.NewRow();
                  row["No"] = a[0];
                  row["TransC_excel_strPaymentTransRef"] = a[2];
                  row["TransC_excel_strType"] = a[3];
                  if (IsDateTime(a[5]))
                    row["TransC_excel_dtmDateTime"] = a[5];
                  row["TransC_excel_curValue"] = a[4];
                  string[] temptValue = a[4].Split(',');
                  string transValue = string.Empty;
                  if (temptValue.Length > 0)
                  {
                    for (int index = 0; index < temptValue.Length; index++)
                    {
                      transValue = transValue + temptValue[index];
                    }
                    if (IsNumeric(transValue))
                      totalTranscMoney += int.Parse(transValue);
                  }
                  this.tblExcelTrans.Rows.Add(row);
                }

              }

            }
            //LoadData();
            FillDataGrid(this.tblExcelTrans);
            string sFormat = string.Format("#{0}###", ",");
            //string a = double.Parse(12345).ToString(sFormat);
            this.txtPayConnectorTotalAmout.Text = (totalTranscMoney).ToString(sFormat);
            //MessageBox.Show("Import thành công.");
          }
          catch (Exception exp)
          {
            MessageBox.Show(string.Format("Định dạng file Excel không đúng hoặc định dạng ngày tháng dữ liệu trong file không chính xác. Vui lòng kiểm tra lại file hoặc báo Mr. Viễn để check. SYSTEM ERROR MESSAGE: {0}", exp.Message));
          }
          alert.Close();
        }
      }
      else if (this.radOnePayVisa.Checked)
      {
        Int64 totalTranscMoney = 0;

        int rowIndex = 0;
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
          this.ClearAllTables();
          alert = new AlertForm();
          alert.Show();
          try
          {
            string[] a = new string[50];
            DataSet ds = new DataSet();
            string sheetname = "GALAXYCINE";
            if (this.txtSheetName.Text.Length > 0)
              sheetname = this.txtSheetName.Text;

            ds = GetDataExcel(openFileDialog1.FileName, sheetname);// Goi chuong trinh GetDataExcel phia tren luu vao Dataset ds        
            for (int i = 3; i < ds.Tables[0].Rows.Count; i++) //Dong
            {
              for (int j = 0; j < ds.Tables[0].Columns.Count; j++)//Cot 
              {
                a[j] = ds.Tables[0].Rows[i].ItemArray[j].ToString().Trim();
              };

              DataRow row;
              //if (a[2].ToString() != "Refund")
              {
                if (a[2].Length > 0)
                {
                  rowIndex++;
                  row = this.tblExcelTrans.NewRow();
                  row["No"] = rowIndex.ToString();
                  row["TransC_excel_strPaymentTransRef"] = a[0];
                  row["TransC_excel_strType"] = a[4];
                  if (IsDateTime(a[2]))
                    row["TransC_excel_dtmDateTime"] = a[2];
                  row["TransC_excel_curValue"] = a[13];
                  string[] temptValue = a[13].Split(',');
                  string transValue = string.Empty;
                  if (temptValue.Length > 0)
                  {
                    for (int index = 0; index < temptValue.Length; index++)
                    {
                      transValue = transValue + temptValue[index];
                    }
                    if (IsNumeric(transValue))
                      totalTranscMoney += int.Parse(transValue);
                  }
                  this.tblExcelTrans.Rows.Add(row);
                }

              }

            }

            FillDataGrid(this.tblExcelTrans);
            string sFormat = string.Format("#{0}###", ",");
            //string a = double.Parse(12345).ToString(sFormat);
            this.txtPayConnectorTotalAmout.Text = (totalTranscMoney).ToString(sFormat);
            //MessageBox.Show("Import thành công.");
          }
          catch (Exception exp)
          {
            MessageBox.Show(string.Format("Định dạng file Excel hoặc ngày tháng dữ liệu trong file không chính xác. SYSTEM ERROR MESSAGE: {0}", exp.Message));
          }
          alert.Close();
        }
      }
      else
      {
        Int64 totalTranscMoney = 0;
        int count = 0;
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
          this.ClearAllTables();
          alert = new AlertForm();
          alert.Show();
          try
          {
            string[] a = new string[50];
            DataSet ds = new DataSet();
            string date = string.Empty;
            //ONEPAY
            ds = GetDataExcel(openFileDialog1.FileName, "OnePay");// Goi chuong trinh GetDataExcel phia tren luu vao Dataset ds        
            for (int i = 3; i < ds.Tables[0].Rows.Count; i++) //Dong
            {
              for (int j = 0; j < ds.Tables[0].Columns.Count; j++)//Cot 
              {
                a[j] = ds.Tables[0].Rows[i].ItemArray[j].ToString().Trim();
              };
              DataRow row;
              //if (a[2].ToString() != "Refund")
              {
                if (a[2].Length > 0)
                {
                  count++;
                  row = this.tblExcelTrans.NewRow();
                  row["No"] = count;
                  row["TransC_excel_strPaymentTransRef"] = a[2];
                  row["TransC_excel_strType"] = a[3];
                  if (IsDateTime(a[0]))
                  {
                    row["TransC_excel_dtmDateTime"] = a[0];
                    date = a[0];
                  }
                  else
                    row["TransC_excel_dtmDateTime"] = date;

                  row["TransC_excel_curValue"] = a[4];
                  string tmp = ((string)a[4]).Replace("VND ", "0");
                  tmp = tmp.Trim();
                  string[] temptValue = tmp.Split(',');
                  string transValue = string.Empty;
                  if (temptValue.Length > 0)
                  {
                    for (int index = 0; index < temptValue.Length; index++)
                    {
                      transValue = transValue + temptValue[index];
                    }
                    if (IsNumeric(transValue))
                      totalTranscMoney += int.Parse(transValue);
                    //totalTranscMoney += int.Parse(transValue);
                  }
                  //totalTranscMoney += int.Parse(a[4]);

                  this.tblExcelTrans.Rows.Add(row);
                  //count++;
                }

              }

            }
            //123PAY
            date = string.Empty;
            ds = GetDataExcel(openFileDialog1.FileName, "123Pay");// Goi chuong trinh GetDataExcel phia tren luu vao Dataset ds        
            for (int i = 3; i < ds.Tables[0].Rows.Count; i++) //Dong
            {
              for (int j = 0; j < ds.Tables[0].Columns.Count; j++)//Cot 
              {
                a[j] = ds.Tables[0].Rows[i].ItemArray[j].ToString().Trim();
              };
              DataRow row;
              //if (a[2].ToString() != "Refund")
              {
                if (a[2].Length > 0)
                {
                  count++;
                  row = this.tblExcelTrans.NewRow();
                  row["No"] = count;
                  row["TransC_excel_strPaymentTransRef"] = a[2];
                  row["TransC_excel_strType"] = a[3];
                  if (IsDateTime(a[0]))
                  {
                    row["TransC_excel_dtmDateTime"] = a[0];
                    date = a[0];
                  }
                  else
                    row["TransC_excel_dtmDateTime"] = date;

                  row["TransC_excel_curValue"] = a[4];

                  string tmp = ((string)a[4]).Replace("VND ", "0");
                  tmp = tmp.Trim();
                  string[] temptValue = tmp.Split(',');
                  string transValue = string.Empty;
                  if (temptValue.Length > 0)
                  {
                    for (int index = 0; index < temptValue.Length; index++)
                    {
                      transValue = transValue + temptValue[index];
                    }
                    if (IsNumeric(transValue))
                      totalTranscMoney += int.Parse(transValue);
                  }
                  //totalTranscMoney += int.Parse(a[4]);

                  this.tblExcelTrans.Rows.Add(row);
                  //count++;
                }

              }

            }
            //LoadData();
            FillDataGrid(this.tblExcelTrans);
            string sFormat = string.Format("#{0}###", ",");
            //string a = double.Parse(12345).ToString(sFormat);
            this.txtPayConnectorTotalAmout.Text = (totalTranscMoney).ToString(sFormat);
            //MessageBox.Show("Import thành công.");
          }
          catch (Exception exp)
          {
            MessageBox.Show(string.Format("Định dạng file Excel hoặc định dạng ngày tháng dữ liệu trong file không chính xác. SYSTEM ERROR MESSAGE: {0}", exp.Message));
          }
          alert.Close();
        }
      }
    }

    #endregion Methods

    private void btnImportFromExcel_Click(object sender, EventArgs e)
    {
      this.importExcel = true;
      this.ImportFromExcel();
    }

    private void btnRec_Click(object sender, EventArgs e)
    {
      //this.txtVistaTotalAmount.Text = string.Empty;
      this.reconciliation = true;

      if (this.tblBO_DBTrans.Rows.Count <= 0)
      {
        this.RefreshData();
      }

      if (this.chkAutoChecking.Checked)
      {
        if (this.tblExcelTrans.Rows.Count == 0)
          MessageBox.Show("Import dữ liệu từ Excel trước khi tra soát!", "Thông báo");
        else
        {
          alert = new AlertForm();
          alert.Show();
          this.LoadDataFromVistaBO(1);
          alert.Close();
        }
      }
      else
      {
        this.LoadDataFromVistaBO(2);
      }
    }

    private void comOLRecPageInfo_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void txtVistaTotalAmount_TextChanged(object sender, EventArgs e)
    {

    }

    private void OnlinePaymentReconciliation_Load(object sender, EventArgs e)
    {
      this.dtpFromDate.Value = DateTime.Today.AddDays(-4);
      this.dtpToDate.Value = DateTime.Today.AddDays(1);
      string fromDate = string.Format("{0:MM/dd/yyyy}", dtpFromDate.Value);
      string toDate = string.Format("{0:MM/dd/yyyy}", dtpToDate.Value);
      this.rad123Pay.Checked = true;
      this.chkAutoChecking.Checked = true;
      this.RefreshData();
    }
    private void PaymentChecking_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
    {
      this.CloseConnection();
    }

    void btnImportExcelRefund_Click(object sender, System.EventArgs e)
    {
      this.importExcelRefund = true;
      this.ImportFromExcel();
    }

    private void btnInsertRefund_Click(object sender, EventArgs e)
    {

    }

    private void btnRefreshData_Click(object sender, EventArgs e)
    {
      this.RefreshData();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      //this.RefreshData();
      //MessageBox.Show("", "Thông báo");
    }

    
    private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
    {
      string fromDate = string.Format("{0:MM/dd/yyyy}", dtpFromDate.Value);
      string toDate = string.Format("{0:MM/dd/yyyy}", dtpToDate.Value.AddDays(-1));
      //progress.Message = string.Format("Đang lấy BO Data các rạp từ {0} đến {1}....... ", fromDate, toDate) + e.ProgressPercentage.ToString() + "%";
      //progress.Message = string.Format("Đang load BO các rạp về RAM, thời gian từ {0} đến {1}...... ", fromDate, toDate);
      progress.Message2 = string.Format("Thời gian từ {0} đến {1}....", fromDate, toDate);
      progress.ProgressValue = e.ProgressPercentage;
    }

    private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
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
    

    private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
      string fromDate = string.Format("{0:MM/dd/yyyy}", dtpFromDate.Value);
      string toDate = string.Format("{0:MM/dd/yyyy}", dtpToDate.Value);
      BackgroundWorker worker = sender as BackgroundWorker;
      
      worker.ReportProgress(5);
      
      //// BEGIN TEST PROGRESS
      
      DateTime lastReportDateTime = DateTime.Now;
      this.tblBO_DBTrans.Rows.Clear();
      string selectString = string.Empty;
      string fromString = string.Empty;
      string orderByString = string.Empty;
      string sqlCommandString = selectString + fromString + orderByString;
      string whereString = string.Empty;

      selectString = "SELECT TransC_lgnNumber, TransC_strType, TransC_dtmDateTime, TransC_dtmRealTransTime, TransC_curValue, TransC_strBKCardType, TransC_strPaymentTransRef, CinOperator_strCode";
      fromString = " FROM tblTrans_Cash";
      orderByString = " ORDER BY TransC_dtmRealTransTime ASC";
      whereString = string.Format(" WHERE (TransC_dtmRealTransTime BETWEEN '{0}' AND '{1}') AND (TransC_strType = 'R' OR TransC_strType = '0000000013') AND TransC_strBKCardType <> '123PHIM' ", fromDate, toDate);

      sqlCommandString = selectString + fromString + whereString + orderByString;
      //NGUYEN DU LOADING
      this.OpenConnection(this.nd_BOConnectionString);
      this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
      this.adapter.SelectCommand.CommandType = CommandType.Text;
      this.adapter.SelectCommand.CommandTimeout = 0;
      this.tblTemp_BO_DBTrans.Rows.Clear();

      this.adapter.Fill(this.tblTemp_BO_DBTrans);
      this.AddRowToTables(this.tblTemp_BO_DBTrans);
      worker.ReportProgress(25);

      //NGUYEN TRAI LOADING
      this.OpenConnection(this.nt_BOConnectionString);
      this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
      this.adapter.SelectCommand.CommandType = CommandType.Text;
      this.adapter.SelectCommand.CommandTimeout = 0;
      this.tblTemp_BO_DBTrans.Rows.Clear();
      this.adapter.Fill(this.tblTemp_BO_DBTrans);
      //t = DateTime.Now - lastReportDateTime;
      //worker.ReportProgress((int)(t.TotalSeconds * 100 / 180));


      this.AddRowToTables(this.tblTemp_BO_DBTrans);
      worker.ReportProgress(50);
      //TAN BINH LOADING
      this.OpenConnection(this.tb_BOConnectionString);
      this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
      this.adapter.SelectCommand.CommandType = CommandType.Text;
      this.adapter.SelectCommand.CommandTimeout = 0;
      this.tblTemp_BO_DBTrans.Rows.Clear();
      this.adapter.Fill(this.tblTemp_BO_DBTrans);

      //t = DateTime.Now - lastReportDateTime;
      //worker.ReportProgress((int)(t.TotalSeconds * 100 / 180));

      this.AddRowToTables(this.tblTemp_BO_DBTrans);
      worker.ReportProgress(75);

      //KDV LOADING
      this.OpenConnection(this.kdv_BOConnectionString);
      this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
      this.adapter.SelectCommand.CommandType = CommandType.Text;
      this.adapter.SelectCommand.CommandTimeout = 0;
      this.tblTemp_BO_DBTrans.Rows.Clear();
      this.adapter.Fill(this.tblTemp_BO_DBTrans);
      //t = DateTime.Now - lastReportDateTime;
      //worker.ReportProgress((int)(t.TotalSeconds * 100 / 180));

      this.AddRowToTables(this.tblTemp_BO_DBTrans);
      worker.ReportProgress(85);
      //QUANG TRUNG LOADING
      this.OpenConnection(this.qt_BOConnectionString);
      this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
      this.adapter.SelectCommand.CommandType = CommandType.Text;
      this.adapter.SelectCommand.CommandTimeout = 0;
      this.tblTemp_BO_DBTrans.Rows.Clear();
      this.adapter.Fill(this.tblTemp_BO_DBTrans);
      this.AddRowToTables(this.tblTemp_BO_DBTrans);
      worker.ReportProgress(95);
      //BEN TRE LOADING
      this.OpenConnection(this.bt_BOConnectionString);
      this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
      this.adapter.SelectCommand.CommandType = CommandType.Text;
      this.adapter.SelectCommand.CommandTimeout = 0;
      this.tblTemp_BO_DBTrans.Rows.Clear();
      this.adapter.Fill(this.tblTemp_BO_DBTrans);
      this.AddRowToTables(this.tblTemp_BO_DBTrans);
      worker.ReportProgress(100);
      //END LOADING
      this.tblTemp_BO_DBTrans.Rows.Clear();
      /*
      long totalTranscMoney = 0;
      for (int i = 0; i < this.tblBO_DBTrans.Rows.Count; i++)
      {
        string[] tmpMoney = ((string)this.tblBO_DBTrans.Rows[i]["TransC_curValue"]).Split('.');
        if (tmpMoney.Length > 0)
          if (IsNumeric(tmpMoney[0]))
            totalTranscMoney += long.Parse(tmpMoney[0]);
      }

      string sFormat = string.Format("#{0}###", ",");
      this.txtVistaTotalAmount.Text = (totalTranscMoney * 1000).ToString(sFormat);
      */
     
      //// END TEST PROGRESS

      //this.DataCaching(fromDate, toDate);
      
            
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

  }
}

