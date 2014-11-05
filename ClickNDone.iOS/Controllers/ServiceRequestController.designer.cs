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
	[Register ("ServiceRequestController")]
	partial class ServiceRequestController
	{
		[Outlet]
		MonoTouch.UIKit.UIImageView imgCat { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIActivityIndicatorView indicator { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblSubCategory { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (indicator != null) {
				indicator.Dispose ();
				indicator = null;
			}

			if (lblSubCategory != null) {
				lblSubCategory.Dispose ();
				lblSubCategory = null;
			}

			if (imgCat != null) {
				imgCat.Dispose ();
				imgCat = null;
			}
		}
	}
}
