using System;
using MonoTouch.CoreLocation;

namespace ClickNDone.iOS
{
	public class LocationManager
	{
		public LocationManager (){
			this.locMgr = new CLLocationManager();
		}

		protected CLLocationManager locMgr;

		public CLLocationManager LocMgr{
			get { return this.locMgr; }
		}

		public void StartLocationUpdates()
		{
			// we need the user’s permission to use GPS, so we check to make sure they’ve accepted
			if (CLLocationManager.LocationServicesEnabled) {
				//set the desired accuracy, in meters
				LocMgr.DesiredAccuracy = 1;
				LocMgr.StartUpdatingLocation();
			} else {
				Console.WriteLine ("Location services not enabled");
			}
		}
	}
}

