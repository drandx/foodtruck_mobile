// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace DInteractive.iOS
{
	[Register ("SupplierServiceController")]
	partial class SupplierServiceController
	{
		[Outlet]
		MonoTouch.UIKit.UIActivityIndicatorView indicator { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblAcceptService { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblRejectService { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtAddress { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtDate { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtReference { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtTime { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtUserLastName { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtUserName { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtUserRanking { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblAcceptService != null) {
				lblAcceptService.Dispose ();
				lblAcceptService = null;
			}

			if (lblRejectService != null) {
				lblRejectService.Dispose ();
				lblRejectService = null;
			}

			if (txtAddress != null) {
				txtAddress.Dispose ();
				txtAddress = null;
			}

			if (txtDate != null) {
				txtDate.Dispose ();
				txtDate = null;
			}

			if (txtReference != null) {
				txtReference.Dispose ();
				txtReference = null;
			}

			if (txtTime != null) {
				txtTime.Dispose ();
				txtTime = null;
			}

			if (txtUserLastName != null) {
				txtUserLastName.Dispose ();
				txtUserLastName = null;
			}

			if (txtUserName != null) {
				txtUserName.Dispose ();
				txtUserName = null;
			}

			if (txtUserRanking != null) {
				txtUserRanking.Dispose ();
				txtUserRanking = null;
			}

			if (indicator != null) {
				indicator.Dispose ();
				indicator = null;
			}
		}
	}
}
