
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
using ClickNDone.Core;
using ClickNDone.Droid.Activities;

namespace ClickNDone.Droid
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/icon")]			
	public class LoginActivity : BaseActivity<UserModel,CategoriesModel>
	{
		EditText username, password;
		Button login;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView(Resource.Layout.Login);
			username = FindViewById<EditText>(Resource.Id.txtUsername);
			password = FindViewById<EditText>(Resource.Id.txtPassword);
			login = FindViewById<Button>(Resource.Id.btnLogin);
			login.Click += OnLogin;
		}

		protected override void OnResume()
		{
			base.OnResume();
			username.Text =
				password.Text = string.Empty;
		}
		async void OnLogin (object sender, EventArgs e)
		{
			viewModel.Username = username.Text;
			viewModel.Password = password.Text;
			try
			{
				//tmp code
				await viewModelCat.GetBusinessCategoriesAsync();
				await viewModelCat.PutCompanyAsync("garjuanpablo@gmail.com","123456789","987654321");

				await viewModel.Login();
				//TODO: navigate to a new activity
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

