using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace ITS_Manage.BOL.BLL
{
    public class Bus
    {
        #region 属性
        /// <summary>
        /// 车牌号
        /// </summary>
        private string busID;
        /// <summary>
        /// 车牌号
        /// </summary>
        public string BusID
        {
            get
            {
                return busID;
            }
            set
            {
                busID = value;
            }
        }
        /// <summary>
        /// 司机名
        /// </summary>
        private string driverName;
        /// <summary>
        /// 司机名
        /// </summary>
        public string DriverName
        {
            get
            {
                return driverName;
            }
            set
            {
                driverName = value;
            }
        }

        /// <summary>
        /// 纬度
        /// </summary>
        private double lat;
        /// <summary>
        /// 纬度
        /// </summary>
        public double Lat
        {
            get
            {
                return lat;
            }
            set
            {
                lat = value;
            }
        }
        /// <summary>
        /// 经度
        /// </summary>
        private double lng;
        /// <summary>
        /// 经度
        /// </summary>
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
        /// 行驶速度
        /// </summary>
        private double speed;
        /// <summary>
        /// 行驶速度
        /// </summary>
        public double Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
            }
        }
        /// <summary>
        /// 车上人数
        /// </summary>
        private int peopleNum;
        /// <summary>
        /// 车上人数
        /// </summary>
        public int PeopleNum
        {
            get
            {
                return peopleNum;
            }
            set
            {
                peopleNum = value;
            }
        }
        /// <summary>
        /// 行驶方向
        /// </summary>
        private Forward forward;
        /// <summary>
        /// 行驶方向
        /// </summary>
        public Forward Forward
        {
            get
            {
                return forward;
            }
            set
            {
                forward = value;
            }
        }
        /// <summary>
        /// 剩余油量
        /// </summary>
        private double oilRemain;
        /// <summary>
        /// 剩余油量
        /// </summary>
        public double OilRemain
        {
            get
            {
                return oilRemain;
            }
            set
            {
                oilRemain = value;
            }
        }
        /// <summary>
        /// 是否在线
        /// </summary>
        private bool isOnline;
        /// <summary>
        /// 是否在线
        /// </summary>
        public bool IsOnline
        {
            get
            {
                return isOnline;
            }
            set
            {
                isOnline = value;
            }
        }
        /// <summary>
        /// 是否报警
        /// </summary>
        private bool isAlarm;
        /// <summary>
        /// 是否报警
        /// </summary>
        public bool IsAlarm
        {
            get
            {
                return isAlarm;
            }
            set
            {
                isAlarm = value;
            }
        }
        /// <summary>
        /// 线路名
        /// </summary>
        private string lineName;
        /// <summary>
        /// 线路名
        /// </summary>
        public string LineName
        {
            get
            {
                return lineName;
            }
            set
            {
                lineName = value;
            }
        }
        /// <summary>
        /// 下一站站名
        /// </summary>
        private string nextStop;
        /// <summary>
        /// 下一站站名
        /// </summary>
        public string NextStop
        {
            get
            {
                return nextStop;
            }
            set
            {
                nextStop = value;
            }
        }
        ///// <summary>
        ///// 是否在线
        ///// </summary>
        //private bool isRun;
        ///// <summary>
        ///// 是否在线
        ///// </summary>
        //public bool IsRun { get; set; }

        #endregion

        #region 方法

        public Bus()
        { 
            
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="theBusID">公交车牌号</param>
        /// <param name="theDriver">司机</param>
        /// <param name="theLine">线路</param>
        /// <param name="theInfo"></param>
        public Bus(string theBusID, Person theDriver, Line theLine, BusRealInfo theInfo)
        {
            this.busID = theBusID;
            this.driverName = theDriver.Name;
            this.forward = theInfo.Forward;
            this.speed = theInfo.Speed;
            this.lineName = theLine.LineName;
            this.lat = theInfo.Lat;
            this.lng = theInfo.Lng;
            this.isOnline = true;
            this.isAlarm = theInfo.IsAlarm;
            this.oilRemain = theInfo.OilRemain;
        }

        public Bus(string theBusID, bool theIsOnline)
        {
            // TODO: Complete member initialization
            this.BusID = theBusID;
            this.IsOnline = theIsOnline;
        }
        /// <summary>
        /// 精确查找person表
        /// </summary>
        /// <param name="thePerson">查询条件</param>
        /// <returns>person的list</returns>
        public static DataTable SelectBusInfo(Bus theBus)
        {
            DataTable BusDataTable = null;

            try
            {
                string strSql = "SELECT * FROM Bus where Bus_id = '" + theBus.BusID + "'";
                BusDataTable = SQLHelper.Query(strSql).Tables["ds"];
                return BusDataTable;
            }
            catch (Exception ex)//log
            {
                MessageBox.Show("查询失败，请核对查询条件！");
                return null;
            }
        }
        /// <summary>
        /// 查找Bus表，返回全部车辆信息
        /// </summary>
        /// <returns>Bus的DataTable</returns>
        public static DataTable SelectBusInfo()
        {
            DataTable BusDataTable = null;

            try
            {
                string strSql = "SELECT Bus_ID, IsRun FROM Bus";
                BusDataTable = SQLHelper.Query(strSql).Tables["ds"];
                return BusDataTable;
            }
            catch (Exception ex)//log
            {
                MessageBox.Show("加载公交信息失败，请检查数据库或与系统管理员联系！");
                return null;
            }
        }
        /// <summary>
        /// 查找Bus表，返回全部车辆信息de List列表
        /// </summary>
        /// <returns>Bus的List</returns>
        public static List<Bus> SelectBuslist()
        {
            DataTable BusDataTable = null;
            List<Bus> Buslist = null;
            try
            {
                string strSql = "SELECT * FROM Bus";
                BusDataTable = SQLHelper.Query(strSql).Tables["ds"];
                for (int i = 0; i < BusDataTable.Rows.Count; i++)
                {
                    Bus temp = new Bus(BusDataTable.Rows[i][0].ToString(), Convert.ToBoolean(Convert.ToInt16(BusDataTable.Rows[i][5].ToString())));
                    Buslist.Add(temp);
                }
                return Buslist;
            }
            catch (Exception ex)//log
            {
                MessageBox.Show("加载公交信息失败，请检查数据库或与系统管理员联系！");
                return null;
            }
        }
        /// <summary>
        /// 查找Bus表，返回全部车辆信息的数组
        /// </summary>
        /// <returns>Bus的数组</returns>
        public static Bus[] SelectBusArray(string ChargeLineID)
        {
            
            DataTable BusDataTable = null;
            Bus[] BuslArray;
            try
            {
                string strSql = "SELECT * FROM Bus where ChargeLine_id = '" + ChargeLineID + "' order by isOnline desc";
                BusDataTable = SQLHelper.Query(strSql).Tables["ds"];
                BuslArray = new Bus[BusDataTable.Rows.Count];

                for (int i = 0; i < BusDataTable.Rows.Count; i++)
                {
                    BuslArray[i] = new Bus(BusDataTable.Rows[i][0].ToString(), Convert.ToBoolean(Convert.ToInt16(BusDataTable.Rows[i][5].ToString())));
                }
                return BuslArray;
            }
            catch (Exception ex)//log
            {
                MessageBox.Show("加载公交信息失败，请检查数据库或与系统管理员联系！");
                return null;
            }
        }
        #endregion


        //public static Bus GetBusRealInfo(string BusID)
        //{
        //    //在线判断
        //    Bus BusRealInfo = new Bus();
        //    DataTable BusDataTable = null;
        //    Bus[] BuslArray;
        //    try
        //    {
        //        string strSql = "SELECT * FROM Bus where ChargeLine_id = '" + BusID + "' order by isOnline desc";
        //        BusDataTable = SQLHelper.Query(strSql).Tables["ds"];
        //        BuslArray = new Bus[BusDataTable.Rows.Count];

        //        for (int i = 0; i < BusDataTable.Rows.Count; i++)
        //        {
        //            BuslArray[i] = new Bus(BusDataTable.Rows[i][0].ToString(), Convert.ToBoolean(Convert.ToInt16(BusDataTable.Rows[i][5].ToString())));
        //        }
        //        return RealInfo;
        //    }
        //    catch (Exception ex)//log
        //    {
        //        MessageBox.Show("加载公交信息失败，请检查数据库或与系统管理员联系！");
        //        return null;
        //    }
        //    return RealInfo;
        //}
    }
}
