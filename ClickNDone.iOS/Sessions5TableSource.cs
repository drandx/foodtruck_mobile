using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using DInteractive.Core;

namespace DInteractive
{
	public class SessionsTableSource : UITableViewSource
	{		
		static readonly string sessionCellId = "SessionCell";
		List<BusinessCategory> data;
		IGrouping<int, BusinessCategory>[] grouping; // sub-group of speakers in each index
		
		public SessionsTableSource (List<BusinessCategory> sessions)
		{
			data = sessions;
		}
		
		public override int RowsInSection (UITableView tableview, int section)
		{
			return grouping[section].Count ();
		}
		
		public override int NumberOfSections (UITableView tableView)
		{
			return grouping.Count ();
		}
		
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var sessionGroup = grouping [indexPath.Section];
			var session = sessionGroup.ElementAt (indexPath.Row);
			
			new UIAlertView ("Session Selected", session.Title, null, "OK", null).Show ();
			
			tableView.DeselectRow (indexPath, true);
		}
		
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var sessionGroup = grouping [indexPath.Section];
			var session = sessionGroup.ElementAt (indexPath.Row);

			//TODO: Demo5: remove this code that uses a Default cell style
			var cell = tableView.DequeueReusableCell (sessionCellId);
			if (cell == null)
				cell = new UITableViewCell (UITableViewCellStyle.Default, sessionCellId);
			cell.TextLabel.Text = session.Title;

			//TODO: Demo5: need to cast the dequeued cell to our custom type, and create new instances of the custom type
//			var cell = (SessionCell)tableView.DequeueReusableCell (sessionCellId);
//			if (cell == null)
//				cell = new SessionCell (sessionCellId);	
//			cell.Session = session;
			
			return cell;
		}

	} 
}

