using System;
namespace ITS_Manage.Model
{
    /// <summary>
    /// statistics:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Statistics
    {
        public Statistics()
        { }
        #region Model
        private string _lineid;
        private int? _busnumber;
        private int? _traffic;
        /// <summary>
        /// 
        /// </summary>
        public string lineID
        {
            set { _lineid = value; }
            get { return _lineid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? busNumber
        {
            set { _busnumber = value; }
            get { return _busnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? traffic
        {
            set { _traffic = value; }
            get { return _traffic; }
        }
        #endregion Model

    }
}

