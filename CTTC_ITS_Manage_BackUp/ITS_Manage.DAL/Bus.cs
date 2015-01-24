using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data;
using ITS_Manage.Model;
using ITS_Manage.DAL.DBUtility;

namespace ITS_Manage.DAL
{
    public partial class Bus
    {
    
        /*一切的构造函数都并不需要！都以Model传参即可！
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="theBusID">公交车牌号</param>
        /// <param name="theDriver">司机</param>
        /// <param name="theLine">线路</param>
        /// <param name="theInfo"></param>
        public BusService(string theBusID, Person theDriver, Line theLine, BusRealInfo theInfo)
        {
            this.busID = theBusID;
            this.driverName = theDriver.Name;
            this.forward = theInfo.Forward;
            this.speed = theInfo.Speed;
            this.lineName = theLine.LineName;
            this.lat = theInfo.Lat;
            this.lng = theInfo.Lng;
            this.isOnline = true;
            this.isAlarm = theInfo.IsAlarm;
            this.oilRemain = theInfo.OilRemain;
        }
            * */


     
        /// <summary>
        /// 精确查找person表
        /// </summary>
        /// <param name="thePerson">查询条件</param>
        /// <returns>person的list</returns>
        public static DataTable SelectBusInfo(Model.Bus theBus)
        {
            DataTable BusDataTable = null;

            try
            {
                string strSql = "SELECT * FROM Bus where Bus_id = '" + theBus.BusID + "'";
                BusDataTable = SQLHelper.Query(strSql).Tables["ds"];
                return BusDataTable;
            }
            catch (Exception ex)//log
            {
                MessageBox.Show("查询失败，请核对查询条件！");
                return null;
            }
        }
        /// <summary>
        /// 查找Bus表，返回全部车辆信息
        /// </summary>
        /// <returns>Bus的DataTable</returns>
        public static DataTable SelectBusInfo()
        {
            DataTable BusDataTable = null;

            try
            {
                string strSql = "SELECT Bus_ID, IsRun FROM Bus";
                BusDataTable = SQLHelper.Query(strSql).Tables["ds"];
                return BusDataTable;
            }
            catch (Exception ex)//log
            {
                MessageBox.Show("加载公交信息失败，请检查数据库或与系统管理员联系！");
                return null;
            }
        }
        /// <summary>
        /// 查找Bus表，返回全部车辆信息List列表
        /// </summary>
        /// <returns>Bus的List</returns>
        public static List<ITS_Manage.Model.Bus> SelectBuslist()
        {
            DataTable BusDataTable = null;
            List<ITS_Manage.Model.Bus> Buslist = null;
            try
            {
                string strSql = "SELECT * FROM Bus";
                BusDataTable = SQLHelper.Query(strSql).Tables["ds"];
                for (int i = 0; i < BusDataTable.Rows.Count; i++)
                {
                    ITS_Manage.Model.Bus temp = new ITS_Manage.Model.Bus(BusDataTable.Rows[i][0].ToString(), Convert.ToBoolean(Convert.ToInt16(BusDataTable.Rows[i][5].ToString())));
                    Buslist.Add(temp);
                }
                return Buslist;
            }
            catch (Exception ex)//log
            {
                MessageBox.Show("加载公交信息失败，请检查数据库或与系统管理员联系！");
                return null;
            }
        }
        /// <summary>
        /// 查找Bus表，返回全部车辆信息的数组
        /// </summary>
        /// <returns>Bus的数组</returns>
        public static ITS_Manage.Model.Bus[] SelectBusArray(string ChargeLineID)
        {
            
            DataTable BusDataTable = null;
            ITS_Manage.Model.Bus[] BuslArray;
            try
            {
                string strSql = "SELECT * FROM Bus where ChargeLine_id = '" + ChargeLineID + "' order by isOnline desc";
                BusDataTable = SQLHelper.Query(strSql).Tables["ds"];
                BuslArray = new ITS_Manage.Model.Bus[BusDataTable.Rows.Count];

                for (int i = 0; i < BusDataTable.Rows.Count; i++)
                {
                    BuslArray[i] = new ITS_Manage.Model.Bus(BusDataTable.Rows[i][0].ToString(), Convert.ToBoolean(Convert.ToInt16(BusDataTable.Rows[i][5].ToString())));
                }
                return BuslArray;
            }
            catch (Exception ex)//log
            {
                MessageBox.Show("加载公交信息失败，请检查数据库或与系统管理员联系！");
                return null;
            }
        }
    


        //public static Bus GetBusRealInfo(string BusID)
        //{
        //    //在线判断
        //    Bus BusRealInfo = new Bus();
        //    DataTable BusDataTable = null;
        //    Bus[] BuslArray;
        //    try
        //    {
        //        string strSql = "SELECT * FROM Bus where ChargeLine_id = '" + BusID + "' order by isOnline desc";
        //        BusDataTable = SQLHelper.Query(strSql).Tables["ds"];
        //        BuslArray = new Bus[BusDataTable.Rows.Count];

        //        for (int i = 0; i < BusDataTable.Rows.Count; i++)
        //        {
        //            BuslArray[i] = new Bus(BusDataTable.Rows[i][0].ToString(), Convert.ToBoolean(Convert.ToInt16(BusDataTable.Rows[i][5].ToString())));
        //        }
        //        return RealInfo;
        //    }
        //    catch (Exception ex)//log
        //    {
        //        MessageBox.Show("加载公交信息失败，请检查数据库或与系统管理员联系！");
        //        return null;
        //    }
        //    return RealInfo;
        //}
    }
   
     
}
