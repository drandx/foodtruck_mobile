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
		/*
		 * 
		 * 
		 * 
		 */
		public RESTWebServices ()
		{
			SleepDuration = 1;
			client = new WebClient ();
		}
		/*
		 * 
		 * 
		 * 
		 */	
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
			user.sessionToken = objResp["token"].ToString();
			user.userType = objResp["userType"].ToString();
			user.birthAge = objResp["birthAge"].ToString();
			user.mobile = objResp["cellphone"].ToString();

			return user;
		}
		/*
		 * 
		 * 
		 * 
		 */
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
		/*
		 * 
		 * 
		 * 
		 */
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
			myUser.sessionToken = objResp["token"].ToString();
			return myUser;

		}
		/*
		 * 
		 * 
		 * 
		 */
		public async Task<List<Category>> GetCategories(String sessionToken,String deviceToken)
		{
			client.Headers.Add (HttpRequestHeader.Accept, "application/json"); 
			client.Headers.Add (HttpRequestHeader.ContentType, "application/json"); 
			client.Headers.Set ("X-Origin-OS","Iphone 7");
			client.Headers.Set ("X-Origin-Token",deviceToken);
			client.Headers.Set ("User-Agent","IOS7");

			string url = Constants.WebServiceHost + "cnd-api/business/all?allowanceToken="+sessionToken;

			var responseString = await client.DownloadStringTaskAsync (url);
			var objResp = JObject.Parse (responseString);
			List<Category> categoriesRet = new List<Category>();

			foreach(var cat in objResp["categories"])
			{
				List<Category> subCategories = new List<Category>();
				Category category = new Category ();
				category.Name = cat ["categoryName"].ToString();
				category.Description = cat ["categoryDescription"].ToString();
				category.Convention = cat ["categoryConvention"].ToString();

				foreach(var subcat in cat["subCategories"])
				{
					Category subcategory = new Category ();
					subcategory.Name = subcat ["subCategoryName"].ToString();
					subcategory.Description = subcat ["subCategoryDescription"].ToString();
					subcategory.Convention = subcat ["subCategoryConvention"].ToString();
					subCategories.Add (subcategory);
				}

				category.Subcategories = subCategories;
				categoriesRet.Add (category);
			}

			return categoriesRet;
		}
		/*
		 * 
		 * 
		 * 
		 */
		public async Task<String> RequestService(ServiceRequest order, String sessionToken, String deviceToken)
		{
			client.Headers.Add (HttpRequestHeader.Accept, "application/json"); 
			client.Headers.Add (HttpRequestHeader.ContentType, "application/json");
			client.Headers.Set ("X-Origin-OS","Iphone 7");
			client.Headers.Set ("X-Origin-Token",deviceToken);
			client.Headers.Set ("User-Agent","IOS7");

			IDictionary<String,Object> serviceRequestAttributes = new Dictionary<string, object> ();
			serviceRequestAttributes.Add ("comments", order.Comments);
			serviceRequestAttributes.Add ("minimumCost", Convert.ToInt32(order.MinCost));
			serviceRequestAttributes.Add ("maximumCost", Convert.ToInt32(order.MaxCost));
			serviceRequestAttributes.Add ("location", order.Location);
			serviceRequestAttributes.Add ("reservationDate", order.ReservationDate.ToString("MM-dd-yy H:mm:ss"));
			serviceRequestAttributes.Add ("allowanceToken", sessionToken);

			var serviceRequestJson = JsonConvert.SerializeObject (serviceRequestAttributes);

			string url = Constants.WebServiceHost + "cnd-api/service/"+order.Category.Convention+"/bookRequest?allowanceToken="+sessionToken;

			var response = await client.UploadStringTaskAsync (url, "PUT", serviceRequestJson);
			var objResp = JObject.Parse (response);
			return response;
		}
		/*
		 * 
		 * 
		 * 
		 */
		public async Task<User> GetUser(bool isEndUser)
		{
			await Sleep ();
			return null;
		}
		/*
		 * 
		 * 
		 * 
		 */
		public async Task<User[]> GetFriends (int userId)
		{
			await Sleep ();
			return null;
		}
		/*
		 * 
		 * 
		 * 
		 */
		public async Task<User> AddFriend (int userId, string username)
		{
			await Sleep ();
			return null;
		}

	}
}

