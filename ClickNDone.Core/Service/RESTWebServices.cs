using System;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace ClickNDone.Core
{
	public class RESTWebServices : IWebService
	{

		private WebClient client;

		public int SleepDuration { get; set; }

		private Task Sleep ()
		{
			return Task.Delay (SleepDuration);
		}

		public RESTWebServices ()
		{
			SleepDuration = 1;
			client = new WebClient ();
		}
			
		public async Task<User> Login (string username, string password)
		{
			client.Headers.Add (HttpRequestHeader.Accept, "application/json"); 
			client.Headers.Add (HttpRequestHeader.ContentType, "application/json"); 

			User user = new User ();
			user.Id = 1;
			user.username = username;
			user.password = password;

			LoginObj loginObj = new LoginObj ();
			loginObj.password = password;
			loginObj.username = username;

			var json = JsonConvert.SerializeObject (loginObj);
			Console.WriteLine ("JSON representation of person: {0}", json);
			string url = Constants.WebServiceHost + "login";
			var response = await client.UploadStringTaskAsync (url, "POST", json);

			return user;
		}

		public async Task<TermsConditions> GetTermsConditions(bool isEndUser)
		{
			string url = Constants.WebServiceHost + "terms_conditions/";
			if (!isEndUser) 
				url = url + "SERVICE_PROVIDER_TYPE";
			else
				url = url + "END_USER_TYPE";
			var response = await client.DownloadStringTaskAsync (url);
			var terms = JsonConvert.DeserializeObject<TermsConditions> (response);

			return terms;
		}

		public async Task<User> GetUser(bool isEndUser)
		{
			throw new NotImplementedException();
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

