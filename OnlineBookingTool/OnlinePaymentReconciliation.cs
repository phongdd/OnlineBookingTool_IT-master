using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OnlineBookingTool
{
public partial class OnlinePaymentReconciliation : Form
{
  public OnlinePaymentReconciliation()
  {
    InitializeComponent();
    this.tblReconciliationMatch = new DataTable();
    this.tblExcelRefundTrans = new DataTable();
    this.tblExcelTrans = new DataTable();
    this.tblBO_DBTrans = new DataTable();
    this.tblReconciliationNotMatch = new DataTable();
    this.con = new SqlConnection();
    this.OpenConnection(this.lab_connectionString_OPTR);
    this.adapter = new SqlDataAdapter();
    this.CreatTable();
  }

  #region Fields
    private DataTable tblReconciliationMatch;
    private DataTable tblExcelRefundTrans;
    private DataTable tblExcelTrans;
    private DataTable tblBO_DBTrans;
    private DataTable tblReconciliationNotMatch;
    private SqlConnection con;
    private bool isDuplicate = false;
    
    
    ////live connection string
   
    private string lab_connectionString_OPTR = "Data Source=192.168.116.201;Initial Catalog=OPTR;User Id=sa;Password=GaLaXyNDNTTB126;";
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
      this.tblReconciliationMatch.Columns.Add("TransC_BO_strPaymentTransRef", typeof(string));
      this.tblReconciliationMatch.Columns.Add("TransC_excel_strType", typeof(string));
      this.tblReconciliationMatch.Columns.Add("TransC_excel_dtmDateTime", typeof(DateTime));
      this.tblReconciliationMatch.Columns.Add("TransC_excel_curValue", typeof(string));
      this.tblReconciliationMatch.Columns.Add("TransC_excel_strPaymentTransRef", typeof(string));
      this.tblReconciliationMatch.Columns.Add("TransC_BO_strType", typeof(string));
      this.tblReconciliationMatch.Columns.Add("TransC_BO_dtmDateTime", typeof(DateTime));
      this.tblReconciliationMatch.Columns.Add("TransC_BO_curValue", typeof(string));
      
      
      this.tblReconciliationNotMatch.Columns.Add("TransC_BO_strPaymentTransRef", typeof(string));
      this.tblReconciliationNotMatch.Columns.Add("TransC_excel_strType", typeof(string));
      this.tblReconciliationNotMatch.Columns.Add("TransC_excel_dtmDateTime", typeof(DateTime));
      this.tblReconciliationNotMatch.Columns.Add("TransC_excel_curValue", typeof(string));
      this.tblReconciliationNotMatch.Columns.Add("TransC_excel_strPaymentTransRef", typeof(string));
      this.tblReconciliationNotMatch.Columns.Add("TransC_BO_strType", typeof(string));
      this.tblReconciliationNotMatch.Columns.Add("TransC_BO_dtmDateTime", typeof(DateTime));
      this.tblReconciliationNotMatch.Columns.Add("TransC_BO_curValue", typeof(string));
      

      this.tblExcelRefundTrans.Columns.Add("TransC_excel_strPaymentTransRef", typeof(string));
      this.tblExcelRefundTrans.Columns.Add("No", typeof(string));
      this.tblExcelRefundTrans.Columns.Add("TransC_excel_strType", typeof(string));
      this.tblExcelRefundTrans.Columns.Add("TransC_excel_dtmDateTime", typeof(DateTime));
      this.tblExcelRefundTrans.Columns.Add("TransC_excel_curValue", typeof(string));
      

      this.tblExcelTrans.Columns.Add("No", typeof(string));
      this.tblExcelTrans.Columns.Add("TransC_excel_strPaymentTransRef", typeof(string));
      this.tblExcelTrans.Columns.Add("TransC_excel_strType", typeof(string));
      this.tblExcelTrans.Columns.Add("TransC_excel_dtmDateTime", typeof(DateTime));
      this.tblExcelTrans.Columns.Add("TransC_excel_curValue", typeof(string));
      

      this.tblBO_DBTrans.Columns.Add("TransC_lgnNumber", typeof(string));
      this.tblBO_DBTrans.Columns.Add("TransC_strType", typeof(string));
      this.tblBO_DBTrans.Columns.Add("TransC_dtmDateTime", typeof(DateTime));
      this.tblBO_DBTrans.Columns.Add("TransC_curValue", typeof(string));
      this.tblBO_DBTrans.Columns.Add("TransC_strBKCardType", typeof(string));
      this.tblBO_DBTrans.Columns.Add("TransC_strPaymentTransRef", typeof(string));
      this.tblBO_DBTrans.Columns.Add("CinOperator_strCode", typeof(string));
 

     
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
        string fromString = " FROM tblTrans_Cash";
        string orderByString = " ORDER BY TransC_dtmDateTime ASC";

        string whereString = string.Format(" WHERE TransC_dtmDateTime BETWEEN '{0}' AND '{1}'", fromDate, toDate);
        string sqlCommandString = selectString + fromString + whereString + orderByString;

        this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
        this.adapter.SelectCommand.CommandType = CommandType.Text;
        this.adapter.SelectCommand.CommandTimeout = 0;

        this.tblBO_DBTrans.Rows.Clear();
        this.adapter.Fill(this.tblBO_DBTrans);
        this.labTotalTransaction.Text = string.Format("{0} giao dịch", this.tblBO_DBTrans.Rows.Count);

        //this.AddRowTable(startindex, count);
        this.FillDataGrid(this.tblBO_DBTrans);
        //this.FillDropDownList(20, this.tbResult);
      }
      catch (Exception exp)
      {
        MessageBox.Show(exp.Message);
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
        string selectString = "SELECT TransC_lgnNumber, TransC_strType, TransC_dtmDateTime, TransC_curValue, TransC_strBKCardType, TransC_strPaymentTransRef, CinOperator_strCode";
        string fromString = " FROM tblTrans_Cash";
        string orderByString = " ORDER BY TransC_dtmDateTime ASC";

        string whereString = string.Format(" WHERE TransC_dtmDateTime BETWEEN '{0}' AND '{1}'", fromDate, toDate);
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
        MessageBox.Show(exp.Message);
      }

    }
      
    private void FillDataGrid()
    {
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
    public static DataSet GetDataExcel(string fPath, string sheetname)
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
      return isNum;
    }
    #endregion Methods

  private void btnImportFromExcel_Click(object sender, EventArgs e)
  {
    this.tblExcelTrans.Rows.Clear();
    if (openFileDialog1.ShowDialog()==DialogResult.OK)
    {
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
                DataRow row = this.tblExcelTrans.NewRow();
                //row["FirstName"] = this.tbResult.Rows[rowIndex]["FirstName"];
                //row["LastName"] = this.tbResult.Rows[rowIndex]["LastName"];
                row["No"] = a[0];
                row["TransC_excel_strPaymentTransRef"] = a[2];
                row["TransC_excel_strType"] = a[4];
                row["TransC_excel_dtmDateTime"] = a[3];
                row["TransC_excel_curValue"] = a[6];


                this.tblExcelTrans.Rows.Add(row);
              
            }
            //LoadData();
            FillDataGrid(this.tblExcelTrans);
            MessageBox.Show("Import thành công.");
        }
        catch (Exception exp)
        {
          MessageBox.Show(exp.Message);
        }
    }  
  
  }
}
}

