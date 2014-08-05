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
	[Register ("ServiceController")]
	partial class ServiceController
	{
		[Outlet]
		MonoTouch.UIKit.UILabel lblDay { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblMonth { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblYear { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblMonth != null) {
				lblMonth.Dispose ();
				lblMonth = null;
			}

			if (lblDay != null) {
				lblDay.Dispose ();
				lblDay = null;
			}

			if (lblYear != null) {
				lblYear.Dispose ();
				lblYear = null;
			}
		}
	}
}
