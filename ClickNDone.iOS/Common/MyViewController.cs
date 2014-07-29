using System;
using MonoTouch.UIKit;

namespace ClickNDone.iOS
{
	public class MyViewController : UIViewController
	{
		public MyViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			var bbi = new UIBarButtonItem(UIImage.FromBundle("images/slideout.png"), UIBarButtonItemStyle.Plain, (sender, e) => {
				//AppDelegate.FlyoutNav.ToggleMenu();
				MainPageController.navigation.ToggleMenu();
			});
			NavigationItem.SetLeftBarButtonItem (bbi, false);
		}


		public override void TouchesBegan (MonoTouch.Foundation.NSSet touches, UIEvent evt)
		{
			base.TouchesBegan (touches, evt);
			this.View.EndEditing (true);
		}
	}
}

