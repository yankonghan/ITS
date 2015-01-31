using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ITS_Manage.Model;
namespace ITS_Manage.BLL
{
    /// <summary>
    /// stationManager
    /// </summary>
    public partial class StationManager
    {
        private readonly ITS_Manage.DAL.StationService dal = new ITS_Manage.DAL.StationService();
        public StationManager()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string stationID)
        {
            return dal.Exists(stationID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ITS_Manage.Model.Station model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ITS_Manage.Model.Station model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string stationID)
        {

            return dal.Delete(stationID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string stationIDlist)
        {
            return dal.DeleteList(stationIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ITS_Manage.Model.Station GetModel(string stationID)
        {

            return dal.GetModel(stationID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public ITS_Manage.Model.Station GetModelByCache(string stationID)
        {

            string CacheKey = "StationModel-" + stationID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(stationID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (ITS_Manage.Model.Station)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ITS_Manage.Model.Station> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ITS_Manage.Model.Station> DataTableToList(DataTable dt)
        {
            List<ITS_Manage.Model.Station> modelList = new List<ITS_Manage.Model.Station>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ITS_Manage.Model.Station model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

