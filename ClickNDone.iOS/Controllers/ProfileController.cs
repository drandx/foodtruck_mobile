// This file has been autogenerated from a class added in the UI designer.

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using DInteractive.Core;

namespace DInteractive.iOS
{
	public partial class ProfileController : MyViewController
	{
		readonly UserModel UserModel = (UserModel)DependencyInjectionWrapper.Instance.ServiceContainer ().GetService (typeof(UserModel));

		public ProfileController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.AddKeyboarListeners ();
			this.LoadLeftbarButton ();
			var user = UserModel.User;
			this.txtEmail.Text = user.email;
			this.txtName.Text = user.names;
			this.txtPassword.Text = user.password;
			this.txtPhoneNumber.Text = user.mobile;
			this.txtLastName.Text = user.surnames;
		}

	}
}
