using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS_Manage.Model
{
    [Serializable]
    public partial class Line
    {
        private string lineName;
        public string LineName
        {
            set
            {
                lineName = value;
            }
            get
            {
                return lineName;
            }
        }
    }

}
