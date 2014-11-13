using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.MapKit;
using System.Diagnostics;
using MonoTouch.CoreLocation;
using DInteractive.Core;
using System.Threading.Tasks;
using System.Threading;

namespace MappingApp
{
    public partial class MappingAppViewController : UIViewController
    {
		CLLocationManager locationManager = new CLLocationManager ();
		readonly CategoriesModel categoriesModel = (CategoriesModel)DependencyInjectionWrapper.Instance.ServiceContainer ().GetService (typeof(CategoriesModel));
		static int taskId;
		static volatile bool running;
		static MKMapView myMapView = null;

        public MappingAppViewController(IntPtr handle) : base(handle)
        {
			if(myMapView == null)
				myMapView = new MKMapView(UIScreen.MainScreen.Bounds);
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			this.NavigationItem.Title = categoriesModel.SelectedBusinessCategory.Title;

            // Perform any additional setup after loading the view, typically from a nib.

            // add the map view
            View.Add(myMapView);

            // change the map style
            myMapView.MapType = MKMapType.Standard;

            // enable/disable interactions
            myMapView.ZoomEnabled = true;
            myMapView.ScrollEnabled = true;

            // show user location
			if (UIDevice.CurrentDevice.CheckSystemVersion (8, 0)) {
				locationManager.RequestWhenInUseAuthorization();
			}
            myMapView.ShowsUserLocation = true;

            // TODO: Step 3d - specify a custom map delegate
            var mapDelegate = new MyMapDelegate();
            myMapView.Delegate = mapDelegate;

            // Add a point annotation
            //map.AddAnnotation(new MKPointAnnotation()
            //{
                //Title = "MyAnnotation",
               // Coordinate = new MonoTouch.CoreLocation.CLLocationCoordinate2D(42.364260, -71.120824)
            //});

            // TODO: Step 3f - add a custom annotation
            //map.AddAnnotation(new CustomAnnotation("CustomSpot", new MonoTouch.CoreLocation.CLLocationCoordinate2D(38.364260, -68.120824)));

            // TODO: Step 3a - remove old GetViewForAnnotation delegate code to new delegate - we will recreate this next
            // [removed]

			//Centering the Map
			MKCoordinateRegion region;
			MKCoordinateSpan span;
			span.LatitudeDelta = 0.05;
			span.LongitudeDelta = 0.05;
			CLLocationCoordinate2D location;
			location.Latitude = 41.924986;
			location.Longitude = -87.655640;
			region.Span = span;
			region.Center = location;
			myMapView.SetRegion (region, true);

			this.PrintPointOnMapp (myMapView);

			OnStartTask ();

        }

		async void OnStartTask()
		{
			// Stop the task if it's running.
			if (taskId > 0) {
				//Console.WriteLine ("Foodtruck location updates should be activated");
				//Console.WriteLine("Stopping Task...");
				//running = false;
				//taskId = 0;
				return;
			}

			running = true;
			Console.WriteLine ("Foodtruck location updates activated");
			taskId = 1;

			var cts = new CancellationTokenSource();
			taskId = UIApplication.SharedApplication.BeginBackgroundTask("Long-Running Task", () => {
				Console.WriteLine("Task {0} timeout occurred, canceled.", taskId);
				cts.Cancel();
			});

			// Kick off .NET Task to run in the background.
			try {
				await Task.Run(() => {
					for (long count = 1; running == true ; count++) {
						this.BeginInvokeOnMainThread(() => {
							Console.WriteLine("Task {0} running.. {1}", taskId, count);
							var updatedCategory = categoriesModel.GetBusinessCategoryById(categoriesModel.SelectedBusinessCategory.BusinessCategoryID);
							categoriesModel.SelectedBusinessCategory = updatedCategory;
							if(updatedCategory == null)
							{
								Console.WriteLine("updatedCategory List Null");
							}
							else
							{
								this.BeginInvokeOnMainThread(() => {
									Console.WriteLine("Orders List Items Count: "+updatedCategory.AssociatedCompanies.Count);							
								});

								this.PrintPointOnMapp(myMapView);

								/*if((ordersList.Count() > 0))
								{
									ordersModel.RequestedOrder = ordersList.First();
									this.BeginInvokeOnMainThread(() => {
										LoadUIController();
										UIApplication.SharedApplication.EndBackgroundTask(taskId);
										taskId = 0;
										running = false;
									});
								}*/
							}
						});

						cts.Token.ThrowIfCancellationRequested();
						Thread.Sleep(Constants.GET_ORDER_STATUS_WAIT_TIME);
					}
				}, cts.Token);
			}
			catch (OperationCanceledException)
			{
				Console.WriteLine("Task {0} was cancelled.", taskId);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception: {0}", ex.Message);
			}
			finally
			{
				UIApplication.SharedApplication.EndBackgroundTask(taskId);
				taskId = 0;
				running = false;
			}
		}

		private void PrintPointOnMapp(MKMapView map)
		{

			foreach(var an in myMapView.Annotations)
			{
				myMapView.RemoveAnnotation(an);
			}

			foreach(Company company in categoriesModel.SelectedBusinessCategory.AssociatedCompanies)
			{
				Console.WriteLine (company.Title + " Lat:" + company.Latitude + " Long:" + company.Longitude);
				map.AddAnnotation(new CustomAnnotation(company.Title, new MonoTouch.CoreLocation.CLLocationCoordinate2D(company.Latitude, company.Longitude)));

			}

		}

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        #endregion
    }

    // TODO: Step 3b - Setup a map delegate to handle annotations and relative eventing
    class MyMapDelegate : MKMapViewDelegate
    {
        string pId = "PinAnnotation";
        string cId = "CustomAnnotation";

        // TODO: Step 3c - Review new GetViewForAnnotation method that checks for annotation type before returning a view to use
        public override MKAnnotationView GetViewForAnnotation (MKMapView mapView, NSObject annotation)
        {
            MKAnnotationView anView;

            if (annotation is MKUserLocation)
                return null; 

            if (annotation is CustomAnnotation) {

                // show custom annotation
                anView = mapView.DequeueReusableAnnotation (cId);

                if (anView == null)
                    anView = new MKAnnotationView (annotation, cId);

				anView.Image = UIImage.FromFile ("Icon-29.png");
                anView.CanShowCallout = true;
                anView.Draggable = true;
                anView.RightCalloutAccessoryView = UIButton.FromType (UIButtonType.DetailDisclosure);

            } else {

                // show pin annotation
                anView = (MKPinAnnotationView)mapView.DequeueReusableAnnotation (pId);

                if (anView == null)
                    anView = new MKPinAnnotationView (annotation, pId);

                ((MKPinAnnotationView)anView).PinColor = MKPinAnnotationColor.Green;
                anView.CanShowCallout = true;
            }

            return anView;
        }

		/// Because we set anView.Draggable = true; we need to also handle the Ending drag event, or else our annotation will forever be "floating" over the map
		public override void ChangedDragState (MKMapView mapView, MKAnnotationView annotationView, MKAnnotationViewDragState newState, MKAnnotationViewDragState oldState)
		{
			switch (newState) {
			case MKAnnotationViewDragState.Ending:
				annotationView.SetDragState (MKAnnotationViewDragState.None, false);
				break;
			}
		}

        // TODO: Step 3g - Add event handler for accessory being tapped
        public override void CalloutAccessoryControlTapped (MKMapView mapView, MKAnnotationView view, UIControl control)
        {
            var customAn = view.Annotation as CustomAnnotation;

            var alert = new UIAlertView(customAn != null ? "Custom Annotation" : "Generic Annotation", 
                customAn != null ? customAn.Title : "Title Text", 
                null, "OK");

            alert.Show ();
        }

        // TODO: Step 3h - Add event handler for marker being tapped
        public override void DidSelectAnnotationView(MKMapView mapView, MKAnnotationView view)
        {
            //var alert = new UIAlertView("Marker was tapped", "Marker tapped", null, "OK");
            //alert.Show ();
        }
    }
}

