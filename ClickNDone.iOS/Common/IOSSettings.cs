using System;
using ClickNDone.Core;
using MonoTouch.Foundation;
using Newtonsoft.Json;

namespace ClickNDone.iOS
{
	public class IOSSettings:Settings
	{
		public override void SaveUserLocallly() 
		{
			var user = NSUserDefaults.StandardUserDefaults;
			string jsonString = JsonConvert.SerializeObject (this.User);
			user.SetString (jsonString, "UserJsonObj");
		}

		public override User LoadUserLocallly ()
		{
			var user = NSUserDefaults.StandardUserDefaults;
			string jsonString = user.StringForKey ("UserJsonObj");
			return JsonConvert.DeserializeObject<User> (jsonString);
		}
			
	}
}

