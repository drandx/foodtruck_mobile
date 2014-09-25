using System;
using System.Collections.Generic;

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
		public string sessionToken { get; set;}
	}

	public class LoginObj
	{
		public string email { get; set; }
		public string pwd { get; set; }
		public string userType { get; set; }
	}

	public class TermsConditions
	{
		public string terms { get; set; }
		public string conditions { get; set; }
	}

	public class Category
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string Convention { get; set; }
		public List<Category> Subcategories { get; set; }
	}

	public class ServiceRequest
	{
		public string Location { get; set; }
		public string Comments { get; set; }
		public Double MinCost { get; set; }
		public Double MaxCost { get; set; }
		public DateTime ReservationDate { get; set; }
		public Category Category { get; set;}
	}

}

