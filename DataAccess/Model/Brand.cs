using System.Collections.Generic;

namespace DataAccess.Model
{
	public class Brand : BaseEntity
	{
		public Brand()
		{
			this.Cars = new List<Car>();
		}

		public string Name { get; set; }

		public List<Car> Cars { get; set; }
	}
}
