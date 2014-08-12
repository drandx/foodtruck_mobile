using System;

namespace ClickNDone.Core
{
	public interface ISettings
	{
		User User { get; set; }
		string DeviceToken { get; set;}
		void Save();
	}
}

