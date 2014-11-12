using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DInteractive.Core
{
	public interface IWebService
	{
		Task<User> LoginAsync(string username, string password, UserType userType, String deviceToken);
		Task<TermsConditions> GetTermsConditionsAsync(bool isEndUser);
		User GetUser(int userId, UserType userType);
		Task<User> GetUserAsync(int userId, UserType userType);
		Task<User> RegisterAsync(User user,String deviceToken);
		Task<List<Category>> GetCategoriesAsync(String sessionToken,String deviceToken);
		Task<int> RequestServiceAsync(ServiceRequest order, String sessionToken, String deviceToken, int userId);
		Task<Order> GetOrderAsync(int orderId);
		Order GetOrder(int orderId);
		Task<List<Order>> GetOrdersListAsync(int userId, ServiceState state, UserType userType);
		List<Order> GetOrdersList(int userId, ServiceState state, UserType userType);
		Task<bool> ChangeOrderStateAsync(int orderId, ServiceState state, string comments = null, string ranking = null);

		//Digital Interactive CMS
		Task<List<BusinessCategory>> GetBusinessCategoriesAsync();
		Task<Boolean> PutCompanyAsync(Company company);
	}
}

