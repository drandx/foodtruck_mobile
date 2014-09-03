using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.ComponentModel.Design;
using ClickNDone.Core;
using FlyoutNavigation;

namespace ClickNDone.iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		public override UIWindow Window {
			get;
			set;
		}

		public static string _deviceToken="ggggg";
		private ISettings deviceSettinigs;
		
		// This method is invoked when the application is about to move from active to inactive state.
		// OpenGL applications should use this method to pause.
		public override void OnResignActivation (UIApplication application)
		{
		}
		
		// This method should be used to release shared resources and it should store the application state.
		// If your application supports background exection this method is called instead of WillTerminate
		// when the user quits.
		public override void DidEnterBackground (UIApplication application)
		{
		}
		
		// This method is called as part of the transiton from background to active state.
		public override void WillEnterForeground (UIApplication application)
		{
		}
		
		// This method is called when the application is about to terminate. Save data, if needed.
		public override void WillTerminate (UIApplication application)
		{
		}

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			//Styles
			Helper.setAppearances ();
			deviceSettinigs = new IOSSettings ();
			//TODO-temporary solution for debugging
			deviceSettinigs.DeviceToken = _deviceToken;

			//View Settings
			DependencyInjectionWrapper.Instance.ServiceContainer ().AddService (typeof(ISettings),deviceSettinigs);
			DependencyInjectionWrapper.Instance.ServiceContainer ().AddService (typeof(IWebService),new RESTWebServices());

			//ViewModels
			DependencyInjectionWrapper.Instance.ServiceContainer ().AddService (typeof(UserModel),new UserModel());
			DependencyInjectionWrapper.Instance.ServiceContainer ().AddService (typeof(TermsConditionsViewModel),new TermsConditionsViewModel());
			DependencyInjectionWrapper.Instance.ServiceContainer ().AddService (typeof(CategoriesModel),new CategoriesModel());
			DependencyInjectionWrapper.Instance.ServiceContainer ().AddService (typeof(OrdersModel),new OrdersModel());

			//Push Notifications
			UIRemoteNotificationType notificationTypes = UIRemoteNotificationType.Alert | UIRemoteNotificationType.Badge;
			UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(notificationTypes);

			return true;

		}

		public override void RegisteredForRemoteNotifications (UIApplication application, NSData deviceToken)
		{
			//TODO-Remove this property (_deviceToken)
			_deviceToken = deviceToken.ToString();
			deviceSettinigs.DeviceToken = deviceToken.ToString ();
			// code to register with your server application goes here
		}

		public override void FailedToRegisterForRemoteNotifications (UIApplication application , NSError error)
		{
			new UIAlertView("Error registering push notifications", error.LocalizedDescription, null, "OK", null).Show();
		}


	}
}

