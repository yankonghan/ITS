using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ITS_Manage.BOL.BLL;

namespace ITS_Manage.BOL
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
    public class Person
    {
        #region 属性
        /// <summary>
        /// 姓名
        /// </summary>
        private string name;
        /// <summary>
        /// 姓名
        /// </summary>
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
        /// <summary>
        /// 年龄
        /// </summary>
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
        /// <summary>
        /// 性别
        /// </summary>
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
        /// <summary>
        /// 工号
        /// </summary>
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
        /// <summary>
        /// 添加时间
        /// </summary>
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
        /// <summary>
        /// 人员工作类型
        /// </summary>
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
        /// <summary>
        /// 参加工作时间
        /// </summary>
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
        /// <summary>
        /// 所属线路
        /// </summary>
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
        
        private string connectionString;

        #endregion

        #region 方法
        public Person()
        {

        }

        public Person(string theName, string theSex, string theAge, string theID, string theAddtime, string thePersonType, string theWorkStartTime, string theLineID)
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
        public DataTable GetPersonInfo(string SqlString)
        {
            DataTable dt = new DataTable();

            return dt;
        }
        /// <summary>
        /// 添加人员，成功返回true，失败返回false
        /// </summary>
        /// <param name="thePerson">人员实例信息</param>
        /// <returns>成功标志位</returns>
        public static bool AddPersonInfo(Person thePerson)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("INSERT INTO Peoson (personID,personName,personAge,PersonSex,personAddtime,personType,personWorkStartTime,chargeLineID)VALUES(");
                strSql.Append("'" + thePerson.personID + "',");
                strSql.Append("'" + thePerson.name + "',");
                strSql.Append("'" + thePerson.age + "',");
                strSql.Append("'" + thePerson.sex + "',");
                strSql.Append("convert(datetime, '" + thePerson.addTime + "'),");
                strSql.Append("'" + thePerson.personType + "',");
                strSql.Append("convert(datetime, '" + thePerson.personWorkStartTime + "'),");
                strSql.Append("'" + thePerson.chargeLineID + "')");
                object obj = SQLHelper.GetSingle(strSql.ToString());
                if (obj == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("未添加成功，请核对人员编号等信息");
                return false;
            }
        }
        #endregion
    }
}
