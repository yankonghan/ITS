using System;
namespace ITS_Manage.Model
{
    /// <summary>
    /// busTime:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class BusTime
    {
        public BusTime()
        { }
        #region Model
        private string _busid;
        private string _stationid;
        private DateTime? _arrivetime;
        private DateTime? _starttime;
        /// <summary>
        /// 
        /// </summary>
        public string busID
        {
            set { _busid = value; }
            get { return _busid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string stationID
        {
            set { _stationid = value; }
            get { return _stationid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? arriveTime
        {
            set { _arrivetime = value; }
            get { return _arrivetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? startTime
        {
            set { _starttime = value; }
            get { return _starttime; }
        }
        #endregion Model

    }
}
