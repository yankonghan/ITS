using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using ITS_Manage.COMMON;
using ITS_Manage.Model;
using ITS_Manage.DAL.DBUtility;
using GMap.NET;
using System.Text;

namespace ITS_Manage.DAL
{
    public partial class LineStationInfo
    {
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
    }
}