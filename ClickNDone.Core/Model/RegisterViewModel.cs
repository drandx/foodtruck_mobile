﻿using System;
using System.Threading.Tasks;
namespace ClickNDone.Core
{
	public class RegisterViewModel : BaseViewModel
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
		public async Task Register()
		{
			if (string.IsNullOrEmpty(Username))
				throw new Exception("Username is blank.");
			if (string.IsNullOrEmpty(Password))
				throw new Exception("Password is blank.");
			if (Password != ConfirmPassword)
				throw new Exception("Passwords don't match.");
			IsBusy = true;
			try
			{
				settings.User = await service
					.Register(new User { username = Username,
						password = Password, });
				settings.Save();
			} finally {
				IsBusy = false;
			}
		}

	}

}

