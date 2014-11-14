
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
using DInteractive.Core;
using ClickNDone.Droid.Activities;

namespace ClickNDone.Droid
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/icon_foodtruck")]			
	public class LoginActivity : BaseActivity<UserModel,CategoriesModel>
	{
		EditText username;
		Button login;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView(Resource.Layout.Login);
			username = FindViewById<EditText>(Resource.Id.txtUsername);
			login = FindViewById<Button>(Resource.Id.btnLogin);
			login.Click += OnLogin;
		}

		protected override void OnResume()
		{
			base.OnResume();
				username.Text = string.Empty;
		}
		void OnLogin (object sender, EventArgs e)
		{
			viewModel.Email = username.Text;
			try
			{
				System.Diagnostics.Debug.WriteLine(" *** READY TO GO HOME *** ");
                var intent = new Intent(this, typeof(MainPageActivity));                
                StartActivity(intent);

			}
			catch (Exception exc)
			{
				DisplayError(exc);
			}
		}
	}
}

