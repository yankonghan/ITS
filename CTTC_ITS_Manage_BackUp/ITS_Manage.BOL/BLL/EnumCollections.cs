using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITS_Manage.BOL.BLL
{
    class EnumCollections
    {
    }
    /// <summary>
    /// 行车方向，UP是上行，Down是下行，WAITING是待发车待调度
    /// </summary>
    public enum Forward
    {
        UP,
        DOWN,
        WAITING
    }
}
