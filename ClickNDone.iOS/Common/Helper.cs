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
			UIImage barImage = UIImage.FromFile("images/header2.png");
			UIImage barToolImage = UIImage.FromFile("images/barra_copyright@2x.png");
			UINavigationBar.Appearance.SetBackgroundImage (barImage,UIBarMetrics.Default);

			UIToolbar.Appearance.SetBackgroundImage (barToolImage, UIToolbarPosition.Bottom, UIBarMetrics.Default);
		}

	}
}

