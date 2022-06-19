using System.Collections.Generic;

namespace DataAccess.Model
{
	public class Service : BaseEntity
	{
		public Service()
		{
			this.Appointments = new List<Appointment>();
		}
		
		public string Name { get; set; }

		public string ShortDescription { get; set; }

		public string Description { get; set; }

		public double Price { get; set; }

		public string PhotoPath { get; set; }

		public List<Appointment> Appointments { get; set; }
	}
}
