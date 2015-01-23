using System;

namespace CommonClassLibrary
{
	[Serializable()]
	public class CommonProtocol
	{
		private string protocol;

		public CommonProtocol()
		{
		}

		public string Protocol
		{
			get
			{
				return protocol;
			}
			set
			{
				protocol = value;
			}
		}
	}
}
