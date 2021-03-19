using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BackgroundWorkerDemo
{
    public partial class Splash : Form
    {
        #region FIELDS

        Timer timer = new Timer();
        bool fadeIn = true;
        bool fadeOut = true;

        #endregion

        #region METHODS

        public Splash()
        {
            InitializeComponent();

            ExtraFormSettings();
            SetAndStartTimer();
        }

        private void SetAndStartTimer()
        {
            timer.Interval = 100;
            timer.Tick += new EventHandler(t_Tick);
            timer.Start();
        }

        private void ExtraFormSettings()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Opacity = 0.5;
            this.BackgroundImage = Properties.Resources.splash;
        }

        #endregion

        #region EVENTS

        void t_Tick(object sender, EventArgs e)
        {
            if (fadeIn)
            {
                if (this.Opacity < 1.0)
                {
                    this.Opacity += 0.02;
                }
                else
                {
                    fadeIn = false;
                    fadeOut = true;
                }
            }
            else if (fadeOut)
            {
                if (this.Opacity > 0)
                {
                    this.Opacity -= 0.02;
                }
                else
                {
                    fadeOut = false;
                }
            }

            if (!(fadeIn || fadeOut))
            {
                timer.Stop();
                this.Close();
            }
        }

        #endregion

    }
}
