using System;

namespace ClickNDone.Core
{
	public class Conversation
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string Username { get; set; }
	}

	public class Product
	{
		public int Id { get; set; } //Just a numeric identifier
		public string Name { get; set; } //Name of the product
		public float Price { get; set; } //Price of the product
		public Product ()
		{
		}
	}

	public class Message
	{
		public int Id { get; set; }
		public int ConversationId { get; set; }
		public int UserId { get; set; }
		public string Username { get; set; }
		public string Text { get; set; }
	}

	public class User
	{
		public int Id { get; set; }
		public string username { get; set; }
		public string password { get; set; }
		public string urlAvatar { get; set;}
		public string fullName { get; set;}
		public string email { get; set;}
		public string token { get; set;}

	}

	public class LoginObj
	{
		public string username { get; set; }
		public string password { get; set; }
	}

	public class Person
	{
		public string username { get; set; }
		public string password { get; set; }
		public string urlAvatar { get; set;}
		public string fullName { get; set;}
		public string email { get; set;}
		public string token { get; set;}
	}

	public class TermsConditions
	{
		public string terms { get; set; }
		public string conditions { get; set; }
	}

}

