using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ClickNDone.Core
{
	public interface IWebService
	{
		Task<User> Login(string username, string password, UserType userType, String deviceToken);
		Task<TermsConditions> GetTermsConditions(bool isEndUser);
		Task<User> GetUser(int userId, UserType userType);
		Task<User> Register(User user,String deviceToken);
		Task<List<Category>> GetCategories(String sessionToken,String deviceToken);
		Task<int> RequestService(ServiceRequest order, String sessionToken, String deviceToken, int userId);
		Task<Order> GetOrder(int orderId);
		Task<List<Order>> GetOrdersList(int userId, int orderState, UserType userType);
		Task<bool> ChangeOrderState(int orderId, int stateId);
	}
}

