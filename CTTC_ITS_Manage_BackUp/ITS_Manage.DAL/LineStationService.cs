using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using ITS_Manage.COMMON;
using ITS_Manage.Model;
using ITS_Manage.DAL.DBUtility;
using System.Data.SqlClient;
using GMap.NET;
using System.Text;

namespace ITS_Manage.DAL
{
    /// <summary>
    /// 数据访问类:lineStationService
    /// </summary>
    public class LineStationService
    {
        public LineStationService()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string stationID, string lineID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from lineStation");
            strSql.Append(" where stationID=@stationID and lineID=@lineID ");
            SqlParameter[] parameters = {
					new SqlParameter("@stationID", SqlDbType.NVarChar,20),
					new SqlParameter("@lineID", SqlDbType.NVarChar,20)			};
            parameters[0].Value = stationID;
            parameters[1].Value = lineID;

            return SQLHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ITS_Manage.Model.LineStation model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into lineStation(");
            strSql.Append("stationID,lineID,preStationID,nextStationID)");
            strSql.Append(" values (");
            strSql.Append("@stationID,@lineID,@preStationID,@nextStationID)");
            SqlParameter[] parameters = {
					new SqlParameter("@stationID", SqlDbType.NVarChar,20),
					new SqlParameter("@lineID", SqlDbType.NVarChar,20),
					new SqlParameter("@preStationID", SqlDbType.NVarChar,20),
					new SqlParameter("@nextStationID", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.stationID;
            parameters[1].Value = model.lineID;
            parameters[2].Value = model.preStationID;
            parameters[3].Value = model.nextStationID;

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
        public bool Update(ITS_Manage.Model.LineStation model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update lineStation set ");
            strSql.Append("preStationID=@preStationID,");
            strSql.Append("nextStationID=@nextStationID");
            strSql.Append(" where stationID=@stationID and lineID=@lineID ");
            SqlParameter[] parameters = {
					new SqlParameter("@preStationID", SqlDbType.NVarChar,20),
					new SqlParameter("@nextStationID", SqlDbType.NVarChar,20),
					new SqlParameter("@stationID", SqlDbType.NVarChar,20),
					new SqlParameter("@lineID", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.preStationID;
            parameters[1].Value = model.nextStationID;
            parameters[2].Value = model.stationID;
            parameters[3].Value = model.lineID;

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
        public bool Delete(string stationID, string lineID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from lineStation ");
            strSql.Append(" where stationID=@stationID and lineID=@lineID ");
            SqlParameter[] parameters = {
					new SqlParameter("@stationID", SqlDbType.NVarChar,20),
					new SqlParameter("@lineID", SqlDbType.NVarChar,20)			};
            parameters[0].Value = stationID;
            parameters[1].Value = lineID;

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
        /// 得到一个对象实体
        /// </summary>
        public ITS_Manage.Model.LineStation GetModel(string stationID, string lineID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 stationID,lineID,preStationID,nextStationID from lineStation ");
            strSql.Append(" where stationID=@stationID and lineID=@lineID ");
            SqlParameter[] parameters = {
					new SqlParameter("@stationID", SqlDbType.NVarChar,20),
					new SqlParameter("@lineID", SqlDbType.NVarChar,20)			};
            parameters[0].Value = stationID;
            parameters[1].Value = lineID;

            ITS_Manage.Model.LineStation model = new ITS_Manage.Model.LineStation();
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
        public ITS_Manage.Model.LineStation DataRowToModel(DataRow row)
        {
            ITS_Manage.Model.LineStation model = new ITS_Manage.Model.LineStation();
            if (row != null)
            {
                if (row["stationID"] != null)
                {
                    model.stationID = row["stationID"].ToString();
                }
                if (row["lineID"] != null)
                {
                    model.lineID = row["lineID"].ToString();
                }
                if (row["preStationID"] != null)
                {
                    model.preStationID = row["preStationID"].ToString();
                }
                if (row["nextStationID"] != null)
                {
                    model.nextStationID = row["nextStationID"].ToString();
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
            strSql.Append("select stationID,lineID,preStationID,nextStationID ");
            strSql.Append(" FROM lineStation ");
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
            strSql.Append(" stationID,lineID,preStationID,nextStationID ");
            strSql.Append(" FROM lineStation ");
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
            strSql.Append("select count(1) FROM lineStation ");
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
                strSql.Append("order by T.lineID desc");
            }
            strSql.Append(")AS Row, T.*  from lineStation T ");
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
            parameters[0].Value = "lineStation";
            parameters[1].Value = "lineID";
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
        /// 获取指定线路指定方向上的站点名数组
        /// </summary>
        /// <param name="LineID">线路</param>
        /// <param name="UpOrDown">方向</param>
        /// <returns>站点名数组</returns>
        public static string[] GetLineStationName(string LineID, Forward UpOrDown)
        {
            string forwardStr = string.Empty;
            string SqlStr = string.Empty;
            switch (UpOrDown)
            {
                case Forward.UP:
                    SqlStr = "select BusStop_ID From Line_BusStop where Line_ID = N'" + LineID + "' and LineStationSeqUp is not Null order by LineStationSeqUp asc";
                    break;
                case Forward.DOWN:
                    SqlStr = "select BusStop_ID From Line_BusStop where Line_ID = N'" + LineID + "' and LineStationSeqDown is not Null order by LineStationSeqDown asc";
                    break;
                default:
                    break;
            }
            DataTable dt = ITS_Manage.DAL.DBUtility.SQLHelper.Query(SqlStr).Tables["ds"];
            string[] StationName = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StationName[i] = dt.Rows[i][0].ToString();
            }
            return StationName;
        }
        /// <summary>
        /// 获取指定线路上指定方向的站点坐标
        /// </summary>
        /// <param name="LineID">线路</param>
        /// <param name="UpOrDown">方向</param>
        /// <returns>站点坐标数组</returns>
        public static PointLatLng[] GetLineStationLatLng(string LineID, Forward UpOrDown)
        {
            string UOD = string.Empty;
            string UODStation = string.Empty;
            switch (UpOrDown)
            {
                case Forward.UP:
                    UOD = "' and LineStationSeqUp is not null";
                    UODStation = "' and Line_BusStop.LineStationSeqUp is not null order by Line_BusStop.LineStationSeqUp asc";
                    break;
                case Forward.DOWN:
                    UOD = "' and LineStationSeqDown is not null";
                    UODStation = "' and Line_BusStop.LineStationSeqDown is not null order by Line_BusStop.LineStationSeqDown asc";
                    break;
                default:

                    break;
            }
            string SqlStr = "select count(BusStop_ID) From Line_BusStop where Line_ID = N'" + LineID + UOD;

            DataTable dt = SQLHelper.Query(SqlStr).Tables["ds"];
            int StationCount = Convert.ToInt16(dt.Rows[0][0].ToString());
            PointLatLng[] thePoint = new PointLatLng[StationCount];

            string SqlPoint = "select Lat,Lng,LineStationSeqUp from BusStop join Line_BusStop on BusStop.BusStop_id = Line_BusStop.BusStop_ID where Line_BusStop.Line_ID = N'" + LineID + UODStation;
            DataTable dtS = SQLHelper.Query(SqlPoint).Tables["ds"];

            for (int i = 0; i < dtS.Rows.Count; i++)
            {
                thePoint[i] = new PointLatLng(Convert.ToDouble(dtS.Rows[i][0].ToString()), Convert.ToDouble(dtS.Rows[i][1].ToString()));
            }
            return thePoint;

            //此处由于用到了MapOperation，致使DAL和Manage存在相互依赖，而使得DAL和Manage均无法生成，因此
            //日后考虑将其放入UI层中
            ///// <summary>
            ///// 获得线路距离列表
            ///// </summary>
            ///// <param name="Line"></param>
            ///// <param name="UpOrDown"></param>
            ///// <returns></returns>
            //public int[] GetLineStationDistance(ITS_Manage.Model.LineStationInfo Line, Forward UpOrDown)
            //{
            //    int[] Distances;
            //    switch (UpOrDown)
            //    {
            //        case Forward.UP:
            //            Distances = MapOperation.GetDistanceArray(Line.StationLatLngUp).UpDistance;
            //            break;
            //        case Forward.DOWN:
            //            Distances = MapOperation.GetDistanceArray(Line.StationLatLngDown).DownDistance;
            //            break;
            //        default:
            //            return null;

            //    }
            //    return Distances;
            //}
        }
        #endregion  ExtensionMethod

    }
}
