using System;

namespace ClickNDone.Core
{
	public class Settings : ISettings
	{
		public User User { get; set; }
		public void Save() { }
		public bool IsEnduser { get; set;}
		public string IOSDeviceToken { get; set;}
	}

}

