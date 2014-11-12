using System;

namespace DInteractive.Core
{
	public interface ISettings
	{
		User User { get; set; }
		void SaveUserLocallly();
		User LoadUserLocallly();
		String DeviceToken { get; set; }
	}
}

