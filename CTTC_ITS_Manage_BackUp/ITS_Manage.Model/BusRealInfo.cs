using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITS_Manage.COMMON;
using System.Threading.Tasks;

namespace ITS_Manage.Model
{
    [Serializable]
    public partial class BusRealInfo
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
        /// 司机
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
        /// 行车方向
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
        /// 速度
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
        /// 是否报警
        /// </summary>
        private bool isAlarm;

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

    }
}
