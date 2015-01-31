using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using ITS_Manage.Model;
using ITS_Manage.DAL;
using System.Data.SqlClient;
using ITS_Manage.DAL.DBUtility;
using ITS_Manage.COMMON;
using System.Threading.Tasks;

namespace ITS_Manage.DAL
{
    /// <summary>
    /// 数据访问类:stationService
    /// </summary>
    public  class StationService
    {
        public StationService()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string stationID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from station");
            strSql.Append(" where stationID=@stationID ");
            SqlParameter[] parameters = {
					new SqlParameter("@stationID", SqlDbType.NVarChar,20)			};
            parameters[0].Value = stationID;

            return SQLHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ITS_Manage.Model.Station model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into station(");
            strSql.Append("stationID,stationName,lat,lng)");
            strSql.Append(" values (");
            strSql.Append("@stationID,@stationName,@lat,@lng)");
            SqlParameter[] parameters = {
					new SqlParameter("@stationID", SqlDbType.NVarChar,20),
					new SqlParameter("@stationName", SqlDbType.NVarChar,20),
					new SqlParameter("@lat", SqlDbType.Decimal,9),
					new SqlParameter("@lng", SqlDbType.Decimal,9)};
            parameters[0].Value = model.stationID;
            parameters[1].Value = model.stationName;
            parameters[2].Value = model.lat;
            parameters[3].Value = model.lng;

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
        public bool Update(ITS_Manage.Model.Station model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update station set ");
            strSql.Append("stationName=@stationName,");
            strSql.Append("lat=@lat,");
            strSql.Append("lng=@lng");
            strSql.Append(" where stationID=@stationID ");
            SqlParameter[] parameters = {
					new SqlParameter("@stationName", SqlDbType.NVarChar,20),
					new SqlParameter("@lat", SqlDbType.Decimal,9),
					new SqlParameter("@lng", SqlDbType.Decimal,9),
					new SqlParameter("@stationID", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.stationName;
            parameters[1].Value = model.lat;
            parameters[2].Value = model.lng;
            parameters[3].Value = model.stationID;

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
        public bool Delete(string stationID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from station ");
            strSql.Append(" where stationID=@stationID ");
            SqlParameter[] parameters = {
					new SqlParameter("@stationID", SqlDbType.NVarChar,20)			};
            parameters[0].Value = stationID;

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
        public bool DeleteList(string stationIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from station ");
            strSql.Append(" where stationID in (" + stationIDlist + ")  ");
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
        public ITS_Manage.Model.Station GetModel(string stationID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 stationID,stationName,lat,lng from station ");
            strSql.Append(" where stationID=@stationID ");
            SqlParameter[] parameters = {
					new SqlParameter("@stationID", SqlDbType.NVarChar,20)			};
            parameters[0].Value = stationID;

           ITS_Manage.Model.Station model = new ITS_Manage.Model.Station();
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
        public ITS_Manage.Model.Station DataRowToModel(DataRow row)
        {
            ITS_Manage.Model.Station model = new ITS_Manage.Model.Station();
            if (row != null)
            {
                if (row["stationID"] != null)
                {
                    model.stationID = row["stationID"].ToString();
                }
                if (row["stationName"] != null)
                {
                    model.stationName = row["stationName"].ToString();
                }
                if (row["lat"] != null && row["lat"].ToString() != "")
                {
                    model.lat = decimal.Parse(row["lat"].ToString());
                }
                if (row["lng"] != null && row["lng"].ToString() != "")
                {
                    model.lng = decimal.Parse(row["lng"].ToString());
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
            strSql.Append("select stationID,stationName,lat,lng ");
            strSql.Append(" FROM station ");
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
            strSql.Append(" stationID,stationName,lat,lng ");
            strSql.Append(" FROM station ");
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
            strSql.Append("select count(1) FROM station ");
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
                strSql.Append("order by T.stationID desc");
            }
            strSql.Append(")AS Row, T.*  from station T ");
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
            parameters[0].Value = "station";
            parameters[1].Value = "stationID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return SQLHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

            /// <summary>
            /// 查找Station表，返回全部车辆信息的数组
            /// </summary>
            /// <returns>Station的数组</returns>
            public static ITS_Manage.Model.Station[] SelectStationArray()
            {

                DataTable StationDataTable = null;
                ITS_Manage.Model.Station[] StationArray;
                try
                {
                    string strSql = "SELECT * FROM BusStop order by IsOnline desc";
                    StationDataTable = SQLHelper.Query(strSql).Tables["ds"];
                    StationArray = new ITS_Manage.Model.Station[StationDataTable.Rows.Count];

                    for (int i = 0; i < StationDataTable.Rows.Count; i++)
                    {
                        //需要修改
                        //StationArray[i] = new ITS_Manage.Model.Station(StationDataTable.Rows[i][0].ToString(), StationDataTable.Rows[i][1].ToString(), Convert.ToBoolean(Convert.ToInt16(StationDataTable.Rows[i][3].ToString())));
                    }
                    return StationArray;
                }
                catch (Exception ex)//log
                {
                    MessageBox.Show("加载公交信息失败，请检查数据库或与系统管理员联系！");
                    return null;
                }
            }
            /// <summary>
            /// 查找Station表，返回全部车辆信息的数组
            /// </summary>
            /// <returns>Station的数组</returns>
            public static ITS_Manage.Model.Station[] SelectStationLineArray(string LineID)
            {

                DataTable StationDataTable = null;
                ITS_Manage.Model.Station[] StationlArray;
                try
                {
                    string strSql = "SELECT Line_BusStop.Line_ID, BusStop.BusStop_ID, BusStop.BusStop_Name, BusStop.IsOnline, Line_BusStop.LineStationSeqUp from Line_BusStop join BusStop on Line_BusStop.BusStop_ID = BusStop.BusStop_ID where Line_ID = N'" + LineID + "' order by Line_BusStop.LineStationSeqUp asc";
                    StationDataTable = SQLHelper.Query(strSql).Tables["ds"];
                    StationlArray = new ITS_Manage.Model.Station[StationDataTable.Rows.Count];

                    for (int i = 0; i < StationDataTable.Rows.Count; i++)
                    {
                        //需要修改

                        //StationlArray[i] = new ITS_Manage.Model.Station(StationDataTable.Rows[i][1].ToString(), StationDataTable.Rows[i][2].ToString(), Convert.ToBoolean(Convert.ToInt16(StationDataTable.Rows[i][3].ToString())));
                    }
                    return StationlArray;
                }
                catch (Exception ex)//log
                {
                    MessageBox.Show("加载站点信息失败，请检查数据库或与系统管理员联系！");
                    return null;
                }
            }
        }
        #endregion  ExtensionMethod


    
}
