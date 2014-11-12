using System;
using System.Collections.Generic;

namespace ClickNDone.Core
{
	//Digital Interactive CMS Domain Model
	public class BusinessCategory
	{
		public int BusinessCategoryID { get; set; }
		public int BusinessLineID { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public byte[] Icon { get; set; }
		public virtual BusinessLine BusinessLine { get; set; }
		public virtual ICollection<BusinessService> BussinessServices { get; set; }
		public virtual ICollection<Company> AssociatedCompanies { get; set; }
	}

	public class BusinessLine
	{
		public int BusinessLineID { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public virtual ICollection<BusinessCategory> Categories { get; set; }
	}  

	public class BusinessService
	{
		public int ID { get; set; }
		public int BusinessCategoryID { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public byte[] Icon { get; set; }
		public int MinutesDuration { get; set; }

		public virtual BusinessCategory BusinessCategory { get; set; }
		public virtual ICollection<Company> ProviderCompanies { get; set; }
		public virtual ICollection<Staff> Staff { get; set; }
	}

	public class Company
	{
		public int CompanyID { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public byte[] Image { get; set; }
		public byte[] Icon { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string Neighborhood { get; set; }
		public string Country { get; set; }

		public ICollection<BusinessCategory> BusinessCategories { get; set; }
		public ICollection<BusinessService> Services { get; set; }
		public ICollection<Staff> Staff { get; set; }

	}

	public class Staff
	{
		public int StaffID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public byte[] Image { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Address { get; set; }
		public virtual ICollection<MeetingTime> MeetingTimes { get; set; }
		public ICollection<Company> Companies { get; set; }
		public ICollection<BusinessService> Services { get; set; }

	}

	public class MeetingTime
	{
		public int MeetingTimeID { get; set; }
		public int StaffID { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime FinishTime { get; set; }
		public virtual Staff Staff { get; set; }
	}


	public class User
	{
		public int id { get; set;}
		public string password { get; set; }
		public DateTime birthAge { get; set;}
		public string email { get; set;}
		public string names { get; set;}
		public string surnames { get; set;}
		public string mobile { get; set;}
		public string gender { get; set;}
		public UserType userType { get; set;}
		public string urlAvatar { get; set;}
		public string sessionToken { get; set;}
	}

	//Digital Interactive CMS Domain Model Ends Here

	public class LoginObj
	{
		public string email { get; set; }
		public string pwd { get; set; }
		public string userType { get; set; }
	}

	public class TermsConditions
	{
		public string terms { get; set; }
		public string conditions { get; set; }
	}

	public class Category
	{
		public int Id { get; set;}
		public int ParentId { get; set;}
		public string Name { get; set; }
		public string Description { get; set; }
		public string Convention { get; set; }
		public List<Category> Subcategories { get; set; }
		public string ImageName { get; set;}
	}

	public class ServiceRequest
	{
		public string Location { get; set; }
		public string Reference { get; set; }
		public string MinCost { get; set; }
		public string MaxCost { get; set; }
		public DateTime ReservationDate { get; set; }
		public Category SubCategory { get; set;}
	}

	public class Order
	{
		public int Id { get; set;}
		public ServiceState Status { get; set; }
		public int UserId { get; set;}
		public int SupplierId { get; set;}
		public string ClickCode { get; set;}
		public int CategoryId { get; set;}
		public int SubCategoryId { get; set;}
		public DateTime ReservationDate { get ; set; }
		public string Time { get; set;}
		public string MinCost { get; set; }
		public string MaxCost { get; set; }
		public string Location { get; set; }
		public string Reference { get; set; }
		public string Comments { get; set; }

		public Category SubCategory { get; set;}
		public User Supplier { get; set;}
		public User User { get; set;}


		public Order()
		{
			this.Supplier = new User ();
			this.User = new User ();
		}

		public string GetReservationDate()
		{
			return this.ReservationDate.ToString ("MMMM dd, yyyy");
		}

		public string GetReservationTime()
		{
			return this.Time;
		}

	}

}

