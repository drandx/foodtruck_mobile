using System;

namespace ClickNDone.Core
{
	public class Settings : ISettings
	{
		public User User { get; set; }

		//Implementation on each plattform
		public virtual void SaveUserLocallly() { }
		public virtual User LoadUserLocallly() { return null;}

	}

}

