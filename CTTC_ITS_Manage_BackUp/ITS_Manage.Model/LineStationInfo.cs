using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMap.NET;

namespace ITS_Manage.Model
{
    public partial class LineStationInfo
    {
        private string lineID;
        public string LineID
        {
            get
            {
                return this.lineID;
            }
            set
            {
                this.lineID = value;
            }
        }
        private string[] upStationName;
        public string[] UpStationName
        {
            get
            {
                return this.upStationName;
            }
            set
            {
                this.upStationName = value;
            }
        }
        private string[] downStationName;
        public string[] DownStationName
        {
            get
            {
                return this.downStationName;
            }
            set
            {
                this.downStationName = value;
            }
        }
        private int[] upDistance;
        public int[] UpDistance
        {
            get
            {
                return this.upDistance;
            }
            set
            {
                this.upDistance = value;
            }
        }
        private int[] downDistance;
        public int[] DownDistance
        {
            get
            {
                return this.downDistance;
            }
            set
            {
                this.downDistance = value;
            }
        }
        private PointLatLng[] stationLatLngUp;
        public PointLatLng[] StationLatLngUp
        {
            get
            {
                return this.stationLatLngUp;
            }
            set
            {
                this.stationLatLngUp = value;
            }
        }
        private PointLatLng[] stationLatLngDown;
        public PointLatLng[] StationLatLngDown
        {
            get
            {
                return this.stationLatLngDown;
            }
            set
            {
                this.stationLatLngDown = value;
            }
        }

        public LineStationInfo()
        {

        }
        //距离用double吧
        public LineStationInfo(string[] theUpStationName, string[] theDownStationName, int[] theUpDistance, int[] theDownDistance, string theLineID)
        {
            this.UpDistance = theUpDistance;
            this.DownDistance = theDownDistance;
            this.LineID = theLineID;
            this.UpStationName = theUpStationName;
            this.DownStationName = theDownStationName;
        }
    }
}
