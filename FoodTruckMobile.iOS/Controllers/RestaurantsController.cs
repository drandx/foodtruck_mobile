// This file has been autogenerated from a class added in the UI designer.

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using DInteractive.Core;
using System.Drawing;

namespace DInteractive.iOS
{
	public partial class RestaurantsController : UITableViewController
	{

		List<BusinessCategory> restaurants;
		readonly CategoriesModel categoriesModel = (CategoriesModel)DependencyInjectionWrapper.Instance.ServiceContainer ().GetService (typeof(CategoriesModel));

		public RestaurantsController (IntPtr handle) : base (handle)
		{

		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(false);
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			restaurants = categoriesModel.BusinessCategories;
			TableView.Source = new BusinessCategoriesTableSource (restaurants,this);
		}

		public void executeSegue()
		{
			PerformSegue ("OnBusinessCategoryDetail",this);
		}

	}
}
    