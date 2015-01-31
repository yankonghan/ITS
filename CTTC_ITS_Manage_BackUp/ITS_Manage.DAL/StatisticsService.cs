using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ITS_Manage.Model;
using ITS_Manage.DAL.DBUtility;//Please add references
namespace ITS_Manage.DAL
{
    /// <summary>
    /// 数据访问类:statisticsService
    /// </summary>
    public class StatisticsService
    {
        public StatisticsService()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string lineID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from statistics");
            strSql.Append(" where lineID=@lineID ");
            SqlParameter[] parameters = {
					new SqlParameter("@lineID", SqlDbType.NVarChar,20)			};
            parameters[0].Value = lineID;

            return SQLHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ITS_Manage.Model.Statistics model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into statistics(");
            strSql.Append("lineID,busNumber,traffic)");
            strSql.Append(" values (");
            strSql.Append("@lineID,@busNumber,@traffic)");
            SqlParameter[] parameters = {
					new SqlParameter("@lineID", SqlDbType.NVarChar,20),
					new SqlParameter("@busNumber", SqlDbType.SmallInt,2),
					new SqlParameter("@traffic", SqlDbType.SmallInt,2)};
            parameters[0].Value = model.lineID;
            parameters[1].Value = model.busNumber;
            parameters[2].Value = model.traffic;

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
        public bool Update(ITS_Manage.Model.Statistics model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update statistics set ");
            strSql.Append("busNumber=@busNumber,");
            strSql.Append("traffic=@traffic");
            strSql.Append(" where lineID=@lineID ");
            SqlParameter[] parameters = {
					new SqlParameter("@busNumber", SqlDbType.SmallInt,2),
					new SqlParameter("@traffic", SqlDbType.SmallInt,2),
					new SqlParameter("@lineID", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.busNumber;
            parameters[1].Value = model.traffic;
            parameters[2].Value = model.lineID;

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
        public bool Delete(string lineID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from statistics ");
            strSql.Append(" where lineID=@lineID ");
            SqlParameter[] parameters = {
					new SqlParameter("@lineID", SqlDbType.NVarChar,20)			};
            parameters[0].Value = lineID;

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
        public bool DeleteList(string lineIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from statistics ");
            strSql.Append(" where lineID in (" + lineIDlist + ")  ");
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
        public ITS_Manage.Model.Statistics GetModel(string lineID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 lineID,busNumber,traffic from statistics ");
            strSql.Append(" where lineID=@lineID ");
            SqlParameter[] parameters = {
					new SqlParameter("@lineID", SqlDbType.NVarChar,20)			};
            parameters[0].Value = lineID;

            ITS_Manage.Model.Statistics model = new ITS_Manage.Model.Statistics();
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
        public ITS_Manage.Model.Statistics DataRowToModel(DataRow row)
        {
            ITS_Manage.Model.Statistics model = new ITS_Manage.Model.Statistics();
            if (row != null)
            {
                if (row["lineID"] != null)
                {
                    model.lineID = row["lineID"].ToString();
                }
                if (row["busNumber"] != null && row["busNumber"].ToString() != "")
                {
                    model.busNumber = int.Parse(row["busNumber"].ToString());
                }
                if (row["traffic"] != null && row["traffic"].ToString() != "")
                {
                    model.traffic = int.Parse(row["traffic"].ToString());
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
            strSql.Append("select lineID,busNumber,traffic ");
            strSql.Append(" FROM statistics ");
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
            strSql.Append(" lineID,busNumber,traffic ");
            strSql.Append(" FROM statistics ");
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
            strSql.Append("select count(1) FROM statistics ");
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
            strSql.Append(")AS Row, T.*  from statistics T ");
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
            parameters[0].Value = "statistics";
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

        #endregion  ExtensionMethod
    }
}

