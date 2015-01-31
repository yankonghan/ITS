using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS_Manage.Model
{
    /// <summary>
    /// driver:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Driver
    {
        public Driver()
        { }
        #region Model
        private string _driverid;
        private string _drivername;
        private string _busid;
        private bool _sex;
        private int? _age;
        /// <summary>
        /// 
        /// </summary>
        public string driverID
        {
            set { _driverid = value; }
            get { return _driverid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string driverName
        {
            set { _drivername = value; }
            get { return _drivername; }
        }
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
        public bool sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? age
        {
            set { _age = value; }
            get { return _age; }
        }
        #endregion Model

    }
}
