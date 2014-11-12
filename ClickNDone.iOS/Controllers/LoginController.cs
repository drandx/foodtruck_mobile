// This file has been autogenerated from a class added in the UI designer.

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using DInteractive.Core;

namespace DInteractive.iOS
{
	public partial class LoginController : MyViewController
	{
		readonly UserModel loginViewModel = (UserModel)DependencyInjectionWrapper.Instance.ServiceContainer ().GetService (typeof(UserModel));
	
		public LoginController (IntPtr handle) : base (handle)
		{

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

		}
			
		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(false);
			loginViewModel.IsBusyChanged += OnIsBusyChanged;
		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(false);
			loginViewModel.IsBusyChanged -= OnIsBusyChanged;
		}

		void OnIsBusyChanged(object sender, EventArgs e)
		{
			txtEmail.Enabled = 
			txtPassword.Enabled =
					btnLogIn.Enabled =
						indicator.Hidden = !loginViewModel.IsBusy;
		}

	}
}
