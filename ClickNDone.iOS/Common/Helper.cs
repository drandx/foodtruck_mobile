using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace ClickNDone.iOS
{
	public class Helper
	{
		public Helper ()
		{

		}

		public static void setAppearances()
		{
			UIImage barImage = UIImage.FromFile("images/header@2x.png");
			UINavigationBar.Appearance.SetBackgroundImage (barImage,UIBarMetrics.Default);
		}

	}
}

