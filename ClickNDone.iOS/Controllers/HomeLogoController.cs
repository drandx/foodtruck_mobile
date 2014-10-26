// This file has been autogenerated from a class added in the UI designer.

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using ClickNDone.Core;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace ClickNDone.iOS
{
	public partial class HomeLogoController : MyViewController
	{

		readonly UserModel loginViewModel = (UserModel)DependencyInjectionWrapper.Instance.ServiceContainer ().GetService (typeof(UserModel));
		readonly OrdersModel ordersModel = (OrdersModel)DependencyInjectionWrapper.Instance.ServiceContainer ().GetService (typeof(OrdersModel));


		public HomeLogoController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.LoadLeftbarButton ();

			if (loginViewModel.UserType.Equals (UserType.CONSUMER)) {
			} 
			else 
			{
				int taskID = UIApplication.SharedApplication.BeginBackgroundTask (() => {});
				new Task (() => {
					DoWork ();
					UIApplication.SharedApplication.EndBackgroundTask (taskID);
					//UIApplication.SharedApplication.BeginInvokeOnMainThread(LoadUIController);
				}).Start ();
			}
		}

		private void LoadUIController()
		{
			var controller = Storyboard.InstantiateViewController("SupplierServiceController") as UIViewController;
			PresentViewController (controller,true,null);
		}

		private void DoWork()
		{
			//Timer Code Starts Here
			OrderStateTimer timerState = new OrderStateTimer();
			TimerCallback timerDelegate = new TimerCallback(CheckStatus);
			Timer timer = new Timer(timerDelegate, timerState, 10000, Constants.GET_ORDER_STATUS_WAIT_TIME);
			timerState.tmr = timer;
			while (timerState.tmr != null)
				Thread.Sleep(0);
			Console.WriteLine("Timer done.");
			//Ends Timer Code
		}

		void CheckStatus(Object state) {
			OrderStateTimer s = (OrderStateTimer) state;
			try
			{
				var ordersList = ordersModel.GetOrdersList(9,ServiceState.RECHAZADO_USUARIO,UserType.CONSUMER);
				var result = ordersList.Where(c => c.Status.Equals(ServiceState.ABIERTO));
				Console.WriteLine("Running TimeOut Cycle: " + s.AttemptsCount);
				if((result.Count() > 0) || (s.AttemptsCount == Constants.GET_ORDER_STATUS_ATTEMPTS))
				{
					Console.WriteLine("disposing of timer...");

					if(result.Count() > 0){
						ordersModel.RequestedOrder = result.First();
						var requesterUser = loginViewModel.GetUser(ordersModel.RequestedOrder.UserId, UserType.CONSUMER);
						ordersModel.RequestedOrder.User = requesterUser;
					}

					s.tmr.Dispose();
					s.tmr = null;
				}
				s.AttemptsCount++;
			}
			catch (Exception exc)
			{
				new UIAlertView("Oops!", exc.Message, null, "Ok").Show();
			}
		}



	}
}
