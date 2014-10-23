﻿using System;
using System.Threading.Tasks;

namespace ClickNDone.Core
{
	public class OrdersModel:BaseViewModel
	{
		public int RequestedOrderId { get; set;}
		public Order RequestedOrder { get; set;}
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
				serviceRequest.Reference = this.Comments;
				serviceRequest.Location = Location;
				serviceRequest.MinCost = MinCost;
				serviceRequest.MaxCost = MaxCost;
				serviceRequest.ReservationDate = ReservationDate;
				serviceRequest.SubCategory = selectedSubCategroy;
				var ret = await service.RequestService(serviceRequest,settings.User.sessionToken,settings.DeviceToken, settings.User.id);
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
				this.RequestedOrder = retOrder;
				return retOrder;

			}
			finally {
				//IsBusy = false;
			}

		}

		public async Task<bool> ChangeOrderState(ServiceState state, string comments = null, string ranking = null)
		{
			try
			{
				var retOrder = await service.ChangeOrderState(this.RequestedOrder.Id, state, comments, ranking);
				return retOrder;

			}
			finally {
				this.RequestedOrder.Status = state;
			}

		}

	}
}

