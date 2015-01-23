using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace ITS_Manage.BOL.BLL
{
    public class Station
    {
        #region 属性

        /// <summary>
        /// 站点ID
        /// </summary>
        private string stationID;

        public string StationID
        {
            set
            {
                stationID = value;
            }
            get
            {
                return stationID;
            }
        }
        /// <summary>
        /// 站点名称
        /// </summary>
        private string stationName;

        public string StationName
        {
            get
            {
                return stationName;
            }
            set
            {
                stationID = value;
            }
        }
        /// <summary>
        /// 负责人姓名
        /// </summary>
        private string chargeManID;

        public string ChargeManID
        {
            set
            {
                chargeManID = value;
            }
            get
            {
                return chargeManID;
            }
        }
        /// <summary>
        /// 是否在线
        /// </summary>
        private bool isOnline;

        public bool IsOnline
        {
            set
            {
                isOnline = value;
            }
            get
            {
                return isOnline;
            }
        }
        /// <summary>
        /// 纬度
        /// </summary>
        private double lat;

        public double Lat
        {
            set
            {
                lat = value;
            }
            get
            {
                return lat;
            }
        }
        /// <summary>
        /// 经度
        /// </summary>
        private double lng;

        public double Lng
        {
            get
            {
                return lng;
            }
            set
            {
                lng = value;
            }
        }
        /// <summary>
        /// 建站时间
        /// </summary>
        private DateTime buildTime;

        public DateTime BuildTime
        {
            set
            {
                buildTime = value;
            }
            get
            {
                return buildTime;
            }
        }
        /// <summary>
        /// 站点信息
        /// </summary>
        private string stationInfo;

        public string StationInfo
        {
            get
            {
                return stationInfo; 
            }
            set
            {
                 stationInfo = value;
            }
        }
        /// <summary>
        /// 备注
        /// </summary>
        private string remark;

        public string Remark
        {
            set
            {
                remark = value;
            }
            get
            {
                return remark;
            }
        }

        #endregion

        #region 方法

        public Station()
        {

        }
        /// <summary>
        /// Station构造方法
        /// </summary>
        /// <param name="theStationID">站点编号</param>
        /// <param name="theStationName">站点名称</param>
        /// <param name="theIsOnline">是否在线</param>
        public Station(string theStationID, string theStationName, bool theIsOnline)
        {
            this.StationID = theStationID;
            this.StationName = theStationName;
            this.IsOnline = theIsOnline;
        }
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


        /// <summary>
        /// 查找Station表，返回全部车辆信息的数组
        /// </summary>
        /// <returns>Station的数组</returns>
        public static Station[] SelectStationArray()
        {

            DataTable StationDataTable = null;
            Station[] StationlArray;
            try
            {
                string strSql = "SELECT * FROM BusStop order by IsOnline desc";
                StationDataTable = SQLHelper.Query(strSql).Tables["ds"];
                StationlArray = new Station[StationDataTable.Rows.Count];

                for (int i = 0; i < StationDataTable.Rows.Count; i++)
                {
                    StationlArray[i] = new Station(StationDataTable.Rows[i][0].ToString(), StationDataTable.Rows[i][1].ToString(), Convert.ToBoolean(Convert.ToInt16(StationDataTable.Rows[i][3].ToString())));
                }
                return StationlArray;
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
        public static Station[] SelectStationLineArray(string LineID)
        {

            DataTable StationDataTable = null;
            Station[] StationlArray;
            try
            {
                string strSql = "SELECT Line_BusStop.Line_ID, BusStop.BusStop_ID, BusStop.BusStop_Name, BusStop.IsOnline, Line_BusStop.LineStationSeqUp from Line_BusStop join BusStop on Line_BusStop.BusStop_ID = BusStop.BusStop_ID where Line_ID = N'" + LineID + "' order by Line_BusStop.LineStationSeqUp asc";
                StationDataTable = SQLHelper.Query(strSql).Tables["ds"];
                StationlArray = new Station[StationDataTable.Rows.Count];

                for (int i = 0; i < StationDataTable.Rows.Count; i++)
                {
                    StationlArray[i] = new Station(StationDataTable.Rows[i][1].ToString(), StationDataTable.Rows[i][2].ToString(), Convert.ToBoolean(Convert.ToInt16(StationDataTable.Rows[i][3].ToString())));
                }
                return StationlArray;
            }
            catch (Exception ex)//log
            {
                MessageBox.Show("加载站点信息失败，请检查数据库或与系统管理员联系！");
                return null;
            }
        }

        #endregion
    }
}
