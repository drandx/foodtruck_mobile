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
	[Register ("ConfirmedServiceController")]
	partial class ConfirmedServiceController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnCancel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnEndServcie { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView imgCat { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIActivityIndicatorView indicator { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblRanking { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblSubCategory { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtClickCode { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtPrice { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtServiceDate { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtServiceTime { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtState { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtSupplerName { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtSurNames { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtUpplierPhone { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnCancel != null) {
				btnCancel.Dispose ();
				btnCancel = null;
			}

			if (btnEndServcie != null) {
				btnEndServcie.Dispose ();
				btnEndServcie = null;
			}

			if (indicator != null) {
				indicator.Dispose ();
				indicator = null;
			}

			if (lblRanking != null) {
				lblRanking.Dispose ();
				lblRanking = null;
			}

			if (lblSubCategory != null) {
				lblSubCategory.Dispose ();
				lblSubCategory = null;
			}

			if (txtClickCode != null) {
				txtClickCode.Dispose ();
				txtClickCode = null;
			}

			if (txtPrice != null) {
				txtPrice.Dispose ();
				txtPrice = null;
			}

			if (txtServiceDate != null) {
				txtServiceDate.Dispose ();
				txtServiceDate = null;
			}

			if (txtServiceTime != null) {
				txtServiceTime.Dispose ();
				txtServiceTime = null;
			}

			if (txtState != null) {
				txtState.Dispose ();
				txtState = null;
			}

			if (txtSupplerName != null) {
				txtSupplerName.Dispose ();
				txtSupplerName = null;
			}

			if (txtSurNames != null) {
				txtSurNames.Dispose ();
				txtSurNames = null;
			}

			if (txtUpplierPhone != null) {
				txtUpplierPhone.Dispose ();
				txtUpplierPhone = null;
			}

			if (imgCat != null) {
				imgCat.Dispose ();
				imgCat = null;
			}
		}
	}
}
