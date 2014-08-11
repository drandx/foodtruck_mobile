// This file has been autogenerated from a class added in the UI designer.

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using FlyoutNavigation;
using MonoTouch.Dialog;
using ClickNDone.Core;

namespace ClickNDone.iOS
{
	public partial class MainPageController : UIViewController
	{
		public static FlyoutNavigationController navigation;

		public MainPageController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var LateralBar = new FlyoutNavigationController {//this will create a new instance of the FlyoutComponent
				NavigationRoot = new RootElement("Menu"){ //Here we create the root of the alements
					new Section(){//with this code we create Sections
						new StyledStringElement ("Home")    { BackgroundColor = UIColor.Clear, TextColor = UIColor.White },
						new ImageStringElement("",UIImage.FromFile("images/btn_menu_perfil.png")),
						new ImageStringElement("",UIImage.FromFile("images/btn_menu_categorias.png")),
						new ImageStringElement("",UIImage.FromFile("images/btn_menu_historial.png")),
						new ImageStringElement("",UIImage.FromFile("images/btn_menu_ranking.png")),
						new ImageStringElement("",UIImage.FromFile("images/btn_menu_sugerencias.png")),
						//new StyledStringElement ("Perfil")    { BackgroundColor = UIColor.Clear, TextColor = UIColor.White },
						//new StyledStringElement ("Categorias")    { BackgroundColor = UIColor.Clear, TextColor = UIColor.White },
						//new StyledStringElement ("Historial de Servicios")    { BackgroundColor = UIColor.Clear, TextColor = UIColor.White },
						//new StyledStringElement ("Mi Ranking")    { BackgroundColor = UIColor.Clear, TextColor = UIColor.White },
					},
				},
				ViewControllers =  new [] {//here we link Controllers to the elements on the sections
					this.Storyboard.InstantiateViewController("HomeLogoController") as UIViewController,//here we create the instances for the Controllers
					this.Storyboard.InstantiateViewController("ProfileController") as UIViewController,//here we create the instances for the Controllers
					this.Storyboard.InstantiateViewController("CategoryController") as UIViewController,
					this.Storyboard.InstantiateViewController("HistorialController") as UIViewController,
					this.Storyboard.InstantiateViewController("RankingController") as UIViewController,
					this.Storyboard.InstantiateViewController("SugerenciasController") as UIViewController,
				}
			};

			//LateralBar.NavigationTableView.BackgroundView = new UIImageView (UIImage.FromBundle ("images/Background-Party.png"));
			UIColor bgColor = UIColor.FromRGB (0,167,229);
			LateralBar.NavigationTableView.BackgroundColor = bgColor;
			LateralBar.NavigationTableView.SeparatorColor = UIColor.Clear;

			LateralBar.ToggleMenu();
			View.AddSubview (LateralBar.View);
			navigation = LateralBar;

		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}
	}
}
