using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;


namespace ClickNDone.Core
{
	public class CategoriesModel : BaseViewModel
	{
		public List<Category> Categories{ get; set; }
		public Category SelectedCategory;

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

		public Category GetCategoryById(string categoryId)
		{
			Category result = Categories.Where (c => c.Convention == categoryId).First();
			return result;
		}

	}
}

