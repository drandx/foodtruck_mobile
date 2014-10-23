using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Drawing;

namespace ClickNDone.iOS
{
	public class MyViewController : UIViewController
	{
		private UIView activeview;
		// Controller that activated the keyboard
		private float scroll_amount = 0.0f;
		// amount to scroll
		private float bottom = 0.0f;
		// bottom point
		private float offset = 10.0f;
		// extra offset
		private bool moveViewUp = false;
		// which direction are we moving

		public MyViewController (IntPtr handle) : base (handle)
		{
		}

		public void LoadLeftbarButton ()
		{
			var bbi = new UIBarButtonItem (UIImage.FromBundle ("images/slideout.png"), UIBarButtonItemStyle.Plain, (sender, e) => {
				MainPageController.navigation.ToggleMenu ();
			});
			NavigationItem.SetLeftBarButtonItem (bbi, false);
		}


		public override void TouchesBegan (MonoTouch.Foundation.NSSet touches, UIEvent evt)
		{
			base.TouchesBegan (touches, evt);
			this.View.EndEditing (true);
		}


		#region Keyboard scrolling

		public void AddKeyboarListeners ()
		{

			// Keyboard popup
			NSNotificationCenter.DefaultCenter.AddObserver
			(UIKeyboard.DidShowNotification, KeyBoardUpNotification);

			// Keyboard Down
			NSNotificationCenter.DefaultCenter.AddObserver
			(UIKeyboard.WillHideNotification, KeyBoardDownNotification);
		}

		private void KeyBoardUpNotification (NSNotification notification)
		{

			try {
				// get the keyboard size
				var val = new NSValue (notification.UserInfo.ValueForKey (UIKeyboard.FrameBeginUserInfoKey).Handle);
				RectangleF r = val.RectangleFValue;

				// Find what opened the keyboard
				foreach (UIView view in this.View.Subviews) {
					if (view.IsFirstResponder)
						activeview = view;
				}

				// Bottom of the controller = initial position + height + offset      

				bottom = (activeview.Frame.Y + activeview.Frame.Height + offset); //TODO - Crashes right here!!!

				// Calculate how far we need to scroll
				scroll_amount = (r.Height - (View.Frame.Size.Height - bottom));

				// Perform the scrolling
				if (scroll_amount > 0) {
					moveViewUp = true;
					ScrollTheView (moveViewUp);
				} else {
					moveViewUp = false;
				}
			} catch (Exception exc) {
				//new UIAlertView ("Oops!", exc.Message, null, "Ok").Show ();
			}

		}

		private void KeyBoardDownNotification (NSNotification notification)
		{
			if (moveViewUp) {
				ScrollTheView (false);
			}
		}

		private void ScrollTheView (bool move)
		{

			// scroll the view up or down
			UIView.BeginAnimations (string.Empty, System.IntPtr.Zero);
			UIView.SetAnimationDuration (0.3);

			RectangleF frame = View.Frame;

			if (move) {
				frame.Y -= this.scroll_amount;
			} else {
				frame.Y += this.scroll_amount;
				this.scroll_amount = 0;
			}

			View.Frame = frame;
			UIView.CommitAnimations ();
		}

		#endregion
	}
}

