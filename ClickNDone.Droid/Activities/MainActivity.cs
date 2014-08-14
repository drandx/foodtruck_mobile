using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace ClickNDone.Droid
{
	[Activity (Label = "ClickNDone.Droid", MainLauncher = false, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				StartActivity(typeof(SecondActivity));
			};


			// Get our button from the layout resource,
			// and attach an event to it
			Button myButton = FindViewById<Button> (Resource.Id.myAddButton);
			TextView myText = FindViewById<TextView> (Resource.Id.textMyCount);

			myButton.Click += delegate {
				myButton.Text = string.Format("{0} clicks!", count++);
			};
		}
	}
}


