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
	[Register ("RateServiceController")]
	partial class RateServiceController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnNoSubmit { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnSubmit { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView imgCat { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIActivityIndicatorView indicator { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblSubCategory { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtClickCode { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtComments { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtLastName { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtName { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtRanking { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtStatus { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnNoSubmit != null) {
				btnNoSubmit.Dispose ();
				btnNoSubmit = null;
			}

			if (btnSubmit != null) {
				btnSubmit.Dispose ();
				btnSubmit = null;
			}

			if (indicator != null) {
				indicator.Dispose ();
				indicator = null;
			}

			if (lblSubCategory != null) {
				lblSubCategory.Dispose ();
				lblSubCategory = null;
			}

			if (txtClickCode != null) {
				txtClickCode.Dispose ();
				txtClickCode = null;
			}

			if (txtComments != null) {
				txtComments.Dispose ();
				txtComments = null;
			}

			if (txtLastName != null) {
				txtLastName.Dispose ();
				txtLastName = null;
			}

			if (txtName != null) {
				txtName.Dispose ();
				txtName = null;
			}

			if (txtRanking != null) {
				txtRanking.Dispose ();
				txtRanking = null;
			}

			if (txtStatus != null) {
				txtStatus.Dispose ();
				txtStatus = null;
			}

			if (imgCat != null) {
				imgCat.Dispose ();
				imgCat = null;
			}
		}
	}
}
