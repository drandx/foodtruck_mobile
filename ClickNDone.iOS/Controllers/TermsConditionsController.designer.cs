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
	[Register ("TermsConditionsController")]
	partial class TermsConditionsController
	{
		[Outlet]
		MonoTouch.UIKit.UIActivityIndicatorView indicator { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextView textConditions { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextView textTerms { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (indicator != null) {
				indicator.Dispose ();
				indicator = null;
			}

			if (textTerms != null) {
				textTerms.Dispose ();
				textTerms = null;
			}

			if (textConditions != null) {
				textConditions.Dispose ();
				textConditions = null;
			}
		}
	}
}
