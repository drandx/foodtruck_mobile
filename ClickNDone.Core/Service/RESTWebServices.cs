using System;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
			
		public async Task<User> Login (string username, string password, UserType userType)
		{
			client.Headers.Add (HttpRequestHeader.Accept, "application/json"); 
			client.Headers.Add (HttpRequestHeader.ContentType, "application/json"); 

			LoginObj loginObj = new LoginObj ();
			loginObj.password = password;
			loginObj.username = username;
			loginObj.userType = userType.ToString();

			var json = JsonConvert.SerializeObject (loginObj);
			string url = Constants.WebServiceHost + "auth/login";

			var response = await client.UploadStringTaskAsync (url, "POST", json);
			var objResp = JObject.Parse (response);

			User user = new User ();
			user.username = username;
			user.password = password;
			user.email = objResp["email"].ToString();
			user.fullName = objResp["fullName"].ToString();
			user.urlAvatar = objResp["urlAvatar"].ToString();
			user.token = objResp["token"].ToString();
			user.userType = objResp["userType"].ToString();
			user.birthAge = objResp["birthAge"].ToString();
			user.cellphone = objResp["cellphone"].ToString();

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

