using System;
using System.Threading.Tasks;

namespace ClickNDone.Core
{
	public interface IWebService
	{

		Task<User> Register(User user);
		Task<User[]> GetFriends(int userId);
		Task<User> AddFriend(int userId, string username);
		Task<Conversation[]> GetConversations(int userId);
		Task<Message[]> GetMessages(int conversationId);
		Task<Message> SendMessage(Message message);

		//Click-n-done Services
		Task<User> Login(string username, string password, UserType userType);
		Task<TermsConditions> GetTermsConditions(bool isEndUser);
		Task<User> GetUser(bool isEndUser);
	}
}

