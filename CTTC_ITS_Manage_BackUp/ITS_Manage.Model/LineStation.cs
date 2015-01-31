using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMap.NET;

namespace ITS_Manage.Model
{

     /// <summary>
	/// lineStation:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class LineStation
	{
		public LineStation()
		{}
		#region Model
		private string _stationid;
		private string _lineid;
		private string _prestationid;
		private string _nextstationid;
		/// <summary>
		/// 
		/// </summary>
		public string stationID
		{
			set{ _stationid=value;}
			get{return _stationid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string lineID
		{
			set{ _lineid=value;}
			get{return _lineid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string preStationID
		{
			set{ _prestationid=value;}
			get{return _prestationid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string nextStationID
		{
			set{ _nextstationid=value;}
			get{return _nextstationid;}
		}
		#endregion Model


        #region  附加的字段，并不存在于数据库中
        private string[] upStationName;
        public string[] UpStationName
        {
            get
            {
                return this.upStationName;
            }
            set
            {
                this.upStationName = value;
            }
        }
        private string[] downStationName;
        public string[] DownStationName
        {
            get
            {
                return this.downStationName;
            }
            set
            {
                this.downStationName = value;
            }
        }
        private int[] upDistance;
        public int[] UpDistance
        {
            get
            {
                return this.upDistance;
            }
            set
            {
                this.upDistance = value;
            }
        }
        private int[] downDistance;
        public int[] DownDistance
        {
            get
            {
                return this.downDistance;
            }
            set
            {
                this.downDistance = value;
            }
        }
        private PointLatLng[] stationLatLngUp;
        public PointLatLng[] StationLatLngUp
        {
            get
            {
                return this.stationLatLngUp;
            }
            set
            {
                this.stationLatLngUp = value;
            }
        }
        private PointLatLng[] stationLatLngDown;
        public PointLatLng[] StationLatLngDown
        {
            get
            {
                return this.stationLatLngDown;
            }
            set
            {
                this.stationLatLngDown = value;
            }
        }
        #endregion

        //原有的代码

        //public LineStation(string[] theUpStationName, string[] theDownStationName, int[] theUpDistance, int[] theDownDistance, string theLineID)
        //{
        //    this.UpDistance = theUpDistance;
        //    this.DownDistance = theDownDistance;
        //    this.LineID = theLineID;
        //    this.UpStationName = theUpStationName;
        //    this.DownStationName = theDownStationName;
        //}
    }
}
