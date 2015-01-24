using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using ITS_Manage.Model;
using ITS_Manage.DAL.DBUtility;
using System.Threading.Tasks;

namespace ITS_Manage.DAL
{
    public partial class Line
    {
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
                string strSql = "SELECT * FROM Bus where Bus_id = '" + theBus.BusID + "'";
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
    }
}
