using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using DInteractive.Core;
using DInteractive.iOS;

namespace DInteractive
{
	public class BusinessCategoriesTableSource : UITableViewSource
	{		
		static readonly string speakerCellId = "SpeakerCell";
		readonly CategoriesModel categoriesModel = (CategoriesModel)DependencyInjectionWrapper.Instance.ServiceContainer ().GetService (typeof(CategoriesModel));
		List<BusinessCategory> data;
		RestaurantsController controller;

		public BusinessCategoriesTableSource (List<BusinessCategory> speakers, RestaurantsController vc)
		{
			data = speakers;
			controller = vc;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return data.Count;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var businessCategory = data [indexPath.Row];
			categoriesModel.SelectedBusinessCategory = (BusinessCategory)businessCategory;

			// Pass the selected object to the new view controller.
			controller.executeSegue ();
			tableView.DeselectRow (indexPath, true);
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (speakerCellId);

			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Subtitle, speakerCellId);
			}
			var speaker = data [indexPath.Row];

			cell.TextLabel.Text = speaker.Title;
			cell.DetailTextLabel.Text = speaker.Content;
			//TODO - Use to draw a logo
			//cell.ImageView.Image = UIImage.FromBundle(speaker.HeadshotUrl);

			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;

			return cell;
		}

	} 
}

