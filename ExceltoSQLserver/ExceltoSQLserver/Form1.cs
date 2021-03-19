using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
//using System.Data.SqlClient;

namespace ExceltoSQLserver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateTable();
        }

        DataSet1TableAdapters.tblMonHocTableAdapter mh = new DataSet1TableAdapters.tblMonHocTableAdapter();
        DataTable tbDisplayResult = new DataTable();
      

        private void CreateTable()
        {
          //this.tbDisplayResult.Columns.Add("FirstName", typeof(string));
          this.tbDisplayResult.Columns.Add("N.O", typeof(string));
          this.tbDisplayResult.Columns.Add("OrderID", typeof(string));
          this.tbDisplayResult.Columns.Add("BankID", typeof(string));
          this.tbDisplayResult.Columns.Add("TransDate", typeof(string));
          //this.tbDisplayResult.Columns.Add("EmailSent", typeof(string));
          this.tbDisplayResult.Columns.Add("Amount", typeof(string));
          
        }
        private void AddRowTable(int index, int count)
        {
          
        }
        private void FillDataGrid()
        {
          this.dataGridView1.DataSource = this.tbDisplayResult;
        }
        
        void LoadData()
        {
            dataGridView1.DataSource = mh.GetData();
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

        private void button1_Click(object sender, EventArgs e)
        {
          this.tbDisplayResult.Rows.Clear();
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
                        DataRow row = this.tbDisplayResult.NewRow();
                        //row["FirstName"] = this.tbResult.Rows[rowIndex]["FirstName"];
                        //row["LastName"] = this.tbResult.Rows[rowIndex]["LastName"];
                        row["N.O"] = a[0];
                        row["OrderID"] = a[1];
                        row["BankID"] = a[2];
                        row["TransDate"] = a[3];
                        row["Amount"] = a[6];


                        this.tbDisplayResult.Rows.Add(row);
                      
                    }
                    //LoadData();
                    FillDataGrid();
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
