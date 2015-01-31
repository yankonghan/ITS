using System;
namespace ITS_Manage.Model
{
	/// <summary>
	/// event:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public  class Event
	{
		public Event()
		{}
		#region Model
		private string _eventnumber;
		private DateTime? _time;
		private string _scheme;
		private string _result;
		private string _driverid;
		/// <summary>
		/// 
		/// </summary>
		public string eventNumber
		{
			set{ _eventnumber=value;}
			get{return _eventnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? time
		{
			set{ _time=value;}
			get{return _time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string scheme
		{
			set{ _scheme=value;}
			get{return _scheme;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string result
		{
			set{ _result=value;}
			get{return _result;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string driverID
		{
			set{ _driverid=value;}
			get{return _driverid;}
		}
		#endregion Model

	}
}

