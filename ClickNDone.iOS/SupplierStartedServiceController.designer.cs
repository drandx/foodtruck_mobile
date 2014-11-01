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
	[Register ("SupplierStartedServiceController")]
	partial class SupplierStartedServiceController
	{
		[Outlet]
		MonoTouch.UIKit.UIActivityIndicatorView indicator { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblCancel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblNotCancel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtClickCode { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtDate { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtState { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtUserLastName { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtUserName { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (indicator != null) {
				indicator.Dispose ();
				indicator = null;
			}

			if (lblCancel != null) {
				lblCancel.Dispose ();
				lblCancel = null;
			}

			if (lblNotCancel != null) {
				lblNotCancel.Dispose ();
				lblNotCancel = null;
			}

			if (txtDate != null) {
				txtDate.Dispose ();
				txtDate = null;
			}

			if (txtState != null) {
				txtState.Dispose ();
				txtState = null;
			}

			if (txtUserLastName != null) {
				txtUserLastName.Dispose ();
				txtUserLastName = null;
			}

			if (txtUserName != null) {
				txtUserName.Dispose ();
				txtUserName = null;
			}

			if (txtClickCode != null) {
				txtClickCode.Dispose ();
				txtClickCode = null;
			}
		}
	}
}
