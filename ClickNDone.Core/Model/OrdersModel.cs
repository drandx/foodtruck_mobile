﻿using System;
using System.Threading.Tasks;

namespace ClickNDone.Core
{
	public class OrdersModel:BaseViewModel
	{
		public int RequestedOrderId { get; set;}
		public string Location { get; set; }
		public string Comments { get; set; }
		public Double MinCost { get; set; }
		public Double MaxCost { get; set; }
		public DateTime ReservationDate { get; set; }

		public OrdersModel ()
		{

		}

		public async Task<bool> RequestService(Category selectedSubCategroy, Action RequestCallback)
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
				serviceRequest.Category = selectedSubCategroy;
				var ret = await service.RequestService(serviceRequest,settings.User.sessionToken,settings.DeviceToken);
				this.RequestedOrderId = ret;
				return true;
			}
			finally {
				IsBusy = false;
				RequestCallback();
			}

		}

		public async Task<Order> GetOrder(int orderId)
		{
			try
			{
				//IsBusy = true;
				var retOrder = await service.GetOrder(orderId);
				return retOrder;

			}
			finally {
				//IsBusy = false;
			}

		}

	}
}

