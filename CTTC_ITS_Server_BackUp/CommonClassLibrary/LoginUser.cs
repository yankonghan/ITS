using System;

namespace CommonClassLibrary
{
	[Serializable()]
	public class LoginUser : CommonProtocol
	{
		private string userID;
		private string password;
		private string userName;
		private bool isLogin;
		private string ip;

		public LoginUser()
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

		public string UserName
		{
			get
			{
				return userName;
			}
			set
			{
				userName = value;
			}
		}

		public string Password
		{
			get
			{
				return password;
			}
			set
			{
				password = value;
			}
		}

		public bool IsLogin
		{
			get
			{
				return isLogin;
			}
			set
			{
				isLogin = value;
			}
		}

		public string IP
		{
			get
			{
				return ip;
			}
			set
			{
				ip = value;
			}
		}

	}
}