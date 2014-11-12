
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

namespace ClickNDone.Droid
{
	[Activity]
	public class BaseActivity<TViewModelOne, TViewModelTwo> : Activity 
		where TViewModelOne : BaseViewModel
		where TViewModelTwo : BaseViewModel
	{
		protected readonly TViewModelOne viewModel;
		protected readonly TViewModelTwo viewModelCat;
		protected ProgressDialog progress;

		public BaseActivity()
		{
			viewModel = (TViewModelOne)DependencyInjectionWrapper.Instance.ServiceContainer ().GetService (typeof(TViewModelOne));
			viewModelCat = (TViewModelTwo)DependencyInjectionWrapper.Instance.ServiceContainer ().GetService (typeof(TViewModelTwo));
		}

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			progress = new ProgressDialog(this);
			progress.SetCancelable(false);
			progress.SetTitle(Resource.String.Loading);
		}
		protected override void OnResume()
		{
			base.OnResume();
			viewModel.IsBusyChanged += OnIsBusyChanged;
		}
		protected override void OnPause()
		{
			base.OnPause();
			viewModel.IsBusyChanged -= OnIsBusyChanged;
		}

		void OnIsBusyChanged (object sender, EventArgs e)
		{
			if (viewModel.IsBusy)
				progress.Show();
			else
				progress.Hide();
		}

		protected void DisplayError(Exception exc)
		{
			string error = exc.Message;
			new AlertDialog.Builder(this)
				.SetTitle(Resource.String.ErrorTitle)
				.SetMessage(error)
				.SetPositiveButton(Android.Resource.String.Ok,
					(IDialogInterfaceOnClickListener)null)
				.Show();
		}
	}
}

