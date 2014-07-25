using System;
using MonoTouch.UIKit;

namespace ClickNDone.iOS
{
	[MonoTouch.Foundation.Register ("MyUITextField")]
	public class MyUITextField : UITextField
	{
		public MyUITextField (IntPtr handle) : base (handle)
		{
			UIColor borderColor = UIColor.FromRGB (0,167,229);
			this.Layer.BorderColor = borderColor.CGColor;
			this.Layer.BorderWidth = 2f;
		}
	}
}

