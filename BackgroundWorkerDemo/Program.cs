using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BackgroundWorkerDemo
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
            #region Splash
            Application.Run(new Splash());
            // After splash form closed, start the main form.
            Application.Run(new GUI());
            #endregion
        }
    }
}
