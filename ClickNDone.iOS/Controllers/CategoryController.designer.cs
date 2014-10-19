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
	[Register ("CategoryController")]
	partial class CategoryController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnBeauty { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnHome { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnBeauty != null) {
				btnBeauty.Dispose ();
				btnBeauty = null;
			}

			if (btnHome != null) {
				btnHome.Dispose ();
				btnHome = null;
			}
		}
	}
}
