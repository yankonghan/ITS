using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using ITS_Manage.Model;
using ITS_Manage.DAL;
using ITS_Manage.DAL.DBUtility;
using ITS_Manage.COMMON;
using System.Threading.Tasks;

namespace ITS_Manage.DAL
{
    
    public partial class Station
    {
         public Station()
        {

        }
         #region 无用的构造函数
         /******************************************
         * 一切的Model的构造函数其实都是用不着的，在DAL层中可以直接传入Model model，利用"model.  "来获得
         * 所有方法中所需的原本需要分开写的多个参数。因此下面的构造函数全部舍去！
         *****************************
         */
        /*
        /// <summary>
        /// Station构造方法
        /// </summary>
        /// <param name="theStationID">站点编号</param>
        /// <param name="theStationName">站点名称</param>
        /// <param name="theIsOnline">是否在线</param>
       
        /// <summary>
        /// Station构造方法
        /// </summary>
        /// <param name="theStationID">站点编号</param>
        /// <param name="theStationName">站点名称</param>
        /// <param name="theChargeManID">负责人编号</param>
        /// <param name="theIsOnline">是否在线</param>
        /// <param name="Lat">纬度</param>
        /// <param name="Lng">经度</param>
        /// <param name="theRemark">备注</param>
        public Station(string theStationID, string theStationName, string theChargeManID, bool theIsOnline, double theLat, double theLng, string theRemark)
        {
            this.StationID = theStationID;
            this.StationName = theStationName;
            this.ChargeManID = theChargeManID;
            this.IsOnline = theIsOnline;
            this.Lat = theLat;
            this.Lng = theLng;
            this.Remark = theRemark;
        }
        /// <summary>
        /// station构造方法
        /// </summary>
        /// <param name="theStationID">站点编号</param>
        public Station(string theStationID)
        {
            this.StationID = theStationID;
        }
        /// <summary>
        /// station构造方法
        /// </summary>
        /// <param name="theStationID">站点编号</param>
        /// <param name="theLat">纬度</param>
        /// <param name="theLng">经度</param>
        public Station(string theStationID, double theLat, double theLng)
        {
            this.StationID = theStationID;
            this.Lat = theLat;
            this.Lng = theLng;
        }
         * */
         #endregion


         /// <summary>
        /// 查找Station表，返回全部车辆信息的数组
        /// </summary>
        /// <returns>Station的数组</returns>
        public static ITS_Manage.Model.Station[]  SelectStationArray()
        {

            DataTable StationDataTable = null;
            ITS_Manage.Model.Station[] StationArray;
            try
            {
                string strSql = "SELECT * FROM BusStop order by IsOnline desc";
                StationDataTable = SQLHelper.Query(strSql).Tables["ds"];
                StationArray = new ITS_Manage.Model.Station[StationDataTable.Rows.Count];

                for (int i = 0; i < StationDataTable.Rows.Count; i++)
                {
                    StationArray[i] = new ITS_Manage.Model.Station(StationDataTable.Rows[i][0].ToString(), StationDataTable.Rows[i][1].ToString(), Convert.ToBoolean(Convert.ToInt16(StationDataTable.Rows[i][3].ToString())));
                }
                return StationArray;
            }
            catch (Exception ex)//log
            {
                MessageBox.Show("加载公交信息失败，请检查数据库或与系统管理员联系！");
                return null;
            }
        }
        /// <summary>
        /// 查找Station表，返回全部车辆信息的数组
        /// </summary>
        /// <returns>Station的数组</returns>
        public static ITS_Manage.Model.Station[] SelectStationLineArray(string LineID)
        {

            DataTable StationDataTable = null;
            ITS_Manage.Model.Station[] StationlArray;
            try
            {
                string strSql = "SELECT Line_BusStop.Line_ID, BusStop.BusStop_ID, BusStop.BusStop_Name, BusStop.IsOnline, Line_BusStop.LineStationSeqUp from Line_BusStop join BusStop on Line_BusStop.BusStop_ID = BusStop.BusStop_ID where Line_ID = N'" + LineID + "' order by Line_BusStop.LineStationSeqUp asc";
                StationDataTable = SQLHelper.Query(strSql).Tables["ds"];
                StationlArray = new ITS_Manage.Model.Station[StationDataTable.Rows.Count];

                for (int i = 0; i < StationDataTable.Rows.Count; i++)
                {
                    StationlArray[i] = new ITS_Manage.Model.Station(StationDataTable.Rows[i][1].ToString(), StationDataTable.Rows[i][2].ToString(), Convert.ToBoolean(Convert.ToInt16(StationDataTable.Rows[i][3].ToString())));
                }
                return StationlArray;
            }
            catch (Exception ex)//log
            {
                MessageBox.Show("加载站点信息失败，请检查数据库或与系统管理员联系！");
                return null;
            }
        }
    }
}
