// This file has been autogenerated from a class added in the UI designer.

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using ClickNDone.Core;

namespace ClickNDone.iOS
{
	public partial class LoginController : UIViewController
	{
		readonly UserModel loginViewModel = (UserModel)DependencyInjectionWrapper.Instance.ServiceContainer ().GetService (typeof(UserModel));
	
		public LoginController (IntPtr handle) : base (handle)
		{

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			btnLogIn.TouchUpInside += async(sender, e) =>
			{
				loginViewModel.Username = txtEmail.Text;
				loginViewModel.Password = txtPassword.Text;
				try {
					await loginViewModel.Login();
					PerformSegue("OnLogin", this);
				}
				catch (Exception exc)
				{
					new UIAlertView("Oops!", exc.Message, null, "Ok").Show();
				}
			};
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
