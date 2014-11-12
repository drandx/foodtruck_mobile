using System;
using MonoTouch.UIKit;
using System.Drawing;

namespace DInteractive.iOS
{
	[MonoTouch.Foundation.Register ("MyUIButton")]
	public class MyUIButton : UIButton
	{
		public MyUIButton (IntPtr handle) : base (handle)
		{

		}

		public override void Draw(RectangleF rect)
		{
			UIColor borderColor = UIColor.FromRGB (0,167,229);
			UIColor ButtonBackgroundColor = UIColor.White;

			try
			{
				var path = UIBezierPath.FromRect(rect);

				ButtonBackgroundColor.SetFill();
				path.Fill();

				CurrentTitleColor.SetStroke();
				path.Stroke();

			}
			catch (Exception ex)
			{
				Console.WriteLine("Error in SevenButton > Draw : {0}\n",ex.Message);
			}

			this.Layer.BorderColor = borderColor.CGColor;
			this.Layer.BorderWidth = 2f;
		}

	}
}

