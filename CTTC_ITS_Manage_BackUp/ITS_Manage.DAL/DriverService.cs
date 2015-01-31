using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ITS_Manage.DAL.DBUtility;
namespace ITS_Manage.DAL
{
    /// <summary>
    /// 数据访问类:driverService
    /// </summary>
    public class DriverService
    {
        public DriverService()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string driverID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from driver");
            strSql.Append(" where driverID=@driverID ");
            SqlParameter[] parameters = {
					new SqlParameter("@driverID", SqlDbType.NVarChar,20)			};
            parameters[0].Value = driverID;

            return SQLHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ITS_Manage.Model.Driver model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into driver(");
            strSql.Append("driverID,driverName,busID,sex,age)");
            strSql.Append(" values (");
            strSql.Append("@driverID,@driverName,@busID,@sex,@age)");
            SqlParameter[] parameters = {
					new SqlParameter("@driverID", SqlDbType.NVarChar,20),
					new SqlParameter("@driverName", SqlDbType.NVarChar,20),
					new SqlParameter("@busID", SqlDbType.NVarChar,20),
					new SqlParameter("@sex", SqlDbType.Bit,1),
					new SqlParameter("@age", SqlDbType.SmallInt,2)};
            parameters[0].Value = model.driverID;
            parameters[1].Value = model.driverName;
            parameters[2].Value = model.busID;
            parameters[3].Value = model.sex;
            parameters[4].Value = model.age;

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
        public bool Update(ITS_Manage.Model.Driver model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update driver set ");
            strSql.Append("driverName=@driverName,");
            strSql.Append("busID=@busID,");
            strSql.Append("sex=@sex,");
            strSql.Append("age=@age");
            strSql.Append(" where driverID=@driverID ");
            SqlParameter[] parameters = {
					new SqlParameter("@driverName", SqlDbType.NVarChar,20),
					new SqlParameter("@busID", SqlDbType.NVarChar,20),
					new SqlParameter("@sex", SqlDbType.Bit,1),
					new SqlParameter("@age", SqlDbType.SmallInt,2),
					new SqlParameter("@driverID", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.driverName;
            parameters[1].Value = model.busID;
            parameters[2].Value = model.sex;
            parameters[3].Value = model.age;
            parameters[4].Value = model.driverID;

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
        public bool Delete(string driverID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from driver ");
            strSql.Append(" where driverID=@driverID ");
            SqlParameter[] parameters = {
					new SqlParameter("@driverID", SqlDbType.NVarChar,20)			};
            parameters[0].Value = driverID;

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
        public bool DeleteList(string driverIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from driver ");
            strSql.Append(" where driverID in (" + driverIDlist + ")  ");
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
        public ITS_Manage.Model.Driver GetModel(string driverID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 driverID,driverName,busID,sex,age from driver ");
            strSql.Append(" where driverID=@driverID ");
            SqlParameter[] parameters = {
					new SqlParameter("@driverID", SqlDbType.NVarChar,20)			};
            parameters[0].Value = driverID;

            ITS_Manage.Model.Driver model = new ITS_Manage.Model.Driver();
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
        public ITS_Manage.Model.Driver DataRowToModel(DataRow row)
        {
            ITS_Manage.Model.Driver model = new ITS_Manage.Model.Driver();
            if (row != null)
            {
                if (row["driverID"] != null)
                {
                    model.driverID = row["driverID"].ToString();
                }
                if (row["driverName"] != null)
                {
                    model.driverName = row["driverName"].ToString();
                }
                if (row["busID"] != null)
                {
                    model.busID = row["busID"].ToString();
                }
                if (row["sex"] != null && row["sex"].ToString() != "")
                {
                    if ((row["sex"].ToString() == "1") || (row["sex"].ToString().ToLower() == "true"))
                    {
                        model.sex = true;
                    }
                    else
                    {
                        model.sex = false;
                    }
                }
                if (row["age"] != null && row["age"].ToString() != "")
                {
                    model.age = int.Parse(row["age"].ToString());
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
            strSql.Append("select driverID,driverName,busID,sex,age ");
            strSql.Append(" FROM driver ");
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
            strSql.Append(" driverID,driverName,busID,sex,age ");
            strSql.Append(" FROM driver ");
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
            strSql.Append("select count(1) FROM driver ");
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
                strSql.Append("order by T.driverID desc");
            }
            strSql.Append(")AS Row, T.*  from driver T ");
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
            parameters[0].Value = "driver";
            parameters[1].Value = "driverID";
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

