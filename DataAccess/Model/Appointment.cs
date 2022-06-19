using System;

namespace DataAccess.Model
{
	public class Appointment : BaseEntity
	{
		public DateTime VisitDate { get; set; }

		public DateTime CreationDate { get; set; }

		public bool IsConfirmed { get; set; }

		public Service Service { get; set; }
		public int ServiceId { get; set; }

		public Technician Technician { get; set; }
		public int TechnicianId { get; set; }

		public User User { get; set; }
		public int UserId { get; set; }

		public Order Order { get; set; }
		public int OrderId { get; set; }
	}
}
