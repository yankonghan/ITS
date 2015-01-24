using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITS_Manage.COMMON;
using System.Threading.Tasks;

namespace ITS_Manage.Model
{
    [Serializable]
    public partial class Bus
    {
        /// <summary>
        /// 车牌号
        /// </summary>
        private string busID;

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

        public bool IsRun
        {
            set
            {
                IsRun = value;
            }
            get
            {
                return IsRun;
            }
        }
        public Bus()
        {

        }
        //此处可以进行Model的构造，为了配合DAL.Bus中的SelectBusList方法。
        public Bus(string theBusID, bool theIsOnline)
        {
            // TODO: Complete member initialization
            Bus busInstance = new Bus();
            busInstance.BusID = theBusID;
            busInstance.IsOnline = theIsOnline;
        }
       
    }
}
