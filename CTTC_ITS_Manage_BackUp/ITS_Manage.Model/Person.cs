using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS_Manage.Model
{
         #region 数据库表说明
        //personID char(20),
        //personName Nvarchar(Max),
        //personAge int,
        //PersonSex Nvarchar(10),
        //personAddtime datetime,
        //personType Nvarchar(Max),
        //personWorkStartTime datetime,
        //chargeLineID char(20),
        //primary key(personID) 
        #endregion
    [Serializable]
    public partial class Person
    {
        #region 属性
        /// <summary>
        /// 姓名
        /// </summary>
        private string name;
       
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        /// <summary>
        /// 年龄
        /// </summary>
        private string age;
        
        public string Age
        {
            get 
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        /// <summary>
        /// 性别
        /// </summary>
        private string sex;
      
        public string Sex
        {
            get
            {
                return sex;
            }
            set
            {
                sex = value;
            }
        }
        /// <summary>
        /// 工号
        /// </summary>
        private string personID;
       
        public string PersonID
        {
            get
            {
                return personID;
            }
            set
            {
                personID = value;
            }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        private DateTime addTime;
      
        public DateTime AddTime
        {
            get
            {
                return addTime;
            }
            set
            {
                addTime = value;
            }
        }
        /// <summary>
        /// 人员工作类型
        /// </summary>
        private string personType;
      
        public string PersonType
        {
            get
            {
                return personType;
            }
            set
            {
                personType = value;
            }
        }
        /// <summary>
        /// 参加工作时间
        /// </summary>
        private DateTime personWorkStartTime;
      
        public DateTime PersonWorkStartTime
        {
            get
            {
                return personWorkStartTime;
            }
            set
            {
                personWorkStartTime = value;
            }
        }
        /// <summary>
        /// 所属线路
        /// </summary>
        private string chargeLineID;
    
        public string ChargeLineID
        {
            get
            {
                return chargeLineID;
            }
            set
            {
                chargeLineID = value;
            }
        }
        #endregion

    
    }
}
