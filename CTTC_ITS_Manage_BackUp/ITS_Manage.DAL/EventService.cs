using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ITS_Manage.Model;
using ITS_Manage.DAL.DBUtility;


namespace ITS_Manage.DAL
{
	/// <summary>
	/// 数据访问类:eventService
	/// </summary>
	public class EventService
	{
		public EventService()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string eventNumber)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from event");
			strSql.Append(" where eventNumber=@eventNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@eventNumber", SqlDbType.NVarChar,20)			};
			parameters[0].Value = eventNumber;

			return SQLHelper.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ITS_Manage.Model.Event model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into event(");
			strSql.Append("eventNumber,time,scheme,result,driverID)");
			strSql.Append(" values (");
			strSql.Append("@eventNumber,@time,@scheme,@result,@driverID)");
			SqlParameter[] parameters = {
					new SqlParameter("@eventNumber", SqlDbType.NVarChar,20),
					new SqlParameter("@time", SqlDbType.DateTime),
					new SqlParameter("@scheme", SqlDbType.NVarChar,-1),
					new SqlParameter("@result", SqlDbType.NVarChar,-1),
					new SqlParameter("@driverID", SqlDbType.NVarChar,20)};
			parameters[0].Value = model.eventNumber;
			parameters[1].Value = model.time;
			parameters[2].Value = model.scheme;
			parameters[3].Value = model.result;
			parameters[4].Value = model.driverID;

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
		public bool Update(ITS_Manage.Model.Event model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update event set ");
			strSql.Append("time=@time,");
			strSql.Append("scheme=@scheme,");
			strSql.Append("result=@result,");
			strSql.Append("driverID=@driverID");
			strSql.Append(" where eventNumber=@eventNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@time", SqlDbType.DateTime),
					new SqlParameter("@scheme", SqlDbType.NVarChar,-1),
					new SqlParameter("@result", SqlDbType.NVarChar,-1),
					new SqlParameter("@driverID", SqlDbType.NVarChar,20),
					new SqlParameter("@eventNumber", SqlDbType.NVarChar,20)};
			parameters[0].Value = model.time;
			parameters[1].Value = model.scheme;
			parameters[2].Value = model.result;
			parameters[3].Value = model.driverID;
			parameters[4].Value = model.eventNumber;

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
		public bool Delete(string eventNumber)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from event ");
			strSql.Append(" where eventNumber=@eventNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@eventNumber", SqlDbType.NVarChar,20)			};
			parameters[0].Value = eventNumber;

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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string eventNumberlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from event ");
			strSql.Append(" where eventNumber in ("+eventNumberlist + ")  ");
			int rows=SQLHelper.ExecuteSql(strSql.ToString());
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
		public ITS_Manage.Model.Event GetModel(string eventNumber)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 eventNumber,time,scheme,result,driverID from event ");
			strSql.Append(" where eventNumber=@eventNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@eventNumber", SqlDbType.NVarChar,20)			};
			parameters[0].Value = eventNumber;

			ITS_Manage.Model.Event model=new ITS_Manage.Model.Event();
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
		public ITS_Manage.Model.Event DataRowToModel(DataRow row)
		{
			ITS_Manage.Model.Event model=new ITS_Manage.Model.Event();
			if (row != null)
			{
				if(row["eventNumber"]!=null)
				{
					model.eventNumber=row["eventNumber"].ToString();
				}
				if(row["time"]!=null && row["time"].ToString()!="")
				{
					model.time=DateTime.Parse(row["time"].ToString());
				}
				if(row["scheme"]!=null)
				{
					model.scheme=row["scheme"].ToString();
				}
				if(row["result"]!=null)
				{
					model.result=row["result"].ToString();
				}
				if(row["driverID"]!=null)
				{
					model.driverID=row["driverID"].ToString();
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
			strSql.Append("select eventNumber,time,scheme,result,driverID ");
			strSql.Append(" FROM event ");
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
			strSql.Append(" eventNumber,time,scheme,result,driverID ");
			strSql.Append(" FROM event ");
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
			strSql.Append("select count(1) FROM event ");
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
				strSql.Append("order by T.eventNumber desc");
			}
			strSql.Append(")AS Row, T.*  from event T ");
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
			parameters[0].Value = "event";
			parameters[1].Value = "eventNumber";
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

