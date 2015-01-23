using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMap.NET.WindowsForms;
using GMap.NET;

namespace CTTC_ITS_Manage.MainClass
{
    public class CTTCGmapMarker : GMapMarker
    {
        public CTTCGmapMarker(PointLatLng Pos)
            : base(Pos)
        {

        }
    }
}
