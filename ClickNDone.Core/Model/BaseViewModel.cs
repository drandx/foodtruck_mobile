using System;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using ClickNDone.Core;


namespace ClickNDone.Core
{
	public class BaseViewModel
	{
		protected readonly IWebService service = (IWebService)DependencyInjectionWrapper.Instance.ServiceContainer().GetService(typeof(IWebService));
		protected readonly ISettings settings = (ISettings)DependencyInjectionWrapper.Instance.ServiceContainer().GetService(typeof(ISettings));

		public event EventHandler IsBusyChanged = delegate { };

		private bool isBusy = false;

		public bool IsBusy
		{
			get { return isBusy; }
			set
			{
				isBusy = value;
				IsBusyChanged(this, EventArgs.Empty);
			}
		} 
	}
}

