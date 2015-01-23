using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CTTC_ITS_Manage.UserControl
{
    /*主要是用来显示站点的按钮*/
    public partial class StationButton : DevExpress.XtraEditors.XtraUserControl
    {
        public StationButton()
        {
            InitializeComponent();
            this.button1.MouseHover += new EventHandler(button1_MouseHover);
            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;

            toolTip1.ShowAlways = false;
        }
        private string txt;
        public string TXT
        {
            get
            {
                this.txt = this.label1.Text;
                return this.txt;
            }
            set
            {
                this.txt = value;
                this.label1.Text = txt;
            }
        }
        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(TXT, this.button1);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
