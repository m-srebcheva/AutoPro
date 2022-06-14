using System.Collections.Generic;

namespace DataAccess.Model
{
	public class Technician : BaseEntity
	{
		public Technician()
		{
			this.Appointments = new List<Appointment>();
		}

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public List<Appointment> Appointments { get; set; }
	}
}
