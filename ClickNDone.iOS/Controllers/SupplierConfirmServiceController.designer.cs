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
	[Register ("SupplierConfirmServiceController")]
	partial class SupplierConfirmServiceController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnCancelService { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnEnterCode { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnEnterCode != null) {
				btnEnterCode.Dispose ();
				btnEnterCode = null;
			}

			if (btnCancelService != null) {
				btnCancelService.Dispose ();
				btnCancelService = null;
			}
		}
	}
}
