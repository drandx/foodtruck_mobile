using System;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;

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
			
		public async Task<User> Login (string username, string password, UserType userType, String deviceToken)
		{
			client.Headers.Add (HttpRequestHeader.Accept, "application/json"); 
			client.Headers.Add (HttpRequestHeader.ContentType, "application/json"); 

			LoginObj loginObj = new LoginObj ();
			loginObj.password = password;
			loginObj.username = username;
			loginObj.userType = userType.ToString();

			var json = JsonConvert.SerializeObject (loginObj);
			string url = Constants.WebServiceHost + "auth/login";

			client.Headers.Set ("X-Origin-OS","Iphone 7");
			client.Headers.Set ("X-Origin-Token",deviceToken);
			client.Headers.Set ("User-Agent","IOS7");
			var response = await client.UploadStringTaskAsync (url, "POST", json);
			var objResp = JObject.Parse (response);

			User user = new User ();
			user.password = password;
			user.email = objResp["email"].ToString();
			user.names = objResp["fullName"].ToString();
			user.urlAvatar = objResp["urlAvatar"].ToString();
			user.token = objResp["token"].ToString();
			user.userType = objResp["userType"].ToString();
			user.birthAge = objResp["birthAge"].ToString();
			user.mobile = objResp["cellphone"].ToString();

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

		public async Task<User> Register (User user, String deviceToken)
		{
			client.Headers.Add (HttpRequestHeader.Accept, "application/json"); 
			client.Headers.Add (HttpRequestHeader.ContentType, "application/json");
			client.Headers.Set ("X-Origin-OS","Iphone 7");
			client.Headers.Set ("X-Origin-Token",deviceToken);
			client.Headers.Set ("User-Agent","IOS7");

			IDictionary<String,Object> userAttributes = new Dictionary<string, object> ();
			userAttributes.Add ("username", user.mobile);
			userAttributes.Add ("password", user.password);
			userAttributes.Add ("email", user.email);
			userAttributes.Add ("names", user.names);
			userAttributes.Add ("surnames", user.surnames);
			userAttributes.Add ("mobile", user.mobile);
			userAttributes.Add ("userType", user.userType.ToString());

			var userJson = JsonConvert.SerializeObject (userAttributes);

			string url = Constants.WebServiceHost + "auth/signup";
			var response = await client.UploadStringTaskAsync (url, "POST", userJson);
			var objResp = JObject.Parse (response);
			User myUser = new User ();
			myUser.token = objResp["token"].ToString();
			return myUser;

		}

		public async Task<User> GetUser(bool isEndUser)
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

	}
}

