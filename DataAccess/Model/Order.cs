using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
	public class Order : BaseEntity
	{
		public Order()
		{
			this.Appointments = new List<Appointment>();
		}

		public List<Appointment> Appointments { get; set; }
	}
}
