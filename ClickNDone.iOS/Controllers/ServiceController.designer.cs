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
		MonoTouch.UIKit.UILabel lblAMPM { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblDay { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblHour { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblMinute { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblMonth { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblYear { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtFromValue { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtToValue { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblAMPM != null) {
				lblAMPM.Dispose ();
				lblAMPM = null;
			}

			if (lblDay != null) {
				lblDay.Dispose ();
				lblDay = null;
			}

			if (lblHour != null) {
				lblHour.Dispose ();
				lblHour = null;
			}

			if (lblMinute != null) {
				lblMinute.Dispose ();
				lblMinute = null;
			}

			if (lblMonth != null) {
				lblMonth.Dispose ();
				lblMonth = null;
			}

			if (lblYear != null) {
				lblYear.Dispose ();
				lblYear = null;
			}

			if (txtFromValue != null) {
				txtFromValue.Dispose ();
				txtFromValue = null;
			}

			if (txtToValue != null) {
				txtToValue.Dispose ();
				txtToValue = null;
			}
		}
	}
}
