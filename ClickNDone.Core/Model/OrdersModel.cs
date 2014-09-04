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

		public async Task ReuestService()
		{


		}

	}
}

