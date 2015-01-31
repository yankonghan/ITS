using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data;
using ITS_Manage.Model;
using System.Data.SqlClient;
using ITS_Manage.DAL.DBUtility;

namespace ITS_Manage.DAL
{
    /// <summary>
    /// 数据访问类:busService
    /// </summary>
    public partial class BusService
    {
        public BusService()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string busID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from bus");
            strSql.Append(" where busID=@busID ");
            SqlParameter[] parameters = {
					new SqlParameter("@busID", SqlDbType.NVarChar,20)			};
            parameters[0].Value = busID;

            return SQLHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ITS_Manage.Model.Bus model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into bus(");
            strSql.Append("busID,lineID,state,isOnline)");
            strSql.Append(" values (");
            strSql.Append("@busID,@lineID,@state,@isOnline)");
            SqlParameter[] parameters = {
					new SqlParameter("@busID", SqlDbType.NVarChar,20),
					new SqlParameter("@lineID", SqlDbType.NVarChar,20),
					new SqlParameter("@state", SqlDbType.SmallInt,2),
					new SqlParameter("@isOnline", SqlDbType.Bit,1)};
            parameters[0].Value = model.busID;
            parameters[1].Value = model.lineID;
            parameters[2].Value = model.state;
            parameters[3].Value = model.isOnline;

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
        public bool Update(ITS_Manage.Model.Bus model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update bus set ");
            strSql.Append("lineID=@lineID,");
            strSql.Append("state=@state,");
            strSql.Append("isOnline=@isOnline");
            strSql.Append(" where busID=@busID ");
            SqlParameter[] parameters = {
					new SqlParameter("@lineID", SqlDbType.NVarChar,20),
					new SqlParameter("@state", SqlDbType.SmallInt,2),
					new SqlParameter("@isOnline", SqlDbType.Bit,1),
					new SqlParameter("@busID", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.lineID;
            parameters[1].Value = model.state;
            parameters[2].Value = model.isOnline;
            parameters[3].Value = model.busID;

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
            strSql.Append("delete from bus ");
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
            strSql.Append("delete from bus ");
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
        public ITS_Manage.Model.Bus GetModel(string busID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 busID,lineID,state,isOnline from bus ");
            strSql.Append(" where busID=@busID ");
            SqlParameter[] parameters = {
					new SqlParameter("@busID", SqlDbType.NVarChar,20)			};
            parameters[0].Value = busID;

            ITS_Manage.Model.Bus model = new ITS_Manage.Model.Bus();
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
        public ITS_Manage.Model.Bus DataRowToModel(DataRow row)
        {
            ITS_Manage.Model.Bus model = new ITS_Manage.Model.Bus();
            if (row != null)
            {
                if (row["busID"] != null)
                {
                    model.busID = row["busID"].ToString();
                }
                if (row["lineID"] != null)
                {
                    model.lineID = row["lineID"].ToString();
                }
                if (row["state"] != null && row["state"].ToString() != "")
                {
                    model.state = int.Parse(row["state"].ToString());
                }
                if (row["isOnline"] != null && row["isOnline"].ToString() != "")
                {
                    if ((row["isOnline"].ToString() == "1") || (row["isOnline"].ToString().ToLower() == "true"))
                    {
                        model.isOnline = true;
                    }
                    else
                    {
                        model.isOnline = false;
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
            strSql.Append("select busID,lineID,state,isOnline ");
            strSql.Append(" FROM bus ");
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
            strSql.Append(" busID,lineID,state,isOnline ");
            strSql.Append(" FROM bus ");
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
            strSql.Append("select count(1) FROM bus ");
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
            strSql.Append(")AS Row, T.*  from bus T ");
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
            parameters[0].Value = "bus";
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
                //需自己修改sqlstr
                string strSql = "SELECT * FROM Bus where Bus_id = '" + theBus.busID + "'";
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
                //需自己修改sqlstr
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
                //需自己修改sqlstr
                string strSql = "SELECT * FROM Bus";
                BusDataTable = SQLHelper.Query(strSql).Tables["ds"];
                for (int i = 0; i < BusDataTable.Rows.Count; i++)
                {
                    ITS_Manage.Model.Bus temp = new ITS_Manage.Model.Bus(BusDataTable.Rows[i][0].ToString(), Convert.ToBoolean(Convert.ToInt16(BusDataTable.Rows[i][3].ToString())));
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
                    BuslArray[i] = new ITS_Manage.Model.Bus(BusDataTable.Rows[i][0].ToString(), Convert.ToBoolean(Convert.ToInt16(BusDataTable.Rows[i][3].ToString())));
                }
                return BuslArray;
            }
            catch (Exception ex)//log
            {
                MessageBox.Show("加载公交信息失败，请检查数据库或与系统管理员联系！");
                return null;
            }
        }



        ////public static Bus GetBusRealInfo(string BusID)
        ////{
        ////    //在线判断
        ////    Bus BusRealInfo = new Bus();
        ////    DataTable BusDataTable = null;
        ////    Bus[] BuslArray;
        ////    try
        ////    {
        ////        string strSql = "SELECT * FROM Bus where ChargeLine_id = '" + BusID + "' order by isOnline desc";
        ////        BusDataTable = SQLHelper.Query(strSql).Tables["ds"];
        ////        BuslArray = new Bus[BusDataTable.Rows.Count];

        ////        for (int i = 0; i < BusDataTable.Rows.Count; i++)
        ////        {
        ////            BuslArray[i] = new Bus(BusDataTable.Rows[i][0].ToString(), Convert.ToBoolean(Convert.ToInt16(BusDataTable.Rows[i][5].ToString())));
        ////        }
        ////        return RealInfo;
        ////    }
        ////    catch (Exception ex)//log
        ////    {
        ////        MessageBox.Show("加载公交信息失败，请检查数据库或与系统管理员联系！");
        ////        return null;
        ////    }
        ////    return RealInfo;
        ////}
    }

        #endregion  ExtensionMethod
     
}
