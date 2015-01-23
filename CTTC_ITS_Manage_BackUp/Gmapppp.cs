using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GMap.NET.WindowsForms;
using GMap.NET.MapProviders;
using GMap.NET.Internals;
using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;


namespace test1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            //初始化地图为google map 并设定初始中心位置为china
            gMap.MapProvider = GMap.NET.MapProviders.GoogleChinaMapProvider.Instance;//.BingMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            //gMap.Position = new PointLatLng(45.74740199642105, 126.69570922851562);//此为定初始位置的另一种方式
            gMap.SetPositionByKeywords("china,harbin");//设置初始中心为china harbin
            //gMap.SetPositionByKeywords("Maputo, Mozambique");


            //创建图层(overlay)和标签(marker)，将标签加入图层，再将图层加入控件中
            //GMapMarker gMapMarker = new GMarkerGoogle(new PointLatLng(45.74740199642105, 126.69570922851562),
            //    GMarkerGoogleType.green);//在(45.7，126.695）上绘制一绿色点
            //GMapOverlay gMapOverlay = new GMapOverlay("mark");　　//创建图层
            //gMapOverlay.Markers.Add(gMapMarker);　　//向图层中添加标签
            //gMap.Overlays.Add(gMapOverlay);　　//向控件中添加图层

            //以街道名称形式画出路线
            //string start = "花园街, 哈尔滨, china";
            //string end = "密山路, 哈尔滨, china";
            //MapRoute route = GMap.NET.MapProviders.GoogleMapProvider.Instance.GetRoute(
            //  start, end, false, false, 15);//找到start到end的一条路

            PointLatLng[] p = new PointLatLng[12];//存储6路公交所有站点经纬度坐标
            p[0] = new PointLatLng(45.759294, 126.632720); p[1] = new PointLatLng(45.75790, 126.64162); p[2] = new PointLatLng(45.76132, 126.64731);
            p[3] = new PointLatLng(45.76588, 126.65259); p[4] = new PointLatLng(45.76975, 126.65710); p[5] = new PointLatLng(45.77516, 126.66789);
            p[6] = new PointLatLng(45.77770, 126.67073); p[7] = new PointLatLng(45.78486, 126.67907); p[8] = new PointLatLng(45.78788, 126.68795);
            p[9] = new PointLatLng(45.79088, 126.69719); p[10] = new PointLatLng(45.79171, 126.69982); p[11] = new PointLatLng(45.78909, 126.70708);

            // 以经纬度的形式画出街道
            //PointLatLng start = new PointLatLng(45.759294, 126.632720);
            //PointLatLng end = new PointLatLng(45.759249, 126.632832);
            //MapRoute route = GMap.NET.MapProviders.GoogleMapProvider.Instance.GetRoute(start, end, false, true, 15);
             

            ////画出路 及 路的规格    
            //GMapRoute rr = new GMapRoute(route.Points, "My route");//将路转换成线
            //rr.Stroke.Width = 5;
            //rr.Stroke.Color = Color.Black;

            GMapOverlay routesOverlay = new GMapOverlay("routes");//新建图层，目的是放置道路GMapRoute
            //routesOverlay.Routes.Add(rr);//将道路加入图层
            //gMap.ZoomAndCenterRoute(rr);//将r这条路初始为视图中心，显示时以r为中心显示


            GeocodingProvider gp; //地址编码服务 可以解析出该经纬度的道路信息
            gp = gMap.MapProvider as GeocodingProvider;
            if (gp == null) //地址转换服务，没有就使用OpenStreetMap
            {
                gp = GMapProviders.OpenStreetMap as GeocodingProvider;
            }
            GMapProvider.Language = LanguageType.ChineseSimplified; //使用的语言，默认是英文

            for (int i = 0; i < 11; i++)//在各个站点间画线
            {
                MapRoute route1;
                if (i == 1) //这条走人行道的话会根据最短距离 改变路线 所以这一条我们不走人行道
                {
                    route1 = GMap.NET.MapProviders.GoogleMapProvider.Instance.GetRoute(
                    p[i], p[i + 1], false, false, 15);
                }
                else
                {
                    route1 = GMap.NET.MapProviders.GoogleMapProvider.Instance.GetRoute(
                        p[i], p[i + 1], false, true, 15);
                }
                GMapRoute r = new GMapRoute(route1.Points, "My route 1");
                r.Stroke.Width = 5;
                r.Stroke.Color = Color.Black;
                routesOverlay.Routes.Add(r);
                GMapMarker marker = new GMarkerGoogle(p[i], GMarkerGoogleType.green);
                //GeoCoderStatusCode statusCode = GeoCoderStatusCode.Unknow; //用于显示详细地址的信息
                //Placemark? place = gp.GetPlacemark(p[i], out statusCode);
                marker.ToolTipText = route1.Distance.ToString();//显示距离 若想显示地址详细信息用place.Value.Address;
                marker.ToolTipMode = MarkerTooltipMode.Always;
                routesOverlay.Markers.Add(marker);
                
            }
            //画出第二条路线
            //string st = "中央大街， 哈尔滨， china";
            //string ed = "一曼街， 哈尔滨， china";
            //MapRoute route1 = GMap.NET.MapProviders.GoogleMapProvider.Instance.GetRoute(
            //  st, ed, false, false, 15);
            //GMapRoute r1 = new GMapRoute(route1.Points, "My route 1");
            //r1.Stroke.Width = 5;
            //r1.Stroke.Color = Color.Black;
            //routesOverlay.Routes.Add(r1);


           // gMap.Overlays.Clear();//清除所有overlay
            gMap.Overlays.Add(routesOverlay);
        }
    }
}
