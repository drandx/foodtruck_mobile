using System;
using MonoTouch.Dialog;
using MonoTouch.UIKit;

namespace DInteractive.iOS
{

	public class MyImageStringElement : ImageStringElement
	{
		UIImage currentImage;
		UITableViewCell currentCell;
		Boolean hidden;

		public MyImageStringElement (string caption, UIImage image, Boolean hidden) : base (caption, image)
		{
			currentImage = image;
			this.hidden = hidden;
		}
			
		public override UITableViewCell GetCell (UITableView tv)     
		{         
			UIColor bgColor = UIColor.FromRGB (0,167,229);
			var cell = base.GetCell (tv);
			cell.BackgroundColor = bgColor;
			cell.ImageView.Image = currentImage; 
			cell.Layer.Hidden = this.hidden;
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

