﻿using System;
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
		public async Task<User> LoginAsync (string username, string password, UserType userType, String deviceToken)
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
			user.surnames = objResp ["surnames"].ToString ();
			//TODO-Use this property to store session token
			//user.sessionToken = objResp["token"].ToString();
			user.sessionToken = "";
			user.userType = (objResp ["userType"].ToString () == UserType.CONSUMER.ToString ()) ? UserType.CONSUMER : UserType.SUPPLIER;
			user.birthAge = new DateTime (); //TODO - Create DateTime object
			user.mobile = objResp ["cellphone"].ToString ();
			var iduser = objResp ["id"].ToString ();
			user.id = iduser == "" || iduser == null ? 0 : Convert.ToInt32 (iduser);

			return user;
		}
		/*
		 * 
		 * 
		 * 
		 */
		public async Task<TermsConditions> GetTermsConditionsAsync (bool isEndUser)
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
		public async Task<User> RegisterAsync (User user, String deviceToken)
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
		public async Task<List<Category>> GetCategoriesAsync (String sessionToken, String deviceToken)
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
		public async Task<int> RequestServiceAsync (ServiceRequest order, String sessionToken, String deviceToken, int userId)
		{
			client.Headers.Add (HttpRequestHeader.Accept, "application/json"); 
			client.Headers.Add (HttpRequestHeader.ContentType, "application/json");
			client.Headers.Set ("X-Origin-OS", "Iphone 7");
			client.Headers.Set ("X-Origin-Token", deviceToken);
			client.Headers.Set ("User-Agent", "IOS7");

			string url = Constants.WebServiceHost + "requestservice";

			//TODO - Send Caqtegory and Subcategory IDS. How?
			IDictionary<String,Object> serviceRequestAttributes = new Dictionary<string, object> ();
			serviceRequestAttributes.Add ("reference", order.Reference);
			serviceRequestAttributes.Add ("minimumCost", Convert.ToInt32 (order.MinCost));
			serviceRequestAttributes.Add ("maximumCost", Convert.ToInt32 (order.MaxCost));
			serviceRequestAttributes.Add ("location", order.Location);
			serviceRequestAttributes.Add ("reservationDate", order.ReservationDate.ToString ("MM-dd-yy H:mm:ss"));
			serviceRequestAttributes.Add ("allowanceToken", sessionToken);
			serviceRequestAttributes.Add ("iduser", userId);
			serviceRequestAttributes.Add ("category", order.SubCategory.ParentId);
			serviceRequestAttributes.Add ("idsub_category", order.SubCategory.Id);

			var serviceRequestJson = JsonConvert.SerializeObject (serviceRequestAttributes);

			var response = await client.UploadStringTaskAsync (url, "POST", serviceRequestJson);
			var objResp = JObject.Parse (response);
			return Convert.ToInt16 (objResp ["serviceID"].ToString ());
		}
		/*
		 * 
		 * 
		 * 
		 */
		public Task<User> GetUserAsync (int userId, UserType UserType)
		{
			try {
				return Task.Run(() => GetUser(userId,UserType));
			} catch (Exception exc) {
				Console.WriteLine ("Crashing on GetUserAsync - " + exc.Message);
				return null;
			}
		}

		/*
		 * 
		 * 
		 * 
		 */
		public User GetUser (int userId, UserType UserType)
		{
			try {

				client.Headers.Add (HttpRequestHeader.Accept, "application/json"); 
				client.Headers.Add (HttpRequestHeader.ContentType, "application/json"); 
				client.Headers.Set ("X-Origin-OS", "Iphone 7");
				client.Headers.Set ("User-Agent", "IOS7");

				string url = Constants.WebServiceHost + "getuser";

				IDictionary<String,Object> userAttributes = new Dictionary<string, object> ();
				userAttributes.Add ("id", 5);
				userAttributes.Add ("userType", UserType.ToString ());

				var userJson = JsonConvert.SerializeObject (userAttributes);
				var response = client.UploadString (url, "POST", userJson);

				var objResp = JObject.Parse (response);
				User user = new User ();
				user.id = userId;
				user.birthAge = new DateTime ();
				user.email = objResp ["email"].ToString ();
				user.names = objResp ["names"].ToString ();
				user.surnames = objResp ["surnames"].ToString ();
				user.urlAvatar = objResp ["urlAvatar"].ToString ();
				user.userType = UserType;
				user.mobile = objResp ["cellphone"].ToString ();

				return user;
			} catch (Exception exc) {
				Console.WriteLine ("Crashing on GetUser - " + exc.Message);
				return null;
			}
		}

		/*
		 * 
		 * 
		 * 
		 */
		public async Task<Order> GetOrderAsync (int orderId)
		{
			try {

				client.Headers.Add (HttpRequestHeader.Accept, "application/json"); 
				client.Headers.Add (HttpRequestHeader.ContentType, "application/json");
				client.Headers.Set ("X-Origin-OS", "Iphone 7");
				client.Headers.Set ("X-Origin-Token", "");
				client.Headers.Set ("User-Agent", "IOS7");

				string url = Constants.WebServiceHost + "GetOrderDetail";

				IDictionary<String,Object> orderAttributes = new Dictionary<string, object> ();
				orderAttributes.Add ("orderId", orderId);

				var orderJson = JsonConvert.SerializeObject (orderAttributes);
				Order order = new Order ();

				if (!client.IsBusy) {
					var response = await client.UploadStringTaskAsync (url, "POST", orderJson);
					var objResp = JObject.Parse (response);
					order.Id = orderId;

					var idUser = objResp ["id_user"].ToString ();
					var idSupplier = objResp ["id_proveedor"].ToString ();
					var catId = objResp ["id_category"].ToString ();
					var subCatId = objResp ["id_subcategory"].ToString ();

					var status = objResp ["status"].ToString ();
					order.Status = status == "" || status == null ? ServiceState.UNKNOWN : (ServiceState)Convert.ToInt32 (status);

					order.UserId = idUser == "" || idUser == null ? 0 : Convert.ToInt32 (idUser);
					order.SupplierId = idSupplier == "" || idSupplier == null ? 0 : Convert.ToInt32 (idSupplier);
					order.ClickCode = objResp ["code_click"].ToString ();
					order.CategoryId = catId == "" || catId == null ? 0 : Convert.ToInt32 (catId);
					order.SubCategoryId = subCatId == "" || subCatId == null ? 0 : Convert.ToInt32 (subCatId);
					order.ReservationDate = new DateTime ();
					order.ReservationTime = new DateTime ();
					order.MinCost = Convert.ToDouble (objResp ["minimum_cost"].ToString ());
					order.MaxCost = Convert.ToDouble (objResp ["maximum_cost"].ToString ());
					order.Location = objResp ["location"].ToString ();
					order.Reference = objResp ["reference"].ToString ();
					order.Comments = objResp ["comments"].ToString ();
					return order;
				}
				return null;

			} catch (Exception exc) {
				Console.WriteLine ("Crashing when gets order - " + exc.Message);
				return null;
			}

		}


		/*
		 * 
		 * 
		 * 
		 */
		public Order GetOrder (int orderId)
		{
			try {

				client.Headers.Add (HttpRequestHeader.Accept, "application/json"); 
				client.Headers.Add (HttpRequestHeader.ContentType, "application/json");
				client.Headers.Set ("X-Origin-OS", "Iphone 7");
				client.Headers.Set ("X-Origin-Token", "");
				client.Headers.Set ("User-Agent", "IOS7");

				string url = Constants.WebServiceHost + "GetOrderDetail";

				IDictionary<String,Object> orderAttributes = new Dictionary<string, object> ();
				orderAttributes.Add ("orderId", orderId);

				var orderJson = JsonConvert.SerializeObject (orderAttributes);
				Order order = new Order ();

				if (!client.IsBusy) {
					var response = client.UploadString (url, "POST", orderJson);
					var objResp = JObject.Parse (response);
					order.Id = orderId;

					var idUser = objResp ["id_user"].ToString ();
					var idSupplier = objResp ["id_proveedor"].ToString ();
					var catId = objResp ["id_category"].ToString ();
					var subCatId = objResp ["id_subcategory"].ToString ();

					var status = objResp ["status"].ToString ();
					order.Status = status == "" || status == null ? ServiceState.UNKNOWN : (ServiceState)Convert.ToInt32 (status);

					order.UserId = idUser == "" || idUser == null ? 0 : Convert.ToInt32 (idUser);
					order.SupplierId = idSupplier == "" || idSupplier == null ? 0 : Convert.ToInt32 (idSupplier);
					order.ClickCode = objResp ["code_click"].ToString ();
					order.CategoryId = catId == "" || catId == null ? 0 : Convert.ToInt32 (catId);
					order.SubCategoryId = subCatId == "" || subCatId == null ? 0 : Convert.ToInt32 (subCatId);
					order.ReservationDate = new DateTime ();
					order.ReservationTime = new DateTime ();
					order.MinCost = Convert.ToDouble (objResp ["minimum_cost"].ToString ());
					order.MaxCost = Convert.ToDouble (objResp ["maximum_cost"].ToString ());
					order.Location = objResp ["location"].ToString ();
					order.Reference = objResp ["reference"].ToString ();
					order.Comments = objResp ["comments"].ToString ();
					return order;
				}
				return null;

			} catch (Exception exc) {
				Console.WriteLine ("Crashing when gets order - " + exc.Message);
				return null;
			}

		}

		/*
		* 
		* 
		* 
		*/
		public async Task<List<Order>> GetOrdersListAsync (int userId, ServiceState orderState, UserType userType)
		{
			try {
				client.Headers.Add (HttpRequestHeader.Accept, "application/json"); 
				client.Headers.Add (HttpRequestHeader.ContentType, "application/json"); 
				client.Headers.Set ("X-Origin-OS", "Iphone 7");
				client.Headers.Set ("User-Agent", "IOS7");

				string url = Constants.WebServiceHost + "GetOrdersList";

				IDictionary<String,Object> orderAttributes = new Dictionary<string, object> ();
				orderAttributes.Add ("STATE", (int)orderState);
				orderAttributes.Add ("UserType", userType.ToString ());
				orderAttributes.Add ("UserID", userId);

				var orderJson = JsonConvert.SerializeObject (orderAttributes);
				var response = await client.UploadStringTaskAsync (url, "POST", orderJson);

				var objListResp = JObject.Parse (response);
				List<Order> ordersList = new List<Order> ();

				foreach (var objResp in objListResp["orders"]) {
					Order orderItem = new Order ();

					var status = objResp ["status"].ToString ();
					orderItem.Status = status == "" || status == null ? ServiceState.UNKNOWN : (ServiceState)Convert.ToInt32 (status);
					var idUser = objResp ["id_user"].ToString ();
					orderItem.UserId = idUser == "" || idUser == null ? 0 : Convert.ToInt32 (idUser);
					var idSupplier = objResp ["id_proveedor"].ToString ();
					orderItem.SupplierId = idSupplier == "" || idSupplier == null ? 0 : Convert.ToInt32 (idSupplier);
					orderItem.ClickCode = objResp ["code_click"].ToString ();
					var catId = objResp ["id_category"].ToString ();
					orderItem.CategoryId = catId == "" || catId == null ? 0 : Convert.ToInt32 (catId);
					var subCatId = objResp ["id_subcategory"].ToString ();
					orderItem.SubCategoryId = subCatId == "" || subCatId == null ? 0 : Convert.ToInt32 (subCatId);
					orderItem.ReservationDate = new DateTime ();
					orderItem.ReservationTime = new DateTime ();
					orderItem.MinCost = Convert.ToDouble (objResp ["minimum_cost"].ToString ());
					orderItem.MaxCost = Convert.ToDouble (objResp ["maximum_cost"].ToString ());
					orderItem.Location = objResp ["location"].ToString ();
					orderItem.Reference = objResp ["reference"].ToString ();
					orderItem.Comments = objResp ["comments"].ToString ();
			
					ordersList.Add (orderItem);
				}
				return ordersList;
			} catch (Exception exc) {
				Console.WriteLine ("Crashing on GetOrdersListAsync - " + exc.Message);
				return null;
			}


		}

		/*
		* 
		* 
		* 
		*/
		public List<Order> GetOrdersList (int userId, ServiceState orderState, UserType userType)
		{
			try {
				client.Headers.Add (HttpRequestHeader.Accept, "application/json"); 
				client.Headers.Add (HttpRequestHeader.ContentType, "application/json"); 
				client.Headers.Set ("X-Origin-OS", "Iphone 7");
				client.Headers.Set ("User-Agent", "IOS7");

				string url = Constants.WebServiceHost + "GetOrdersList";

				IDictionary<String,Object> orderAttributes = new Dictionary<string, object> ();
				orderAttributes.Add ("STATE", (int)orderState);
				orderAttributes.Add ("UserType", userType.ToString ());
				orderAttributes.Add ("UserID", userId);

				var orderJson = JsonConvert.SerializeObject (orderAttributes);
				var response = client.UploadString (url, "POST", orderJson);

				var objListResp = JObject.Parse (response);
				List<Order> ordersList = new List<Order> ();

				foreach (var objResp in objListResp["orders"]) {
					Order orderItem = new Order ();

					var status = objResp ["status"].ToString ();
					orderItem.Status = status == "" || status == null ? ServiceState.UNKNOWN : (ServiceState)Convert.ToInt32 (status);
					var idUser = objResp ["id_user"].ToString ();
					orderItem.UserId = idUser == "" || idUser == null ? 0 : Convert.ToInt32 (idUser);
					var idSupplier = objResp ["id_proveedor"].ToString ();
					orderItem.SupplierId = idSupplier == "" || idSupplier == null ? 0 : Convert.ToInt32 (idSupplier);
					orderItem.ClickCode = objResp ["code_click"].ToString ();
					var catId = objResp ["id_category"].ToString ();
					orderItem.CategoryId = catId == "" || catId == null ? 0 : Convert.ToInt32 (catId);
					var subCatId = objResp ["id_subcategory"].ToString ();
					orderItem.SubCategoryId = subCatId == "" || subCatId == null ? 0 : Convert.ToInt32 (subCatId);
					orderItem.ReservationDate = new DateTime ();
					orderItem.ReservationTime = new DateTime ();
					orderItem.MinCost = Convert.ToDouble (objResp ["minimum_cost"].ToString ());
					orderItem.MaxCost = Convert.ToDouble (objResp ["maximum_cost"].ToString ());
					orderItem.Location = objResp ["location"].ToString ();
					orderItem.Reference = objResp ["reference"].ToString ();
					orderItem.Comments = objResp ["comments"].ToString ();

					ordersList.Add (orderItem);
				}
				return ordersList;
			} catch (Exception exc) {
				Console.WriteLine ("Crashing on GetOrdersListAsync - " + exc.Message);
				return null;
			}


		}

		/*
		* 
		* 
		* 
		*/
		public async Task<bool> ChangeOrderStateAsync (int orderId, ServiceState state, string comments = null, string ranking = null)
		{
			try {
				client.Headers.Add (HttpRequestHeader.Accept, "application/json"); 
				client.Headers.Add (HttpRequestHeader.ContentType, "application/json"); 
				client.Headers.Set ("X-Origin-OS", "Iphone 7");
				client.Headers.Set ("User-Agent", "IOS7");

				string url = Constants.WebServiceHost + "change_order_state";
				IDictionary<String,Object> orderAttributes = new Dictionary<string, object> ();
				orderAttributes.Add ("STATE", (int)state + "");
				orderAttributes.Add ("OrderID", orderId);

				if (comments != null && ranking != null) {
					orderAttributes.Add ("comments", comments);
					orderAttributes.Add ("rate", ranking);

				}

				if (!client.IsBusy) {
					var orderJson = JsonConvert.SerializeObject (orderAttributes);
					await client.UploadStringTaskAsync (url, "POST", orderJson);
					return true;
				}
				return false;


				return true;
			} catch (Exception exc) {
				Console.WriteLine ("Crashing on ChangeOrderState - " + exc.Message);
				return false;
			}
		}
	}
}

