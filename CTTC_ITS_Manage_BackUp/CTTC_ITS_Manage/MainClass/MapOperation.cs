using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITS_Manage.DAL;
using ITS_Manage.DAL.DBUtility;
using ITS_Manage.Model;
using ITS_Manage.COMMON;
using GMap.NET.WindowsForms;
using GMap.NET;
using System.Windows.Forms;
using GMap.NET.WindowsForms.Markers;
using DevExpress.XtraRichEdit.API.Word;
using System.Drawing;
using System.Data;

/*主要是GmapControl类和GmapOverlay类
 * 1 先实例化GmapControl类，得实例Gmap，然后实例化GampOverlay得到站点图层（StopOverlay）和线路图层（RouteOverlay）
 * 然后在Gmap上添加图层，并设置这些图层可见。以及其他的一些设置，包括设置拖拽键位，以及经纬度，这些就是构造方法！
 * 2 在 initMap中进行一些服务模式的设置和初始化位置坐标。
 * 
 * 
 */
namespace CTTC_ITS_Manage.MainClass
{

    class MapOperation
    {
        #region 属性

        /// <summary>
        /// 地图控件
        /// </summary>
        private GMapControl gmap;
        /// <summary>
        /// 地图控件
        /// </summary>
        public GMapControl Gmap
        {
            get
            {
                return this.gmap;
            }
            set
            {
                this.gmap = value;
            }
        }
        /// <summary>
        /// 站点图层
        /// </summary>
        private GMapOverlay stopOverlay;
        /// <summary>
        /// 站点图层
        /// </summary>
        public GMapOverlay StopOverlay
        {
            get
            {
                return this.stopOverlay;
            }
            set
            {
                this.stopOverlay = value;
            }

        }
        /// <summary>
        /// 线路图层
        /// </summary>
        private GMapOverlay routeOverlay;
        /// <summary>
        /// 线路图层
        /// </summary>
        public GMapOverlay RouteOverlay
        {
            get
            {
                return this.routeOverlay;
            }
            set
            {
                this.routeOverlay = value;
            }

        }

        #endregion
        PointLatLng[] p;
        #region 方法

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="theGmap">地图控件</param>
        public MapOperation(GMapControl theGmap)
        {
            this.Gmap = theGmap;
            this.StopOverlay = new GMapOverlay(this.Gmap, "Stops");
            this.RouteOverlay = new GMapOverlay(this.Gmap, "routes");
            this.Gmap.RoutesEnabled = true;
            this.Gmap.Overlays.Add(this.RouteOverlay);
            this.Gmap.Overlays.Add(this.StopOverlay);
            this.RouteOverlay.IsVisibile = true;
            this.StopOverlay.IsVisibile = true;

            #region 实验数据6 104
            //p = new PointLatLng[28];
            ////p[0] = new PointLatLng(45.759294, 126.632720); p[1] = new PointLatLng(45.75790, 126.64162); p[2] = new PointLatLng(45.76132, 126.64731);
            ////p[3] = new PointLatLng(45.76588, 126.65259); p[4] = new PointLatLng(45.76975, 126.65710); p[5] = new PointLatLng(45.77516, 126.66789);
            ////p[6] = new PointLatLng(45.77770, 126.67073); p[7] = new PointLatLng(45.78486, 126.67907); p[8] = new PointLatLng(45.78788, 126.68795);
            ////p[9] = new PointLatLng(45.79088, 126.69719); p[10] = new PointLatLng(45.79171, 126.69982); p[11] = new PointLatLng(45.78909, 126.70708);


            //p[0] = new PointLatLng(45.659571, 126.624028);
            //p[1] = new PointLatLng(45.665680, 126.622716);
            //p[2] = new PointLatLng(45.670011, 126.621667);
            //p[3] = new PointLatLng(45.678389, 126.619787);
            //p[4] = new PointLatLng(45.683004, 126.618752);
            //p[5] = new PointLatLng(45.686043, 126.618125);
            //p[6] = new PointLatLng(45.690862, 126.617260);
            //p[7] = new PointLatLng(45.697512, 126.615722);
            //p[8] = new PointLatLng(45.701658, 126.614846);
            //p[9] = new PointLatLng(45.705785, 126.613750);
            //p[10] = new PointLatLng(45.709068, 126.613120);
            //p[11] = new PointLatLng(45.714895, 126.611865);
            //p[12] = new PointLatLng(45.720781, 126.610351);
            //p[13] = new PointLatLng(45.726325, 126.610980);
            //p[14] = new PointLatLng(45.729612, 126.613693);
            //p[15] = new PointLatLng(45.732779, 126.615720);
            //p[16] = new PointLatLng(45.738237, 126.620564);
            //p[17] = new PointLatLng(45.738856, 126.621126);
            //p[18] = new PointLatLng(45.743803, 126.626875);
            //p[19] = new PointLatLng(45.751710, 126.636099);
            //p[20] = new PointLatLng(45.755380, 126.640384);
            //p[21] = new PointLatLng(45.758799, 126.644078);
            //p[22] = new PointLatLng(45.761326, 126.647311);
            //p[23] = new PointLatLng(45.764834, 126.651277);
            //p[24] = new PointLatLng(45.768529, 126.655614);
            //p[25] = new PointLatLng(45.775362, 126.667932);
            //p[26] = new PointLatLng(45.780408, 126.673547);
            //p[27] = new PointLatLng(45.784400, 126.677934);

            #endregion

            this.Gmap.DragButton = MouseButtons.Left;
        }

        /// <summary>
        /// 初始化地图控件
        /// </summary>
        /// <returns></returns>
        public bool InitMap()
        {
            try
            {
                this.Gmap.MapProvider = GMap.NET.MapProviders.GoogleChinaMapProvider.Instance;
                GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
                gmap.Position = new PointLatLng(45.77107032636983, 126.67253494262695);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("初始化地图失败，请联系系统管理员");
                return false;
            }
        }
        /// <summary>
        /// 显示点,GmapMakerGoogleRed继承自GmapMaker，主要用来显示图标的！在站点图层StopOverlay上添加图标。
        /// </summary>
        /// <param name="Point">坐标</param>
        public void ShowPoints(PointLatLng Point)
        {
            GMapMarkerGoogleRed MarkerToShow = new GMapMarkerGoogleRed(Point);
            this.StopOverlay.Markers.Add(MarkerToShow);
            MarkerToShow.IsVisible = true;
        }
        /// <summary>
        /// 两点间画线路
        /// </summary>
        /// <param name="StartPoint">起始点</param>
        /// <param name="EndPoint">终点</param>
        public void ShowLinePoints(PointLatLng StartPoint, PointLatLng EndPoint)
        {

            List<PointLatLng> listp = new List<PointLatLng>(p);  //通过传入数组p来构造泛型实例listp

            
            GMapRoute routeToshow = new GMapRoute(listp, "6");//GmapRoute的第一个参数是List泛型数组的值，第二个参数是string的线路名称。
            this.RouteOverlay.Routes.Add(routeToshow);//有了GmapRoute之后再在RouteOverlay图层上添加
            routeToshow.IsVisible = true;
        }

        public void ShowDistance(PointLatLng[] StopArray, string LineID)
        {
            for (int i = 0; i < StopArray.Length - 1; i++)//在各个站点间画线
            {
                MapRoute theRouteToShow;
                if (i == 1) //不走人行道，为什么是1？
                {
                    theRouteToShow = GMap.NET.MapProviders.GoogleMapProvider.Instance.GetRouteBetweenPoints(
                        StopArray[i], StopArray[i + 1], false, false, 12);//5个参数（开始坐标，终点坐标，是否避开高速公路，是否步行，缩放比例）
                }
                else  //步行
                {
                    theRouteToShow = GMap.NET.MapProviders.GoogleMapProvider.Instance.GetRouteBetweenPoints(
                        StopArray[i], StopArray[i + 1], false, true, 12);
                }
                if (theRouteToShow != null)
                {
                    GMapRoute r = new GMapRoute(theRouteToShow.Points, LineID);
                    r.Stroke.Width = 5;
                    r.Stroke.Color = Color.Tomato;
                    this.RouteOverlay.Routes.Add(r);
                    GMapMarker StopMarker = new GMapMarkerGoogleGreen(StopArray[i]);
                    StopMarker.ToolTipText = ((int)(theRouteToShow.Distance * 1000)).ToString();//显示距离 若想显示地址详细信息用place.Value.Address;
                    StopMarker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                    StopMarker.IsVisible = false;
                    this.RouteOverlay.Markers.Add(StopMarker);
                }

            }
        }

        /// <summary>
        /// 地图显示线路
        /// </summary>
        /// <param name="Line">指定线路</param>
        public void ShowLine(LineStationInfo Line)
        {
            for (int i = 0; i < Line.StationLatLngUp.Length - 1; i++)//在各个站点间画线
            {
                MapRoute theRouteToShow;
                if (i == 1) //不走人行道
                {
                    theRouteToShow = GMap.NET.MapProviders.GoogleMapProvider.Instance.GetRouteBetweenPoints(
                        Line.StationLatLngUp[i], Line.StationLatLngUp[i + 1], false, false, 12);
                }
                else
                {
                    theRouteToShow = GMap.NET.MapProviders.GoogleMapProvider.Instance.GetRouteBetweenPoints(
                        Line.StationLatLngUp[i], Line.StationLatLngUp[i + 1], false, true, 12);
                }
                if (theRouteToShow != null)
                {
                    GMapRoute r = new GMapRoute(theRouteToShow.Points, Line.LineID);
                    r.Stroke.Width = 5;
                    r.Stroke.Color = Color.Tomato;
                    this.RouteOverlay.Routes.Add(r);
                    r.IsVisible = true;
                    //GMapMarker StopMarker = new GMapMarkerGoogleGreen(Line.StationLatLngUp[i]);
                    //StopMarker.ToolTipText = ((int)(theRouteToShow.Distance * 1000)).ToString();//显示距离 若想显示地址详细信息用place.Value.Address;
                    //StopMarker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                    //StopMarker.IsVisible = false;
                    //this.RouteOverlay.Markers.Add(StopMarker);
                }

            }

        }
        /// <summary>
        /// 遍历找到指定的站点线路
        /// </summary>
        /// <param name="line"></param>
        public void StopShowLine(LineStationInfo line)
        {
            try
            {
                for (int i = 0; i < this.routeOverlay.Routes.Count; i++)
                {
                    if (this.routeOverlay.Routes[i].Name == line.LineID)
                    {
                        this.routeOverlay.Routes[i].IsVisible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("stopShowLine" + ex.Message);
                return;
            }
        }
        /// <summary>
        /// 在地图上显示在线车辆
        /// </summary>
        /// <param name="LineBusRealTime">在线车辆列表</param>
        public void ShowBusOnLine(List<ITS_Manage.Model.BusRealInfo> LineBusRealTime, string LineID)
        {
            lock (this)
            {
                if (LineBusRealTime == null)
                {
                    return;
                }
                routeOverlay.Markers.Clear();  //不为空的话就一个一个把汽车图标添加进线路图层（RouteOverlay）中

                for (int i = 0; i < LineBusRealTime.Count; i++)
                {
                    GMapMarkerGoogleRed busReal = new GMapMarkerGoogleRed(new PointLatLng(LineBusRealTime[i].Lat, LineBusRealTime[i].Lng));
                    busReal.ToolTipText = LineBusRealTime[i].BusID;
                    busReal.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                    busReal.IsVisible = true;
                    this.RouteOverlay.Markers.Add(busReal);
                }
            }
        }

        public void ShowLineC(object theline)
        {
            LineStationInfo ttline = (LineStationInfo)theline;
            while (true)
            {
                this.routeOverlay.Markers.Clear();
                ShowBusOnLine(ITS_Manage.DAL.BusRealInfo.GetBusRealInfoList(ttline.LineID), ttline.LineID);
            }
        }

        /// <summary>
        /// 获取线路距离列表
        /// </summary>
        /// <param name="StopArray">站点坐标数组</param>
        /// <returns>线路信息</returns>
        public static LineStationInfo GetDistanceArray(PointLatLng[] StopArray)
        {
            LineStationInfo theLine = new LineStationInfo();
            if (StopArray.Length <= 1)
            {
                return null;
            }
            int[] DistanceArrayUp = new int[StopArray.Length - 1];
            for (int i = 0; i < StopArray.Length - 1; i++)//在各个站点间画线
            {
                MapRoute theRouteToShow;
                if (i == 1) //不走人行道
                {
                    theRouteToShow = GMap.NET.MapProviders.GoogleMapProvider.Instance.GetRouteBetweenPoints(
                        StopArray[i], StopArray[i + 1], false, false, 12);
                }
                else
                {
                    theRouteToShow = GMap.NET.MapProviders.GoogleMapProvider.Instance.GetRouteBetweenPoints(
                        StopArray[i], StopArray[i + 1], false, true, 12);
                }
                if (theRouteToShow != null)
                {
                    DistanceArrayUp[i] = (int)(theRouteToShow.Distance * 1000);//显示距离 若想显示地址详细信息用place.Value.Address;
                }
            }
            int[] tempDown = new int[DistanceArrayUp.Length];

            for (int h = 0; h < DistanceArrayUp.Length; h++)
            {
                tempDown[h] = DistanceArrayUp[DistanceArrayUp.Length - 1 - h];
            }
            //Array.Reverse(DistanceArrayUp);
            theLine.UpDistance = DistanceArrayUp;
            theLine.DownDistance = tempDown;

            return theLine;
        }

        internal static void CheckBusRealInfoOnMap(string BusID)
        {

        }

        #endregion
    }
}
