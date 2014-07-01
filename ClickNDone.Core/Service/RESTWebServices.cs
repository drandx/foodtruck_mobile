using System;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace ClickNDone.Core
{
	public class RESTWebServices : IWebService
	{

		private WebClient client;

		public RESTWebServices ()
		{
			client = new WebClient ();
		}

		private Task Sleep ()
		{
			return Task.Delay (1);
		}
			
		public async Task<User> Login (string username, string password)
		{
			await Sleep ();
			client.Headers.Add (HttpRequestHeader.Accept, "application/json"); 
			client.Headers.Add (HttpRequestHeader.ContentType, "application/json"); 
			//client.Headers.Add ("X-ZUMO-APPLICATION", MobileServiceAppId);
			User user = new User ();
			user.Id = 1;
			user.username = username;
			user.username = password;

			Person person = new Person ();
			person.password = password;
			person.username = username;

			var json = JsonConvert.SerializeObject (person);
			Console.WriteLine ("JSON representation of person: {0}", json);
			string url = Constants.WebServiceHost + "login";
			var response = client.UploadString (url, "POST", json);
			return user;
		}

		public async Task<User> Register (User user)
		{
			throw new NotImplementedException();
		}

		public async Task<User[]> GetFriends (int userId)
		{
			throw new NotImplementedException();
		}

		public async Task<User> AddFriend (int userId, string username)
		{
			throw new NotImplementedException();
		}

		public async Task<Conversation[]> GetConversations(int userId)
		{
			throw new NotImplementedException();
		}

		public async Task<Message[]> GetMessages(int conversationId)
		{
			throw new NotImplementedException();
		}

		public async Task<Message> SendMessage(Message message)
		{
			throw new NotImplementedException();
		}

	}
}

