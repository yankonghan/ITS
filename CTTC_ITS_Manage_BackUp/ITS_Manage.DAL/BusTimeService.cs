using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ITS_Manage.Model;
using ITS_Manage.DAL.DBUtility;//Please add references
namespace ITS_Manage.DAL
{
	/// <summary>
	/// 数据访问类:busTimeService
	/// </summary>
	public class BusTimeService
	{
		public BusTimeService()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string busID,string stationID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from busTime");
			strSql.Append(" where busID=@busID and stationID=@stationID ");
			SqlParameter[] parameters = {
					new SqlParameter("@busID", SqlDbType.NVarChar,20),
					new SqlParameter("@stationID", SqlDbType.NVarChar,20)			};
			parameters[0].Value = busID;
			parameters[1].Value = stationID;

			return SQLHelper.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ITS_Manage.Model.BusTime model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into busTime(");
			strSql.Append("busID,stationID,arriveTime,startTime)");
			strSql.Append(" values (");
			strSql.Append("@busID,@stationID,@arriveTime,@startTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@busID", SqlDbType.NVarChar,20),
					new SqlParameter("@stationID", SqlDbType.NVarChar,20),
					new SqlParameter("@arriveTime", SqlDbType.DateTime),
					new SqlParameter("@startTime", SqlDbType.DateTime)};
			parameters[0].Value = model.busID;
			parameters[1].Value = model.stationID;
			parameters[2].Value = model.arriveTime;
			parameters[3].Value = model.startTime;

			int rows=SQLHelper.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Update(ITS_Manage.Model.BusTime model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update busTime set ");
			strSql.Append("arriveTime=@arriveTime,");
			strSql.Append("startTime=@startTime");
			strSql.Append(" where busID=@busID and stationID=@stationID ");
			SqlParameter[] parameters = {
					new SqlParameter("@arriveTime", SqlDbType.DateTime),
					new SqlParameter("@startTime", SqlDbType.DateTime),
					new SqlParameter("@busID", SqlDbType.NVarChar,20),
					new SqlParameter("@stationID", SqlDbType.NVarChar,20)};
			parameters[0].Value = model.arriveTime;
			parameters[1].Value = model.startTime;
			parameters[2].Value = model.busID;
			parameters[3].Value = model.stationID;

			int rows=SQLHelper.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(string busID,string stationID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from busTime ");
			strSql.Append(" where busID=@busID and stationID=@stationID ");
			SqlParameter[] parameters = {
					new SqlParameter("@busID", SqlDbType.NVarChar,20),
					new SqlParameter("@stationID", SqlDbType.NVarChar,20)			};
			parameters[0].Value = busID;
			parameters[1].Value = stationID;

			int rows=SQLHelper.ExecuteSql(strSql.ToString(),parameters);
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
		public ITS_Manage.Model.BusTime GetModel(string busID,string stationID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 busID,stationID,arriveTime,startTime from busTime ");
			strSql.Append(" where busID=@busID and stationID=@stationID ");
			SqlParameter[] parameters = {
					new SqlParameter("@busID", SqlDbType.NVarChar,20),
					new SqlParameter("@stationID", SqlDbType.NVarChar,20)			};
			parameters[0].Value = busID;
			parameters[1].Value = stationID;

			ITS_Manage.Model.BusTime model=new ITS_Manage.Model.BusTime();
			DataSet ds=SQLHelper.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public ITS_Manage.Model.BusTime DataRowToModel(DataRow row)
		{
			ITS_Manage.Model.BusTime model=new ITS_Manage.Model.BusTime();
			if (row != null)
			{
				if(row["busID"]!=null)
				{
					model.busID=row["busID"].ToString();
				}
				if(row["stationID"]!=null)
				{
					model.stationID=row["stationID"].ToString();
				}
				if(row["arriveTime"]!=null && row["arriveTime"].ToString()!="")
				{
					model.arriveTime=DateTime.Parse(row["arriveTime"].ToString());
				}
				if(row["startTime"]!=null && row["startTime"].ToString()!="")
				{
					model.startTime=DateTime.Parse(row["startTime"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select busID,stationID,arriveTime,startTime ");
			strSql.Append(" FROM busTime ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return SQLHelper.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" busID,stationID,arriveTime,startTime ");
			strSql.Append(" FROM busTime ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return SQLHelper.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM busTime ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.stationID desc");
			}
			strSql.Append(")AS Row, T.*  from busTime T ");
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
			parameters[0].Value = "busTime";
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

		#endregion  ExtensionMethod
	}
}

