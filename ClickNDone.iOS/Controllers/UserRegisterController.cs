// This file has been autogenerated from a class added in the UI designer.

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using ClickNDone.Core;

namespace ClickNDone.iOS
{
	public partial class UserRegisterController : UIViewController
	{
		readonly UserModel userModel = (UserModel)DependencyInjectionWrapper.Instance.ServiceContainer ().GetService (typeof(UserModel));

		public UserRegisterController (IntPtr handle) : base (handle)
		{

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			btnRegister.TouchUpInside += async(sender, e) =>
			{
				userModel.Password = txtPassword.Text;
				userModel.Email = txtEmail.Text;
				userModel.LastName = txtLastName.Text;
				userModel.Image = "http://digitalinteractive.co/site/";
				userModel.Name = txtName.Text;
				userModel.PhoneNumber = txtPhoneNumber.Text;

				try {
					await userModel.Register();
					new UIAlertView("Felicitaciones!", "Se ha registrado con exito", null, "Aceptar").Show();
				}
				catch (Exception exc)
				{
					new UIAlertView("Oops!", "El telefono o email ya se encuentran registrados.", null, "Ok").Show();
				}
			};


			btnClear.TouchUpInside += (sender, e) => 
			{
				ClearFields();

			};

		}

		private void ClearFields()
		{
			txtEmail.Text = "";
			txtImage.Text = "";
			txtLastName.Text = "";
			txtName.Text = "";
			txtPhoneNumber.Text = "";
		}

		public override void TouchesBegan (MonoTouch.Foundation.NSSet touches, UIEvent evt)
		{
			base.TouchesBegan (touches, evt);
			this.View.EndEditing (true);
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(false);
			userModel.IsBusyChanged += OnIsBusyChanged;
		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(false);
			userModel.IsBusyChanged -= OnIsBusyChanged;
		}

		void OnIsBusyChanged(object sender, EventArgs e)
		{
			txtEmail.Enabled = 
				txtImage.Enabled =
					txtLastName.Enabled = 
						txtName.Enabled = 
							txtPhoneNumber.Enabled = 
								btnClear.Enabled = 
									btnRegister.Enabled = 
										indicator.Hidden = !userModel.IsBusy;
		}

	}
}
