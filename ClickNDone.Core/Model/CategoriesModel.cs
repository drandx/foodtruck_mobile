using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;


namespace DInteractive.Core
{
	public class CategoriesModel : BaseViewModel
	{
		public List<Category> Categories{ get; set; }
		public Category SelectedCategory;
		public Category SelectedSubcategory;
		public static bool Loaded { get; set;}

		//Digital Interactive code Starts Here
		public BusinessCategory SelectedBusinessCategory;
		public List<BusinessCategory> BusinessCategories{ get; set; }

		public async Task GetBusinessCategoriesAsync()
		{
			IsBusy = true;
			try
			{
				BusinessCategories = await service.GetBusinessCategoriesAsync();
			}
			finally {
				IsBusy = false;
				Loaded = true;
			}

		}

		public async Task PutCompanyAsync(string email, string latitude, string longitude)
		{
			IsBusy = true;
			try
			{
				Company company = new Company();
				company.CompanyID = 2;
				company.Email = email;
				company.Latitude = latitude;
				company.Longitude = longitude;
				await service.PutCompanyAsync(company);
			}
			finally {
				IsBusy = false;
				Loaded = true;
			}
		}
		//Digital Interactive code Ends Here


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

		public Category GetCategoryByConvention(string categoryConvention)
		{
			Category result = Categories.Where (c => c.Convention == categoryConvention).First();
			return result;
		}

		public Category GetCategoryById(int catId)
		{
			Category result = Categories.Where (c => c.Id == catId).First();
			return result;
		}


		public Category GetSubCategoryById(int subCatId)
		{
			if (SelectedCategory != null) {
				var result = SelectedCategory.Subcategories.Where (c => c.Id == subCatId);
				Category catResult = new Category();
				if (result.Count()>0)
					catResult = result.First ();
				return catResult;
			}
			return new Category ();
		}

	}
}

