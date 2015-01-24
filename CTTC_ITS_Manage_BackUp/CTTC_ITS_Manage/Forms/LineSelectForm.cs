using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ITS_Manage.Model;
using ITS_Manage.DAL;
using ITS_Manage.COMMON;
using DevExpress.XtraBars;
using System.Data.SqlClient;
using CTTC_ITS_Manage.UserControl;

namespace CTTC_ITS_Manage.Forms
{
    public partial class LineSelectForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public CTListType SelectListType = CTListType.LineInfoListType;
        public DataTable dt = null;
        public LineSelectForm()
        {
            dt = new DataTable();
            InitializeComponent();
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void LineSelectForm_Load(object sender, EventArgs e)
        {
            #region 初始化界面控件

            this.groupBox1.Enabled = true;
            this.groupBox2.Enabled = false;
            this.groupBox3.Enabled = false;
            this.radioButton1.Checked = true;
            this.radioButton2.Checked = false;
            this.radioButton3.Checked = false;

            #endregion
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                this.radioButton2.Checked = false;
                this.radioButton3.Checked = false;
                this.groupBox1.Enabled = true;
                this.groupBox2.Enabled = false;
                this.groupBox3.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                this.radioButton3.Checked = false;
                this.radioButton1.Checked = false;
                this.groupBox1.Enabled = false;
                this.groupBox2.Enabled = true;
                this.groupBox3.Enabled = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                this.radioButton1.Checked = false;
                this.radioButton2.Checked = false;
                this.groupBox1.Enabled = false;
                this.groupBox2.Enabled = false;
                this.groupBox3.Enabled = true;
            }
        }
    }
}