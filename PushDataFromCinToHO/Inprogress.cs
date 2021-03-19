using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PushDataFromCinToHO
{
    public partial class Inprogress : Form
    {
        public string Message1
        {
            set { lblMessage1.Text = value; }
        }

        public string Message2
        {
            set { lblMessage2.Text = value; }
        }

        public int ProgressValue
        {
            set { progressBar1.Value = value; }
        }

        public Inprogress()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs> Canceled;

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            EventHandler<EventArgs> ea = Canceled;
            if (ea != null)
                ea(this, e);
        }
    }
}
