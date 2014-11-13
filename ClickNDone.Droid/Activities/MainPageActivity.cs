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

namespace ClickNDone.Droid.Activities
{
    [Activity(Label = "MainPageActivity")]
	public class MainPageActivity : BaseActivity<UserModel,CategoriesModel>
    {
        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
			await viewModelCat.PutCompanyAsync (viewModel.Email, 41.878298, -87.625592);
        }
    }
}