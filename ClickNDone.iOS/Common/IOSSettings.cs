using System;
using ClickNDone.Core;
using MonoTouch.Foundation;
using Newtonsoft.Json;

namespace ClickNDone.iOS
{
	public class IOSSettings:Settings
	{
		public override void SaveUserLocallly ()
		{
			var user = NSUserDefaults.StandardUserDefaults;
			string jsonString = JsonConvert.SerializeObject (this.User);
			user.SetString (jsonString, "UserJsonObj");
			user.Synchronize ();
		}

		public override User LoadUserLocallly ()
		{
			var user = NSUserDefaults.StandardUserDefaults;
			string jsonString = user.StringForKey ("UserJsonObj");
			User retUser = new User ();
			try {
				retUser = JsonConvert.DeserializeObject<User> (jsonString);
			} catch (Exception exc) {
				System.Diagnostics.Debug.WriteLine ("Problems loading user from file "+exc.Message);
			}
			return retUser;
			
		}
	}
}

