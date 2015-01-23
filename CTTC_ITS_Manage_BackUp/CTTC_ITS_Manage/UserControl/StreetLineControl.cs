using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic.PowerPacks;

namespace CTTC_ITS_Manage.UserControl
{
    public partial class StreetLineControl : DevExpress.XtraEditors.XtraUserControl
    {
        #region 全局变量

        private const int UpForwardY = 180;
        private const int DownForwardY = 360;
        private const int UpStationY = 193;
        private const int DownStationY = 373;

        private const int StartX = 30;
        private const int EndX = 1030;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer;
        private StationButton[] UpStationControl;
        private StationButton[] DownStationControl;
        private int UpLineLength = 0;
        private int DownLineLength = 0;

        #endregion

        private int upStationNumbetr;
        public int UpStationNumbetr
        {
            get
            {
                return this.upStationNumbetr;
            }
            set
            {
                this.upStationNumbetr = value;
            }
        }
        private int downStationNumbetr;
        public int DownStationNumbetr
        {
            get
            {
                return this.downStationNumbetr;
            }
            set
            {
                this.downStationNumbetr = value;
            }
        }
        private string lineID;
        public string LineID
        {
            get
            {
                return this.lineID;
            }
            set
            {
                this.lineID = value;
            }
        }
        public StreetLineControl(int[] UpDistance, int[] DownDistance, string[] UpStationName, string[] DownStationName,string theLineID)
        {
            //站点控件数组
            UpStationControl = new StationButton[UpStationName.Length];
            DownStationControl = new StationButton[DownStationName.Length];

            for (int a = 0; a < UpStationControl.Length; a++)
            {
                UpStationControl[a] = new StationButton();
            }
            for (int s = 0; s < DownStationControl.Length; s++)
            {
                DownStationControl[s] = new StationButton();
            }

            //上一个站点坐标
            int UpLastStartX = 30;
            int DownLastStartX = 30;

            InitializeComponent();
            //初始化控件
            this.StreetLinegroupBox.SuspendLayout();


            #region 上下行总路长

            for (int m = 0; m < UpDistance.Length; m++)
            {
                //上行线路总长度
                this.UpLineLength += UpDistance[m];
            }
            for (int n = 0; n < DownDistance.Length; n++)
            {
                //下行线路总长度
                this.DownLineLength += DownDistance[n];
            }

            #endregion

            #region 上行方向

            for (int i = 0; i <= UpDistance.Length; i++)
            {
                //不是最后一站
                if (i != UpDistance.Length)
                {
                    if (i == 0)
                    {
                        UpStationControl[i].Appearance.BackColor = System.Drawing.Color.Transparent;
                        UpStationControl[i].Appearance.Options.UseBackColor = true;
                        UpStationControl[i].Location = new System.Drawing.Point(StartX , UpStationY);

                        //当前横坐标累加
                        UpLastStartX += Convert.ToInt16(((float)UpDistance[i] / (float)UpLineLength * (float)(EndX - StartX)).ToString().Split('.')[0]);

                    }
                    else if (i == UpDistance.Length - 1)
                    {
                        UpStationControl[i].Appearance.BackColor = System.Drawing.Color.Transparent;
                        UpStationControl[i].Appearance.Options.UseBackColor = true;
                        UpStationControl[i].Location = new System.Drawing.Point(UpLastStartX, UpStationY);


                        //当前横坐标累加
                        UpLastStartX += Convert.ToInt16(((float)UpDistance[i] / (float)UpLineLength * (float)(EndX - StartX)).ToString().Split('.')[0]);

                    }
                    else
                    {
                        UpStationControl[i].Appearance.BackColor = System.Drawing.Color.Transparent;
                        UpStationControl[i].Appearance.Options.UseBackColor = true;
                        UpStationControl[i].Location = new System.Drawing.Point(UpLastStartX, UpStationY);

                        //当前横坐标累加
                        UpLastStartX += Convert.ToInt16(((float)UpDistance[i] / (float)UpLineLength * (float)(EndX - StartX)).ToString().Split('.')[0]);
                    }
                }
                else
                {
                    UpStationControl[i].Appearance.BackColor = System.Drawing.Color.Transparent;
                    UpStationControl[i].Appearance.Options.UseBackColor = true;
                    UpStationControl[i].Location = new System.Drawing.Point(EndX, UpStationY);


                }
                //StationButtonControl
                UpStationControl[i].Name = UpStationName[i];
                UpStationControl[i].Size = new System.Drawing.Size(22, 173);
                UpStationControl[i].TabIndex = 1;
                UpStationControl[i].TXT = UpStationName[i];
            }

            #endregion

            #region 下行方向

            for (int d = 0; d <= DownDistance.Length; d++)
            {
                //不是最后一站
                if (d != DownDistance.Length)
                {
                    if (d == 0)
                    {
                        DownStationControl[d].Appearance.BackColor = System.Drawing.Color.Transparent;
                        DownStationControl[d].Appearance.Options.UseBackColor = true;
                        DownStationControl[d].Location = new System.Drawing.Point(StartX, DownStationY);

                        //当前横坐标累加
                        DownLastStartX += Convert.ToInt16(((float)DownDistance[d] / (float)DownLineLength * (float)(EndX - StartX)).ToString().Split('.')[0]);

                    }
                    else if (d == UpDistance.Length - 1)
                    {
                        DownStationControl[d].Appearance.BackColor = System.Drawing.Color.Transparent;
                        DownStationControl[d].Appearance.Options.UseBackColor = true;
                        DownStationControl[d].Location = new System.Drawing.Point(DownLastStartX, DownStationY);


                        //当前横坐标累加
                        DownLastStartX += Convert.ToInt16(((float)DownDistance[d] / (float)DownLineLength * (float)(EndX - StartX)).ToString().Split('.')[0]);

                    }
                    else
                    {
                        DownStationControl[d].Appearance.BackColor = System.Drawing.Color.Transparent;
                        DownStationControl[d].Appearance.Options.UseBackColor = true;
                        DownStationControl[d].Location = new System.Drawing.Point(DownLastStartX, DownStationY);

                        //当前横坐标累加
                        DownLastStartX += Convert.ToInt16(((float)DownDistance[d] / (float)DownLineLength * (float)(EndX - StartX)).ToString().Split('.')[0]);
                    }
                }
                else
                {
                    DownStationControl[d].Appearance.BackColor = System.Drawing.Color.Transparent;
                    DownStationControl[d].Appearance.Options.UseBackColor = true;
                    DownStationControl[d].Location = new System.Drawing.Point(EndX, DownStationY);


                }
                //StationButtonControl
                DownStationControl[d].Name = DownStationName[d];
                DownStationControl[d].Size = new System.Drawing.Size(22, 173);
                DownStationControl[d].TabIndex = 1;
                DownStationControl[d].TXT = DownStationName[d];
            }

            #endregion




            #region ShapeContainer初始化

            this.StreetLinegroupBox.Controls.Add(this.ShapeContainer);
            this.ShapeContainer = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.ShapeContainer.Location = new System.Drawing.Point(3, 18);
            this.ShapeContainer.Margin = new System.Windows.Forms.Padding(0);
            this.ShapeContainer.Name = "shapeContainer1";
            this.ShapeContainer.Size = new System.Drawing.Size(680, 533);
            this.ShapeContainer.TabIndex = 0;
            this.ShapeContainer.TabStop = false;
            this.StreetLinegroupBox.Controls.AddRange(this.UpStationControl);
            this.StreetLinegroupBox.Controls.AddRange(this.DownStationControl);
            this.StreetLinegroupBox.Controls.Add(this.ShapeContainer);

            #endregion
            this.LineID = theLineID;
            this.label1.Text = this.LineID + "公交直线示意图";
            this.label1.Font = new Font("Times New Roman", 18);
        }

        private void StreetLineControl_Load(object sender, EventArgs e)
        {

        }

        private void StreetLinegroupBox_Enter(object sender, EventArgs e)
        {

        }
    }
}
