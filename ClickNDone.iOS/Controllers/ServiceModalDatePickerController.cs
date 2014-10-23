// This file has been autogenerated from a class added in the UI designer.

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SharpMobileCode.ModalPicker;

namespace ClickNDone.iOS
{
	public partial class ServiceModalDatePickerController : MyViewController
	{
		private DateTime[] _customDates;
		private DateTime selectedDate;


		public ServiceModalDatePickerController (IntPtr handle) : base (handle)
		{
			Initialize();
		}

		private void Initialize()
		{
			_customDates = new DateTime[] 
			{ 
				DateTime.Now, DateTime.Now.AddDays(7), DateTime.Now.AddDays(7*2), 
				DateTime.Now.AddDays(7*3), DateTime.Now.AddDays(7*4), DateTime.Now.AddDays(7*5),
				DateTime.Now.AddDays(7*6), DateTime.Now.AddDays(7*7), DateTime.Now.AddDays(7*8),
				DateTime.Now.AddDays(7*9), DateTime.Now.AddDays(7*10), DateTime.Now.AddDays(7*11), 
				DateTime.Now.AddDays(7*12), DateTime.Now.AddDays(7*13), DateTime.Now.AddDays(7*14)
			};

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.AddKeyboarListeners ();

			//Date Selector
			UITapGestureRecognizer labelTap = new UITapGestureRecognizer(() => {
				DatePickerButtonTapped ();
			});
			UITapGestureRecognizer labelDayTap = new UITapGestureRecognizer(() => {
				DatePickerButtonTapped ();
			});
			UITapGestureRecognizer labelYearTap = new UITapGestureRecognizer(() => {
				DatePickerButtonTapped ();
			});
			lblMonth.UserInteractionEnabled = true;
			lblMonth.AddGestureRecognizer(labelTap);

			lblDay.UserInteractionEnabled = true;
			lblDay.AddGestureRecognizer(labelDayTap);

			lblYear.UserInteractionEnabled = true;
			lblYear.AddGestureRecognizer(labelYearTap);
		}

		async void DatePickerButtonTapped ()
		{
			var modalPicker = new ModalPickerViewController(ModalPickerType.Date, "Seleccione una Fecha", this)
			{
				HeaderBackgroundColor = UIColor.FromRGB (0,167,229),
				HeaderTextColor = UIColor.White,
				TransitioningDelegate = new ModalPickerTransitionDelegate(),
				ModalPresentationStyle = UIModalPresentationStyle.Custom
			};

			modalPicker.DatePicker.Mode = UIDatePickerMode.Date;

			modalPicker.OnModalPickerDismissed += (s, ea) => 
			{
				NSDate selectedDate = modalPicker.DatePicker.Date;
				var dateTime = DateTime.SpecifyKind(selectedDate, DateTimeKind.Unspecified);
				lblMonth.Text = dateTime.ToString("MMMM");
				lblDay.Text = dateTime.Day.ToString();
				lblYear.Text = dateTime.Year.ToString();
				this.selectedDate = dateTime;

			};

			await PresentViewControllerAsync(modalPicker, true);
		}
	}
}