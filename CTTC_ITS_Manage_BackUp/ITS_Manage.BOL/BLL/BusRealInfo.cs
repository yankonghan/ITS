using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace ITS_Manage.BOL.BLL
{
    public class BusRealInfo
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
        /// 司机
        /// </summary>
        private string driverName;
        /// <summary>
        /// 司机
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
        /// 行车方向
        /// </summary>
        private Forward forward;
        /// <summary>
        /// 行车方向
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
        /// 速度
        /// </summary>
        private double speed;
        /// <summary>
        /// 速度
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

        private DateTime realTime;
        public DateTime RealTime
        {
            get
            {
                return realTime;
            }
            set
            {
                realTime = value;
            }
        }

        #endregion

        #region 方法

        public BusRealInfo()
        {

        }
        public BusRealInfo(Forward theForward, double speed, double Lat, double Lng, bool IsAlarm)
        {
            this.forward = theForward;
        }
        /// <summary>
        /// 获取指定线路的车辆实时信息列表
        /// </summary>
        /// <param name="lineID">线路号</param>
        /// <returns>车辆实时信息列表</returns>
        public static List<BusRealInfo> GetBusRealInfoList(string lineID)
        {
            List<BusRealInfo> BusRealList = new List<BusRealInfo>();
            string sqlstr = "select * from (select a.* ,q.personName from Bus_RealTime as a join Bus as b on a.Bus_ID = b.Bus_id join Person as q on a.Driver_ID = q.personID where b.ChargeLine_id = N'" +
                lineID + "') as t where EXISTS (select Bus_ID, max(RealTime) as e from Bus_RealTime group by Bus_ID having t.Bus_ID = Bus_ID and t.RealTime =max(RealTime))";
            DataTable dt = SQLHelper.Query(sqlstr).Tables["ds"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BusRealInfo busReal = new BusRealInfo();
                busReal.BusID = dt.Rows[i][0].ToString();
                busReal.RealTime = Convert.ToDateTime(dt.Rows[i][1].ToString());
                busReal.Speed = Convert.ToDouble(dt.Rows[i][2].ToString());
                busReal.PeopleNum = Convert.ToInt16(dt.Rows[i][3].ToString());
                busReal.Lat = Convert.ToDouble(dt.Rows[i][4].ToString());
                busReal.Lng = Convert.ToDouble(dt.Rows[i][5].ToString());
                busReal.OilRemain = Convert.ToDouble(dt.Rows[i][6].ToString());
                switch (dt.Rows[i][7].ToString())
                {
                    case "0":
                        busReal.IsAlarm = false;
                        break;
                    case "1":
                        busReal.IsAlarm = true;
                        break;
                    default:
                        break;
                }
                busReal.DriverName = dt.Rows[i][10].ToString();
                switch (dt.Rows[i][9].ToString().ToUpper())
                {
                    case "UP":
                        busReal.Forward = Forward.UP;
                        break;
                    case "DOWN":
                        busReal.Forward = Forward.DOWN;
                        break;
                    default:
                        break;
                }
                BusRealList.Add(busReal);
            }
       
        return BusRealList;
        }
        /// <summary>
        /// 获取单个车辆的实时信息
        /// </summary>
        /// <param name="BusID">车牌号</param>
        /// <returns>车辆的实时信息</returns>
        public static BusRealInfo GetBusRealInfo(string BusID)
        {
            BusRealInfo BusReal = new BusRealInfo();




            return BusReal;
        }

        #endregion



    }

}
