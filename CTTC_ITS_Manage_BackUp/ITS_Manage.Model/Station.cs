using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS_Manage.Model
{
    [Serializable]
    public partial class Station
    {
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
                stationName = value;
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
        public Station() 
        {

        }
         #region 一个含三个参数的构造函数，为了配合DAL.Station中的SelectStationArray和SelectStationLineArray
        /*存在的问题：
         * 感觉不太好。。
         * */
        public Station(string theStationID, string theStationName, bool theIsOnline)
        {
            Station stationInstance = new Station();
            stationInstance.StationID = theStationID;
            stationInstance.StationName = theStationName;
            stationInstance.IsOnline = theIsOnline;
        }
        #endregion
    }
}
