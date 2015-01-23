using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CTTC_ITS_Manage.Forms;

namespace CTTC_ITS_Manage.UserControl
{
    public partial class ModelInfoList : DevExpress.XtraEditors.XtraUserControl
    {
        public ModelInfoList()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 对每种窗体的实例化，再最后利用Load时传入的参数来判断具体加载的窗体
        /// </summary>
        /// <param name="SelectForm"></param>
        public ModelInfoList(PersonSelectForm SelectForm)
        {
            InitializeComponent();

            this.DGVToShow.DataSource = SelectForm.dt;
            this.InfoListlabel.Text = "人员信息查询";
            this.InfoListlabel.Font = new Font("Times New Roman", 18);
        }
        public ModelInfoList(LineSelectForm SelectForm)
        {
            InitializeComponent();

            this.DGVToShow.DataSource = SelectForm.dt;
            this.InfoListlabel.Text = "线路信息查询";
            this.InfoListlabel.Font = new Font("Times New Roman", 18);
        }
        /// <summary>
        /// 列表类型
        /// </summary>
        private CTListType infoListType;
        /// <summary>
        /// 列表类型
        /// </summary>
        private CTListType InfoListType
        {
            get
            {
                return infoListType;
            }
            set
            {
                infoListType = value;
            }
        }
        /// <summary>
        /// 显示数据表
        /// </summary>
        private DataTable selectResultDT;
        /// <summary>
        /// 显示数据表
        /// </summary>
        public DataTable SelectResultDT
        {
            get
            {
                return selectResultDT;
            }
            set
            {
                selectResultDT = value;
            }

        }
        /// <summary>
        /// 查询窗体
        /// </summary>
        private PersonSelectForm sF;
        /// <summary>
        /// 查询窗体
        /// </summary>
        public PersonSelectForm SF
        {
            get
            {
                return sF;
            }
            set
            {
                sF = value;
            }

        }
        /// <summary>
        /// 根据不同的信息进行加载  “信息列表窗体”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModelInfoList_Load(object sender, EventArgs e)
        {
            switch (InfoListType)
            {
                case CTListType.PersonInfoListType:
                    

                    break;
                case CTListType.BusInfoListType:
                    break;
                case CTListType.LineInfoListType:
                    break;
                case CTListType.StopInfoListType:
                    break;
            }
        }
    }
}
