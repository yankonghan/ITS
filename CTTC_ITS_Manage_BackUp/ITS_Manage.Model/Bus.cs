using System;
namespace ITS_Manage.Model
{
    /// <summary>
    /// bus:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Bus
    {
        public Bus()
        { }
        #region Model
        private string _busid;
        private string _lineid;
        private int? _state;  //-1,0,1代表三种状态
        private bool _isonline;
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
        public string lineID
        {
            set { _lineid = value; }
            get { return _lineid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? state
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool isOnline
        {
            set { _isonline = value; }
            get { return _isonline; }
        }
        #endregion Model



        /*原有的代码
         * */

        //此处可以进行Model的构造，为了配合DAL.Bus中的SelectBusList等方法。
        public Bus(string theBusID, bool theIsOnline)
        {
            // TODO: Complete member initialization
            Bus busInstance = new Bus();
            busInstance.busID = theBusID;
            busInstance.isOnline = theIsOnline;
        }

    }
}



