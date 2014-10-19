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
		public Category SelectedSubcategory;

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

		public Category GetCategoryById(string categoryConvention)
		{
			Category result = Categories.Where (c => c.Convention == categoryConvention).First();
			return result;
		}

		public Category GetSubCategory(int subCatId)
		{
			Category result = SelectedCategory.Subcategories.Where (c => c.Id == subCatId).First();
			return result;
		}

	}
}

