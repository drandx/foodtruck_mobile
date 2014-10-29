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
	[Register ("HomeLogoController")]
	partial class HomeLogoController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnProveedorServico { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnStartTaskt { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnProveedorServico != null) {
				btnProveedorServico.Dispose ();
				btnProveedorServico = null;
			}

			if (btnStartTaskt != null) {
				btnStartTaskt.Dispose ();
				btnStartTaskt = null;
			}
		}
	}
}
