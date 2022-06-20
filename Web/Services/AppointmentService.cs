using DataAccess;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Services
{
	public class AppointmentService
	{
		private AutoProDbContext _dbContext;

		public AppointmentService(AutoProDbContext dbContext)
		{
			this._dbContext = dbContext;
		}

		public void AddAppointment(Appointment appointment)
		{
			this._dbContext.Add(appointment);
			this._dbContext.SaveChanges();
		}
	}
}
