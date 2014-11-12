
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ClickNDone.Core;

namespace ClickNDone.Droid
{
	[Application(Theme = "@android:style/Theme.Holo.Light")]		
	public class Application : Android.App.Application
	{
		public Application(IntPtr javaReference, JniHandleOwnership transfer): base(javaReference, transfer)
		{

		}

		public override void OnCreate()
		{
			base.OnCreate ();

			//View Settings
			DependencyInjectionWrapper.Instance.ServiceContainer ().AddService (typeof(ISettings),new Settings());
			DependencyInjectionWrapper.Instance.ServiceContainer ().AddService (typeof(IWebService),new RESTWebServices());

			//ViewModels
			DependencyInjectionWrapper.Instance.ServiceContainer ().AddService (typeof(UserModel),new UserModel());
			DependencyInjectionWrapper.Instance.ServiceContainer ().AddService (typeof(CategoriesModel),new CategoriesModel());


		}
	}

}
