using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ITS_Manage.Model;
using ITS_Manage.DAL.DBUtility;
using ITS_Manage.COMMON;
using System.Threading.Tasks;

namespace ITS_Manage.DAL
{
    public partial class BusRealInfo
    {
          public BusRealInfo()
        {

        }
      /* 此处应为多余！ 
       * public BusRealInfoService(Forward theForward, double speed, double Lat, double Lng, bool IsAlarm)
        {
            this.forward = theForward;
        }
       * */

        /// <summary>
        /// 获取指定线路的车辆实时信息列表
        /// </summary>
        /// <param name="lineID">线路号</param>
        /// <returns>车辆实时信息列表</returns>
        
        public static List<Model.BusRealInfo> GetBusRealInfoList(string lineID)
        {
            List<Model.BusRealInfo> BusRealList = new List<Model.BusRealInfo>();
            string sqlstr = "select * from (select a.* ,q.personName from Bus_RealTime as a join Bus as b on a.Bus_ID = b.Bus_id join Person as q on a.Driver_ID = q.personID where b.ChargeLine_id = N'" +
                lineID + "') as t where EXISTS (select Bus_ID, max(RealTime) as e from Bus_RealTime group by Bus_ID having t.Bus_ID = Bus_ID and t.RealTime =max(RealTime))";
            DataTable dt = SQLHelper.Query(sqlstr).Tables["ds"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Model.BusRealInfo busReal = new Model.BusRealInfo();
                busReal.BusID = dt.Rows[i][0].ToString();
                busReal.RealTime = Convert.ToDateTime(dt.Rows[i][1].ToString());
                busReal.Speed = Convert.ToDouble(dt.Rows[i][2].ToString());
                busReal.PeopleNum = Convert.ToInt16(dt.Rows[i][3].ToString());
                busReal.Lat = Convert.ToDouble(dt.Rows[i][4].ToString());
                busReal.Lng = Convert.ToDouble(dt.Rows[i][5].ToString());
                busReal.OilRemain = Convert.ToDouble(dt.Rows[i][6].ToString());
                switch (dt.Rows[i][7].ToString())
                {
                    case "0":
                        busReal.IsAlarm = false;
                        break;
                    case "1":
                        busReal.IsAlarm = true;
                        break;
                    default:
                        break;
                }
                busReal.DriverName = dt.Rows[i][10].ToString();
                switch (dt.Rows[i][9].ToString().ToUpper())
                {
                    case "UP":
                        busReal.Forward = Forward.UP;
                        break;
                    case "DOWN":
                        busReal.Forward = Forward.DOWN;
                        break;
                    default:
                        break;
                }
                BusRealList.Add(busReal);
            }
       
        return BusRealList;
        }
        /// <summary>
        /// 获取单个车辆的实时信息
        /// </summary>
        /// <param name="BusID">车牌号</param>
        /// <returns>车辆的实时信息</returns>
        public static BusRealInfo GetBusRealInfo (string BusID)
        {
            BusRealInfo BusReal = new BusRealInfo();

            return BusReal;
        }
    }
}
