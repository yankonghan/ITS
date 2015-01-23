using System;
using System.Data;

namespace CommonClassLibrary
{
	[Serializable()]
	public class Disconnect : CommonProtocol
	{
		private string userID;

		public Disconnect()
		{

		}

		public string UserID
		{
			get
			{
				return userID;
			}
			set
			{
				userID = value;
			}
		}
	}
}
