using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITS_Manage.Model
{
    /// <summary>
    /// line:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public  class Line
    {
        public Line()
        { }
        #region Model
        private string _lineid;
        private string _linename;
        private float? _linelength;
        private string _startstation;
        private string _endstation;
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
        public string lineName
        {
            set { _linename = value; }
            get { return _linename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public float? lineLength
        {
            set { _linelength = value; }
            get { return _linelength; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string startStation
        {
            set { _startstation = value; }
            get { return _startstation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string endStation
        {
            set { _endstation = value; }
            get { return _endstation; }
        }
        #endregion Model

    }
}
