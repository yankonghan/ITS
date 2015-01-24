using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS_Manage.DAL
{
    public partial class Person
    {
        public Person()
        {

        }
        //缺少关于Person表的数据处理方法
       /* 这应该是多余的
        * public Person(string theName, string theSex, string theAge, string theID, string theAddtime, string thePersonType, string theWorkStartTime, string theLineID)
        {
            this.name = theName;
            this.sex = Sex;
            this.age = theAge;
            this.personID = theID;
            this.addTime = Convert.ToDateTime(theAddtime);
            this.personType = thePersonType;
            this.personWorkStartTime = Convert.ToDateTime(theWorkStartTime);
            this.chargeLineID = theLineID;

        }
        * */

    }
}
