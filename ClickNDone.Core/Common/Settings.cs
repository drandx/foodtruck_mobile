using System;

namespace ClickNDone.Core
{
	public class Settings : ISettings
	{
		public User User { get; set; }
		public string DeviceToken { get; set;}
		//Implementation on each plattform
		public virtual void Save() { }

	}

}

