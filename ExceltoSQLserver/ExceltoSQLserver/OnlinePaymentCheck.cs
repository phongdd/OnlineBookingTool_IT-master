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

namespace ExceltoSQLserver
{
public partial class OnlinePaymentCheck : Form
{
  public OnlinePaymentCheck()
  {
    InitializeComponent();
    this.tblReconciliationMatch = new DataTable("tblReconciliationMatch");
    this.tblExcelRefundTrans = new DataTable("tblExcelRefundTrans");
    this.tblExcelTrans = new DataTable("tblExcelTrans");
    this.tblBO_DBTrans = new DataTable("tblBO_DBTrans");
    this.tblVISTAIT_OLTrans = new DataTable("tblVISTAIT_OLTrans");
    this.tblBO_DBTransNotInExcel = new DataTable("tblBO_DBTransNotInExcel");
    this.tblReconciliationNotMatch = new DataTable("tblReconciliationNotMatch");
    this.con = new SqlConnection();
    this.OpenConnection(this.lab_connectionString_OPTR);
    this.adapter = new SqlDataAdapter();
    this.CreatTable();
  }

  #region Fields

  /// <summary>
  /// //////////////////////
  private DataTable tbResult;
  private bool isDuplicate = false;
  //private DataRow rowResult;
  //private DataColumn colResult;
  //private int index = 0;
  private AlertForm alert;
  private DataTable tblDuplicate;
  private DataTable tbTempResult;
  private DataTable tbTempTransC;
  //private SqlConnection con;
  private DataRow[] dataRowList;

  ////live connection string
  //private string connectionString = "Data Source=192.168.116.5;Initial Catalog=VISTAIT_41;User Id=sa;Password=GaLaXyNDNTTB126;";
  private string lab_connectionString = "Data Source=192.168.116.201;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
  //private string lab_connectionString_OPTR = "Data Source=192.168.116.201;Initial Catalog=OPTR;User Id=sa;Password=GaLaXyNDNTTB126;";
  private string nd_BOConnectionString = "Data Source=192.168.116.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
  private string nt_BOConnectionString = "Data Source=192.168.117.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
  private string tb_BOConnectionString = "Data Source=192.168.118.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;Connection Timeout=120;";
  private string kdv_BOConnectionString = "Data Source=192.168.119.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
  private string qt_BOConnectionString = "Data Source=192.168.120.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
  /// </summary>

    //private AlertForm alert;
    private DataTable tblReconciliationMatch;
    private DataTable tblExcelRefundTrans;
    private DataTable tblExcelTrans;
    private DataTable tblBO_DBTrans;
    private DataTable tblVISTAIT_OLTrans;
    private DataTable tblReconciliationNotMatch;
    private DataTable tblBO_DBTransNotInExcel;
    DataSet ds = new DataSet("DataSet");
    private SqlConnection con;
    //private bool isDuplicate = false;
    private bool importExcel = false;
    private bool reconciliation = false;
    private bool importExcelRefund = false;
    private static readonly Regex ShortDate = new Regex(@"^\d{6}$");
    private static readonly Regex LongDate = new Regex(@"^\d{8}$");
    
    
    ////live connection string
   
    private string lab_connectionString_OPTR = "Data Source=192.168.116.201;Initial Catalog=OPTR;User Id=sa;Password=GaLaXyNDNTTB126;";
    private string connectionString_VISTAIT = "Data Source=192.168.116.5;Initial Catalog=VISTAIT_41;User Id=sa;Password=GaLaXyNDNTTB126;";
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
      //this.tblBO_DBTrans.PrimaryKey = new DataColumn[] { this.tblBO_DBTrans.Columns["TransC_strPaymentTransRef"] };

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
      this.tblExcelTrans.Rows.Clear();
      this.tblBO_DBTrans.Rows.Clear();
      this.tblBO_DBTransNotInExcel.Rows.Clear();
      this.tblVISTAIT_OLTrans.Rows.Clear();
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

        //this.dgrTransVistaNotInExcel.DataSource = this.tblBO_DBTransNotInExcel;
      }
      catch (Exception exp)
      {
        MessageBox.Show(string.Format("Định dạng file Excel không đúng hoặc định dạng ngày tháng dữ liệu trong file không chính xác. Vui lòng kiểm tra lại file hoặc báo Mr. Viễn để check. SYSTEM ERROR MESSAGE: {0}", exp.Message));
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
            //row["TransC_excel_dtmDateTime"] = dr["TransC_excel_dtmDateTime"];
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

        //this.dgrTransVistaNotInExcel.DataSource = this.tblBO_DBTransNotInExcel;
      }
      catch (Exception exp)
      {
        MessageBox.Show(string.Format("Định dạng file Excel không đúng hoặc định dạng ngày tháng dữ liệu trong file không chính xác. Vui lòng kiểm tra lại file hoặc báo Mr. Viễn để check. SYSTEM ERROR MESSAGE: {0}", exp.Message));
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

        //this.dgrTransVistaNotInExcel.DataSource = this.tblBO_DBTransNotInExcel;
      }
      catch (Exception exp)
      {
        MessageBox.Show(string.Format("Định dạng file Excel không đúng hoặc định dạng ngày tháng dữ liệu trong file không chính xác. Vui lòng kiểm tra lại file hoặc báo Mr. Viễn để check. SYSTEM ERROR MESSAGE: {0}", exp.Message));
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
        MessageBox.Show(string.Format("Hệ thống phát sinh lỗi: {0}. Vui lòng chụp màn hình và báo Mr. Viễn để check. Thành thật xin lỗi vì sự bất tiện này!", exp.Message));
      }
         
    }
    private void LoadDataFromVistaBO(int option)
    {
      this.tblBO_DBTrans.Rows.Clear();
      this.tblVISTAIT_OLTrans.Rows.Clear();
      string fromDate = string.Format("{0:MM/dd/yyyy}", dtpFromDate.Value);
      string toDate = string.Format("{0:MM/dd/yyyy}", dtpToDate.Value);

      try
      {
        if (option == 0)
        {
          this.OpenConnection(this.connectionString_VISTAIT);
          string selectString = "SELECT WebPayTN_lngPayTransNumber, WebPayH_strBankRef, OrderH_intVistaBookingNumber, OrderH_dtmLastUpdated";
          string fromString = " FROM vwOrderHistory WHERE (OrderH_strZipCode <> '') AND (OrderH_strZipCode is not NULL)";
          string orderByString = " ORDER BY OrderH_dtmLastUpdated DESC";

          string sqlCommandString = selectString + fromString + orderByString;

          this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
          this.adapter.SelectCommand.CommandType = CommandType.Text;
          this.adapter.Fill(this.tblVISTAIT_OLTrans);          
          this.CombineRefundWithVISTAIT();
          MessageBox.Show("Đối soát xong. Vui lòng kiểm tra danh sách bên dưới.", "Thông báo");
        }
        else
        {

          this.OpenConnection(this.lab_connectionString_OPTR);
          string selectString = "SELECT TransC_lgnNumber, TransC_strType, TransC_dtmDateTime, TransC_curValue, TransC_strBKCardType, TransC_strPaymentTransRef, TransC_dtmRealTransTime, CinOperator_strCode";
          string fromString = " FROM tbl_Trans_Cash";
          if(chk2014.Checked)
            fromString = " FROM tbl_Trans_Cash_2014";

          string orderByString = " ORDER BY TransC_dtmRealTransTime ASC";
          string whereString = string.Format(" WHERE TransC_dtmRealTransTime BETWEEN '{0}' AND '{1}'", fromDate, toDate);
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
            if (tmpMoney.Length > 0)
              totalTranscMoney += long.Parse(tmpMoney[0]);
          }
          string sFormat = string.Format("#{0}###", ",");
          this.txtVistaTotalAmount.Text = (totalTranscMoney * 1000).ToString(sFormat);
          if (this.radLapTest.Checked)
          {
            this.CombineRefundTable();
          }
          else
            this.CombineTable();          
          //MessageBox.Show("Đối soát xong. Vui lòng kiểm tra danh sách bên dưới.", "Thông báo");
        }
      }
      catch (Exception exp)
      {
        MessageBox.Show(string.Format("Hệ thống phát sinh lỗi: {0}. Vui lòng chụp màn hình và báo Mr. Viễn để check. Thành thật xin lỗi vì sự bất tiện này!", exp.Message));
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
        MessageBox.Show(string.Format("Hệ thống phát sinh lỗi: {0}. Vui lòng chụp màn hình và báo Mr. Viễn để check. Thành thật xin lỗi vì sự bất tiện này!", exp.Message));
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
    private void CreatTable(int test)
    {
      this.tbTempTransC.Columns.Add("TransC_lgnNumber", typeof(string));
      this.tbTempTransC.Columns.Add("TransC_strType", typeof(string));
      this.tbTempTransC.Columns.Add("TransC_dtmDateTime", typeof(DateTime));
      this.tbTempTransC.Columns.Add("TransC_curValue", typeof(string));
      this.tbTempTransC.Columns.Add("TransC_strBKCardType", typeof(string));
      this.tbTempTransC.Columns.Add("TransC_strPaymentTransRef", typeof(string));
      this.tbTempTransC.Columns.Add("TransC_dtmRealTransTime", typeof(DateTime));
      this.tbTempTransC.Columns.Add("CinOperator_strCode", typeof(string));

      this.tblDuplicate.Columns.Add("TransC_lgnNumber", typeof(string));
      this.tblDuplicate.Columns.Add("TransC_strType", typeof(string));
      this.tblDuplicate.Columns.Add("TransC_dtmDateTime", typeof(DateTime));
      this.tblDuplicate.Columns.Add("TransC_curValue", typeof(string));
      this.tblDuplicate.Columns.Add("TransC_strBKCardType", typeof(string));
      this.tblDuplicate.Columns.Add("TransC_strPaymentTransRef", typeof(string));
      this.tblDuplicate.Columns.Add("TransC_dtmRealTransTime", typeof(DateTime));
      this.tblDuplicate.Columns.Add("CinOperator_strCode", typeof(string));

      this.tbResult.Columns.Add("TransC_lgnNumber", typeof(string));
      this.tbResult.Columns.Add("TransC_strType", typeof(string));
      this.tbResult.Columns.Add("TransC_dtmDateTime", typeof(DateTime));
      this.tbResult.Columns.Add("TransC_curValue", typeof(string));
      this.tbResult.Columns.Add("TransC_strBKCardType", typeof(string));
      this.tbResult.Columns.Add("TransC_strPaymentTransRef", typeof(string));
      this.tbResult.Columns.Add("TransC_dtmRealTransTime", typeof(DateTime));
      this.tbResult.Columns.Add("CinOperator_strCode", typeof(string));

      this.tbTempResult.Columns.Add("TransC_lgnNumber", typeof(string));
      this.tbTempResult.Columns.Add("TransC_strType", typeof(string));
      this.tbTempResult.Columns.Add("TransC_dtmDateTime", typeof(DateTime));
      this.tbTempResult.Columns.Add("TransC_curValue", typeof(string));
      this.tbTempResult.Columns.Add("TransC_strBKCardType", typeof(string));
      this.tbTempResult.Columns.Add("TransC_strPaymentTransRef", typeof(string));
      this.tbTempResult.Columns.Add("TransC_dtmRealTransTime", typeof(DateTime));
      this.tbTempResult.Columns.Add("CinOperator_strCode", typeof(string));


    }
    private void AddRowTable(int index, int count)
    {
      int rowIndex = index * count;
      this.tbTempTransC.Rows.Clear();
      for (int i = 0; i < count; i++)
      {
        if (rowIndex < this.tbResult.Rows.Count)
        {
          DataRow row = this.tbTempTransC.NewRow();
          row["TransC_lgnNumber"] = this.tbResult.Rows[rowIndex]["TransC_lgnNumber"];
          row["TransC_strType"] = this.tbResult.Rows[rowIndex]["TransC_strType"];
          row["TransC_dtmDateTime"] = this.tbResult.Rows[rowIndex]["TransC_dtmDateTime"];
          row["TransC_curValue"] = this.tbResult.Rows[rowIndex]["TransC_curValue"];
          row["TransC_strBKCardType"] = this.tbResult.Rows[rowIndex]["TransC_strBKCardType"];
          row["TransC_strPaymentTransRef"] = this.tbResult.Rows[rowIndex]["TransC_strPaymentTransRef"];
          row["TransC_dtmRealTransTime"] = this.tbResult.Rows[rowIndex]["TransC_dtmRealTransTime"];
          row["CinOperator_strCode"] = this.tbResult.Rows[rowIndex]["CinOperator_strCode"];
          this.tbTempTransC.Rows.Add(row);
        }
        else
          break;
        rowIndex++;
      }
    }
    private void LoadDataFromVistaBO(int cinemaCode, int startindex, int count)
    {
      this.tbTempTransC.Rows.Clear();
      this.tbResult.Rows.Clear();
      this.isDuplicate = false;
      string fromDate = string.Format("{0:MM/dd/yyyy}", dtpFromDate.Value);
      string toDate = string.Format("{0:MM/dd/yyyy}", dtpToDate.Value);
      switch (cinemaCode)
      {
        case 1:
          {
            try
            {
              this.OpenConnection(this.nd_BOConnectionString);
              string selectString = "SELECT TransC_lgnNumber, TransC_strType, TransC_dtmDateTime, TransC_curValue, TransC_strBKCardType, TransC_strPaymentTransRef, TransC_dtmRealTransTime, CinOperator_strCode";
              string fromString = " FROM tblTrans_Cash";
              string orderByString = " ORDER BY TransC_dtmRealTransTime ASC";
              string whereString = string.Format(" WHERE TransC_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND TransC_strType = 'R' AND TransC_strBKCardType <> '123PHIM' ", fromDate, toDate);
              string sqlCommandString = selectString + fromString + whereString + orderByString;

              this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
              this.adapter.SelectCommand.CommandType = CommandType.Text;
              this.adapter.SelectCommand.CommandTimeout = 0;

              this.tbResult.Rows.Clear();
              this.adapter.Fill(this.tbResult);
              this.labTotalTransaction.Text = string.Format("{0} giao dịch", this.tbResult.Rows.Count);

              this.AddRowTable(startindex, count);
              this.FillDataGrid();
              this.FillDropDownList(20, this.tbResult);
            }
            catch (Exception exp)
            {
              MessageBox.Show(exp.Message);
            }
          }
          break;

        case 2:
          {
            try
            {
              this.OpenConnection(this.nt_BOConnectionString);
              string selectString = "SELECT TransC_lgnNumber, TransC_strType, TransC_dtmDateTime, TransC_curValue, TransC_strBKCardType, TransC_strPaymentTransRef, TransC_dtmRealTransTime, CinOperator_strCode";
              string fromString = " FROM tblTrans_Cash";
              string orderByString = " ORDER BY TransC_dtmRealTransTime ASC";

              string whereString = string.Format(" WHERE TransC_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND TransC_strType = 'R' AND TransC_strBKCardType <> '123PHIM' ", fromDate, toDate);
              string sqlCommandString = selectString + fromString + whereString + orderByString;

              this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
              this.adapter.SelectCommand.CommandType = CommandType.Text;
              this.adapter.SelectCommand.CommandTimeout = 0;

              this.tbResult.Rows.Clear();
              this.adapter.Fill(this.tbResult);
              this.labTotalTransaction.Text = string.Format("{0} giao dịch", this.tbResult.Rows.Count);

              this.AddRowTable(startindex, count);
              this.FillDataGrid();
              this.FillDropDownList(20, this.tbResult);
            }
            catch (Exception exp)
            {
              MessageBox.Show(exp.Message);
            }
          }
          break;
        case 3:
          {
            try
            {
              this.OpenConnection(this.tb_BOConnectionString);
              //MessageBox.Show(this.con.ConnectionTimeout.ToString());
              string selectString = "SELECT TransC_lgnNumber, TransC_strType, TransC_dtmDateTime, TransC_curValue, TransC_strBKCardType, TransC_strPaymentTransRef, TransC_dtmRealTransTime, CinOperator_strCode";
              string fromString = " FROM tblTrans_Cash";
              string orderByString = " ORDER BY TransC_dtmRealTransTime ASC";

              string whereString = string.Format(" WHERE TransC_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND TransC_strType = 'R' AND TransC_strBKCardType <> '123PHIM' ", fromDate, toDate);
              string sqlCommandString = selectString + fromString + whereString + orderByString;

              this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
              this.adapter.SelectCommand.CommandType = CommandType.Text;
              this.adapter.SelectCommand.CommandTimeout = 0;

              this.tbResult.Rows.Clear();
              this.adapter.Fill(this.tbResult);
              this.labTotalTransaction.Text = string.Format("{0} giao dịch", this.tbResult.Rows.Count);

              this.AddRowTable(startindex, count);
              this.FillDataGrid();
              this.FillDropDownList(20, this.tbResult);
            }
            catch (Exception exp)
            {
              MessageBox.Show(exp.Message);
            }
          }
          break;
        case 4:
          {
            try
            {
              this.OpenConnection(this.kdv_BOConnectionString);
              string selectString = "SELECT TransC_lgnNumber, TransC_strType, TransC_dtmDateTime, TransC_curValue, TransC_strBKCardType, TransC_strPaymentTransRef, TransC_dtmRealTransTime, CinOperator_strCode";
              string fromString = " FROM tblTrans_Cash";
              string orderByString = " ORDER BY TransC_dtmRealTransTime ASC";

              string whereString = string.Format(" WHERE TransC_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND TransC_strType = 'R' AND TransC_strBKCardType <> '123PHIM' ", fromDate, toDate);
              string sqlCommandString = selectString + fromString + whereString + orderByString;

              this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
              this.adapter.SelectCommand.CommandType = CommandType.Text;
              this.adapter.SelectCommand.CommandTimeout = 0;

              this.tbResult.Rows.Clear();
              this.adapter.Fill(this.tbResult);
              this.labTotalTransaction.Text = string.Format("{0} giao dịch", this.tbResult.Rows.Count);

              this.AddRowTable(startindex, count);
              this.FillDataGrid();
              this.FillDropDownList(20, this.tbResult);
            }
            catch (Exception exp)
            {
              MessageBox.Show(exp.Message);
            }
          }
          break;
        case 5:
          {
            try
            {
              this.OpenConnection(this.qt_BOConnectionString);
              string selectString = "SELECT TransC_lgnNumber, TransC_strType, TransC_dtmDateTime, TransC_curValue, TransC_strBKCardType, TransC_strPaymentTransRef, TransC_dtmRealTransTime, CinOperator_strCode";
              string fromString = " FROM tblTrans_Cash";
              string orderByString = " ORDER BY TransC_dtmRealTransTime ASC";

              string whereString = string.Format(" WHERE TransC_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND [TransC_strType] = '0000000013' AND TransC_strBKCardType <> '123PHIM' ", fromDate, toDate);
              string sqlCommandString = selectString + fromString + whereString + orderByString;

              this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
              this.adapter.SelectCommand.CommandType = CommandType.Text;
              this.adapter.SelectCommand.CommandTimeout = 0;

              this.tbResult.Rows.Clear();
              this.adapter.Fill(this.tbResult);
              this.labTotalTransaction.Text = string.Format("{0} giao dịch", this.tbResult.Rows.Count);

              this.AddRowTable(startindex, count);
              this.FillDataGrid();
              this.FillDropDownList(20, this.tbResult);
            }
            catch (Exception exp)
            {
              MessageBox.Show(exp.Message);
            }
          }
          break;
        case 6:
          {
            try
            {
              this.OpenConnection(this.lab_connectionString_OPTR);
              string selectString = "SELECT TransC_lgnNumber, TransC_strType, TransC_dtmDateTime, TransC_curValue, TransC_strBKCardType, TransC_strPaymentTransRef, TransC_dtmRealTransTime, CinOperator_strCode";
              string fromString = " FROM tbl_Trans_Cash";
              string orderByString = " ORDER BY TransC_dtmRealTransTime ASC";

              string whereString = string.Format(" WHERE TransC_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND TransC_strBKCardType <> '123PHIM' ", fromDate, toDate);
              string sqlCommandString = selectString + fromString + whereString + orderByString;

              this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
              this.adapter.SelectCommand.CommandType = CommandType.Text;
              this.adapter.SelectCommand.CommandTimeout = 0;

              this.tbResult.Rows.Clear();
              this.adapter.Fill(this.tbResult);
              this.labTotalTransaction.Text = string.Format("{0} giao dịch", this.tbResult.Rows.Count);

              this.AddRowTable(startindex, count);
              this.FillDataGrid();
              this.FillDropDownList(20, this.tbResult);
            }
            catch (Exception exp)
            {
              MessageBox.Show(exp.Message);
            }
          }
          break;

        default:
          {/*
              try
              {
                this.OpenConnection(this.connectionString);
                this.DataCaching();
              }
              catch (Exception exp)
              {
                MessageBox.Show(exp.Message);
              }*/
          }
          break;
      }
    }
    private void ImportFromExcel()
    {
      this.ClearAllTables();
      this.txtPayConnectorTotalAmout.Text = string.Empty;
      this.txtRefundInTime.Text = string.Empty;
      this.txtRefundOutOfTime.Text = string.Empty;
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
            DataSet ds = new DataSet();
            ds = GetDataExcel(openFileDialog1.FileName, "Sum up");// Goi chuong trinh GetDataExcel phia tren luu vao Dataset ds        
            for (int i = 4; i < ds.Tables[0].Rows.Count; i++) //Dong
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
                  row["No"] = a[0];
                  row["TransC_excel_strPaymentTransRef"] = a[2];
                  row["TransC_excel_strType"] = a[4];
                  if (IsDateTime(a[3]))
                    row["TransC_excel_dtmDateTime"] = a[3];

                  row["TransC_excel_curValue"] = a[6];
                  string[] temptValue = a[6].Split(',');
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
              else
              {
                if (a[2].Length > 0)
                {
                  row = this.tblExcelRefundTrans.NewRow();
                  row["No"] = a[0];
                  row["TransC_excel_strPaymentTransRef"] = a[2];
                  row["TransC_excel_strType"] = a[4];
                  if (IsDateTime(a[3]))
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
                    if (IsNumeric(transValue))
                      totalRefundInTimeMoney += int.Parse(transValue);
                  }
                  if (temptValue8.Length > 0)
                  {
                    string transValue = string.Empty;
                    row["TransC_excel_curValue"] = a[8];
                    for (int index = 0; index < temptValue8.Length; index++)
                    {
                      transValue = transValue + temptValue8[index];
                    }
                    if (IsNumeric(transValue))
                      totalRefundOutTimeMoney += int.Parse(transValue);
                  }

                  this.tblExcelRefundTrans.Rows.Add(row);
                }
              }
            }
            //LoadData();
            FillDataGrid(this.tblExcelTrans);
            string sFormat = string.Format("#{0}###", ",");
            //string a = double.Parse(12345).ToString(sFormat);
            this.txtPayConnectorTotalAmout.Text = (totalTranscMoney).ToString(sFormat);
            this.txtRefundInTime.Text = (totalRefundInTimeMoney).ToString(sFormat);
            this.txtRefundOutOfTime.Text = (totalRefundOutTimeMoney).ToString(sFormat);
            //MessageBox.Show("Import thành công!", "Thông báo");
          }
          catch (Exception exp)
          {
            MessageBox.Show(string.Format("Định dạng file Excel không đúng hoặc định dạng ngày tháng dữ liệu trong file không chính xác. Vui lòng kiểm tra lại file hoặc báo Mr. Viễn để check. SYSTEM ERROR MESSAGE: {0}", exp.Message));
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
            MessageBox.Show(string.Format("Định dạng file Excel không đúng hoặc định dạng ngày tháng dữ liệu trong file không chính xác. Vui lòng kiểm tra lại file hoặc báo Mr. Viễn để check. SYSTEM ERROR MESSAGE: {0}", exp.Message));
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
            MessageBox.Show(string.Format("Định dạng file Excel không đúng hoặc định dạng ngày tháng dữ liệu trong file không chính xác. Vui lòng kiểm tra lại file hoặc báo Mr. Viễn để check. SYSTEM ERROR MESSAGE: {0}", exp.Message));
          }
          alert.Close();
        }  
      }
      else
      {
        Int64 totalTranscMoney = 0;
        Int64 totalRefundMoney = 0;
        int count = 0;
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
          alert = new AlertForm();
          alert.Show();
          try
          {
            string[] a = new string[50];
            DataSet ds = new DataSet();
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
                  if(IsDateTime(a[0]))
                    row["TransC_excel_dtmDateTime"] = a[0];
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
                  if(IsDateTime(a[0]))
                    row["TransC_excel_dtmDateTime"] = a[0];
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
            MessageBox.Show(string.Format("Định dạng file Excel không đúng hoặc định dạng ngày tháng dữ liệu trong file không chính xác. Vui lòng kiểm tra lại file hoặc báo Mr. Viễn để check. SYSTEM ERROR MESSAGE: {0}", exp.Message));
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
      else if (this.radLapTest.Checked)
      {
        this.LoadDataFromVistaBO(4);
      }
      else
        this.LoadDataFromVistaBO(0);
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

  }
  void btnImportExcelRefund_Click(object sender, System.EventArgs e)
  {
    this.importExcelRefund = true;
    this.ImportFromExcel();
  }

  private void timer1_Tick(object sender, EventArgs e)
  {
    
  }

  
}
}

