// This file has been autogenerated from a class added in the UI designer.

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;
using DInteractive.Core;

namespace ClickNDone.iOS
{
	public partial class PositionTrackerController : UIViewController
	{
		readonly CategoriesModel categoriesModel = (CategoriesModel)DependencyInjectionWrapper.Instance.ServiceContainer ().GetService (typeof(CategoriesModel));
		readonly UserModel userModel = (UserModel)DependencyInjectionWrapper.Instance.ServiceContainer ().GetService (typeof(UserModel));

		public PositionTrackerController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(false);
		}


		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			CLLocationManager locationManager = new CLLocationManager();
			locationManager.StartUpdatingLocation();
			locationManager.StartUpdatingHeading();

			locationManager.LocationsUpdated += async delegate(object sender , CLLocationsUpdatedEventArgs e )
			{
				foreach(CLLocation loc in e.Locations)
				{
					Console.WriteLine(loc.Coordinate.Latitude);
					Console.WriteLine(loc.Coordinate.Longitude);

					try 
					{
						await categoriesModel.PutCompanyAsync(userModel.Email, loc.Coordinate.Latitude, loc.Coordinate.Longitude);
					}
					catch(Exception exc) 
					{
						Console.WriteLine("Error on UserSelectionController - ViewDidLoad " + exc.Message);

					}

				}
			};


		}
	}
}