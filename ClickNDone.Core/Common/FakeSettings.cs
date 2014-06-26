using System;

namespace ClickNDone.Core
{
	public class FakeSettings : ISettings
	{
		public User User { get; set; }
		public void Save() { }
	}

}

