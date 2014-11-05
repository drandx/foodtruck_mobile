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
		public static bool Loaded { get; set;}

		public async Task GetCategories()
		{
			IsBusy = true;
			try
			{
				Categories = await service.GetCategoriesAsync(settings.User.sessionToken, settings.DeviceToken);
			}
			finally {
				IsBusy = false;
				Loaded = true;
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

