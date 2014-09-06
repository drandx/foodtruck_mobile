using System;
using System.Threading.Tasks;

namespace ClickNDone.Core
{
	public class OrdersModel:BaseViewModel
	{
		public string Location { get; set; }
		public string Comments { get; set; }
		public Double MinCost { get; set; }
		public Double MaxCost { get; set; }
		public DateTime ReservationDate { get; set; }

		public OrdersModel ()
		{

		}

		public async Task<String> RequestService()
		{
			if (string.IsNullOrEmpty(Location) || string.IsNullOrEmpty(Comments) || string.IsNullOrEmpty(MinCost.ToString()) 
				|| string.IsNullOrEmpty(MaxCost.ToString()) || string.IsNullOrEmpty(ReservationDate.ToString()))
				throw new Exception("Ingrese los campos correctamente");
			IsBusy = true;
			try
			{
				ServiceRequest serviceRequest = new ServiceRequest();
				serviceRequest.Comments = this.Comments;
				serviceRequest.Location = Location;
				serviceRequest.MinCost = MinCost;
				serviceRequest.MaxCost = MaxCost;
				serviceRequest.ReservationDate = ReservationDate;
				//TODO - Replace with dinamyc category.
				Category selectedCat = new Category();
				selectedCat.Convention = "BEA-NAIL";
				serviceRequest.Category = selectedCat;
				var ret = await service.RequestService(serviceRequest,settings.User.sessionToken,settings.DeviceToken);

				return ret;
			}
			finally {
				IsBusy = false;
			}

		}

	}
}

