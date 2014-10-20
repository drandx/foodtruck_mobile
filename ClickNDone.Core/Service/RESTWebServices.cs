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
			loginObj.pwd = password;
			loginObj.email = username;
			loginObj.userType = userType.ToString ();

			var json = JsonConvert.SerializeObject (loginObj);
			string url = Constants.WebServiceHost + "login";

			client.Headers.Set ("X-Origin-OS", "Iphone 7");
			client.Headers.Set ("X-Origin-Token", deviceToken);
			client.Headers.Set ("User-Agent", "IOS7");
			var response = await client.UploadStringTaskAsync (url, "POST", json);
			var objResp = JObject.Parse (response);

			User user = new User ();
			user.password = password;
			user.email = objResp ["email"].ToString ();
			user.names = objResp ["names"].ToString ();
			//TODO-Use this property to store session token
			//user.sessionToken = objResp["token"].ToString();
			user.sessionToken = "";
			user.userType = (objResp ["userType"].ToString () == UserType.CONSUMER.ToString ()) ? UserType.CONSUMER : UserType.SUPPLIER;
			user.birthAge = new DateTime ();
			//TODO-Include campo cellphone
			user.mobile = objResp ["cellphone"].ToString ();

			return user;
		}
		/*
		 * 
		 * 
		 * 
		 */
		public async Task<TermsConditions> GetTermsConditions (bool isEndUser)
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
			string url = Constants.WebServiceHost + "signup";

			client.Headers.Add (HttpRequestHeader.Accept, "application/json"); 
			client.Headers.Add (HttpRequestHeader.ContentType, "application/json");
			client.Headers.Set ("X-Origin-OS", "Iphone 7");
			client.Headers.Set ("X-Origin-Token", deviceToken);
			client.Headers.Set ("User-Agent", "IOS7");

			IDictionary<String,Object> userAttributes = new Dictionary<string, object> ();
			userAttributes.Add ("username", user.email);
			userAttributes.Add ("password", user.password);
			userAttributes.Add ("email", user.email);
			userAttributes.Add ("names", user.names);
			userAttributes.Add ("surnames", user.surnames);
			userAttributes.Add ("mobile", user.mobile);
			userAttributes.Add ("userType", user.userType.ToString ());

			var userJson = JsonConvert.SerializeObject (userAttributes);

			var response = await client.UploadStringTaskAsync (url, "POST", userJson);
			var objResp = JObject.Parse (response);

			//TODO-Pedir que me devuelvan un token basura
			User myUser = new User ();
			//myUser.sessionToken = objResp["token"].ToString();
			return myUser;

		}
		/*
		 * 
		 * 
		 * 
		 */
		public async Task<List<Category>> GetCategories (String sessionToken, String deviceToken)
		{
			client.Headers.Add (HttpRequestHeader.Accept, "application/json"); 
			client.Headers.Add (HttpRequestHeader.ContentType, "application/json"); 
			client.Headers.Set ("X-Origin-OS", "Iphone 7");
			client.Headers.Set ("X-Origin-Token", deviceToken);
			client.Headers.Set ("User-Agent", "IOS7");

			string url = Constants.WebServiceHost + "allcategories";

			var responseString = await client.DownloadStringTaskAsync (url);
			var objResp = JObject.Parse (responseString);
			List<Category> categoriesRet = new List<Category> ();

			foreach (var cat in objResp["category"]) {
				List<Category> subCategories = new List<Category> ();
				Category category = new Category ();
				category.Name = cat ["categoryName"].ToString ();
				category.Description = cat ["categoryDescription"].ToString ();
				category.Convention = cat ["categoryConvention"].ToString ();

				foreach (var subcat in cat["subCategories"]) {
					Category subcategory = new Category ();
					subcategory.Name = subcat ["subCategoryName"].ToString ();
					subcategory.Description = subcat ["subCategoryDescription"].ToString ();
					subcategory.Convention = subcat ["subCategoryConvention"].ToString ();
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
		public async Task<int> RequestService (ServiceRequest order, String sessionToken, String deviceToken)
		{
			client.Headers.Add (HttpRequestHeader.Accept, "application/json"); 
			client.Headers.Add (HttpRequestHeader.ContentType, "application/json");
			client.Headers.Set ("X-Origin-OS", "Iphone 7");
			client.Headers.Set ("X-Origin-Token", deviceToken);
			client.Headers.Set ("User-Agent", "IOS7");

			string url = Constants.WebServiceHost + "requestservice";

			//TODO - Send Caqtegory and Subcategory IDS. How?
			IDictionary<String,Object> serviceRequestAttributes = new Dictionary<string, object> ();
			serviceRequestAttributes.Add ("comments", order.Comments);
			serviceRequestAttributes.Add ("minimumCost", Convert.ToInt32 (order.MinCost));
			serviceRequestAttributes.Add ("maximumCost", Convert.ToInt32 (order.MaxCost));
			serviceRequestAttributes.Add ("location", order.Location);
			serviceRequestAttributes.Add ("reservationDate", order.ReservationDate.ToString ("MM-dd-yy H:mm:ss"));
			serviceRequestAttributes.Add ("allowanceToken", sessionToken);

			var serviceRequestJson = JsonConvert.SerializeObject (serviceRequestAttributes);

			var response = await client.UploadStringTaskAsync (url, "POST", serviceRequestJson);
			var objResp = JObject.Parse (response);
			return Convert.ToInt16(objResp ["serviceID"].ToString ());
		}
		/*
		 * 
		 * 
		 * 
		 */
		public async Task<User> GetUser (int userId, UserType UserType)
		{
			client.Headers.Add (HttpRequestHeader.Accept, "application/json"); 
			client.Headers.Add (HttpRequestHeader.ContentType, "application/json"); 
			client.Headers.Set ("X-Origin-OS", "Iphone 7");
			client.Headers.Set ("User-Agent", "IOS7");

			string url = Constants.WebServiceHost + "getuser";

			IDictionary<String,Object> userAttributes = new Dictionary<string, object> ();
			userAttributes.Add ("id", userId);
			userAttributes.Add ("UserType", UserType.ToString ());

			var userJson = JsonConvert.SerializeObject (userAttributes);
			var response = await client.UploadStringTaskAsync (url, "POST", userJson);

			var objResp = JObject.Parse (response);
			User user = new User ();
			user.id = userId;
			user.birthAge = new DateTime ();
			user.email = objResp ["email"].ToString ();
			user.names = objResp ["names"].ToString ();
			user.surnames = objResp ["surnames"].ToString ();
			user.userType = (objResp ["userType"].ToString () == UserType.CONSUMER.ToString ()) ? UserType.CONSUMER : UserType.SUPPLIER;
			user.urlAvatar = objResp ["urlAvatar"].ToString ();
			user.mobile = objResp ["cellphone"].ToString ();

			return user;
		}
		/*
		 * 
		 * 
		 * 
		 */
		public async Task<Order> GetOrder (int orderId)
		{
			client.Headers.Add (HttpRequestHeader.Accept, "application/json"); 
			client.Headers.Add (HttpRequestHeader.ContentType, "application/json");
			client.Headers.Set ("X-Origin-OS", "Iphone 7");
			client.Headers.Set ("X-Origin-Token", "");
			client.Headers.Set ("User-Agent", "IOS7");

			string url = Constants.WebServiceHost + "GetOrderDetail";

			IDictionary<String,Object> orderAttributes = new Dictionary<string, object> ();
			orderAttributes.Add ("orderId", orderId);

			var orderJson = JsonConvert.SerializeObject (orderAttributes);
			var response = await client.UploadStringTaskAsync (url, "POST", orderJson);

			var objResp = JObject.Parse (response);

			Order order = new Order ();
			order.Id = orderId;

			var status = objResp ["status"].ToString ();
			var idUser = objResp ["id_user"].ToString ();
			var idSupplier = objResp ["id_proveedor"].ToString ();
			var catId = objResp ["id_category"].ToString ();
			var subCatId = objResp ["id_subcategory"].ToString();

			order.Status = status == "" || status == null ? 0 : Convert.ToInt32 (status);
			order.UserId = idUser == "" || idUser == null ? 0 : Convert.ToInt32 (idUser);
			order.SupplierId = idSupplier == "" || idSupplier == null ? 0 : Convert.ToInt32 (idSupplier);
			order.ClickCode = objResp ["code_click"].ToString ();
			order.CategoryId = catId == "" || catId == null ? 0 : Convert.ToInt32 (catId);
			order.SubCategoryId = subCatId == "" || subCatId == null ? 0 : Convert.ToInt32 (subCatId);
			order.ReservationDate = new DateTime ();
			order.ReservationTime = new DateTime ();
			order.MinCost = Convert.ToDouble (objResp ["minimum_cost"].ToString());
			order.MaxCost = Convert.ToDouble (objResp ["maximum_cost"].ToString());
			order.Location = objResp ["location"].ToString ();
			order.Reference = objResp ["reference"].ToString ();
			order.Comments = objResp ["comments"].ToString ();

			return order;

		}

		/*
		* 
		* 
		* 
		*/
		public async Task<List<Order>> GetOrdersList (int userId, int orderState, UserType userType)
		{
			client.Headers.Add (HttpRequestHeader.Accept, "application/json"); 
			client.Headers.Add (HttpRequestHeader.ContentType, "application/json"); 
			client.Headers.Set ("X-Origin-OS", "Iphone 7");
			client.Headers.Set ("User-Agent", "IOS7");

			string url = Constants.WebServiceHost + "GetOrdersList";

			IDictionary<String,Object> orderAttributes = new Dictionary<string, object> ();
			orderAttributes.Add ("STATE", orderState);
			orderAttributes.Add ("UserType", userType.ToString ());
			orderAttributes.Add ("userId", userId);

			var orderJson = JsonConvert.SerializeObject (orderAttributes);
			var response = await client.UploadStringTaskAsync (url, "POST", orderJson);

			var objResp = JObject.Parse (response);
			List<Order> ordersList = new List<Order> ();

			foreach (var item in objResp["orders"]) {
				Order orderItem = new Order ();
				orderItem.Status = Convert.ToInt16 (item["status"].ToString ());
				orderItem.UserId = Convert.ToInt16 (item["id_user"].ToString ());
				orderItem.SupplierId = Convert.ToInt16 (item["id_proveedor"].ToString ());
				orderItem.ClickCode = item["code_click"].ToString ();
				orderItem.CategoryId = Convert.ToInt16 (item["id_category"].ToString ());
				orderItem.SubCategoryId = Convert.ToInt16 (item["id_subcategory"].ToString ());
				orderItem.ReservationDate = new DateTime ();
				orderItem.ReservationTime = new DateTime ();
				orderItem.MinCost = Convert.ToDouble (objResp ["minimum_cost"]);
				orderItem.MaxCost = Convert.ToDouble (objResp ["maximum_cost"]);
				orderItem.Location = objResp ["location"].ToString ();
				orderItem.Reference = objResp ["reference"].ToString ();
				orderItem.Comments = objResp ["comments"].ToString ();
			
				ordersList.Add (orderItem);
			}
			return ordersList;

		}

		/*
		* 
		* 
		* 
		*/
		public async Task<bool> ChangeOrderState (int orderId, int stateId)
		{
			string url = Constants.WebServiceHost + "change_order_state";
			IDictionary<String,Object> orderAttributes = new Dictionary<string, object> ();
			orderAttributes.Add ("STATE", stateId);
			orderAttributes.Add ("OrderID", orderId);
			var orderJson = JsonConvert.SerializeObject (orderAttributes);
			await client.UploadStringTaskAsync (url, "POST", orderJson);

			return true;
		}
	}
}

