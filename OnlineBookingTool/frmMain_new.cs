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
      //private DataRow rowResult;
      //private DataColumn colResult;
      //private int index = 0;
      private DataTable tbDisplayResult;
      private SqlConnection con;
      //private string connectionString = "Data Source=192.168.116.5;Initial Catalog=VISTAIT;User Id=sa;Password=GaLaXyNDNTTB126;";
      private string connectionString = "Data Source=192.168.116.5;Initial Catalog=VISTAIT_41;User Id=sa;Password=GaLaXyNDNTTB126;";
      private SqlDataAdapter adapter;
      //private SqlCommand command;

      #endregion Fields

      #region Constructors
      public frmMain()
      {
          InitializeComponent();
          this.tbResult = new DataTable();
          this.tbDisplayResult = new DataTable();
          //this.colResult = new DataColumn();
          this.con = new SqlConnection();          
          this.OpenConnection();
          this.adapter = new SqlDataAdapter();
          this.CreatTable();
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
      #endregion Properties.

      #region Methods
      private void OpenConnection()
      {
        if (this.con.State != ConnectionState.Open)
        {
          this.con.ConnectionString = this.connectionString;
          this.con.Open();
        }
      }
      private void CloseConnection()
      {
        if (this.con.State == ConnectionState.Open)
          this.con.Close();
      }
      private void CreatTable()
      {
        //this.tbDisplayResult.Columns.Add("FirstName", typeof(string));
        //this.tbDisplayResult.Columns.Add("LastName", typeof(string));
        this.tbDisplayResult.Columns.Add("FullName", typeof(string));
        this.tbDisplayResult.Columns.Add("CMND", typeof(string));
        this.tbDisplayResult.Columns.Add("Email", typeof(string));
        //this.tbDisplayResult.Columns.Add("EmailSent", typeof(string));
        this.tbDisplayResult.Columns.Add("Phone", typeof(string));
        this.tbDisplayResult.Columns.Add("BookingInfo", typeof(string));
        //this.tbDisplayResult.Columns.Add("BookingNo", typeof(string));
        //this.tbDisplayResult.Columns.Add("TransactionNo", typeof(string));
        //this.tbDisplayResult.Columns.Add("TransactionCompletedDate", typeof(string));
          
        this.tbDisplayResult.Columns.Add("OnePayOrderInfo", typeof(string));
        this.tbDisplayResult.Columns.Add("BankTransaction", typeof(string));
        //this.tbDisplayResult.Columns.Add("CardNumber", typeof(string));
        this.tbDisplayResult.Columns.Add("PaidStatus", typeof(string));
        this.tbDisplayResult.Columns.Add("ApproveStatus", typeof(string));

        this.tbResult.Columns.Add("FirstName", typeof(string));
        this.tbResult.Columns.Add("LastName", typeof(string));
        //this.tbResult.Columns.Add("FullName", typeof(string));
        this.tbResult.Columns.Add("CMND", typeof(string));
        this.tbResult.Columns.Add("Email", typeof(string));
        //this.tbResult.Columns.Add("EmailSent", typeof(string));
        this.tbResult.Columns.Add("Phone", typeof(string));
        this.tbResult.Columns.Add("BookingInfo", typeof(string));
        //this.tbResult.Columns.Add("BookingNo", typeof(string));
        //this.tbResult.Columns.Add("TransactionNo", typeof(string));
        //this.tbResult.Columns.Add("TransactionCompletedDate", typeof(string));
        this.tbResult.Columns.Add("OnePayOrderInfo", typeof(string));
        this.tbResult.Columns.Add("BankTransaction", typeof(string));
        //this.tbResult.Columns.Add("CardNumber", typeof(string));
        this.tbResult.Columns.Add("PaidStatus", typeof(string));
        this.tbResult.Columns.Add("ApproveStatus", typeof(string));
        
      }
      private void AddRowTable(int index, int count)
      {
        int rowIndex = index * count;
        this.tbDisplayResult.Clear();
        for (int i = 0; i < count; i++)
        {
          if (rowIndex < this.tbResult.Rows.Count)
          {
            DataRow row = this.tbDisplayResult.NewRow();
            //row["FirstName"] = this.tbResult.Rows[rowIndex]["FirstName"];
            //row["LastName"] = this.tbResult.Rows[rowIndex]["LastName"];
            row["FullName"] = this.tbResult.Rows[rowIndex]["FirstName"] + " " + this.tbResult.Rows[rowIndex]["LastName"];
            row["Email"] = this.tbResult.Rows[rowIndex]["Email"];
            row["CMND"] = this.tbResult.Rows[rowIndex]["CMND"];
            //row["EmailSent"] = this.tbResult.Rows[rowIndex]["EmailSent"];
            row["Phone"] = this.tbResult.Rows[rowIndex]["Phone"];
            row["BookingInfo"] = this.tbResult.Rows[rowIndex]["BookingInfo"];
            //row["BookingNo"] = this.tbResult.Rows[rowIndex]["BookingNo"];
            //row["TransactionNo"] = this.tbResult.Rows[rowIndex]["TransactionNo"];
            //row["TransactionCompletedDate"] = this.tbResult.Rows[rowIndex]["TransactionCompletedDate"];
            row["OnePayOrderInfo"] = this.tbResult.Rows[rowIndex]["OnePayOrderInfo"];
            row["BankTransaction"] = this.tbResult.Rows[rowIndex]["BankTransaction"];
            //row["CardNumber"] = this.tbResult.Rows[rowIndex]["CardNumber"];
            row["PaidStatus"] = this.tbResult.Rows[rowIndex]["PaidStatus"];
            row["ApproveStatus"] = this.tbResult.Rows[rowIndex]["ApproveStatus"];
            
            this.tbDisplayResult.Rows.Add(row);
          }
          else
            break;
          rowIndex++;
        }
      }
      private void Search(int startindex, int count)
      {
          if (!IsNumeric(this.txtInfoSearch.Text))
          {
              MessageBox.Show("Vui lòng nhập số!", "Thông báo");
              this.txtInfoSearch.Text = "";
          }
          else
          {
              this.tbResult.Clear();
              this.comPageInfo.Items.Clear();
              //string selectString = "SELECT WebPayTN_lngPayTransNumber as OnePayOrderInfo, WebPayH_strBankRef as BankTransaction, OrderH_strBookingRef as BookingInfo, OrderH_intVistaBookingNumber as BookingNo, OrderH_intVistaTransNumber as TransactionNo, OrderH_strCard as CardNumber, OrderH_strPaid as PaidStatus, WebPayH_strApproved as ApproveStatus, OrderH_strUFirstName as FirstName, OrderH_strULastName as LastName, OrderH_strEmail as Email, OrderH_strPhone as CMND, OrderH_strZipCode as Phone, OrderH_dtmLastUpdated as TransactionCompletedDate";
              string selectString = "SELECT WebPayTN_lngPayTransNumber as OnePayOrderInfo, WebPayH_strBankRef as BankTransaction, OrderH_strBookingRef as BookingInfo, OrderH_strPaid as PaidStatus, WebPayH_strApproved as ApproveStatus, OrderH_strUFirstName as FirstName, OrderH_strULastName as LastName, OrderH_strEmail as Email, OrderH_strPhone as Phone, OrderH_strZipCode as CMND, OrderH_dtmLastUpdated as TransactionCompletedDate";
              //string fromString = " FROM tblWebPaymentHistory inner join tblOrderHistory on CAST(SUBSTRING(WebPayH_strClientRef, CHARINDEX('-', WebPayH_strClientRef) + 1, 20) as INT) = OrderH_intVistaTransNumber";
              string child_select_Statement = string.Empty;
              string fromString = string.Empty;
              string whereString = string.Empty;
              if (this.txtOrderID.Text.Length > 0 & this.txtInfoSearch.Text.Length > 0 & this.txtEmailAddress.Text.Length > 0)
              {
                  MessageBox.Show("Chỉ được nhập một trong các thông tin: Mã ngân hàng, Đơn hàng HOẶC mã số booking, số CMND, ... HOẶC địa chỉ email để tìm kiếm!");
                  this.txtOrderID.Focus();
              }
              else
              {
                  if (this.txtInfoSearch.Text.Length > 0)
                  {
                      string selectStr = string.Empty;
                      selectStr = "SELECT OrderH_strBookingRef as BookingInfo, OrderH_strPaid as PaidStatus, OrderH_strUFirstName as FirstName, OrderH_strULastName as LastName, OrderH_strEmail as Email, OrderH_strPhone as Phone, OrderH_strZipCode as CMND, OrderH_dtmLastUpdated as TransactionCompletedDate";
                      fromString = " FROM tblOrderHistory";
                      whereString = string.Format(" WHERE OrderH_intVistaBookingNumber = '{0}' OR OrderH_strPhone = '{0}' OR OrderH_strZipCode = '{0}') AND (OrderH_dtmLastUpdated BETWEEN '{1}' AND '{2}')", this.txtInfoSearch.Text, "9/1/2014 12:00:00 AM", "12/31/2015 11:59:00 PM");
                      child_select_Statement = selectStr + fromString + whereString;

                      //whereString = string.Format(" WHERE (WebPayH_strBankRef ='{0}' Or WebPayTN_lngPayTransNumber ='{0}' OR OrderH_intVistaBookingNumber = '{0}' OR OrderH_strPhone = '{0}' OR OrderH_strZipCode = '{0}') AND (OrderH_dtmLastUpdated BETWEEN '{1}' AND '{2}')", this.txtInfoSearch.Text, "9/1/2014 12:00:00 AM", "12/31/2015 11:59:00 PM");
                  }
                  else
                      if (this.txtEmailAddress.Text.Length > 0)
                      {
                          string selectStr = string.Empty;
                          selectStr = "SELECT OrderH_strBookingRef as BookingInfo, OrderH_strPaid as PaidStatus, OrderH_strUFirstName as FirstName, OrderH_strULastName as LastName, OrderH_strEmail as Email, OrderH_strPhone as Phone, OrderH_strZipCode as CMND, OrderH_dtmLastUpdated as TransactionCompletedDate";
                          fromString = " FROM tblOrderHistory";
                          whereString = string.Format(" WHERE OrderH_intVistaBookingNumber = '{0}' OR OrderH_strPhone = '{0}' OR OrderH_strZipCode = '{0}') AND (OrderH_dtmLastUpdated BETWEEN '{1}' AND '{2}')", this.txtInfoSearch.Text, "9/1/2014 12:00:00 AM", "12/31/2015 11:59:00 PM");
                          child_select_Statement = selectStr + fromString + whereString;
                          
                          //whereString = string.Format(" WHERE (OrderH_strEmail like '%{0}%') AND (OrderH_dtmLastUpdated BETWEEN '{1}' AND '{2}')", this.txtEmailAddress.Text, "9/1/2014 12:00:00 AM", "12/31/2015 11:59:00 PM");
                      }
                      else
                          if (this.txtOrderID.Text.Length > 0)
                          {
                              string selectStr = string.Empty;
                              selectStr = "SELECT CAST(SUBSTRING(WebPayH_strClientRef, LEN(Cinema_strID)+2, 20) as INT) as TransNum, WebPayTN_lngPayTransNumber as OnePayOrderInfo, WebPayH_strBankRef as BankTransaction";
                              fromString = " FROM tblWebPaymentHistory";
                              whereString = string.Format(" WHERE (WebPayH_strBankRef ='{0}' Or WebPayTN_lngPayTransNumber ='{0}') AND (OrderH_dtmLastUpdated BETWEEN '{1}' AND '{2}')", this.txtInfoSearch.Text, "9/1/2014 12:00:00 AM", "12/31/2015 11:59:00 PM");
                              //whereString = string.Format(" WHERE OrderH_intVistaBookingNumber = '{0}' OR OrderH_strPhone = '{0}' OR OrderH_strZipCode = '{0}') AND (OrderH_dtmLastUpdated BETWEEN '{1}' AND '{2}')", this.txtInfoSearch.Text, "9/1/2014 12:00:00 AM", "12/31/2015 11:59:00 PM");
                              child_select_Statement = selectStr + fromString + whereString;

                              //whereString = string.Format(" WHERE (OrderH_strEmail like '%{0}%') AND (OrderH_dtmLastUpdated BETWEEN '{1}' AND '{2}')", this.txtEmailAddress.Text, "9/1/2014 12:00:00 AM", "12/31/2015 11:59:00 PM");
                          }
                          else
                              whereString = string.Format(" WHERE OrderH_dtmLastUpdated BETWEEN '{0}' AND '{1}'", "9/1/2014 12:00:00 AM", "12/31/2015 11:59:00 PM");


                  string orderByString = " ORDER BY TransactionCompletedDate DESC";

                  string sqlCommandString = selectString + fromString + whereString + orderByString;

                  this.adapter.SelectCommand = new SqlCommand(sqlCommandString, this.con);
                  this.adapter.SelectCommand.CommandType = CommandType.Text;

                  this.adapter.Fill(this.tbResult);
                  this.labTotalTransaction.Text = string.Format("{0} giao dịch", this.tbResult.Rows.Count);

                  this.AddRowTable(startindex, count);
                  //int emailAlertCount = 0;
                  //int posAlertCount = 0;
                  if (this.txtInfoSearch.Text.Length > 0 || this.txtEmailAddress.Text.Length > 0)
                  {
                      for (int index = 0; index < this.tbDisplayResult.Rows.Count; index++)
                      {
                          string bookingnumber = (string)this.tbDisplayResult.Rows[index]["BookingInfo"];
                          string emailAddress = (string)this.tbDisplayResult.Rows[index]["Email"];
                          try
                          {
                              StreamReader streamReader = new StreamReader("VistaWebClient_PostChargeOrders.log");
                              string errorlog = streamReader.ReadToEnd();
                              //string test = "12345";
                              if (errorlog.IndexOf(bookingnumber, 0) >= 0)
                              {
                                  MessageBox.Show(string.Format(@"Booking: {0} nằm trong file error log VistaWebClient_PostChargeOrders.log (192.168.116.5\Vista\Log\VistaWebClient_PostChargeOrders.log)!", bookingnumber));
                                  streamReader.Close();
                                  //posAlertCount++;
                              }
                              //if (this.txtInfoSearch.Text.Length > 0)
                              {
                                  streamReader = new StreamReader("visInternetTicketing.log");
                                  errorlog = streamReader.ReadToEnd();
                                  //string test = "12345";
                                  if (errorlog.IndexOf(emailAddress, 0) >= 0 )
                                  {
                                      MessageBox.Show(string.Format(@"Booking: {0} có địa chỉ email nằm trong error log visInternetTicketing.log (192.168.116.5\Vista\Log\visInternetTicketing.log). Vui lòng kiểm tra và gửi lại email confirmation nếu chưa được gửi đến KH!", bookingnumber));
                                      streamReader.Close();
                                      //emailAlertCount++;
                                  }
                              }
                          }
                          catch
                          {
                              MessageBox.Show("Không tìm thấy file log VistaWebClient_PostChargeOrders.log hoặc visInternetTicketing.log!");
                              break;
                              //streamReader.Close();
                          }
                      }
                  }
              }
          }

      }
      private void FillDataGrid()
      {
        this.dgrResult.DataSource = this.tbDisplayResult;
      }
      private void FillDropDownList(int maxItem)
      {
        if (this.tbResult.Rows.Count > 0)
        {
          int totalPage = 0;
          totalPage = this.tbResult.Rows.Count / maxItem;
          if ((this.tbResult.Rows.Count % maxItem) > 0)
            totalPage++;
          for (int i = 0; i < totalPage; i++)
          {
            this.comPageInfo.Items.Insert(i, i + 1);
          }
          if (this.comPageInfo.SelectedIndex < 0)
            this.comPageInfo.SelectedIndex = 0;
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
        Author frmAuthor = new Author();
        frmAuthor.ShowDialog();        
      }

      void frmMain_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
      {
        this.CloseConnection();
        //MessageBox.Show("Test thoi ma");
      }

      private void btnSearch_Click(object sender, EventArgs e)
      {
        this.Search(0, 20);        
        this.FillDataGrid();
        this.FillDropDownList(20);
      }
      void txtInfoSearch_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
      {
        if (e.KeyChar == (char)13)
        {
          this.Search(0, 20);
          this.FillDataGrid();
          this.FillDropDownList(20);
        }
      }
      void txtInfoSearch_Leave(object sender, System.EventArgs e)
      {
           
      }
      void txtInfoSearch_Enter(object sender, System.EventArgs e)
      {
          
      }


      #endregion Events

      private void comPageInfo_SelectedIndexChanged(object sender, EventArgs e)
      {
        this.AddRowTable(this.comPageInfo.SelectedIndex, 20);
        this.FillDataGrid();
      }

      private void grpResult_Enter(object sender, EventArgs e)
      {

      }

      private void grpInfoSearch_Enter(object sender, EventArgs e)
      {

      }
    }
}
