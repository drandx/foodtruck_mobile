using System;

namespace ClickNDone.Core
{
	public interface ISettings
	{
		User User { get; set; }
		void Save();
	}
}

