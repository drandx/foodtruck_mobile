using System;
using MonoTouch.UIKit;
using System.Collections.Generic;
using MonoTouch.Foundation;

namespace DInteractive.iOS
{
	public class ServiceCategoriesTableSource : UITableViewSource
	{

		String[] dummyData;
		static readonly string categoryCellId = "CategoryCell";

		public ServiceCategoriesTableSource ()
		{
			dummyData = new string[3];
			dummyData[0] = "Home Soluttions";
			dummyData[1] = "Pies";
			dummyData[2] = "Manos";


		}
		public override int RowsInSection (UITableView tableview, int section)
		{
			return 3;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			new UIAlertView ("Speaker Selected", dummyData[indexPath.Row], null, "OK", null).Show ();
			tableView.DeselectRow (indexPath, true);
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (categoryCellId);

			if (cell == null)
				cell = new UITableViewCell (UITableViewCellStyle.Subtitle, categoryCellId);

			cell.TextLabel.Text = dummyData[indexPath.Row];

			return cell;
		}
	}
}

