using DataAccess;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Services
{
	public class OrderService
	{
		private AutoProDbContext _dbContext;

		public OrderService(AutoProDbContext dbContext)
		{
			this._dbContext = dbContext;
		}

		public void AddOrder(Order order)
		{
			this._dbContext.Orders.Add(order);
			this._dbContext.SaveChanges();
		}

		public void UpdateOrder(Order newOrder)
		{
			this._dbContext.Update(newOrder);
			this._dbContext.SaveChanges();
		}
	}
}
