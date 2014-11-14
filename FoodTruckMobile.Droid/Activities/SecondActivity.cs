
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ClickNDone.Droid
{
	[Activity (Label = "SecondActivity")]			
	public class SecondActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView(Resource.Layout.Second);
			var finish = FindViewById<Button>(Resource.Id.btnFinish);
			finish.Click += (sender, e) => Finish();
		}
	}
}

