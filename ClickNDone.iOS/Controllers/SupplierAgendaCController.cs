// This file has been autogenerated from a class added in the UI designer.

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using DInteractive.Core;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace DInteractive.iOS
{
	public partial class SupplierAgendaCController : MyViewController
	{
		readonly OrdersModel ordersModel = (OrdersModel)DependencyInjectionWrapper.Instance.ServiceContainer ().GetService (typeof(OrdersModel));
		readonly UserModel userModel = (UserModel)DependencyInjectionWrapper.Instance.ServiceContainer ().GetService (typeof(UserModel));


		private float scrollBtnCursor = 0f;
		private float buttonHeight = 35.0f;
		private float scrollerHeigt = 0.0f;
		private bool movedToChild = false;


		public SupplierAgendaCController (IntPtr handle) : base (handle)
		{
		}

		public async Task<bool> LoadMenuItems()
		{
			var scrollerSubviews = this.scrollerAgenda.Subviews;
			foreach (UIView subView in scrollerSubviews) {
				subView.RemoveFromSuperview ();
			}
			scrollBtnCursor = 0.0f;
			scrollerHeigt = 0.0f;

			try {
				var requesterOrders = await ordersModel.GetOrdersListAsync (userModel.User.id, ServiceState.CONFIRMADO, userModel.UserType);
				ordersModel.SupplierAgenda = requesterOrders;

				foreach(Order item in requesterOrders)
				{
					UIButton btn = this.CreateButton (item.Id,item.Id + " - " +item.GetReservationDate());
					this.scrollerAgenda.Add (btn);
				}

				SizeF scrollerSize = new SizeF ();
				float heightSize = this.scrollerHeigt * 1.5f;
				scrollerSize.Height = heightSize;
				scrollerSize.Width = 300;
				this.scrollerAgenda.ContentSize = scrollerSize;

				return true;
			}
			catch (Exception exc) {
				Console.WriteLine("Error relacionado con ordersModel.GetOrdersListAsync " + exc.Message);
				return false;
			}
		}

		public override async void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			Console.WriteLine ("Did Appear MovingFromParent: %%%"+IsMovingFromParentViewController.ToString () + " "+IsMovingFromParentViewController.ToString());
			if (!movedToChild) {
				await this.LoadMenuItems ();
			}
			movedToChild = false;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.AddKeyboarListeners ();
			this.LoadLeftbarButton ();
		}

		private void handler(Object sender, EventArgs args)
		{
			UIButton selectedOrder = (UIButton)sender;
			ordersModel.RequestedOrder = ordersModel.SupplierAgenda.Where (a => a.Id == selectedOrder.Tag).First();

			if (userModel.User.userType.Equals (UserType.SUPPLIER)) {
				PerformSegue ("OnServiceDetail", this);
			} else if (userModel.User.userType.Equals (UserType.CONSUMER)) {
				PerformSegue ("OnServiceConsumerDetail", this);
			}

			movedToChild = true;
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
			Console.WriteLine ("IsMovingToParentViewController ***"+IsMovingToParentViewController.ToString());

		}

		void OnIsBusyChanged(object sender, EventArgs e)
		{				
			indicator.Hidden = !ordersModel.IsBusy;
		}


		/**
		 *
		 *
		 * 
		 * */
		private UIButton CreateButton(int catId,string title)
		{
			var x = UIScreen.MainScreen.Bounds.Width;
			UIButton button = UIButton.FromType(UIButtonType.RoundedRect);

			RectangleF rect = new RectangleF(x*0.2f, this.scrollBtnCursor, x*0.6f, this.buttonHeight);
			button.Frame = rect;
			button.SetTitle(title, UIControlState.Normal);
			button.Tag = catId;
			UIColor borderColor = UIColor.FromRGB (0,167,229);
			UIColor ButtonBackgroundColor = UIColor.White;

			this.scrollBtnCursor = rect.Location.Y + 45f;
			this.scrollerHeigt = this.scrollerHeigt + this.buttonHeight;

			try
			{
				var path = UIBezierPath.FromRect(rect);
				ButtonBackgroundColor.SetFill();
				path.Fill();

				button.CurrentTitleColor.SetStroke();
				path.Stroke();

				button.Layer.BorderColor = borderColor.CGColor;
				button.Layer.BorderWidth = 2f;

				button.TouchDown += handler;

				return button;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error in SevenButton > Draw : {0}\n",ex.Message);
			}

			return null;

		}

		public override void ToggleMenuHandler()
		{
			Console.WriteLine ("**Toggle Pressed");
		}



	}
}