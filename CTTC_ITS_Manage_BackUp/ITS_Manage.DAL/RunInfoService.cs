using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ITS_Manage.Model;
using ITS_Manage.DAL.DBUtility;
using ITS_Manage.COMMON;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ITS_Manage.DAL
{/// <summary>
    /// 数据访问类:RunInfoService
    /// </summary>
    public class RunInfoService
    {
        public RunInfoService()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string busID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from runInfo");
            strSql.Append(" where busID=@busID ");
            SqlParameter[] parameters = {
					new SqlParameter("@busID", SqlDbType.NVarChar,20)			};
            parameters[0].Value = busID;

            return SQLHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ITS_Manage.Model.RunInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into runInfo(");
            strSql.Append("busID,oilRemain,speed,lat,lng,passengerNumber,nextStationID,isAlarm,isDeviate)");
            strSql.Append(" values (");
            strSql.Append("@busID,@oilRemain,@speed,@lat,@lng,@passengerNumber,@nextStationID,@isAlarm,@isDeviate)");
            SqlParameter[] parameters = {
					new SqlParameter("@busID", SqlDbType.NVarChar,20),
					new SqlParameter("@oilRemain", SqlDbType.Decimal,9),
					new SqlParameter("@speed", SqlDbType.Decimal,9),
					new SqlParameter("@lat", SqlDbType.Decimal,9),
					new SqlParameter("@lng", SqlDbType.Decimal,9),
					new SqlParameter("@passengerNumber", SqlDbType.SmallInt,2),
					new SqlParameter("@nextStationID", SqlDbType.NVarChar,20),
					new SqlParameter("@isAlarm", SqlDbType.Bit,1),
					new SqlParameter("@isDeviate", SqlDbType.Bit,1)};
            parameters[0].Value = model.busID;
            parameters[1].Value = model.oilRemain;
            parameters[2].Value = model.speed;
            parameters[3].Value = model.lat;
            parameters[4].Value = model.lng;
            parameters[5].Value = model.passengerNumber;
            parameters[6].Value = model.nextStationID;
            parameters[7].Value = model.isAlarm;
            parameters[8].Value = model.isDeviate;

            int rows = SQLHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ITS_Manage.Model.RunInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update runInfo set ");
            strSql.Append("oilRemain=@oilRemain,");
            strSql.Append("speed=@speed,");
            strSql.Append("lat=@lat,");
            strSql.Append("lng=@lng,");
            strSql.Append("passengerNumber=@passengerNumber,");
            strSql.Append("nextStationID=@nextStationID,");
            strSql.Append("isAlarm=@isAlarm,");
            strSql.Append("isDeviate=@isDeviate");
            strSql.Append(" where busID=@busID ");
            SqlParameter[] parameters = {
					new SqlParameter("@oilRemain", SqlDbType.Decimal,9),
					new SqlParameter("@speed", SqlDbType.Decimal,9),
					new SqlParameter("@lat", SqlDbType.Decimal,9),
					new SqlParameter("@lng", SqlDbType.Decimal,9),
					new SqlParameter("@passengerNumber", SqlDbType.SmallInt,2),
					new SqlParameter("@nextStationID", SqlDbType.NVarChar,20),
					new SqlParameter("@isAlarm", SqlDbType.Bit,1),
					new SqlParameter("@isDeviate", SqlDbType.Bit,1),
					new SqlParameter("@busID", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.oilRemain;
            parameters[1].Value = model.speed;
            parameters[2].Value = model.lat;
            parameters[3].Value = model.lng;
            parameters[4].Value = model.passengerNumber;
            parameters[5].Value = model.nextStationID;
            parameters[6].Value = model.isAlarm;
            parameters[7].Value = model.isDeviate;
            parameters[8].Value = model.busID;

            int rows = SQLHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string busID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from runInfo ");
            strSql.Append(" where busID=@busID ");
            SqlParameter[] parameters = {
					new SqlParameter("@busID", SqlDbType.NVarChar,20)			};
            parameters[0].Value = busID;

            int rows = SQLHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string busIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from runInfo ");
            strSql.Append(" where busID in (" + busIDlist + ")  ");
            int rows = SQLHelper.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ITS_Manage.Model.RunInfo GetModel(string busID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 busID,oilRemain,speed,lat,lng,passengerNumber,nextStationID,isAlarm,isDeviate from runInfo ");
            strSql.Append(" where busID=@busID ");
            SqlParameter[] parameters = {
					new SqlParameter("@busID", SqlDbType.NVarChar,20)			};
            parameters[0].Value = busID;

            ITS_Manage.Model.RunInfo model = new ITS_Manage.Model.RunInfo();
            DataSet ds = SQLHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ITS_Manage.Model.RunInfo DataRowToModel(DataRow row)
        {
            ITS_Manage.Model.RunInfo model = new ITS_Manage.Model.RunInfo();
            if (row != null)
            {
                if (row["busID"] != null)
                {
                    model.busID = row["busID"].ToString();
                }
                if (row["oilRemain"] != null && row["oilRemain"].ToString() != "")
                {
                    model.oilRemain = decimal.Parse(row["oilRemain"].ToString());
                }
                if (row["speed"] != null && row["speed"].ToString() != "")
                {
                    model.speed = decimal.Parse(row["speed"].ToString());
                }
                if (row["lat"] != null && row["lat"].ToString() != "")
                {
                    model.lat = decimal.Parse(row["lat"].ToString());
                }
                if (row["lng"] != null && row["lng"].ToString() != "")
                {
                    model.lng = decimal.Parse(row["lng"].ToString());
                }
                if (row["passengerNumber"] != null && row["passengerNumber"].ToString() != "")
                {
                    model.passengerNumber = int.Parse(row["passengerNumber"].ToString());
                }
                if (row["nextStationID"] != null)
                {
                    model.nextStationID = row["nextStationID"].ToString();
                }
                if (row["isAlarm"] != null && row["isAlarm"].ToString() != "")
                {
                    if ((row["isAlarm"].ToString() == "1") || (row["isAlarm"].ToString().ToLower() == "true"))
                    {
                        model.isAlarm = true;
                    }
                    else
                    {
                        model.isAlarm = false;
                    }
                }
                if (row["isDeviate"] != null && row["isDeviate"].ToString() != "")
                {
                    if ((row["isDeviate"].ToString() == "1") || (row["isDeviate"].ToString().ToLower() == "true"))
                    {
                        model.isDeviate = true;
                    }
                    else
                    {
                        model.isDeviate = false;
                    }
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select busID,oilRemain,speed,lat,lng,passengerNumber,nextStationID,isAlarm,isDeviate ");
            strSql.Append(" FROM runInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SQLHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" busID,oilRemain,speed,lat,lng,passengerNumber,nextStationID,isAlarm,isDeviate ");
            strSql.Append(" FROM runInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SQLHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM runInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = SQLHelper.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.busID desc");
            }
            strSql.Append(")AS Row, T.*  from runInfo T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return SQLHelper.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "runInfo";
            parameters[1].Value = "busID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return SQLHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        /*需要修改
         * 
         * */
        /// <summary>
        /// 获取指定线路的车辆实时信息列表
        /// </summary>
        /// <param name="lineID">线路号</param>
        /// <returns>车辆实时信息列表</returns>

        public static List<Model.RunInfo> GetRunInfoList(string lineID)
        {
            List<Model.RunInfo> RunInfoList = new List<Model.RunInfo>();
            string sqlstr = null;
          
            /*此为旧版本的sqlstr，需修改 
             * */
            
            //string sqlstr = "select * from (select a.* ,q.personName from Bus_RealTime as a join Bus as b on a.Bus_ID = b.Bus_id join Person as q on a.Driver_ID = q.personID where b.ChargeLine_id = N'" +
            //    lineID + "') as t where EXISTS (select Bus_ID, max(RealTime) as e from Bus_RealTime group by Bus_ID having t.Bus_ID = Bus_ID and t.RealTime =max(RealTime))";
            DataTable dt = SQLHelper.Query(sqlstr).Tables["ds"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Model.RunInfo busReal = new Model.RunInfo();
                busReal.busID = dt.Rows[i][0].ToString();
                busReal.oilRemain = Convert.ToDecimal(dt.Rows[i][1].ToString());
                busReal.speed = Convert.ToDecimal(dt.Rows[i][2].ToString());
                busReal.lat = Convert.ToDecimal(dt.Rows[i][3].ToString());
                busReal.lng = Convert.ToDecimal(dt.Rows[i][4].ToString());
                busReal.passengerNumber = Convert.ToInt16(dt.Rows[i][5].ToString());
                busReal.nextStationID = dt.Rows[i][6].ToString();      
                
                switch (dt.Rows[i][7].ToString())
                {
                    case "0":
                        busReal.isAlarm = false;
                        break;
                    case "1":
                        busReal.isAlarm = true;
                        break;
                    default:
                        break;
                }
                busReal.isDeviate = Convert.ToBoolean(dt.Rows[i][8]);    
                //以后决定是否在该方法中添加驾驶员名字 
                //busReal.DriverName = dt.Rows[i][10].ToString();        
                RunInfoList.Add(busReal);
            }

            return RunInfoList;
        }
        ///// <summary>
        ///// 获取单个车辆的实时信息
        ///// </summary>
        ///// <param name="BusID">车牌号</param>
        ///// <returns>车辆的实时信息</returns>
        //public static RunInfo GetRunInfo (string BusID)
        //{
        //    RunInfo BusReal = new RunInfo();

        //    return BusReal;
        //}
        #endregion  ExtensionMethod
    }


}
