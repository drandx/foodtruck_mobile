// This file has been autogenerated from a class added in the UI designer.

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using DInteractive.Core;

namespace DInteractive.iOS
{
	public partial class SupplierRateServiceController : MyViewController
	{
		readonly OrdersModel ordersModel = (OrdersModel)DependencyInjectionWrapper.Instance.ServiceContainer ().GetService (typeof(OrdersModel));


		public SupplierRateServiceController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.AddKeyboarListeners ();
			this.NavigationItem.SetHidesBackButton (true, false);

			try {

				txtUserName.Text = ordersModel.RequestedOrder.User.names;
				txtUserLastName.Text = ordersModel.RequestedOrder.User.surnames;

			} catch (Exception exc) {
				Console.WriteLine("Error relacionado con ordersModel.RequestedOrder " + exc.Message);
			}


		}

	}
}
