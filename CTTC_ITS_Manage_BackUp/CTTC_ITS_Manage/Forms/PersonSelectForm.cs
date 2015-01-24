using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using CTTC_ITS_Manage.UserControl;
using ITS_Manage.Model;
using ITS_Manage.DAL;
using ITS_Manage.DAL.DBUtility;
using ITS_Manage.COMMON;
using System.Data.SqlClient;

namespace CTTC_ITS_Manage.Forms
{
    public partial class PersonSelectForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        public CTListType SelectListType = CTListType.PersonInfoListType;
        public DataTable dt = null;

        public PersonSelectForm()
        {
            dt = new DataTable();
            InitializeComponent();
        }


        #region 三种查找类型的单一选择
        /// <summary>
        /// 确立只有3个中的一个单选框可被选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
            {
                this.groupBox1.Enabled = true;
                this.groupBox2.Enabled = false;
                this.groupBox3.Enabled = false;
                this.radioButton2.Checked = false;
                this.radioButton3.Checked = false;
            }

        }
        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (this.radioButton2.Checked)
            {
                this.groupBox1.Enabled = false;
                this.groupBox2.Enabled = true;
                this.groupBox3.Enabled = false;
                this.radioButton1.Checked = false;
                this.radioButton3.Checked = false;
            }
        }
        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {

            if (this.radioButton3.Checked)
            {
                this.groupBox1.Enabled = false;
                this.groupBox2.Enabled = false;
                this.groupBox3.Enabled = true;
                this.radioButton1.Checked = false;
                this.radioButton2.Checked = false;
            }
        }
        #endregion


        private void SelectForm_Load(object sender, EventArgs e)
        {
            #region 初始化界面控件
            //通过首先初始化groupBox1的控件可用，从而得到“三种查找类型的单一选择”的代码执行正确性！
            this.groupBox1.Enabled = true;
            this.groupBox2.Enabled = false;
            this.groupBox3.Enabled = false;
            this.radioButton1.Checked = true;
            this.radioButton2.Checked = false;
            this.radioButton3.Checked = false;
            #endregion
           
            #region 从数据库加载数据，需修改！
            this.comboBox1.Items.Clear();
            string SqlStr = "select line_id from Line order by istest asc";
            DataSet ds = SQLHelper.Query(SqlStr);
            ds.Tables[0].Columns[0].ColumnName = "LineId";
            //绑定数据,从数据库中加载数据进而对comboBox进行数据绑定,"ds"是表名
            for (int i = 0; i < ds.Tables["ds"].Rows.Count; i++)  //绑定combBox1,线路组合框
            {
                this.comboBox1.Items.Add(ds.Tables["ds"].Rows[i].ItemArray[0].ToString().Trim());
            }

            ds.Tables[0].Columns[1].ColumnName = "Job";   //绑定comBox2,岗位组合框
            
            for (int i = 0; i < ds.Tables["ds"].Rows.Count; i++ )
            {
                this.comboBox2.Items.Add(ds.Tables["ds"].Rows[i].ItemArray[1].ToString().Trim());
            }
            //根据数据库表的实际情况需进行修改补充！！！！！！！

            #endregion
        }

        #region 条件查询
     
        /// <summary>
        /// gooupBox1的查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //RTRIM是去掉右边空格
            string Sqlstr = @"SELECT RTRIM(LTRIM(personID)) as '员工工号',
            RTRIM(LTRIM(personName)) as '姓  名', RTRIM(LTRIM(PersonSex)) as '性  别',
            RTRIM(LTRIM(personType)) as '岗  位', RTRIM(LTRIM(chargeLineID)) as '线  路'
            from Person where ChargeLineID = '" + comboBox1.Text + "'";
            dt = SQLHelper.Query(Sqlstr).Tables["ds"];
        }

       

        #endregion

        #region 精确查找
        /// <summary>
        /// 性别组合框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox4.SelectedIndex == 0)   
                {
                    comboBox4.Text = "男";
                }
                else if (comboBox4.SelectedIndex == 1)
                {
                    comboBox4.Text = "女";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
       
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string sqlStr = @"select Name  as '姓名', PersonID as '编号' , Sex as '性别' 
                             from Person where Name ='"+ textBox1.Text+"'+ and  PersonID = '"+textBox2.Text+"'";
            dt = SQLHelper.Query(sqlStr).Tables["ds"];   //还需加入DataGridView
 
        }

        #endregion

        #region 条件查找
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        #endregion

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            
 
        }

       

       
    }
}