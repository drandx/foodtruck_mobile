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
	[Register ("CancelServiceController")]
	partial class CancelServiceController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnCancelConfirm { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnNotCancel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIActivityIndicatorView indicator { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblMsgText1 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblMsgText2 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblRanking { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtClickCode { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtLastName { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtName { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtState { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblMsgText1 != null) {
				lblMsgText1.Dispose ();
				lblMsgText1 = null;
			}

			if (lblMsgText2 != null) {
				lblMsgText2.Dispose ();
				lblMsgText2 = null;
			}

			if (btnCancelConfirm != null) {
				btnCancelConfirm.Dispose ();
				btnCancelConfirm = null;
			}

			if (btnNotCancel != null) {
				btnNotCancel.Dispose ();
				btnNotCancel = null;
			}

			if (txtClickCode != null) {
				txtClickCode.Dispose ();
				txtClickCode = null;
			}

			if (txtState != null) {
				txtState.Dispose ();
				txtState = null;
			}

			if (lblRanking != null) {
				lblRanking.Dispose ();
				lblRanking = null;
			}

			if (txtName != null) {
				txtName.Dispose ();
				txtName = null;
			}

			if (txtLastName != null) {
				txtLastName.Dispose ();
				txtLastName = null;
			}

			if (indicator != null) {
				indicator.Dispose ();
				indicator = null;
			}
		}
	}
}
