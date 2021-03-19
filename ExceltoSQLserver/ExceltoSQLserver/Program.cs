using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ExceltoSQLserver
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            //Chay tool doi soat cho ke toan
            //Application.Run(new OnlinePaymentReconciliation());

            //Chay tool refund cho IT Team
            Application.Run(new RefundChecking());
        }
    }
}
