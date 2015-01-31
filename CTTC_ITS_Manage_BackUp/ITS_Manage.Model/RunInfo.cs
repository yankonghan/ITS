using System;
namespace ITS_Manage.Model
{
    /// <summary>
    /// runInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class RunInfo
    {
        public RunInfo()
        { }
        #region Model
        private string _busid;
        private decimal? _oilremain;
        private decimal? _speed;
        private decimal? _lat;
        private decimal? _lng;
        private int? _passengernumber;
        private string _nextstationid;
        private bool _isalarm;
        private bool _isdeviate;
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
        public decimal? oilRemain
        {
            set { _oilremain = value; }
            get { return _oilremain; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? speed
        {
            set { _speed = value; }
            get { return _speed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? lat
        {
            set { _lat = value; }
            get { return _lat; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? lng
        {
            set { _lng = value; }
            get { return _lng; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? passengerNumber
        {
            set { _passengernumber = value; }
            get { return _passengernumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string nextStationID
        {
            set { _nextstationid = value; }
            get { return _nextstationid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool isAlarm
        {
            set { _isalarm = value; }
            get { return _isalarm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool isDeviate
        {
            set { _isdeviate = value; }
            get { return _isdeviate; }
        }
        #endregion Model

    }
}
