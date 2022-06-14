using DataAccess.Model.Enums;
using System.Collections.Generic;

namespace DataAccess.Model
{
	public class User : BaseEntity
	{
		public User()
		{
			this.Appointments = new List<Appointment>();
			this.Cars = new List<Car>();
		}

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Password { get; set; }

		public string Email { get; set; }
		
		public string PhoneNumber { get; set; }

		public Role Role { get; set; }

		public List<Appointment> Appointments { get; set; }

		public List<Car> Cars { get; set; }
	}
}
