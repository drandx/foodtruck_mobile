// This file has been autogenerated from a class added in the UI designer.

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using ClickNDone.Core;

namespace ClickNDone.iOS
{
	public partial class SupplierCancelServiceController : MyViewController
	{

		readonly OrdersModel ordersModel = (OrdersModel)DependencyInjectionWrapper.Instance.ServiceContainer ().GetService (typeof(OrdersModel));

		public SupplierCancelServiceController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.NavigationItem.SetHidesBackButton (true, false);

			base.ViewDidLoad ();
			UITapGestureRecognizer labelCancelTap = new UITapGestureRecognizer (async() => {
				await ordersModel.ChangeRequestedOrderStateAsync(ServiceState.CONFIRMADO);
				PerformSegue("OnCancel",this);
			});
			lblCancel.UserInteractionEnabled = true;
			lblCancel.AddGestureRecognizer (labelCancelTap);

			UITapGestureRecognizer labelNotCancelTap = new UITapGestureRecognizer (() => {
				PerformSegue("OnNotCancel",this);
			});
			lblNotCancel.UserInteractionEnabled = true;
			lblNotCancel.AddGestureRecognizer (labelNotCancelTap);

		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(false);
			ordersModel.IsBusyChanged += OnIsBusyChanged;
		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(false);
			ordersModel.IsBusyChanged -= OnIsBusyChanged;
		}

		void OnIsBusyChanged(object sender, EventArgs e)
		{
			lblNotCancel.Enabled =
				lblCancel.Enabled = 
			indicator.Hidden = !ordersModel.IsBusy;
		}
	}
}