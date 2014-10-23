using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ClickNDone.Core
{
	public interface IWebService
	{
		Task<User> LoginAsync(string username, string password, UserType userType, String deviceToken);
		Task<TermsConditions> GetTermsConditionsAsync(bool isEndUser);
		Task<User> GetUserAsync(int userId, UserType userType);
		Task<User> RegisterAsync(User user,String deviceToken);
		Task<List<Category>> GetCategoriesAsync(String sessionToken,String deviceToken);
		Task<int> RequestServiceAsync(ServiceRequest order, String sessionToken, String deviceToken, int userId);
		Task<Order> GetOrderAsync(int orderId);
		Task<List<Order>> GetOrdersListAsync(int userId, int orderState, UserType userType);
		Task<bool> ChangeOrderStateAsync(int orderId, ServiceState state, string comments = null, string ranking = null);
	}
}

