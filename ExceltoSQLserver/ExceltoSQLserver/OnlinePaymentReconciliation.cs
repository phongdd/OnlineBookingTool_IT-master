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
using System.Globalization;

namespace ExceltoSQLserver
{
public partial class OnlinePaymentReconciliation : Form
{
  public OnlinePaymentReconciliation()
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
    this.tblBO_ElectronicPaymentAmount = new DataTable("tblBOElectronicPaymentAmount");
    this.con = new SqlConnection();
    this.OpenConnection(this.lab_connectionString_OPTR);
    this.adapter = new SqlDataAdapter();
    this.CreatTable();
  }

  #region Fields
    private AlertForm alert;
    private DataTable tblReconciliationMatch;
    private DataTable tbl_Temp_Trans_Refund;
    private DataTable tblExcelRefundTrans;
    private DataTable tblExcelRefundTransNotInTime;
    private DataTable tblExcelTrans;
    private DataTable tblBO_DBTrans;
    private DataTable tblBO_ElectronicPaymentAmount;
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
      //this.con.
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
      //this.tblReconciliationMatch.Columns.Add("TransC_excel_dtmDateTime", typeof(DateTime));
      this.tblReconciliationMatch.Columns.Add("TransC_excel_dtmDateTime", typeof(string));
      this.tblReconciliationMatch.Columns.Add("TransC_excel_curValue", typeof(string));
      this.tblReconciliationMatch.Columns.Add("TransC_strPaymentTransRef", typeof(string));
      this.tblReconciliationMatch.Columns.Add("TransC_strType", typeof(string));
      this.tblReconciliationMatch.Columns.Add("TransC_dtmDateTime", typeof(DateTime));
      this.tblReconciliationMatch.Columns.Add("TransC_dtmRealTransTime", typeof(DateTime));
      this.tblReconciliationMatch.Columns.Add("TransC_curValue", typeof(string));

      this.tblReconciliationNotMatch.Columns.Add("No", typeof(string));
      this.tblReconciliationNotMatch.Columns.Add("TransC_excel_strPaymentTransRef", typeof(string));
      this.tblReconciliationNotMatch.Columns.Add("TransC_excel_strType", typeof(string));
      //this.tblReconciliationNotMatch.Columns.Add("TransC_excel_dtmDateTime", typeof(DateTime));
      this.tblReconciliationNotMatch.Columns.Add("TransC_excel_dtmDateTime", typeof(string));
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

      this.tblBO_ElectronicPaymentAmount.Columns.Add("TotalValue", typeof(string));

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
      this.tblBO_DBTrans.Rows.Clear();
      this.tblBO_DBTransNotInExcel.Rows.Clear();

      this.tblVISTAIT_OLTrans.Rows.Clear();
    }
    private void DataCaching(string fromDate, string toDate)
    {
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
      //NGUYEN TRAI LOADING
      this.OpenConnection(this.nt_BOConnectionString);
      this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
      this.adapter.SelectCommand.CommandType = CommandType.Text;
      this.adapter.SelectCommand.CommandTimeout = 0;
      this.tblTemp_BO_DBTrans.Rows.Clear();
      this.adapter.Fill(this.tblTemp_BO_DBTrans);
      this.AddRowToTables(this.tblTemp_BO_DBTrans);
      //TAN BINH LOADING
      this.OpenConnection(this.tb_BOConnectionString);
      this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
      this.adapter.SelectCommand.CommandType = CommandType.Text;
      this.adapter.SelectCommand.CommandTimeout = 0;
      this.tblTemp_BO_DBTrans.Rows.Clear();
      this.adapter.Fill(this.tblTemp_BO_DBTrans);
      this.AddRowToTables(this.tblTemp_BO_DBTrans);
      //KDV LOADING
      this.OpenConnection(this.kdv_BOConnectionString);
      this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
      this.adapter.SelectCommand.CommandType = CommandType.Text;
      this.adapter.SelectCommand.CommandTimeout = 0;
      this.tblTemp_BO_DBTrans.Rows.Clear();
      this.adapter.Fill(this.tblTemp_BO_DBTrans);
      this.AddRowToTables(this.tblTemp_BO_DBTrans);
      //QUANG TRUNG LOADING
      this.OpenConnection(this.qt_BOConnectionString);
      this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
      this.adapter.SelectCommand.CommandType = CommandType.Text;
      this.adapter.SelectCommand.CommandTimeout = 0;
      this.tblTemp_BO_DBTrans.Rows.Clear();
      this.adapter.Fill(this.tblTemp_BO_DBTrans);
      this.AddRowToTables(this.tblTemp_BO_DBTrans);
      //BEN TRE LOADING
      this.OpenConnection(this.bt_BOConnectionString);
      this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
      this.adapter.SelectCommand.CommandType = CommandType.Text;
      this.adapter.SelectCommand.CommandTimeout = 0;
      this.tblTemp_BO_DBTrans.Rows.Clear();
      this.adapter.Fill(this.tblTemp_BO_DBTrans);
      this.AddRowToTables(this.tblTemp_BO_DBTrans);
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
      this.txtVistaTotalAmount.Text = (totalTranscMoney * 1000).ToString(sFormat);
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
    private void InsertTransRefundToDB()
    {
      //this.tbTempTransC.Rows.Clear();
      int duplicateTransCount = 0;
      this.OpenConnection(this.lab_connectionString_OPTR);
      string selectString = "SELECT *";
      string insertIntoString = "INSERT INTO tbl_Temp_Trans_Refund (TransC_strPaymentTransRef, WebPayTN_lngPayTransNumber, TransC_dtmDateTime, TransC_curValue)";
      string insertValueString = string.Empty;
      string fromString = " FROM tbl_Temp_Trans_Refund";
      string whereString = string.Empty;
      string transDatetime = string.Empty;
      string transRealDatetime = string.Empty;
      //this.tblDuplicate.Rows.Clear();

      for (int i = 0; i < this.tblExcelTrans.Rows.Count; i++)
      {
        //this.tbTempResult.Rows.Clear();
        
        //whereString = string.Format(" WHERE TransC_strPaymentTransRef = '{0}'", this.tblExcelTrans.Rows[i]["TransC_excel_strPaymentTransRef"]);
        string sqlCommandString = selectString + fromString + whereString;
        /*
        this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
        this.adapter.SelectCommand.CommandType = CommandType.Text;
        this.adapter.SelectCommand.CommandTimeout = 0;

        this.adapter.Fill(this.tbl_Temp_Trans_Refund);
        if (this.tbl_Temp_Trans_Refund.Rows.Count > 0)
        {
          //this.AddRowTable(this.tblDuplicate, this.tbTempResult);
          duplicateTransCount++;
        }
        else
        */
        {
          //transDatetime = string.Format("{0:MM/dd/yyyy HH:mm:ss tt}", (DateTime)this.tbResult.Rows[i]["TransC_dtmDateTime"]);
          string[] splitDateTime = ((string)this.tblExcelTrans.Rows[i]["TransC_excel_dtmDateTime"]).Split('/');
          string trans_DateTime = splitDateTime[1] + "-" + splitDateTime[0] + "-" + splitDateTime[2];
          //transRealDatetime = string.Format("{0:MM/dd/yyyy HH:mm:ss tt}", (DateTime)splitDateTime[1]+);

          insertValueString = string.Format(" VALUES ('{0}', {1}, '{2}', '{3}')", this.tblExcelTrans.Rows[i]["TransC_excel_strPaymentTransRef"], this.tblExcelTrans.Rows[i]["TransC_excel_strType"], trans_DateTime, this.tblExcelTrans.Rows[i]["TransC_excel_curValue"]);
          sqlCommandString = insertIntoString + insertValueString;
          this.adapter.InsertCommand = new SqlCommand(sqlCommandString, this.con);
          this.adapter.InsertCommand.CommandType = CommandType.Text;
          this.adapter.InsertCommand.CommandTimeout = 0;

          try
          {
            adapter.InsertCommand.ExecuteNonQuery();

          }
          catch (Exception exp)
          {
              MessageBox.Show(string.Format("SYSTEM ERROR MESSAGE: {0}", exp.Message));
          }
          //this.adapter.ru
        }
        
      }
      MessageBox.Show(string.Format("{0} giao dịch dupplicated", duplicateTransCount));
    }
    private void CombineTable()
    {
      long totalMoneyAfterCombine = 0;
      long totalMoneyExcelNotInVista = 0;
      long totalMoneyVistaNotInExcel = 0;
      //ds.Clear();
      this.tblReconciliationMatch.Rows.Clear();
      this.tblReconciliationNotMatch.Rows.Clear();
      this.tblBO_DBTransNotInExcel.Rows.Clear();
      this.dgrVistaTrans.DataSource = this.tblBO_DBTrans;
      
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
            
            string dtpTmp = dr["TransC_excel_dtmDateTime"].ToString();
              /*
            if(this.rad123Pay.Checked || this.radOnePayATM.Checked)
            {
                if (IsDateTime(dtpTmp.ToString()) == 2)
                {
                    string[] strDateTime = dtpTmp.Split('/');
                    dtpTmp = strDateTime[1] + "/" + strDateTime[0] + "/" + strDateTime[2];
                }
                DateTime outDate = DateTime.Today;
                if (DateTime.TryParseExact(dtpTmp, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out outDate))
                    row["TransC_excel_dtmDateTime"] = outDate;
            }
            else if (this.radOnePayVisa.Checked)
            {
                DateTime outDate = DateTime.Today;
                if (DateTime.TryParse(dtpTmp, out outDate))
                    row["TransC_excel_dtmDateTime"] = outDate;
            }
               */

            

            

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
            /* 
            string dtpTmp = dr["TransC_excel_dtmDateTime"].ToString();

            if (this.rad123Pay.Checked || this.radOnePayATM.Checked)
            {
                if (IsDateTime(dtpTmp.ToString()) == 2)
                {
                    string[] strDateTime = dtpTmp.Split('/');
                    dtpTmp = strDateTime[1] + "/" + strDateTime[0] + "/" + strDateTime[2];
                }
                DateTime outDate = DateTime.Today;
                if (DateTime.TryParseExact(dtpTmp, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out outDate))
                    row["TransC_excel_dtmDateTime"] = outDate;
            }
            else if (this.radOnePayVisa.Checked)
            {
                DateTime outDate = DateTime.Today;
                if (DateTime.TryParse(dtpTmp, out outDate))
                    row["TransC_excel_dtmDateTime"] = outDate;
            }
               
            //row["TransC_excel_dtmDateTime"] = dtpTmp;
               
            */

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
        //this.dgrVistaRefund.DataSource = this.tblBO_DBTransTicketRefund;
      }
      catch (Exception exp)
      {
        MessageBox.Show(string.Format("SYSTEM ERROR MESSAGE: {0}", exp.Message));
      }

    }
    private void CombineRefundTable()
    {
      long totalMoneyAfterCombine = 0;
      long totalMoneyExcelNotInVista = 0;
      long totalMoneyVistaNotInExcel = 0;
      //ds.Clear();
      this.tblReconciliationMatch.Rows.Clear();
      this.tblReconciliationNotMatch.Rows.Clear();
      
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
            //row["TransC_excel_dtmDateTime"] = dr["TransC_excel_dtmDateTime"];
            row["TransC_excel_curValue"] = dr["TransC_excel_curValue"];
            row["TransC_strPaymentTransRef"] = parentRow["TransC_strPaymentTransRef"];
            row["TransC_strType"] = parentRow["TransC_strType"];
            row["TransC_dtmDateTime"] = parentRow["TransC_dtmDateTime"];
            row["TransC_dtmRealTransTime"] = parentRow["TransC_dtmRealTransTime"];
            row["TransC_curValue"] = parentRow["TransC_curValue"];

            string[] tmpMoney = ((string)parentRow["TransC_curValue"]).Split('.');
            if ((tmpMoney.Length > 0) && (IsNumeric(tmpMoney[0])))
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

            string tmp = ((string)dr["TransC_excel_curValue"]).Replace("VND ", "0");
            tmp = tmp.Trim();
            string[] tmpMoney = tmp.Split(',');
            //string[] tmpMoney = ((string)dr["TransC_excel_curValue"]).Split(',');
            string transValue = string.Empty;
            if (tmpMoney.Length > 0)
              for (int index = 0; index < tmpMoney.Length; index++)
              {
                transValue = transValue + tmpMoney[index];
              }
            if(IsNumeric(transValue))
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
      }
      catch (Exception exp)
      {
        MessageBox.Show(string.Format("SYSTEM ERROR MESSAGE: {0}", exp.Message));
      }

    }
    private void CombineRefundWithVISTAIT()
    {
      int indexCount = 0;
      //ds.Clear();
      this.tblReconciliationMatch.Rows.Clear();
      this.tblReconciliationNotMatch.Rows.Clear();

      string whereString = string.Empty;
      try
      {
        foreach (DataRow dr in this.tblExcelTrans.Rows)
        {
          indexCount++;
          whereString = string.Format("WebPayH_strBankRef = '{0}'", dr["TransC_excel_strPaymentTransRef"]);
          DataRow[] dataRowList = this.tblVISTAIT_OLTrans.Select(whereString);
          if (dataRowList.Length > 0)
          {
            DataRow parentRow = dataRowList[0];
            DataRow row = this.tblReconciliationMatch.NewRow();
            row["No"] = dr["No"];
            row["TransC_excel_strPaymentTransRef"] = dr["TransC_excel_strPaymentTransRef"];
            row["TransC_excel_strType"] = dr["TransC_excel_strType"];
            //row["TransC_excel_dtmDateTime"] = dr["TransC_excel_dtmDateTime"];
            row["TransC_excel_curValue"] = dr["TransC_excel_curValue"];
            row["TransC_strPaymentTransRef"] = parentRow["WebPayH_strBankRef"];
            //row["TransC_strType"] = parentRow["TransC_strType"];
            row["TransC_strType"] = parentRow["WebPayTN_lngPayTransNumber"];
            row["TransC_dtmRealTransTime"] = parentRow["OrderH_dtmLastUpdated"];
            row["TransC_curValue"] = parentRow["OrderH_intVistaBookingNumber"];
            /*string[] tmpMoney = ((string)parentRow["TransC_curValue"]).Split('.');
            if (tmpMoney.Length > 0)
              totalMoneyAfterCombine += long.Parse(tmpMoney[0]);
             */
            this.tblReconciliationMatch.Rows.Add(row);
          }
          else
          {
            DataRow row = this.tblReconciliationNotMatch.NewRow();
            row["No"] = dr["No"];
            row["TransC_excel_strPaymentTransRef"] = dr["TransC_excel_strPaymentTransRef"];
            row["TransC_excel_strType"] = dr["TransC_excel_strType"];
            //row["TransC_excel_dtmDateTime"] = dr["TransC_excel_dtmDateTime"];
            row["TransC_excel_curValue"] = dr["TransC_excel_curValue"];
            /*
            string[] tmpMoney = ((string)dr["TransC_excel_curValue"]).Split(',');
            string transValue = string.Empty;
            if (tmpMoney.Length > 0)
              for (int index = 0; index < tmpMoney.Length; index++)
              {
                transValue = transValue + tmpMoney[index];
              }
            totalMoneyExcelNotInVista += long.Parse(transValue);
             */
            this.tblReconciliationNotMatch.Rows.Add(row);
          }
        }

        string sFormat = string.Format("#{0}###", ",");
        /*
        DataRow sumRow = this.tblReconciliationMatch.NewRow();
        sumRow["TransC_excel_strPaymentTransRef"] = "TỔNG SỐ TIỀN:";
        sumRow["TransC_excel_curValue"] = (totalMoneyAfterCombine * 1000).ToString(sFormat);
        this.tblReconciliationMatch.Rows.Add(sumRow);
         */

        this.FillDataGrid(this.tblReconciliationMatch);
        /*
        sumRow = this.tblReconciliationNotMatch.NewRow();
        sumRow["TransC_excel_strPaymentTransRef"] = "TỔNG SỐ TIỀN:";
        sumRow["TransC_excel_curValue"] = (totalMoneyExcelNotInVista).ToString(sFormat);
        this.tblReconciliationNotMatch.Rows.Add(sumRow);
         */

        this.dgrTransNotInVista.DataSource = this.tblReconciliationNotMatch;

        foreach (DataRow dr in this.tblVISTAIT_OLTrans.Rows)
        {

          whereString = string.Format("TransC_excel_strPaymentTransRef = '{0}'", dr["WebPayH_strBankRef"]);
          DataRow[] dataRowList = this.tblExcelTrans.Select(whereString);
          if (dataRowList.Length == 0)
          {
            DataRow row = this.tblBO_DBTransNotInExcel.NewRow();
            row["TransC_lgnNumber"] = dr["WebPayTN_lngPayTransNumber"];
            //row["TransC_strType"] = dr["TransC_strType"];
            //row["TransC_dtmDateTime"] = dr["TransC_dtmDateTime"];
            row["TransC_dtmRealTransTime"] = dr["OrderH_dtmLastUpdated"];
            //row["TransC_curValue"] = dr["TransC_curValue"];
            //row["TransC_strBKCardType"] = dr["TransC_strBKCardType"];
            row["TransC_strPaymentTransRef"] = dr["WebPayH_strBankRef"];
            //row["CinOperator_strCode"] = dr["CinOperator_strCode"];
            /*
            string[] tmpMoney = ((string)dr["TransC_curValue"]).Split('.');
            if (tmpMoney.Length > 0)
              totalMoneyVistaNotInExcel += long.Parse(tmpMoney[0]);
            */
            this.tblBO_DBTransNotInExcel.Rows.Add(row);
          }
        }
        /*sumRow = this.tblBO_DBTransNotInExcel.NewRow();
        
        sumRow["TransC_lgnNumber"] = "TỔNG SỐ TIỀN:";
        sumRow["TransC_curValue"] = (totalMoneyVistaNotInExcel * 1000).ToString(sFormat);
         
        this.tblBO_DBTransNotInExcel.Rows.Add(sumRow);
         */

        this.dgrTransVistaNotInExcel.DataSource = this.tblBO_DBTransNotInExcel;
      }
      catch (Exception exp)
      {
        MessageBox.Show(string.Format("SYSTEM ERROR MESSAGE: {0}", exp.Message));
      }

    }
    private void LoadDataFromVistaBO()
    {
      this.tblBO_DBTrans.Rows.Clear();
      string fromDate = string.Format("{0:MM/dd/yyyy}", dtpFromDate.Value);
      string toDate = string.Format("{0:MM/dd/yyyy}", dtpToDate.Value);
      
      try
      {
        this.OpenConnection(this.lab_connectionString_OPTR);
        string selectString = "SELECT TransC_lgnNumber, TransC_strType, TransC_dtmDateTime, TransC_curValue, TransC_strBKCardType, TransC_strPaymentTransRef, CinOperator_strCode";
        string fromString = " FROM tbl_Trans_Cash";
        string orderByString = " ORDER BY TransC_dtmDateTime ASC";

        string whereString = string.Format(" WHERE TransC_dtmDateTime BETWEEN '{0}' AND '{1}'", fromDate, toDate);
        string sqlCommandString = selectString + fromString + whereString + orderByString;

        this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
        this.adapter.SelectCommand.CommandType = CommandType.Text;
        this.adapter.SelectCommand.CommandTimeout = 0;

        this.tblBO_DBTrans.Rows.Clear();
        this.adapter.Fill(this.tblBO_DBTrans);
        long totalTranscMoney = 0;
        for (int i = 0; i < this.tblBO_DBTrans.Rows.Count; i++)
        {
          string[] tmpMoney = ((string)this.tblBO_DBTrans.Rows[i]["TransC_curValue"]).Split('.');
          if(tmpMoney.Length > 0)
            totalTranscMoney += long.Parse(tmpMoney[0]);
        }
        string sFormat = string.Format("#{0}###", ",");
        //string a = double.Parse(12345).ToString(sFormat);
        this.txtVistaTotalAmount.Text = (totalTranscMoney * 1000).ToString(sFormat);
        //this.labTotalTransaction.Text = string.Format("{0} giao dịch", this.tblBO_DBTrans.Rows.Count);

        //this.AddRowTable(startindex, count);
        this.FillDataGrid(this.tblBO_DBTrans);
        //this.FillDropDownList(20, this.tbResult);
      }
      catch (Exception exp)
      {
          MessageBox.Show(string.Format("SYSTEM ERROR MESSAGE: {0}", exp.Message));
      }
         
    }
    private void LoadDataFromVistaBO(int option)
    {
      this.tblBO_DBTrans.Rows.Clear();
      this.tblVISTAIT_OLTrans.Rows.Clear();
      this.tblBO_ElectronicPaymentAmount.Rows.Clear();
      string fromDate = string.Format("{0:MM/dd/yyyy}", dtpFromDate.Value);
      string toDate = string.Format("{0:MM/dd/yyyy}", dtpToDate.Value.AddDays(1));

      try
      {
         /*
        if (this.chkAutoChecking.Checked)
        {
          if(this.tblBO_DBTrans.Rows.Count <=0)
            this.DataCaching(fromDate, toDate);
 
          if (this.radCheckRefund.Checked && !this.chkAutoChecking.Checked)
          {
            this.CombineRefundTable();
          }
          else
        
            this.CombineTable();
          //MessageBox.Show("Đối soát xong. Vui lòng kiểm tra danh sách bên dưới.", "Thông báo");
        }
        else
        */
        {

          this.OpenConnection(this.lab_connectionString_OPTR);
          string selectString = "SELECT *";
          string fromString = " FROM tblTrans_Ticket_Refund";
          string orderByString = " ORDER BY TransT_dtmRealTransTime ASC";
          //string orderByString = " ORDER BY TransC_dtmDateTime ASC";
          string sqlCommandString = selectString + fromString + orderByString;
          string sqlCommandStringRefund = selectString + fromString + orderByString;
          /*
          this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
          this.adapter.SelectCommand.CommandType = CommandType.Text;
          this.adapter.SelectCommand.CommandTimeout = 0;

          this.tblBO_DBTransTicketRefund.Rows.Clear();
          this.adapter.Fill(this.tblBO_DBTransTicketRefund);
          */

          selectString = "SELECT TransC_lgnNumber, TransC_strType, TransC_dtmDateTime, TransC_curValue, TransC_strBKCardType, TransC_strPaymentTransRef, TransC_dtmRealTransTime, CinOperator_strCode";
          fromString = " FROM tbl_Trans_Cash tc";
          //if(chk2014.Checked)
            //fromString = " FROM tbl_Trans_Cash_2014 tc";

          //orderByString = " ORDER BY TransC_dtmRealTransTime ASC";
          orderByString = " ORDER BY TransC_dtmDateTime ASC";
            
          string whereStringRefund = string.Format(" WHERE (EXISTS (select TransT_lgnNumber, CinOperator_strCode FROM tblTrans_Ticket_Refund tr WHERE tc.TransC_lgnNumber = tr.TransT_lgnNumber AND tc.CinOperator_strCode = tr.CinOperator_strCode)) AND TransC_dtmRealTransTime BETWEEN '{0}' AND '{1}'", fromDate, toDate);
          string whereString = string.Format(" WHERE (NOT EXISTS (select TransT_lgnNumber, CinOperator_strCode FROM tblTrans_Ticket_Refund tr WHERE tc.TransC_lgnNumber = tr.TransT_lgnNumber AND tc.CinOperator_strCode = tr.CinOperator_strCode)) AND TransC_dtmRealTransTime BETWEEN '{0}' AND '{1}'", fromDate, toDate);
          //string whereStringRefund = string.Format(" WHERE (EXISTS (select TransT_lgnNumber, CinOperator_strCode FROM tblTrans_Ticket_Refund tr WHERE tc.TransC_lgnNumber = tr.TransT_lgnNumber AND tc.CinOperator_strCode = tr.CinOperator_strCode)) AND TransC_dtmDateTime BETWEEN '{0}' AND '{1}'", fromDate, toDate);
          //string whereString = string.Format(" WHERE (NOT EXISTS (select TransT_lgnNumber, CinOperator_strCode FROM tblTrans_Ticket_Refund tr WHERE tc.TransC_lgnNumber = tr.TransT_lgnNumber AND tc.CinOperator_strCode = tr.CinOperator_strCode)) AND TransC_dtmDateTime BETWEEN '{0}' AND '{1}'", fromDate, toDate);
          switch (option)
          {
            case 1:
              {
                whereString += string.Format(" AND (TransC_strBKCardType = '{0}' OR TransC_strBKCardType = '{1}')", "123PAY-ATM", "123PAY-VIS");
                break;
              }
            case 2:
              whereString += string.Format(" AND TransC_strBKCardType = '{0}'", "ONEPAY-ATM");
              break;
            case 3:
              whereString += string.Format(" AND TransC_strBKCardType = '{0}'", "ONEPAY-VIS");
              break;
            default:
              break;
          }
          sqlCommandString = selectString + fromString + whereString + orderByString;
          sqlCommandStringRefund = selectString + fromString + whereStringRefund + orderByString;

          this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
          this.adapter.SelectCommand.CommandType = CommandType.Text;
          this.adapter.SelectCommand.CommandTimeout = 0;

          this.tblBO_DBTrans.Rows.Clear();
          this.adapter.Fill(this.tblBO_DBTrans);

          this.adapter.SelectCommand = new SqlCommand(sqlCommandStringRefund, this.con);
          this.adapter.SelectCommand.CommandType = CommandType.Text;
          this.adapter.SelectCommand.CommandTimeout = 0;
          this.tblBO_DBTransTicketRefund.Rows.Clear();
          this.adapter.Fill(this.tblBO_DBTransTicketRefund);

          long totalTranscMoney = 0;
          
          for (int i = 0; i < this.tblBO_DBTrans.Rows.Count; i++)
          {
            string[] tmpMoney = ((string)this.tblBO_DBTrans.Rows[i]["TransC_curValue"]).Split('.');
            if (tmpMoney.Length > 0)
              if (IsNumeric(tmpMoney[0]))
                totalTranscMoney += long.Parse(tmpMoney[0]);
          }

          long totalTranscMoneyRefund = 0;
          for (int i = 0; i < this.tblBO_DBTransTicketRefund.Rows.Count; i++)
          {
            string[] tmpMoney = ((string)this.tblBO_DBTransTicketRefund.Rows[i]["TransC_curValue"]).Split('.');
            if (tmpMoney.Length > 0)
              if (IsNumeric(tmpMoney[0]))
                totalTranscMoneyRefund += long.Parse(tmpMoney[0]);
          }
          string sFormat = string.Format("#{0}###", ",");
          this.txtVistaTotalAmount.Text = (totalTranscMoney * 1000).ToString(sFormat);
          //this.txtVistaTotalRefundAmount.Text = (totalTranscMoneyRefund * 1000).ToString(sFormat);
          /*if (this.radCheckRefund.Checked)
          {
            this.CombineRefundTable();
          }
          else
           */
          //PHAN NAY SE TINH TONG GIA TRI GHI NHAN TREN REPORT VISTA ELECTRONIC PAYMENT - KHI NAO CAN THI ENABLE LEN
        /*
          sqlCommandString = string.Format("SELECT SUM([TransC_curValue]) TotalValue FROM [OPTR].[dbo].[tbl_Trans_Cash] WHERE ([TransC_dtmDateTime] between '{0}' and '{1}')", fromDate, toDate);
          if (option == 1)
          {
              sqlCommandString += string.Format(" AND (TransC_strBKCardType = '{0}' OR TransC_strBKCardType = '{1}')", "123PAY-ATM", "123PAY-VIS");
          }
          else
          {
              if (option == 2)
              {
                  sqlCommandString += string.Format(" AND TransC_strBKCardType = '{0}'", "ONEPAY-ATM");
              }
              else
              {
                  sqlCommandString += string.Format(" AND TransC_strBKCardType = '{0}'", "ONEPAY-VIS");
              }
          }
          this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
          this.adapter.SelectCommand.CommandType = CommandType.Text;
          this.adapter.SelectCommand.CommandTimeout = 0;

          this.tblBO_ElectronicPaymentAmount.Rows.Clear();
          this.adapter.Fill(this.tblBO_ElectronicPaymentAmount);
          totalTranscMoney = 0;

          for (int i = 0; i < this.tblBO_ElectronicPaymentAmount.Rows.Count; i++)
          {
              string[] tmpMoney = ((string)this.tblBO_ElectronicPaymentAmount.Rows[i]["TotalValue"]).Split('.');
              if (tmpMoney.Length > 0)
                  if (IsNumeric(tmpMoney[0]))
                      totalTranscMoney += long.Parse(tmpMoney[0]);
          }

          sFormat = string.Format("#{0}###", ",");
          this.txtElectronicPayment.Text = (totalTranscMoney * 1000).ToString(sFormat);
         */
          this.CombineTable();          
          //MessageBox.Show("Đối soát xong. Vui lòng kiểm tra danh sách bên dưới.", "Thông báo");
        }
      }
      catch (Exception exp)
      {
          MessageBox.Show(string.Format("SYSTEM ERROR MESSAGE: {0}", exp.Message));
      }

    }
    private void LoadDataFromVistaBO(int startindex, int count)
    {
      this.tblBO_DBTrans.Rows.Clear();
      this.isDuplicate = false;
      string fromDate = string.Format("{0:MM/dd/yyyy}", dtpFromDate.Value);
      string toDate = string.Format("{0:MM/dd/yyyy}", dtpToDate.Value);

      try
      {
        this.OpenConnection(this.lab_connectionString_OPTR);
        string selectString = "SELECT TransC_lgnNumber, TransC_strType, TransC_dtmDateTime, TransC_curValue, TransC_strBKCardType, TransC_strPaymentTransRef, TransC_dtmRealTransTime, CinOperator_strCode";
        string fromString = " FROM tblTrans_Cash";
        string orderByString = " ORDER BY TransC_dtmRealTransTime ASC";

        string whereString = string.Format(" WHERE TransC_dtmRealTransTime BETWEEN '{0}' AND '{1}'", fromDate, toDate);
        string sqlCommandString = selectString + fromString + whereString + orderByString;

        this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
        this.adapter.SelectCommand.CommandType = CommandType.Text;
        this.adapter.SelectCommand.CommandTimeout = 0;

        this.tblBO_DBTrans.Rows.Clear();
        this.adapter.Fill(this.tblBO_DBTrans);
        this.labTotalTransaction.Text = string.Format("{0} giao dịch", this.tblBO_DBTrans.Rows.Count);

        //this.AddRowTable(startindex, count);
        this.FillDataGrid();
        //this.FillDropDownList(20, this.tbResult);
      }
      catch (Exception exp)
      {
          MessageBox.Show(string.Format("SYSTEM ERROR MESSAGE: {0}", exp.Message));
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
    private void FillDropDownList(int maxItem, DataTable tblDataFill)
    {
      this.comOLRecPageInfo.Items.Clear();
      if (tblDataFill.Rows.Count > 0)
      {
        int totalPage = 0;
        totalPage = tblDataFill.Rows.Count / maxItem;
        if ((tblDataFill.Rows.Count % maxItem) > 0)
          totalPage++;
        for (int i = 0; i < totalPage; i++)
        {
          this.comOLRecPageInfo.Items.Insert(i, i + 1);
        }
        if (this.comOLRecPageInfo.SelectedIndex < 0)
          this.comOLRecPageInfo.SelectedIndex = 0;
      }
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
          MessageBox.Show(string.Format("SYSTEM ERROR MESSAGE: {0}", exp.Message));
        return string.Empty;
      }
    }
    public static DataSet GetDataExcel(string fPath, string sheetname)
    {
      try
      {
        DataSet ds = new DataSet();
        System.Data.DataTable dt = null;
        string connectionstring = OpenExcelFile(fPath);
        string query = "SELECT * FROM [" + sheetname + "$]";
        using (OleDbConnection cnn = new OleDbConnection(connectionstring))
        {
          cnn.Open();
          dt = cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            if(dt.Rows.Count > 0)
                sheetname = dt.Rows[0]["TABLE_NAME"].ToString(); 
          query = "SELECT * FROM [" + sheetname + "]";
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
          MessageBox.Show(string.Format("SYSTEM ERROR MESSAGE: {0}", exp.Message));
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

    public int IsDateTime(string value)
    {
        //msg = null;
        string s = value.Trim();
        if (s.Length == 0)
        {
            return 0;
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
            if (DateTime.TryParseExact(s, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out d))
            {
                return 1;
            }
            else
            {
                if (DateTime.TryParseExact(s, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out d))
                {
                    return 2;
                }
                else 
                    if(DateTime.TryParse(s, out d))
                    {
                        return 3;
                    }
                    else
                        return 0;
            }
        }

    }
    
    private void ImportFromExcel()
    {
      this.ClearAllTables();
      this.txtPayConnectorTotalAmout.Text = string.Empty;
      //this.txtRefundInTime.Text = string.Empty;
      //this.txtRefundOutOfTime.Text = string.Empty;
      this.txtVistaTotalAmount.Text = string.Empty;
      if (this.rad123Pay.Checked)
      {
        Int64 totalTranscMoney = 0;
        Int64 totalRefundInTimeMoney = 0;
        Int64 totalRefundOutTimeMoney = 0;
        
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
          alert = new AlertForm();
          alert.Show();
          try
          {
            
            string[] a = new string[50];
            string[] strDateTime = new string[20];
            DataSet ds = new DataSet();
            int orderNumber = 0;
            ds = GetDataExcel(openFileDialog1.FileName, "Sum up");// Goi chuong trinh GetDataExcel phia tren luu vao Dataset ds        
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++) //Dong
            {
              for (int j = 0; j < ds.Tables[0].Columns.Count; j++)//Cot 
              {
                a[j] = ds.Tables[0].Rows[i].ItemArray[j].ToString().Trim();
              };
              //MessageBox.Show(a.Length.ToString());
              //Bat dau import du lieu vao
              //mh.Insert(a[0], a[1], byte.Parse(a[2]));
              DataRow row;
              if (a[4].ToString() != "Refund")
              {
                if (a[2].Length > 0)
                {
                  row = this.tblExcelTrans.NewRow();
                  row["No"] = orderNumber + 1;
                  row["TransC_excel_strPaymentTransRef"] = a[2];
                  row["TransC_excel_strType"] = a[5];
                  
                  if (IsDateTime(a[3]) != 0)
                  {
                      strDateTime = a[3].Split('/');
                      if(strDateTime.Length >= 0)
                          row["TransC_excel_dtmDateTime"] = strDateTime[1] + "/" + strDateTime[0] + "/" + strDateTime[2];
                  }

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
                  orderNumber++;
                }

              }
              else
              {
                if (a[2].Length > 0)
                {
                  

                  string[] temptValue7 = a[7].Split(',');
                  string[] temptValue8 = a[8].Split(',');
                  int tempRefundInTimeMoney = 0;
                  int tempRefundOutTimeMoney = 0;

                  if (temptValue7.Length > 0)
                  {
                    string transValue = string.Empty;
                    
                    for (int index = 0; index < temptValue7.Length; index++)
                    {
                      transValue = transValue + temptValue7[index];
                    }
                    if (IsNumeric(transValue))
                      tempRefundInTimeMoney = int.Parse(transValue);
                    if (tempRefundInTimeMoney > 0)
                    {
                      row = this.tblExcelRefundTrans.NewRow();
                      row["TransC_excel_curValue"] = a[7];
                      row["No"] = a[0];
                      row["TransC_excel_strPaymentTransRef"] = a[2];
                      row["TransC_excel_strType"] = a[4];
                      if (IsDateTime(a[3]) != 0)
                      {
                          strDateTime = a[3].Split('/');
                          if (strDateTime.Length >= 0)
                              row["TransC_excel_dtmDateTime"] = strDateTime[1] + "/" + strDateTime[0] + "/" + strDateTime[2];
                      }
                      this.tblExcelRefundTrans.Rows.Add(row);

                    }                    
                    totalRefundInTimeMoney += tempRefundInTimeMoney;
                  }
                  if (temptValue8.Length > 0)
                  {
                    string transValue = string.Empty;
                    //row["TransC_excel_curValue"] = a[8];
                    for (int index = 0; index < temptValue8.Length; index++)
                    {
                      transValue = transValue + temptValue8[index];
                    }
                    if (IsNumeric(transValue))
                      tempRefundOutTimeMoney = int.Parse(transValue);
                    totalRefundOutTimeMoney += tempRefundOutTimeMoney;
                    if (tempRefundOutTimeMoney > 0)
                    {
                      row = this.tblExcelRefundTransNotInTime.NewRow();
                      row["TransC_excel_curValue"] = a[8];
                      row["No"] = a[0];
                      row["TransC_excel_strPaymentTransRef"] = a[2];
                      row["TransC_excel_strType"] = a[4];
                      if (IsDateTime(a[3]) != 0)
                      {
                          strDateTime = a[3].Split('/');
                          if (strDateTime.Length >= 0)
                              row["TransC_excel_dtmDateTime"] = strDateTime[1] + "/" + strDateTime[0] + "/" + strDateTime[2];
                          //row["TransC_excel_dtmDateTime"] = a[3];
                      }
                      this.tblExcelRefundTransNotInTime.Rows.Add(row);
                    }
                  }                  
                }
              }
            }
            //LoadData();
            FillDataGrid(this.tblExcelTrans);
            //this.dgrBankRefundInTime.DataSource = this.tblExcelRefundTrans;
            //this.dgrBankRefundOutTime.DataSource = this.tblExcelRefundTransNotInTime;
            string sFormat = string.Format("#{0}###", ",");
            //string a = double.Parse(12345).ToString(sFormat);
            this.txtPayConnectorTotalAmout.Text = (totalTranscMoney).ToString(sFormat);
            //this.txtRefundInTime.Text = (totalRefundInTimeMoney).ToString(sFormat);
            //this.txtRefundOutOfTime.Text = (totalRefundOutTimeMoney).ToString(sFormat);
            //MessageBox.Show("Import thành công!", "Thông báo");
          }
          catch (Exception exp)
          {
            MessageBox.Show(string.Format("SYSTEM ERROR MESSAGE: {0}", exp.Message));
          }
          alert.Close();
        }  
      }
      else if(this.radOnePayATM.Checked)
      {
        Int64 totalTranscMoney = 0;
        //Int64 totalRefundMoney = 0;
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
          alert = new AlertForm();
          alert.Show();
          try
          {

            string[] a = new string[50];
            string[] strDateTime = new string[20];
            
            DataSet ds = new DataSet();
            ds = GetDataExcel(openFileDialog1.FileName, "sheetname");// Goi chuong trinh GetDataExcel phia tren luu vao Dataset ds        
            for (int i = 7; i < ds.Tables[0].Rows.Count; i++) //Dong
            {
              for (int j = 0; j < ds.Tables[0].Columns.Count; j++)//Cot 
              {
                a[j] = ds.Tables[0].Rows[i].ItemArray[j].ToString().Trim();
              };
              //MessageBox.Show(a.Length.ToString());
              //Bat dau import du lieu vao
              //mh.Insert(a[0], a[1], byte.Parse(a[2]));
              DataRow row;
              //if (a[2].ToString() != "Refund")
              {
                if (a[2].Length > 0)
                {
                  row = this.tblExcelTrans.NewRow();
                  row["No"] = a[0];
                  row["TransC_excel_strPaymentTransRef"] = a[2];
                  row["TransC_excel_strType"] = a[3];
                  string[] tmpDate = a[5].Split(' ');

                  if (IsDateTime(tmpDate[0]) != 0)
                  {
                      strDateTime = tmpDate[0].Split('/');
                      if (strDateTime.Length >= 0)
                          row["TransC_excel_dtmDateTime"] = strDateTime[1] + "/" + strDateTime[0] + "/" + strDateTime[2];
                      //row["TransC_excel_dtmDateTime"] = a[5];
                  }
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
              /*
              else
              {
                if (a[2].Length > 0)
                {
                  row = this.tblExcelRefundTrans.NewRow();
                  row["No"] = a[0];
                  row["TransC_excel_strPaymentTransRef"] = a[2];
                  row["TransC_excel_strType"] = a[4];
                  row["TransC_excel_dtmDateTime"] = a[3];


                  string[] temptValue7 = a[7].Split(',');
                  string[] temptValue8 = a[8].Split(',');

                  if (temptValue7.Length > 0)
                  {
                    string transValue = string.Empty;
                    row["TransC_excel_curValue"] = a[7];
                    for (int index = 0; index < temptValue7.Length; index++)
                    {
                      transValue = transValue + temptValue7[index];
                    }
                    totalRefundMoney += int.Parse(transValue);
                  }
                  if (temptValue8.Length > 0)
                  {
                    string transValue = string.Empty;
                    row["TransC_excel_curValue"] = a[8];
                    for (int index = 0; index < temptValue8.Length; index++)
                    {
                      transValue = transValue + temptValue8[index];
                    }
                    totalRefundMoney += int.Parse(transValue);
                  }

                  this.tblExcelRefundTrans.Rows.Add(row);
                }
              }
               */
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
            MessageBox.Show(string.Format("SYSTEM ERROR MESSAGE: {0}", exp.Message));
          }
          alert.Close();
        }  
      }
      else if (this.radOnePayVisa.Checked)
      {
        Int64 totalTranscMoney = 0;
        //Int64 totalRefundMoney = 0;
        int rowIndex = 0;
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
          alert = new AlertForm();
          alert.Show();
          try
          {
            string[] a = new string[50];
            DataSet ds = new DataSet();
            ds = GetDataExcel(openFileDialog1.FileName, "GALAXYCINE");// Goi chuong trinh GetDataExcel phia tren luu vao Dataset ds        
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
                  
                  row = this.tblExcelTrans.NewRow();
                  row["No"] = rowIndex + 1;
                  row["TransC_excel_strPaymentTransRef"] = a[0];
                  row["TransC_excel_strType"] = a[4];
                  if (IsDateTime(a[2]) != 0)
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
                  rowIndex++;
                }

              }
              /*
              else
              {
                if (a[2].Length > 0)
                {
                  row = this.tblExcelRefundTrans.NewRow();
                  row["No"] = a[0];
                  row["TransC_excel_strPaymentTransRef"] = a[2];
                  row["TransC_excel_strType"] = a[4];
                  row["TransC_excel_dtmDateTime"] = a[3];


                  string[] temptValue7 = a[7].Split(',');
                  string[] temptValue8 = a[8].Split(',');

                  if (temptValue7.Length > 0)
                  {
                    string transValue = string.Empty;
                    row["TransC_excel_curValue"] = a[7];
                    for (int index = 0; index < temptValue7.Length; index++)
                    {
                      transValue = transValue + temptValue7[index];
                    }
                    totalRefundMoney += int.Parse(transValue);
                  }
                  if (temptValue8.Length > 0)
                  {
                    string transValue = string.Empty;
                    row["TransC_excel_curValue"] = a[8];
                    for (int index = 0; index < temptValue8.Length; index++)
                    {
                      transValue = transValue + temptValue8[index];
                    }
                    totalRefundMoney += int.Parse(transValue);
                  }

                  this.tblExcelRefundTrans.Rows.Add(row);
                }
              }
               */
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
            MessageBox.Show(string.Format("SYSTEM ERROR MESSAGE: {0}", exp.Message));
          }
          alert.Close();
        }  
      }
      else
      {
        Int64 totalTranscMoney = 0;
        //Int64 totalRefundMoney = 0;
        int count = 0;
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
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
              //MessageBox.Show(a.Length.ToString());
              //Bat dau import du lieu vao
              //mh.Insert(a[0], a[1], byte.Parse(a[2]));
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
                  if (IsDateTime(a[0]) != 0)
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
              //MessageBox.Show(a.Length.ToString());
              //Bat dau import du lieu vao
              //mh.Insert(a[0], a[1], byte.Parse(a[2]));
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
                  if (IsDateTime(a[0]) != 0)
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
                    if(IsNumeric(transValue))
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
            MessageBox.Show(string.Format("SYSTEM ERROR MESSAGE: {0}", exp.Message));
          }
          alert.Close();
        }  
      }
    }
    private void StartBackgroundWorker()
    {/*
      if (backgroundWorker1.IsBusy != true)
      {
        // create a new instance of the alert form
        alert = new AlertForm();

        // event handler for the Cancel button in AlertForm
        alert.Canceled += new EventHandler<EventArgs>(buttonCancel_Click);
        alert.Show();
        // Start the asynchronous operation.
        backgroundWorker1.RunWorkerAsync();
      }
      */ 
    }
    private void CancelBackgroundWorker()
    {
      /*
      if (backgroundWorker1.WorkerSupportsCancellation == true)
      {
        // Cancel the asynchronous operation.
        backgroundWorker1.CancelAsync();
        // Close the AlertForm
        alert.Close();
      }
       */
    }
    #endregion Methods
    // This event handler is where the time-consuming work is done.
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
      /*
      BackgroundWorker worker = sender as BackgroundWorker;
      for (int i = 1; i <= 8; i++)
      {
        // Perform a time consuming operation and report progress.
        worker.ReportProgress(i * 10);
        System.Threading.Thread.Sleep(500);
      }
      //this.DataCaching();
      if (this.reconciliation)
      {
        if (this.rad123Pay.Checked)
        {
          this.LoadDataFromVistaBO(1);
        }
        else if (this.radOnePayATM.Checked)
        {
          this.LoadDataFromVistaBO(2);
        }
        else if (this.radOnePayVisa.Checked)
        {
          this.LoadDataFromVistaBO(3);
        }
        else if (this.radLapTest.Checked)
        {
          this.LoadDataFromVistaBO(4);
        }
        else
          this.LoadDataFromVistaBO(0);
      }
      else
      {
        this.ImportFromExcel();
      }
      this.ClearAllOptionValue();
      for (int i = 8; i <= 10; i++)
      {
        // Perform a time consuming operation and report progress.
        worker.ReportProgress(i * 10);
        System.Threading.Thread.Sleep(500);
      }
       */
    }
    // This event handler updates the progress.
    private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
    {
      // Show the progress in main form (GUI)
      //labelResult.Text = (e.ProgressPercentage.ToString() + "%");
      // Pass the progress to AlertForm label and progressbar
      //alert.Message = "Đang kết nối hệ thống! Vui lòng đợi...... " + e.ProgressPercentage.ToString() + "%";
      //alert.ProgressValue = e.ProgressPercentage;
    }
    // This event handler cancels the backgroundworker, fired from Cancel button in AlertForm.
    private void buttonCancel_Click(object sender, EventArgs e)
    {
      /*
      if (backgroundWorker1.WorkerSupportsCancellation == true)
      {
        // Cancel the asynchronous operation.
        backgroundWorker1.CancelAsync();
        // Close the AlertForm
        alert.Close();
      }
       */
    }
    // This event handler deals with the results of the background operation.
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
      /* 
      else
      {
        MessageBox.Show("Đã kết nối thành công!", "Thông báo");
      }
      */
      // Close the AlertForm
      alert.Close();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      /*
      if (backgroundWorker1.IsBusy != true)
      {
        // create a new instance of the alert form
        alert = new AlertForm();
        //mainForm = new frmMain();
        // event handler for the Cancel button in AlertForm
        alert.Canceled += new EventHandler<EventArgs>(buttonCancel_Click);
        alert.Show();
        // Start the asynchronous operation.
        backgroundWorker1.RunWorkerAsync();
      }
       */

    }
  private void btnImportFromExcel_Click(object sender, EventArgs e)
  {
    this.importExcel = true;
    this.ImportFromExcel();
  }

  private void btnRec_Click(object sender, EventArgs e)
  {
    this.txtVistaTotalAmount.Text = string.Empty;
    this.txtElectronicPayment.Text = string.Empty;
    this.reconciliation = true;
    if (this.tblExcelTrans.Rows.Count == 0)
    {
      MessageBox.Show("Import dữ liệu từ Excel trước khi tra soát!", "Thông báo");
    }
    else
    {
      alert = new AlertForm();
      alert.Show();
      
      //this.StartBackgroundWorker();
      
      if (this.rad123Pay.Checked)
      {
        this.LoadDataFromVistaBO(1);
      }
      else if (this.radOnePayATM.Checked)
      {
        this.LoadDataFromVistaBO(2);
      }
      else if (this.radOnePayVisa.Checked)
      {
        this.LoadDataFromVistaBO(3);
      }
      /*else if (this.radCheckRefund.Checked)
      {
        this.LoadDataFromVistaBO(4);
      }
      */
      else 
      {
        //this.LoadDataFromVistaBO(0);
      }
      alert.Close();   
      
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
    
    this.dtpFromDate.Value = DateTime.Today.AddDays(-3);
    this.dtpToDate.Value = DateTime.Today;
    string fromDate = string.Format("{0:MM/dd/yyyy}", dtpFromDate.Value);
    string toDate = string.Format("{0:MM/dd/yyyy}", dtpToDate.Value);
  /*
    alert = new AlertForm();
    this.alert.Show();
    this.DataCaching(fromDate, toDate);
    this.alert.Close();
   */ 
 
  }
  void btnImportExcelRefund_Click(object sender, System.EventArgs e)
  {
    this.importExcelRefund = true;
    this.ImportFromExcel();
  }

  private void btnInsertRefund_Click(object sender, EventArgs e)
  {
    this.InsertTransRefundToDB();
  }

  private void txtElectronicPayment_TextChanged(object sender, EventArgs e)
  {

  }

  
}
}

