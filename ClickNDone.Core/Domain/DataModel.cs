using System;

namespace ClickNDone.Core
{

	public class User
	{
		public string password { get; set; }
		public string birthAge { get; set;}
		public string email { get; set;}
		public string names { get; set;}
		public string surnames { get; set;}
		public string mobile { get; set;}
		public string gender { get; set;}
		public string userType { get; set;}
		public string urlAvatar { get; set;}
		public string token { get; set;}
	}

	public class LoginObj
	{
		public string username { get; set; }
		public string password { get; set; }
		public string userType { get; set; }
	}

	public class TermsConditions
	{
		public string terms { get; set; }
		public string conditions { get; set; }
	}

}

