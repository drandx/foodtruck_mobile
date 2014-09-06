using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ClickNDone.Core
{
	public class CategoriesModel : BaseViewModel
	{
		public List<Category> Categories{ get; set; }

		public async Task GetCategories()
		{
			IsBusy = true;
			try
			{
				Categories = await service.GetCategories(settings.User.sessionToken, settings.DeviceToken);
			}
			finally {
				IsBusy = false;
			}

		}

	}
}

