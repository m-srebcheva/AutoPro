using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Helpers;
using Web.Models;
using Web.Services;

namespace Web.Controllers
{
	public class AppointmentController : Controller
	{
		private AppointmentService _appointmentService;
		private OrderService _orderService;

		public AppointmentController(AppointmentService appointmentService, OrderService orderService)
		{
			this._appointmentService = appointmentService;
			this._orderService = orderService;
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(AppointmentViewModel model)
		{
			Order order = new Order();
			this._orderService.AddOrder(order);

			foreach (Service service in Logged.Cart)
			{
				Appointment app = new Appointment();
				DateTime date = new DateTime(model.Date.Year, model.Date.Month, model.Date.Day, model.Hour.Hour, model.Hour.Minute, 0);
				app.ServiceId = service.Id;
				app.VisitDate = date;
				app.CreationDate = DateTime.Now;
				app.TechnicianId = 1;
				app.UserId = Logged.User.Id;
				app.OrderId = order.Id;
				this._appointmentService.AddAppointment(app);
				order.Appointments.Add(app);
			}

			this._orderService.UpdateOrder(order);

			Logged.Cart = new List<Service>();

			return RedirectToAction("Cart", "User");
		}
	}
}
