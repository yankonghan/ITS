using System;
namespace ITS_Manage.Model
{
    /// <summary>
    /// station:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Station
    {
       public Station()
		{}
		#region Model
		private string _stationid;
		private string _stationname;
		private decimal? _lat;
		private decimal? _lng;
		private bool _isonline;
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
		public string stationName
		{
			set{ _stationname=value;}
			get{return _stationname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? lat
		{
			set{ _lat=value;}
			get{return _lat;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? lng
		{
			set{ _lng=value;}
			get{return _lng;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool isOnline
		{
			set{ _isonline=value;}
			get{return _isonline;}
		}
		#endregion Model

        /*原有的代码
         * */
        

        // #region 一个含三个参数的构造函数，为了配合DAL.Station中的SelectStationArray和SelectStationLineArray
        ///*存在的问题：
        // * 感觉不太好。。
        // * */
        //public Station(string theStationID, string theStationName, bool theIsOnline)
        //{
        //    Station stationInstance = new Station();
        //    stationInstance.StationID = theStationID;
        //    stationInstance.StationName = theStationName;
        //    stationInstance.IsOnline = theIsOnline;
        //}
        //#endregion

    }
}
    
