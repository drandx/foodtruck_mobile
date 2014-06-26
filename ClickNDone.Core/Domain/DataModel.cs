using System;

namespace XamChat.Core
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
		public string Username { get; set; }
		public string Password { get; set; }
	}

}

