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
	[Register ("UserSelectionController")]
	partial class UserSelectionController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnCustomer { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnProvider { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnProvider != null) {
				btnProvider.Dispose ();
				btnProvider = null;
			}

			if (btnCustomer != null) {
				btnCustomer.Dispose ();
				btnCustomer = null;
			}
		}
	}
}
