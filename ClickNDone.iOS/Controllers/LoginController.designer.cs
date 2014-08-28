// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace ClickNDone.iOS
{
	[Register ("LoginController")]
	partial class LoginController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnLogIn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnRegister { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIActivityIndicatorView indicator { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtEmail { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtPassword { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnLogIn != null) {
				btnLogIn.Dispose ();
				btnLogIn = null;
			}

			if (indicator != null) {
				indicator.Dispose ();
				indicator = null;
			}

			if (txtEmail != null) {
				txtEmail.Dispose ();
				txtEmail = null;
			}

			if (btnRegister != null) {
				btnRegister.Dispose ();
				btnRegister = null;
			}

			if (txtPassword != null) {
				txtPassword.Dispose ();
				txtPassword = null;
			}
		}
	}
}
