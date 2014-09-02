using System;
using System.Threading.Tasks;

namespace ClickNDone.Core
{
	public interface IWebService
	{
		Task<User> Login(string username, string password, UserType userType, String deviceToken);
		Task<TermsConditions> GetTermsConditions(bool isEndUser);
		Task<User> GetUser(bool isEndUser);
		Task<User> Register(User user,String deviceToken);
	}
}

