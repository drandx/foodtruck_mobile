using System;

namespace ClickNDone.Core
{
	public interface ISettings
	{
		User User { get; set; }
		bool IsEnduser { get; set;}
		void Save();
		string DeviceToken { get; set;}
	}
}

