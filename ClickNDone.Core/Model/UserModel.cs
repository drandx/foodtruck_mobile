using System;
using System.Threading.Tasks;

namespace ClickNDone.Core
{
	public class UserModel : BaseViewModel
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public UserType UserType { get; set;}

		public User User
		{
			get{return this.settings.LoadUserLocallly();}
		}
			
		public async Task Login()
		{
			if (string.IsNullOrEmpty(Username))
				throw new Exception("Username is blank.");
			if (string.IsNullOrEmpty(Password))
				throw new Exception("Password is blank.");
			IsBusy = true;
			try
			{
				settings.User = await service.Login(Username, Password, UserType);
				settings.SaveUserLocallly();
			}
			finally {
				IsBusy = false;
			}
		}

	}
}

