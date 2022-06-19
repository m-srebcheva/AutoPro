using DataAccess;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Services
{
	public class ProductService
	{
		private AutoProDbContext _dbContext;

		public ProductService(AutoProDbContext dbContext)
		{
			this._dbContext = dbContext;
		}

		public List<Service> GetServices() => this._dbContext.Services.ToList();

		public Service GetService(string id) => this.GetServices().FirstOrDefault(x => x.Id.ToString() == id);
	}
}
