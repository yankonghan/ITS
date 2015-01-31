using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ITS_Manage.Model;
using ITS_Manage.DAL.DBUtility;
using System.Threading.Tasks;

namespace ITS_Manage.DAL
{

    /// <summary>
    /// 数据访问类:lineService
    /// </summary>
    public class LineService
    {
        public LineService()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string lineID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from line");
            strSql.Append(" where lineID=@lineID ");
            SqlParameter[] parameters = {
					new SqlParameter("@lineID", SqlDbType.NVarChar,20)			};
            parameters[0].Value = lineID;

            return SQLHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ITS_Manage.Model.Line model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into line(");
            strSql.Append("lineID,lineName,lineLength,startStation,endStation)");
            strSql.Append(" values (");
            strSql.Append("@lineID,@lineName,@lineLength,@startStation,@endStation)");
            SqlParameter[] parameters = {
					new SqlParameter("@lineID", SqlDbType.NVarChar,20),
					new SqlParameter("@lineName", SqlDbType.NVarChar,20),
					new SqlParameter("@lineLength", SqlDbType.Int,4),
					new SqlParameter("@startStation", SqlDbType.NVarChar,20),
					new SqlParameter("@endStation", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.lineID;
            parameters[1].Value = model.lineName;
            parameters[2].Value = model.lineLength;
            parameters[3].Value = model.startStation;
            parameters[4].Value = model.endStation;

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
        public bool Update(ITS_Manage.Model.Line model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update line set ");
            strSql.Append("lineName=@lineName,");
            strSql.Append("lineLength=@lineLength,");
            strSql.Append("startStation=@startStation,");
            strSql.Append("endStation=@endStation");
            strSql.Append(" where lineID=@lineID ");
            SqlParameter[] parameters = {
					new SqlParameter("@lineName", SqlDbType.NVarChar,20),
					new SqlParameter("@lineLength", SqlDbType.Int,4),
					new SqlParameter("@startStation", SqlDbType.NVarChar,20),
					new SqlParameter("@endStation", SqlDbType.NVarChar,20),
					new SqlParameter("@lineID", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.lineName;
            parameters[1].Value = model.lineLength;
            parameters[2].Value = model.startStation;
            parameters[3].Value = model.endStation;
            parameters[4].Value = model.lineID;

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
            strSql.Append("delete from line ");
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
            strSql.Append("delete from line ");
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
        public ITS_Manage.Model.Line GetModel(string lineID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 lineID,lineName,lineLength,startStation,endStation from line ");
            strSql.Append(" where lineID=@lineID ");
            SqlParameter[] parameters = {
					new SqlParameter("@lineID", SqlDbType.NVarChar,20)			};
            parameters[0].Value = lineID;

            ITS_Manage.Model.Line model = new ITS_Manage.Model.Line();
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
        public ITS_Manage.Model.Line DataRowToModel(DataRow row)
        {
            ITS_Manage.Model.Line model = new ITS_Manage.Model.Line();
            if (row != null)
            {
                if (row["lineID"] != null)
                {
                    model.lineID = row["lineID"].ToString();
                }
                if (row["lineName"] != null)
                {
                    model.lineName = row["lineName"].ToString();
                }
                if (row["lineLength"] != null && row["lineLength"].ToString() != "")
                {
                    model.lineLength = int.Parse(row["lineLength"].ToString());
                }
                if (row["startStation"] != null)
                {
                    model.startStation = row["startStation"].ToString();
                }
                if (row["endStation"] != null)
                {
                    model.endStation = row["endStation"].ToString();
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
            strSql.Append("select lineID,lineName,lineLength,startStation,endStation ");
            strSql.Append(" FROM line ");
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
            strSql.Append(" lineID,lineName,lineLength,startStation,endStation ");
            strSql.Append(" FROM line ");
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
            strSql.Append("select count(1) FROM line ");
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
            strSql.Append(")AS Row, T.*  from line T ");
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
            parameters[0].Value = "line";
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
        /// 精确查找Line表
        /// </summary>
        /// <param name="thePerson">查询条件</param>
        /// <returns>person的list</returns>
        public static DataTable SelectLineInfo(Model.Bus theBus)
        {
            DataTable BusDataTable = null;

            try
            {
                string strSql = "SELECT * FROM Bus where Bus_id = '" + theBus.busID + "'";
                BusDataTable = SQLHelper.Query(strSql).Tables["ds"];
                return BusDataTable;
            }
            catch (Exception ex)//log
            {
                MessageBox.Show("线路加载失败，请查看数据库相关信息，或联系系统管理员");
                return null;
            }
        }
        /// <summary>
        /// 返回所有线路名
        /// </summary>
        /// <returns>Line的DataTable</returns>
        public static DataTable SelectLineInfo()
        {
            DataTable LineDataTable = null;

            try
            {
                string strSql = "SELECT line_id from Line order by Line_Index asc";
                LineDataTable = SQLHelper.Query(strSql).Tables["ds"];
                return LineDataTable;
            }
            catch (Exception ex)//log
            {
                MessageBox.Show("线路获取失败，请查看数据库相关信息，或联系系统管理员！");
                return null;
            }
        }

        #endregion  ExtensionMethod

    }
}

