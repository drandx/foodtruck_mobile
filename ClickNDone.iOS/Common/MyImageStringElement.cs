using System;
using MonoTouch.Dialog;
using MonoTouch.UIKit;

namespace ClickNDone.iOS
{

	public class MyImageStringElement : ImageStringElement
	{
		UIImage currentImage;
		UITableViewCell currentCell;

		public MyImageStringElement (string caption, UIImage image) : base (caption, image)
		{
			currentImage = image;
		}
			
		public override UITableViewCell GetCell (UITableView tv)     
		{         
			UIColor bgColor = UIColor.FromRGB (0,167,229);
			var cell = base.GetCell (tv);
			cell.BackgroundColor = bgColor;
			cell.ImageView.Image = currentImage; 
			currentCell = cell;
			return currentCell;
		}

		public void SetImage (UIImage image)
		{
			currentImage = image;
			if (currentCell != null)
				currentCell.ImageView.Image = currentImage;
		}
	}
}

