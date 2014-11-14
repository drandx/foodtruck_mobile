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
using System.Threading;

namespace ClickNDone.Droid.Activities
{
    [Activity(Label = "MainPageActivity")]
	public class MainPageActivity : BaseActivity<UserModel,CategoriesModel>
    {
		bool running;

        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.MainPage);

			// Get our button from the layout resource,
			// and attach an event to it
			Button buttonStart = FindViewById<Button> (Resource.Id.btnStart);
			Button buttonStop = FindViewById<Button> (Resource.Id.btnStop);
			TextView labelStatus = FindViewById<TextView> (Resource.Id.lblStatus);



			buttonStart.Click += delegate {
				running	= true;
				labelStatus.Text = "Sending locations...";
				UpdateLocation();
			};
				
			buttonStop.Click += delegate {
				running	= false;
				labelStatus.Text = "Not Sending locations...";

			};

        }

		private async void UpdateLocation()
		{

			await viewModelCat.PutCompanyAsync (viewModel.Email, 41.878298, -87.625592);
			Thread.Sleep(Constants.GET_ORDER_STATUS_WAIT_TIME);

		}

    }
}