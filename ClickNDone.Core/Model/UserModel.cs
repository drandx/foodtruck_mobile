using System;
using System.Threading.Tasks;

namespace ClickNDone.Core
{
	public class UserModel : BaseViewModel
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public UserType UserType { get; set;}
		public string Email { get; set; }
		public string Image { get; set; }
		public string LastName { get; set; }
		public string Name { get; set; }
		public string PhoneNumber { get; set; }

		public User User
		{
			get{return this.settings.LoadUserLocallly();}
		}
			
		public async Task Login()
		{
			if (string.IsNullOrEmpty(Username))
				throw new Exception("Ingrese el nombre de usuario.");
			if (string.IsNullOrEmpty(Password))
				throw new Exception("Ingrese el password");
			IsBusy = true;
			try
			{
				settings.User = await service.Login(Username, Password, UserType, settings.DeviceToken);
				settings.SaveUserLocallly();
			}
			finally {
				IsBusy = false;
			}
		}

		public async Task Register()
		{
			if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(PhoneNumber) || string.IsNullOrEmpty(Name))
				throw new Exception("Ingrese los campos correctamente");
			IsBusy = true;
			try
			{
				User user = new User();

				user.password = Password;
				user.mobile = PhoneNumber;
				user.email = Email;
				user.userType = UserType;
				user.names = Name;
				user.surnames = LastName;
				user.urlAvatar = Image;

				User retUser = await service.Register(user,settings.DeviceToken);

				//Completing the User Object after SigningUp
				retUser.names = Name;
				retUser.surnames = LastName;
				retUser.email = Email;
				retUser.mobile = PhoneNumber;
				retUser.userType = UserType;
				settings.User = retUser;
				settings.SaveUserLocallly();

			}
			finally {
				IsBusy = false;
			}

		}

	}
}

