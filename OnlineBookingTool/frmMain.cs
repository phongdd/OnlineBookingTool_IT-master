using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace OnlineBookingTool
{
    public partial class frmMain : Form
    {
      #region Fields
      private DataTable tbResult;
      private bool isDuplicate = false;
      //private DataRow rowResult;
      //private DataColumn colResult;
      //private int index = 0;
      private AlertForm alert;
      private DataTable tblDuplicate;
      private DataTable tbTempResult;
      private DataTable tbTempTransC;
      private SqlConnection con;
      private DataRow[] dataRowList;
      
      ////live connection string
      private string connectionString = "Data Source=192.168.116.5;Initial Catalog=VISTAIT_41;User Id=sa;Password=GaLaXyNDNTTB126;";
      private string lab_connectionString = "Data Source=192.168.116.201;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
      private string lab_connectionString_OPTR = "Data Source=192.168.116.201;Initial Catalog=OPTR;User Id=sa;Password=GaLaXyNDNTTB126;";
      private string nd_BOConnectionString = "Data Source=192.168.116.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
      private string nt_BOConnectionString = "Data Source=192.168.117.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
      private string tb_BOConnectionString = "Data Source=192.168.118.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;Connection Timeout=120;";
      private string kdv_BOConnectionString = "Data Source=192.168.119.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
      private string qt_BOConnectionString = "Data Source=192.168.120.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
      private string bt_BOConnectionString = "Data Source=192.168.130.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
      private string mipecHN_BOConnectionString = "Data Source=192.168.132.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
      private string dn_BOConnectionString = "Data Source=192.168.133.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
      private string q12_BOConnectionString = "Data Source=192.168.134.2;Initial Catalog=VISTA;User Id=sa;Password=GaLaXyNDNTTB126;";
      //Lab connection string
      //private string connectionString = "Data Source=192.168.116.250;Initial Catalog=VISTAIT;User Id=sa;Password=Galaxy@116;";
      private SqlDataAdapter adapter;
      //private SqlCommand command;

      #endregion Fields

      #region Constructors
      public frmMain()
      {
          InitializeComponent();
          this.tbTempTransC = new DataTable();
          this.tbResult = new DataTable();
          this.tbTempResult = new DataTable();
          this.tblDuplicate = new DataTable();
          this.con = new SqlConnection();          
          this.OpenConnection(this.connectionString);
          this.adapter = new SqlDataAdapter();
          this.CreatTable();
          //this.DataCaching();
        }
      #endregion Constructors

      #region Properties
      string ConnectionString
      {
        get
        {
          return this.connectionString;
        }
        set
        {
          this.connectionString = value;
        }
      }
      string Lab_ConnectionString
      {
        get
        {
          return this.lab_connectionString;
        }
        set
        {
          this.lab_connectionString = value;
        }
      }
      string ND_BOConnectionString
      {
        get
        {
          return this.nd_BOConnectionString;
        }
        set
        {
          this.nd_BOConnectionString = value;
        }
      }
      string NT_BOConnectionString
      {
        get
        {
          return this.nt_BOConnectionString;
        }
        set
        {
          this.nt_BOConnectionString = value;
        }
      }
      string TB_BOConnectionString
      {
        get
        {
          return this.tb_BOConnectionString;
        }
        set
        {
          this.tb_BOConnectionString = value;
        }
      }
      string KDV_BOConnectionString
      {
        get
        {
          return this.kdv_BOConnectionString;
        }
        set
        {
          this.kdv_BOConnectionString = value;
        }
      }
      string QT_BOConnectionString
      {
        get
        {
          return this.qt_BOConnectionString;
        }
        set
        {
          this.qt_BOConnectionString = value;
        }
      }
      #endregion Properties.

      #region Methods
      private void StartBackgroundWorker()
      {
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
      }
      private void CancelBackgroundWorker()
      {
        if (backgroundWorker1.WorkerSupportsCancellation == true)
        {
          // Cancel the asynchronous operation.
          backgroundWorker1.CancelAsync();
          // Close the AlertForm
          alert.Close();
        }
      }
      
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
      
      private void RefreshData()
      {
        this.tbResult.Clear();
        this.comPageInfo.Items.Clear();
        //this.tbDisplayResult.Clear();
        this.tbTempResult.Clear();
        this.labTotalTransaction.Text = string.Empty;
        this.StartBackgroundWorker();
      }
      private void CreatTable()
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
      private void AddRowTable()
      {
        this.tbTempTransC.Rows.Clear();
        for (int i = 0; i < this.tbResult.Rows.Count; i++)
        {
          DataRow row = this.tbTempTransC.NewRow();
          row["TransC_lgnNumber"] = this.tbResult.Rows[i]["TransC_lgnNumber"];
          row["TransC_strType"] = this.tbResult.Rows[i]["TransC_strType"];
          row["TransC_dtmDateTime"] = this.tbResult.Rows[i]["TransC_dtmDateTime"];
          row["TransC_curValue"] = this.tbResult.Rows[i]["TransC_curValue"];
          row["TransC_strBKCardType"] = this.tbResult.Rows[i]["TransC_strBKCardType"];
          row["TransC_strPaymentTransRef"] = this.tbResult.Rows[i]["TransC_strPaymentTransRef"];
          row["TransC_dtmRealTransTime"] = this.tbResult.Rows[i]["TransC_dtmRealTransTime"];
          row["CinOperator_strCode"] = this.tbResult.Rows[i]["CinOperator_strCode"];
          this.tbTempTransC.Rows.Add(row);
        }
      }
      private void AddRowTable(DataTable tblAddRow, DataTable tblSource)
      {
        for (int i = 0; i < tblSource.Rows.Count; i++)
        {
          DataRow row = tblAddRow.NewRow();
          row["TransC_lgnNumber"] = tblSource.Rows[i]["TransC_lgnNumber"];
          row["TransC_strType"] = tblSource.Rows[i]["TransC_strType"];
          row["TransC_dtmDateTime"] = tblSource.Rows[i]["TransC_dtmDateTime"];
          row["TransC_curValue"] = tblSource.Rows[i]["TransC_curValue"];
          row["TransC_strBKCardType"] = tblSource.Rows[i]["TransC_strBKCardType"];
          row["TransC_strPaymentTransRef"] = this.tbResult.Rows[i]["TransC_strPaymentTransRef"];
          row["TransC_dtmRealTransTime"] = this.tbResult.Rows[i]["TransC_dtmRealTransTime"];
          row["CinOperator_strCode"] = tblSource.Rows[i]["CinOperator_strCode"];
          tblAddRow.Rows.Add(row);
        }
      }
      private void AddRowTable(DataTable tblSource, int index, int count)
      {
        int rowIndex = index * count;
        this.tbTempTransC.Rows.Clear();
        for (int i = 0; i < count; i++)
        {
          if (rowIndex < tblSource.Rows.Count)
          {
            DataRow row = this.tbTempTransC.NewRow();
            row["TransC_lgnNumber"] = tblSource.Rows[rowIndex]["TransC_lgnNumber"];
            row["TransC_strType"] = tblSource.Rows[rowIndex]["TransC_strType"];
            row["TransC_dtmDateTime"] = tblSource.Rows[rowIndex]["TransC_dtmDateTime"];
            row["TransC_curValue"] = tblSource.Rows[rowIndex]["TransC_curValue"];
            row["TransC_strBKCardType"] = tblSource.Rows[rowIndex]["TransC_strBKCardType"];
            row["TransC_strPaymentTransRef"] = this.tbResult.Rows[rowIndex]["TransC_strPaymentTransRef"];
            row["TransC_dtmRealTransTime"] = this.tbResult.Rows[rowIndex]["TransC_dtmRealTransTime"];
            row["CinOperator_strCode"] = tblSource.Rows[rowIndex]["CinOperator_strCode"];
            this.tbTempTransC.Rows.Add(row);
          }
          else
            break;
          rowIndex++;
        }
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
        string selectString = string.Empty;
        string fromString = string.Empty;
        string orderByString = string.Empty;
        string whereString = string.Empty;
        string sqlCommandString = string.Empty;
        switch (cinemaCode)
        {
          case 1:
            {
              try
              {
                this.OpenConnection(this.nd_BOConnectionString);
                if (this.chkRefund.Checked)
                {
                  selectString = "SELECT DISTINCT TransT_lgnNumber, TransT_strType, TransT_strStatus, TransT_curValueEach, TransT_dtmRealTransTime";
                  fromString = " FROM tblTrans_Ticket";
                  orderByString = " ORDER BY TransT_dtmRealTransTime ASC";
                  
                  //whereString = string.Format(" WHERE TransT_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND TransT_strStatus = 'R'", fromDate, toDate);
                  whereString = string.Format(" WHERE TransT_strStatus = 'R' AND TransT_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND (TransT_lgnNumber NOT IN (select TransT_lgnNumber FROM tblTrans_Ticket WHERE TransT_strStatus = 'V'))", fromDate, toDate);
                }
                else
                {
                  selectString = "SELECT TransC_lgnNumber, TransC_strType, TransC_dtmDateTime, TransC_curValue, TransC_strBKCardType, TransC_strPaymentTransRef, TransC_dtmRealTransTime, CinOperator_strCode";
                  fromString = " FROM tblTrans_Cash";
                  orderByString = " ORDER BY TransC_dtmRealTransTime ASC";
                  whereString = string.Format(" WHERE TransC_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND TransC_strType = 'R' AND TransC_strBKCardType <> '123PHIM' ", fromDate, toDate);
                }
                
                sqlCommandString = selectString + fromString + whereString + orderByString;

                this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
                this.adapter.SelectCommand.CommandType = CommandType.Text;
                this.adapter.SelectCommand.CommandTimeout = 0;

                this.tbResult.Rows.Clear();
                if (this.chkRefund.Checked)
                {
                  DataTable tblTemp = new DataTable();
                  this.adapter.Fill(tblTemp);
                  
                  foreach (DataRow row in tblTemp.Rows)
                  {
                    DataRow tempRow = this.tbResult.NewRow();
                    tempRow["TransC_lgnNumber"] = row["TransT_lgnNumber"];
                    tempRow["TransC_strType"] = row["TransT_strStatus"];
                    tempRow["TransC_dtmDateTime"] = row["TransT_dtmRealTransTime"];
                    tempRow["TransC_curValue"] = row["TransT_curValueEach"];
                    tempRow["TransC_strBKCardType"] = row["TransT_strType"];
                    tempRow["TransC_strPaymentTransRef"] = string.Empty;
                    tempRow["TransC_dtmRealTransTime"] = row["TransT_dtmRealTransTime"];
                    tempRow["CinOperator_strCode"] = "0000000001";
                    this.tbResult.Rows.Add(tempRow);
                  }
                }
                else
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
                if (this.chkRefund.Checked)
                {
                  selectString = "SELECT DISTINCT TransT_lgnNumber, TransT_strType, TransT_strStatus, TransT_curValueEach, TransT_dtmRealTransTime";
                  fromString = " FROM tblTrans_Ticket";
                  orderByString = " ORDER BY TransT_dtmRealTransTime ASC";
                  whereString = string.Format(" WHERE TransT_strStatus = 'R' AND TransT_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND (TransT_lgnNumber NOT IN (select TransT_lgnNumber FROM tblTrans_Ticket WHERE TransT_strStatus = 'V'))", fromDate, toDate);
                
                  //whereString = string.Format(" WHERE TransT_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND TransT_strStatus = 'R'", fromDate, toDate);
                }
                else
                {
                  selectString = "SELECT TransC_lgnNumber, TransC_strType, TransC_dtmDateTime, TransC_curValue, TransC_strBKCardType, TransC_strPaymentTransRef, TransC_dtmRealTransTime, CinOperator_strCode";
                  fromString = " FROM tblTrans_Cash";
                  orderByString = " ORDER BY TransC_dtmRealTransTime ASC";
                  whereString = string.Format(" WHERE TransC_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND TransC_strType = 'R' AND TransC_strBKCardType <> '123PHIM' ", fromDate, toDate);
                }
                sqlCommandString = selectString + fromString + whereString + orderByString;

                this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
                this.adapter.SelectCommand.CommandType = CommandType.Text;
                this.adapter.SelectCommand.CommandTimeout = 0;

                this.tbResult.Rows.Clear();

                if (this.chkRefund.Checked)
                {
                  DataTable tblTemp = new DataTable();
                  this.adapter.Fill(tblTemp);

                  foreach (DataRow row in tblTemp.Rows)
                  {
                    DataRow tempRow = this.tbResult.NewRow();
                    tempRow["TransC_lgnNumber"] = row["TransT_lgnNumber"];
                    tempRow["TransC_strType"] = row["TransT_strType"];
                    tempRow["TransC_dtmDateTime"] = row["TransT_dtmRealTransTime"];
                    tempRow["TransC_curValue"] = row["TransT_curValueEach"];
                    tempRow["TransC_strBKCardType"] = string.Empty;
                    tempRow["TransC_strPaymentTransRef"] = string.Empty;
                    tempRow["TransC_dtmRealTransTime"] = row["TransT_dtmRealTransTime"];
                    tempRow["CinOperator_strCode"] = "0000000002";
                    this.tbResult.Rows.Add(tempRow);
                  }
                }
                else
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
                if (this.chkRefund.Checked)
                {
                  selectString = "SELECT DISTINCT TransT_lgnNumber, TransT_strType, TransT_strStatus, TransT_curValueEach, TransT_dtmRealTransTime";
                  fromString = " FROM tblTrans_Ticket";
                  orderByString = " ORDER BY TransT_dtmRealTransTime ASC";
                  whereString = string.Format(" WHERE TransT_strStatus = 'R' AND TransT_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND (TransT_lgnNumber NOT IN (select TransT_lgnNumber FROM tblTrans_Ticket WHERE TransT_strStatus = 'V'))", fromDate, toDate);
                
                  //whereString = string.Format(" WHERE TransT_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND TransT_strStatus = 'R'", fromDate, toDate);
                }
                else
                {
                  selectString = "SELECT TransC_lgnNumber, TransC_strType, TransC_dtmDateTime, TransC_curValue, TransC_strBKCardType, TransC_strPaymentTransRef, TransC_dtmRealTransTime, CinOperator_strCode";
                  fromString = " FROM tblTrans_Cash";
                  orderByString = " ORDER BY TransC_dtmRealTransTime ASC";

                  whereString = string.Format(" WHERE TransC_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND TransC_strType = 'R' AND TransC_strBKCardType <> '123PHIM' ", fromDate, toDate);
                }
                sqlCommandString = selectString + fromString + whereString + orderByString;

                this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
                this.adapter.SelectCommand.CommandType = CommandType.Text;
                this.adapter.SelectCommand.CommandTimeout = 0;

                this.tbResult.Rows.Clear();
                if (this.chkRefund.Checked)
                {
                  DataTable tblTemp = new DataTable();
                  this.adapter.Fill(tblTemp);

                  foreach (DataRow row in tblTemp.Rows)
                  {
                    DataRow tempRow = this.tbResult.NewRow();
                    tempRow["TransC_lgnNumber"] = row["TransT_lgnNumber"];
                    tempRow["TransC_strType"] = row["TransT_strType"];
                    tempRow["TransC_dtmDateTime"] = row["TransT_dtmRealTransTime"];
                    tempRow["TransC_curValue"] = row["TransT_curValueEach"];
                    tempRow["TransC_strBKCardType"] = string.Empty;
                    tempRow["TransC_strPaymentTransRef"] = string.Empty;
                    tempRow["TransC_dtmRealTransTime"] = row["TransT_dtmRealTransTime"];
                    tempRow["CinOperator_strCode"] = "0000000003";
                    this.tbResult.Rows.Add(tempRow);
                  }
                }
                else
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
                if (this.chkRefund.Checked)
                {
                  selectString = "SELECT DISTINCT TransT_lgnNumber, TransT_strType, TransT_strStatus, TransT_curValueEach, TransT_dtmRealTransTime";
                  fromString = " FROM tblTrans_Ticket";
                  orderByString = " ORDER BY TransT_dtmRealTransTime ASC";
                  whereString = string.Format(" WHERE TransT_strStatus = 'R' AND TransT_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND (TransT_lgnNumber NOT IN (select TransT_lgnNumber FROM tblTrans_Ticket WHERE TransT_strStatus = 'V'))", fromDate, toDate);
                
                  //whereString = string.Format(" WHERE TransT_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND TransT_strStatus = 'R'", fromDate, toDate);
                }
                else
                {
                  selectString = "SELECT TransC_lgnNumber, TransC_strType, TransC_dtmDateTime, TransC_curValue, TransC_strBKCardType, TransC_strPaymentTransRef, TransC_dtmRealTransTime, CinOperator_strCode";
                  fromString = " FROM tblTrans_Cash";
                  orderByString = " ORDER BY TransC_dtmRealTransTime ASC";
                  whereString = string.Format(" WHERE TransC_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND TransC_strType = 'R' AND TransC_strBKCardType <> '123PHIM' ", fromDate, toDate);
                }
                sqlCommandString = selectString + fromString + whereString + orderByString;

                this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
                this.adapter.SelectCommand.CommandType = CommandType.Text;
                this.adapter.SelectCommand.CommandTimeout = 0;

                this.tbResult.Rows.Clear();
                if (this.chkRefund.Checked)
                {
                  DataTable tblTemp = new DataTable();
                  this.adapter.Fill(tblTemp);

                  foreach (DataRow row in tblTemp.Rows)
                  {
                    DataRow tempRow = this.tbResult.NewRow();
                    tempRow["TransC_lgnNumber"] = row["TransT_lgnNumber"];
                    tempRow["TransC_strType"] = row["TransT_strType"];
                    tempRow["TransC_dtmDateTime"] = row["TransT_dtmRealTransTime"];
                    tempRow["TransC_curValue"] = row["TransT_curValueEach"];
                    tempRow["TransC_strBKCardType"] = string.Empty;
                    tempRow["TransC_strPaymentTransRef"] = string.Empty;
                    tempRow["TransC_dtmRealTransTime"] = row["TransT_dtmRealTransTime"];
                    tempRow["CinOperator_strCode"] = "0000000004";
                    this.tbResult.Rows.Add(tempRow);
                  }
                }
                else
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
                if (this.chkRefund.Checked)
                {
                  selectString = "SELECT DISTINCT TransT_lgnNumber, TransT_strType, TransT_strStatus, TransT_curValueEach, TransT_dtmRealTransTime";
                  fromString = " FROM tblTrans_Ticket";
                  orderByString = " ORDER BY TransT_dtmRealTransTime ASC";
                  whereString = string.Format(" WHERE TransT_strStatus = 'R' AND TransT_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND (TransT_lgnNumber NOT IN (select TransT_lgnNumber FROM tblTrans_Ticket WHERE TransT_strStatus = 'V'))", fromDate, toDate);
                
                  //whereString = string.Format(" WHERE TransT_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND TransT_strStatus = 'R'", fromDate, toDate);
                }
                else
                {
                  selectString = "SELECT TransC_lgnNumber, TransC_strType, TransC_dtmDateTime, TransC_curValue, TransC_strBKCardType, TransC_strPaymentTransRef, TransC_dtmRealTransTime, CinOperator_strCode";
                  fromString = " FROM tblTrans_Cash";
                  orderByString = " ORDER BY TransC_dtmRealTransTime ASC";

                  whereString = string.Format(" WHERE TransC_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND [TransC_strType] = '0000000013' AND TransC_strBKCardType <> '123PHIM' ", fromDate, toDate);
                }
                sqlCommandString = selectString + fromString + whereString + orderByString;

                this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
                this.adapter.SelectCommand.CommandType = CommandType.Text;
                this.adapter.SelectCommand.CommandTimeout = 0;

                this.tbResult.Rows.Clear();
                if (this.chkRefund.Checked)
                {
                  DataTable tblTemp = new DataTable();
                  this.adapter.Fill(tblTemp);

                  foreach (DataRow row in tblTemp.Rows)
                  {
                    DataRow tempRow = this.tbResult.NewRow();
                    tempRow["TransC_lgnNumber"] = row["TransT_lgnNumber"];
                    tempRow["TransC_strType"] = row["TransT_strType"];
                    tempRow["TransC_dtmDateTime"] = row["TransT_dtmRealTransTime"];
                    tempRow["TransC_curValue"] = row["TransT_curValueEach"];
                    tempRow["TransC_strBKCardType"] = string.Empty;
                    tempRow["TransC_strPaymentTransRef"] = string.Empty;
                    tempRow["TransC_dtmRealTransTime"] = row["TransT_dtmRealTransTime"];
                    tempRow["CinOperator_strCode"] = "0000000005";
                    this.tbResult.Rows.Add(tempRow);
                  }
                }
                else
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
                    this.OpenConnection(this.bt_BOConnectionString);
                    if (this.chkRefund.Checked)
                    {
                        selectString = "SELECT DISTINCT TransT_lgnNumber, TransT_strType, TransT_strStatus, TransT_curValueEach, TransT_dtmRealTransTime";
                        fromString = " FROM tblTrans_Ticket";
                        orderByString = " ORDER BY TransT_dtmRealTransTime ASC";
                        whereString = string.Format(" WHERE TransT_strStatus = 'R' AND TransT_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND (TransT_lgnNumber NOT IN (select TransT_lgnNumber FROM tblTrans_Ticket WHERE TransT_strStatus = 'V'))", fromDate, toDate);

                        //whereString = string.Format(" WHERE TransT_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND TransT_strStatus = 'R'", fromDate, toDate);
                    }
                    else
                    {
                        selectString = "SELECT TransC_lgnNumber, TransC_strType, TransC_dtmDateTime, TransC_curValue, TransC_strBKCardType, TransC_strPaymentTransRef, TransC_dtmRealTransTime, CinOperator_strCode";
                        fromString = " FROM tblTrans_Cash";
                        orderByString = " ORDER BY TransC_dtmRealTransTime ASC";

                        whereString = string.Format(" WHERE TransC_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND [TransC_strType] = '0000000013' AND TransC_strBKCardType <> '123PHIM' ", fromDate, toDate);
                    }
                    sqlCommandString = selectString + fromString + whereString + orderByString;

                    this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
                    this.adapter.SelectCommand.CommandType = CommandType.Text;
                    this.adapter.SelectCommand.CommandTimeout = 0;

                    this.tbResult.Rows.Clear();
                    if (this.chkRefund.Checked)
                    {
                        DataTable tblTemp = new DataTable();
                        this.adapter.Fill(tblTemp);

                        foreach (DataRow row in tblTemp.Rows)
                        {
                            DataRow tempRow = this.tbResult.NewRow();
                            tempRow["TransC_lgnNumber"] = row["TransT_lgnNumber"];
                            tempRow["TransC_strType"] = row["TransT_strType"];
                            tempRow["TransC_dtmDateTime"] = row["TransT_dtmRealTransTime"];
                            tempRow["TransC_curValue"] = row["TransT_curValueEach"];
                            tempRow["TransC_strBKCardType"] = string.Empty;
                            tempRow["TransC_strPaymentTransRef"] = string.Empty;
                            tempRow["TransC_dtmRealTransTime"] = row["TransT_dtmRealTransTime"];
                            tempRow["CinOperator_strCode"] = "0000000006";
                            this.tbResult.Rows.Add(tempRow);
                        }
                    }
                    else
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
          case 7:
            {
                try
                {
                    this.OpenConnection(this.mipecHN_BOConnectionString);
                    if (this.chkRefund.Checked)
                    {
                        selectString = "SELECT DISTINCT TransT_lgnNumber, TransT_strType, TransT_strStatus, TransT_curValueEach, TransT_dtmRealTransTime";
                        fromString = " FROM tblTrans_Ticket";
                        orderByString = " ORDER BY TransT_dtmRealTransTime ASC";
                        whereString = string.Format(" WHERE TransT_strStatus = 'R' AND TransT_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND (TransT_lgnNumber NOT IN (select TransT_lgnNumber FROM tblTrans_Ticket WHERE TransT_strStatus = 'V'))", fromDate, toDate);

                        //whereString = string.Format(" WHERE TransT_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND TransT_strStatus = 'R'", fromDate, toDate);
                    }
                    else
                    {
                        selectString = "SELECT TransC_lgnNumber, TransC_strType, TransC_dtmDateTime, TransC_curValue, TransC_strBKCardType, TransC_strPaymentTransRef, TransC_dtmRealTransTime, CinOperator_strCode";
                        fromString = " FROM tblTrans_Cash";
                        orderByString = " ORDER BY TransC_dtmRealTransTime ASC";

                        whereString = string.Format(" WHERE TransC_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND [TransC_strType] = '0000000014' AND TransC_strBKCardType <> '123PHIM' ", fromDate, toDate);
                    }
                    sqlCommandString = selectString + fromString + whereString + orderByString;

                    this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
                    this.adapter.SelectCommand.CommandType = CommandType.Text;
                    this.adapter.SelectCommand.CommandTimeout = 0;

                    this.tbResult.Rows.Clear();
                    if (this.chkRefund.Checked)
                    {
                        DataTable tblTemp = new DataTable();
                        this.adapter.Fill(tblTemp);

                        foreach (DataRow row in tblTemp.Rows)
                        {
                            DataRow tempRow = this.tbResult.NewRow();
                            tempRow["TransC_lgnNumber"] = row["TransT_lgnNumber"];
                            tempRow["TransC_strType"] = row["TransT_strType"];
                            tempRow["TransC_dtmDateTime"] = row["TransT_dtmRealTransTime"];
                            tempRow["TransC_curValue"] = row["TransT_curValueEach"];
                            tempRow["TransC_strBKCardType"] = string.Empty;
                            tempRow["TransC_strPaymentTransRef"] = string.Empty;
                            tempRow["TransC_dtmRealTransTime"] = row["TransT_dtmRealTransTime"];
                            tempRow["CinOperator_strCode"] = "0000000007";
                            this.tbResult.Rows.Add(tempRow);
                        }
                    }
                    else
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
          case 8:
            {
                try
                {
                    this.OpenConnection(this.dn_BOConnectionString);
                    if (this.chkRefund.Checked)
                    {
                        selectString = "SELECT DISTINCT TransT_lgnNumber, TransT_strType, TransT_strStatus, TransT_curValueEach, TransT_dtmRealTransTime";
                        fromString = " FROM tblTrans_Ticket";
                        orderByString = " ORDER BY TransT_dtmRealTransTime ASC";
                        whereString = string.Format(" WHERE TransT_strStatus = 'R' AND TransT_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND (TransT_lgnNumber NOT IN (select TransT_lgnNumber FROM tblTrans_Ticket WHERE TransT_strStatus = 'V'))", fromDate, toDate);

                        //whereString = string.Format(" WHERE TransT_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND TransT_strStatus = 'R'", fromDate, toDate);
                    }
                    else
                    {
                        selectString = "SELECT TransC_lgnNumber, TransC_strType, TransC_dtmDateTime, TransC_curValue, TransC_strBKCardType, TransC_strPaymentTransRef, TransC_dtmRealTransTime, CinOperator_strCode";
                        fromString = " FROM tblTrans_Cash";
                        orderByString = " ORDER BY TransC_dtmRealTransTime ASC";

                        whereString = string.Format(" WHERE TransC_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND [TransC_strType] = '0000000013' AND TransC_strBKCardType <> '123PHIM' ", fromDate, toDate);
                    }
                    sqlCommandString = selectString + fromString + whereString + orderByString;

                    this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
                    this.adapter.SelectCommand.CommandType = CommandType.Text;
                    this.adapter.SelectCommand.CommandTimeout = 0;

                    this.tbResult.Rows.Clear();
                    if (this.chkRefund.Checked)
                    {
                        DataTable tblTemp = new DataTable();
                        this.adapter.Fill(tblTemp);

                        foreach (DataRow row in tblTemp.Rows)
                        {
                            DataRow tempRow = this.tbResult.NewRow();
                            tempRow["TransC_lgnNumber"] = row["TransT_lgnNumber"];
                            tempRow["TransC_strType"] = row["TransT_strType"];
                            tempRow["TransC_dtmDateTime"] = row["TransT_dtmRealTransTime"];
                            tempRow["TransC_curValue"] = row["TransT_curValueEach"];
                            tempRow["TransC_strBKCardType"] = string.Empty;
                            tempRow["TransC_strPaymentTransRef"] = string.Empty;
                            tempRow["TransC_dtmRealTransTime"] = row["TransT_dtmRealTransTime"];
                            tempRow["CinOperator_strCode"] = "0000000008";
                            this.tbResult.Rows.Add(tempRow);
                        }
                    }
                    else
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
          case 9:
            {
                try
                {
                    this.OpenConnection(this.q12_BOConnectionString);
                    if (this.chkRefund.Checked)
                    {
                        selectString = "SELECT DISTINCT TransT_lgnNumber, TransT_strType, TransT_strStatus, TransT_curValueEach, TransT_dtmRealTransTime";
                        fromString = " FROM tblTrans_Ticket";
                        orderByString = " ORDER BY TransT_dtmRealTransTime ASC";
                        whereString = string.Format(" WHERE TransT_strStatus = 'R' AND TransT_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND (TransT_lgnNumber NOT IN (select TransT_lgnNumber FROM tblTrans_Ticket WHERE TransT_strStatus = 'V'))", fromDate, toDate);

                        //whereString = string.Format(" WHERE TransT_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND TransT_strStatus = 'R'", fromDate, toDate);
                    }
                    else
                    {
                        selectString = "SELECT TransC_lgnNumber, TransC_strType, TransC_dtmDateTime, TransC_curValue, TransC_strBKCardType, TransC_strPaymentTransRef, TransC_dtmRealTransTime, CinOperator_strCode";
                        fromString = " FROM tblTrans_Cash";
                        orderByString = " ORDER BY TransC_dtmRealTransTime ASC";

                        whereString = string.Format(" WHERE TransC_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND [TransC_strType] = '0000000013' AND TransC_strBKCardType <> '123PHIM' ", fromDate, toDate);
                    }
                    sqlCommandString = selectString + fromString + whereString + orderByString;

                    this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
                    this.adapter.SelectCommand.CommandType = CommandType.Text;
                    this.adapter.SelectCommand.CommandTimeout = 0;

                    this.tbResult.Rows.Clear();
                    if (this.chkRefund.Checked)
                    {
                        DataTable tblTemp = new DataTable();
                        this.adapter.Fill(tblTemp);

                        foreach (DataRow row in tblTemp.Rows)
                        {
                            DataRow tempRow = this.tbResult.NewRow();
                            tempRow["TransC_lgnNumber"] = row["TransT_lgnNumber"];
                            tempRow["TransC_strType"] = row["TransT_strType"];
                            tempRow["TransC_dtmDateTime"] = row["TransT_dtmRealTransTime"];
                            tempRow["TransC_curValue"] = row["TransT_curValueEach"];
                            tempRow["TransC_strBKCardType"] = string.Empty;
                            tempRow["TransC_strPaymentTransRef"] = string.Empty;
                            tempRow["TransC_dtmRealTransTime"] = row["TransT_dtmRealTransTime"];
                            tempRow["CinOperator_strCode"] = "0000000009";
                            this.tbResult.Rows.Add(tempRow);
                        }
                    }
                    else
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
          case 10:
            {
                try
                {
                    this.OpenConnection(this.lab_connectionString_OPTR);
                    if (this.chkRefund.Checked)
                    {
                        selectString = "SELECT DISTINCT TransT_lgnNumber, TransT_strType, TransT_strStatus, TransT_curValueEach, TransT_dtmRealTransTime";
                        fromString = " FROM tblTrans_Ticket";
                        orderByString = " ORDER BY TransT_dtmRealTransTime ASC";
                        whereString = string.Format(" WHERE TransT_strStatus = 'R' AND TransT_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND (TransT_lgnNumber NOT IN (select TransT_lgnNumber FROM tblTrans_Ticket WHERE TransT_strStatus = 'V'))", fromDate, toDate);

                        //whereString = string.Format(" WHERE TransT_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND TransT_strStatus = 'R'", fromDate, toDate);
                    }
                    else
                    {
                        selectString = "SELECT TransC_lgnNumber, TransC_strType, TransC_dtmDateTime, TransC_curValue, TransC_strBKCardType, TransC_strPaymentTransRef, TransC_dtmRealTransTime, CinOperator_strCode";
                        fromString = " FROM tbl_Trans_Cash";
                        orderByString = " ORDER BY TransC_dtmRealTransTime ASC";
                        whereString = string.Format(" WHERE TransC_dtmRealTransTime BETWEEN '{0}' AND '{1}' AND TransC_strBKCardType <> '123PHIM' ", fromDate, toDate);
                    }
                    sqlCommandString = selectString + fromString + whereString + orderByString;

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
      private void InsertToDB()
      {
        this.tbTempTransC.Rows.Clear();
        this.OpenConnection(this.lab_connectionString_OPTR);
        string selectString = "SELECT *";
        string insertIntoString = "INSERT INTO tbl_Trans_Cash (TransC_lgnNumber, TransC_strType, TransC_dtmDateTime, TransC_curValue, TransC_strBKCardType, TransC_strPaymentTransRef, TransC_dtmRealTransTime, CinOperator_strCode)";
        string insertValueString = string.Empty;
        string fromString = " FROM tbl_Trans_Cash";
        string whereString = string.Empty;
        string transDatetime = string.Empty;
        string transRealDatetime = string.Empty;
        this.tblDuplicate.Rows.Clear();
        
        for (int i = 0; i < this.tbResult.Rows.Count; i++)
        {
          this.tbTempResult.Rows.Clear();
          whereString = string.Format(" WHERE TransC_lgnNumber = {0}", this.tbResult.Rows[i]["TransC_lgnNumber"]) + string.Format(" AND CinOperator_strCode = '{0}'", this.tbResult.Rows[i]["CinOperator_strCode"]);
          string sqlCommandString = selectString + fromString + whereString;

          this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
          this.adapter.SelectCommand.CommandType = CommandType.Text;
          this.adapter.SelectCommand.CommandTimeout = 0;

          this.adapter.Fill(this.tbTempResult);
          if (this.tbTempResult.Rows.Count > 0)
          {
            this.AddRowTable(this.tblDuplicate, this.tbTempResult);
          }
          else
          {
            transDatetime = string.Format("{0:MM/dd/yyyy HH:mm:ss tt}", (DateTime)this.tbResult.Rows[i]["TransC_dtmDateTime"]);
            transRealDatetime = string.Format("{0:MM/dd/yyyy HH:mm:ss tt}", (DateTime)this.tbResult.Rows[i]["TransC_dtmRealTransTime"]);
            insertValueString = string.Format(" VALUES ('{0}', '{1}', '{2}', {3}, '{4}', '{5}', '{6}', '{7}')", this.tbResult.Rows[i]["TransC_lgnNumber"], this.tbResult.Rows[i]["TransC_strType"], transDatetime, this.tbResult.Rows[i]["TransC_curValue"], this.tbResult.Rows[i]["TransC_strBKCardType"], this.tbResult.Rows[i]["TransC_strPaymentTransRef"], transRealDatetime, this.tbResult.Rows[i]["CinOperator_strCode"]);
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
              MessageBox.Show(exp.Message);
            }
            //this.adapter.ru
          }
          if (this.tblDuplicate.Rows.Count == 10)
          {
            if (MessageBox.Show("Hiện có hơn 10 record bị trùng. Tiếp tục importdata?", "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
              break;            
          }
          if (this.tblDuplicate.Rows.Count == 100)
          {
            if (MessageBox.Show("Hiện có hơn 100 record bị trùng. Tiếp tục importdata?", "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
              break;
          }  
        }
        if (this.tblDuplicate.Rows.Count > 0)
          this.isDuplicate = true;
        this.AddRowTable(this.tblDuplicate, 0, 20);
        this.FillDataGrid();
        this.FillDropDownList(20, this.tblDuplicate);
        this.labTotalTransaction.Text = string.Format("{0} giao dịch dupplicated", this.tblDuplicate.Rows.Count);
      }
      private void InsertTransRefundToDB()
      {
        this.tbTempTransC.Rows.Clear();
        this.OpenConnection(this.lab_connectionString_OPTR);
        string selectString = "SELECT *";
        string insertIntoString = "INSERT INTO tblTrans_Ticket_Refund (TransT_lgnNumber, TransT_curValueEach, TransT_strType, TransT_strStatus, TransT_dtmRealTransTime, CinOperator_strCode)";
        string insertValueString = string.Empty;
        string fromString = " FROM tblTrans_Ticket_Refund";
        string whereString = string.Empty;
        string transDatetime = string.Empty;
        string transRealDatetime = string.Empty;
        this.tblDuplicate.Rows.Clear();

        for (int i = 0; i < this.tbResult.Rows.Count; i++)
        {
          this.tbTempResult.Rows.Clear();
          whereString = string.Format(" WHERE TransT_lgnNumber = {0}", this.tbResult.Rows[i]["TransC_lgnNumber"]) + string.Format(" AND CinOperator_strCode = '{0}'", this.tbResult.Rows[i]["CinOperator_strCode"]);
          string sqlCommandString = selectString + fromString + whereString;

          this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
          this.adapter.SelectCommand.CommandType = CommandType.Text;
          this.adapter.SelectCommand.CommandTimeout = 0;

          this.adapter.Fill(this.tbTempResult);
          if (this.tbTempResult.Rows.Count > 0)
          {
            this.AddRowTable(this.tblDuplicate, this.tbTempResult);
          }
          else
          {
            //transDatetime = string.Format("{0:MM/dd/yyyy HH:mm:ss tt}", (DateTime)this.tbResult.Rows[i]["TransC_dtmDateTime"]);
            transRealDatetime = string.Format("{0:MM/dd/yyyy HH:mm:ss tt}", (DateTime)this.tbResult.Rows[i]["TransC_dtmRealTransTime"]);
            
            insertValueString = string.Format(" VALUES ('{0}', {1}, '{2}', '{3}', '{4}', '{5}')", this.tbResult.Rows[i]["TransC_lgnNumber"], this.tbResult.Rows[i]["TransC_curValue"], this.tbResult.Rows[i]["TransC_strBKCardType"], this.tbResult.Rows[i]["TransC_strType"], transRealDatetime, this.tbResult.Rows[i]["CinOperator_strCode"]);
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
              MessageBox.Show(exp.Message);
            }
            //this.adapter.ru
          }
          if (this.tblDuplicate.Rows.Count == 10)
          {
            if (MessageBox.Show("Hiện có hơn 10 record bị trùng. Tiếp tục importdata?", "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
              break;
          }
          if (this.tblDuplicate.Rows.Count == 100)
          {
            if (MessageBox.Show("Hiện có hơn 100 record bị trùng. Tiếp tục importdata?", "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
              break;
          }
        }
        if (this.tblDuplicate.Rows.Count > 0)
          this.isDuplicate = true;
        this.AddRowTable(this.tblDuplicate, 0, 20);
        this.FillDataGrid();
        this.FillDropDownList(20, this.tblDuplicate);
        this.labTotalTransaction.Text = string.Format("{0} giao dịch dupplicated", this.tblDuplicate.Rows.Count);
      }
      private void InsertData2014ToDB()
      {
        this.tbTempTransC.Rows.Clear();
        this.OpenConnection(this.lab_connectionString_OPTR);
        string selectString = "SELECT *";
        string insertIntoString = "INSERT INTO tbl_Trans_Cash_2014 (TransC_lgnNumber, TransC_strType, TransC_dtmDateTime, TransC_curValue, TransC_strBKCardType, TransC_strPaymentTransRef, TransC_dtmRealTransTime, CinOperator_strCode)";
        string insertValueString = string.Empty;
        string fromString = " FROM tbl_Trans_Cash_2014";
        string whereString = string.Empty;
        string transDatetime = string.Empty;
        string transRealDatetime = string.Empty;
        this.tblDuplicate.Rows.Clear();
        
        for (int i = 0; i < this.tbResult.Rows.Count; i++)
        {
          this.tbTempResult.Rows.Clear();
          whereString = string.Format(" WHERE TransC_lgnNumber = {0}", this.tbResult.Rows[i]["TransC_lgnNumber"]) + string.Format(" AND CinOperator_strCode = '{0}'", this.tbResult.Rows[i]["CinOperator_strCode"]);
          string sqlCommandString = selectString + fromString + whereString;

          this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
          this.adapter.SelectCommand.CommandType = CommandType.Text;
          this.adapter.SelectCommand.CommandTimeout = 0;

          this.adapter.Fill(this.tbTempResult);
          if (this.tbTempResult.Rows.Count > 0)
          {
            this.AddRowTable(this.tblDuplicate, this.tbTempResult);
          }
          else
          {
            transDatetime = string.Format("{0:MM/dd/yyyy HH:mm:ss tt}", (DateTime)this.tbResult.Rows[i]["TransC_dtmDateTime"]);
            transRealDatetime = string.Format("{0:MM/dd/yyyy HH:mm:ss tt}", (DateTime)this.tbResult.Rows[i]["TransC_dtmRealTransTime"]);
            insertValueString = string.Format(" VALUES ('{0}', '{1}', '{2}', {3}, '{4}', '{5}', '{6}', '{7}')", this.tbResult.Rows[i]["TransC_lgnNumber"], this.tbResult.Rows[i]["TransC_strType"], transDatetime, this.tbResult.Rows[i]["TransC_curValue"], this.tbResult.Rows[i]["TransC_strBKCardType"], this.tbResult.Rows[i]["TransC_strPaymentTransRef"], transRealDatetime, this.tbResult.Rows[i]["CinOperator_strCode"]);
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
              MessageBox.Show(exp.Message);
            }
            //this.adapter.ru
          }
          if (this.tblDuplicate.Rows.Count == 10)
          {
            if (MessageBox.Show("Hiện có hơn 10 record bị trùng. Tiếp tục importdata?", "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
              break;            
          }
          if (this.tblDuplicate.Rows.Count == 100)
          {
            if (MessageBox.Show("Hiện có hơn 100 record bị trùng. Tiếp tục importdata?", "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
              break;
          }  
        }
        if (this.tblDuplicate.Rows.Count > 0)
          this.isDuplicate = true;
        this.AddRowTable(this.tblDuplicate, 0, 20);
        this.FillDataGrid();
        this.FillDropDownList(20, this.tblDuplicate);
        this.labTotalTransaction.Text = string.Format("{0} giao dịch dupplicated", this.tblDuplicate.Rows.Count);
      }
      
      private void NewAddRowTable(int index, int count)
      {
        
        int rowIndex = index * count;
        this.tbTempTransC.Clear();
        for (int i = 0; i < count; i++)
        {
          if (rowIndex < this.dataRowList.Length)
          {
            DataRow row = this.tbTempResult.NewRow();
            
            row["TransC_lgnNumber"] = this.dataRowList[rowIndex]["TransC_lgnNumber"];
            row["TransC_strType"] = this.dataRowList[rowIndex]["TransC_strType"];
            row["TransC_dtmDateTime"] = this.dataRowList[rowIndex]["TransC_dtmDateTime"];
            row["TransC_curValue"] = this.dataRowList[rowIndex]["TransC_curValue"];
            row["TransC_strBKCardType"] = this.dataRowList[rowIndex]["TransC_strBKCardType"];
            row["TransC_strPaymentTransRef"] = this.dataRowList[rowIndex]["TransC_strPaymentTransRef"];
            row["TransC_dtmRealTransTime"] = this.dataRowList[rowIndex]["TransC_dtmRealTransTime"];
            row["CinOperator_strCode"] = this.dataRowList[rowIndex]["CinOperator_strCode"];
            this.tbTempTransC.Rows.Add(row);
          }
          else
            break;
          rowIndex++;
        }
      }
      private void FillDataGrid()
      {
        this.dgrResult.DataSource = this.tbTempTransC;
      }
      private void FillDataGrid(DataTable tblSource)
      {
        this.dgrResult.DataSource = tblSource;
      }
      private void FillDropDownList(int maxItem, DataTable tblDataFill)
      {
        this.comPageInfo.Items.Clear();
        if (tblDataFill.Rows.Count > 0)
        {
          int totalPage = 0;
          totalPage = tblDataFill.Rows.Count / maxItem;
          if ((tblDataFill.Rows.Count % maxItem) > 0)
            totalPage++;
          for (int i = 0; i < totalPage; i++)
          {
            this.comPageInfo.Items.Insert(i, i + 1);
          }
          if (this.comPageInfo.SelectedIndex < 0)
            this.comPageInfo.SelectedIndex = 0;
        }
      }
      private bool DataCaching()
      {
        try
        {
          string selectString = "SELECT WebPayTN_lngPayTransNumber as OnePayOrderInfo, WebPayH_strBankRef as BankTransaction, OrderH_strBookingRef as BookingInfo, OrderH_intVistaBookingNumber as BookingNumber, OrderH_strPaid as PaidStatus, WebPayH_strApproved as ApproveStatus, OrderH_strUFirstName as FirstName, OrderH_strULastName as LastName, OrderH_strEmail as Email, OrderH_strPhone as Phone, OrderH_strZipCode as CMND, OrderH_dtmLastUpdated as TransactionCompletedDate";
          string fromString = " FROM vwOrderHistory";
          string orderByString = " ORDER BY TransactionCompletedDate DESC";

          string sqlCommandString = selectString + fromString + orderByString;

          this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
          this.adapter.SelectCommand.CommandType = CommandType.Text;

          this.adapter.Fill(this.tbTempResult);
          return false;
        }
        catch (Exception e)
        {
          MessageBox.Show(e.Message);
          return false;
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
        return isNum;
      }
      #endregion Methods

      #region Events      
      
      private void frmMain_Load(object sender, EventArgs e)
      {
        //Author frmAuthor = new Author();
        //frmAuthor.ShowDialog(); 
        //this.StartBackgroundWorker();
      }

      void frmMain_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
      {
        this.CloseConnection();
        //MessageBox.Show("Test thoi ma");
      }

      private void btnSearch_Click(object sender, EventArgs e)
      {
        //this.Search(0, 20);  
        //this.Search(0, 20);
        //this.FillDataGrid();
        //this.FillDropDownList(20, );
      }
      void txtInfoSearch_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
      {
        if (e.KeyChar == (char)13)
        {
          //this.Search(0, 20);
          //this.NewSearch(0, 20);
          //this.FillDataGrid();
          //this.NewFillDropDownList(20);
        }
      }
      void txtInfoSearch_Leave(object sender, System.EventArgs e)
      {
           
      }
      void txtInfoSearch_Enter(object sender, System.EventArgs e)
      {
          
      }


      private void comPageInfo_SelectedIndexChanged(object sender, EventArgs e)
      {
        if (this.isDuplicate)
          this.AddRowTable(this.tblDuplicate,this.comPageInfo.SelectedIndex, 20);
        else
          this.AddRowTable(this.comPageInfo.SelectedIndex, 20);

        this.FillDataGrid();
      }

      private void grpResult_Enter(object sender, EventArgs e)
      {

      }

      private void grpInfoSearch_Enter(object sender, EventArgs e)
      {

      }
      // This event handler is where the time-consuming work is done.
      private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
      {

        BackgroundWorker worker = sender as BackgroundWorker;
        for (int i = 1; i <= 8; i++)
        {
            // Perform a time consuming operation and report progress.
            worker.ReportProgress(i * 10);
            System.Threading.Thread.Sleep(50);          
        }
        //this.DataCaching();
        if (this.radND.Checked)
          this.LoadDataFromVistaBO(1, 0, 20);
        else if (this.radNT.Checked)
          this.LoadDataFromVistaBO(2, 0, 20);
        else if (this.radTB.Checked)
          this.LoadDataFromVistaBO(3, 0, 20);
        else if (this.radKDV.Checked)
          this.LoadDataFromVistaBO(4, 0, 20);
        else if (this.radQT.Checked)
          this.LoadDataFromVistaBO(5, 0, 20);
        else if (this.radLapTest.Checked)
          this.LoadDataFromVistaBO(6, 0, 20);
        else this.LoadDataFromVistaBO(0, 0, 20); 

        for (int i = 8; i <= 10; i++)
        {
          // Perform a time consuming operation and report progress.
          worker.ReportProgress(i * 10);
          System.Threading.Thread.Sleep(50);
        }        
      }
      // This event handler updates the progress.
      private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
      {
        // Show the progress in main form (GUI)
        //labelResult.Text = (e.ProgressPercentage.ToString() + "%");
        // Pass the progress to AlertForm label and progressbar
        alert.Message = "Đang thực hiện thao tác! Vui lòng đợi...... " + e.ProgressPercentage.ToString() + "%";
        alert.ProgressValue = e.ProgressPercentage;
      }
      // This event handler cancels the backgroundworker, fired from Cancel button in AlertForm.
      private void buttonCancel_Click(object sender, EventArgs e)
      {
        if (backgroundWorker1.WorkerSupportsCancellation == true)
        {
          // Cancel the asynchronous operation.
          backgroundWorker1.CancelAsync();
          // Close the AlertForm
          alert.Close();
        }
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

      }

      private void btnRefresh_Click(object sender, EventArgs e)
      {
        this.RefreshData();
      }

      private void timer1_Tick(object sender, EventArgs e)
      {
        this.RefreshData();
      }

      private void dgrResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
      {

      }
      #endregion Events

      private void btnInserData_Click(object sender, EventArgs e)
      {
        if (this.tbResult.Rows.Count == 0)
          MessageBox.Show("Vui lòng lấy data từ Rạp về trước khi import!", "Thông báo!");
        else if (this.rad2014.Checked)
        {
          this.InsertData2014ToDB();
        }
        else
          if (this.chkRefund.Checked)
          {
            this.InsertTransRefundToDB();
          }
          else
            this.InsertToDB();
      }

      private void btnLoadData_Click(object sender, EventArgs e)
      {
        
        if(this.radND.Checked)
          this.LoadDataFromVistaBO(1, 0, 20);
        else if (this.radNT.Checked)
          this.LoadDataFromVistaBO(2, 0, 20);
        else if (this.radTB.Checked)
          this.LoadDataFromVistaBO(3, 0, 20);
        else if (this.radKDV.Checked)
          this.LoadDataFromVistaBO(4, 0, 20);
        else if (this.radQT.Checked)
          this.LoadDataFromVistaBO(5, 0, 20);
        else if (this.radBT.Checked)
          this.LoadDataFromVistaBO(6, 0, 20);
        else if (this.radMipecHN.Checked)
            this.LoadDataFromVistaBO(7, 0, 20);
        else if (this.radDN.Checked)
            this.LoadDataFromVistaBO(8, 0, 20);
        else if (this.radQ12.Checked)
            this.LoadDataFromVistaBO(9, 0, 20);
        else if (this.radLapTest.Checked)
            this.LoadDataFromVistaBO(10, 0, 20);
        else this.LoadDataFromVistaBO(0, 0, 20); 
         
        
      }

      private void radMipecHN_CheckedChanged(object sender, EventArgs e)
      {

      }
    }
}
