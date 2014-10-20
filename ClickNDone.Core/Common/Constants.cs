using System;

namespace ClickNDone.Core
{


	public enum UserType
	{
		CONSUMER,
		SUPPLIER
	};

	public class Constants
	{
		public static int GET_ORDER_STATUS_WAIT_TIME = 10000; //Seconds
		public static int GET_ORDER_STATUS_ATTEMPTS = 1; //Calls
		public const string WebServiceHost = "http://click-n-done.com/WebApp/service/api.php?rquest=";
	}
}

