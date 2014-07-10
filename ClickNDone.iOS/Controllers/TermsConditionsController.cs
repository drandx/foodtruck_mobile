// This file has been autogenerated from a class added in the UI designer.

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using ClickNDone.Core;


namespace ClickNDone.iOS
{
	public partial class TermsConditionsController : UIViewController
	{
		public TermsConditionsController ()
		{
			System.Diagnostics.Debug.Write ("Init this shit");
		}

		readonly TermsConditionsViewModel termsViewModel = (TermsConditionsViewModel)DependencyInjectionWrapper.Instance.ServiceContainer ().GetService (typeof(TermsConditionsViewModel));

		public override async void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			try 
			{
				var terms = await termsViewModel.GetTermsConditions();
				textTerms.Text = terms.terms;
				textConditions.Text = terms.conditions;
			}
			catch (Exception exc)
			{
				new UIAlertView("**Oops!", exc.Message, null, "Ok").Show();
			}
		}

		public TermsConditionsController (IntPtr handle) : base (handle)
		{

		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(false);
			termsViewModel.IsBusyChanged += OnIsBusyChanged;
		}
		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(false);
			termsViewModel.IsBusyChanged -= OnIsBusyChanged;
		}

		void OnIsBusyChanged(object sender, EventArgs e)
		{
			indicator.Hidden = !termsViewModel.IsBusy;
		}
	}
}
