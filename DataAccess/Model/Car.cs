namespace DataAccess.Model
{
	public class Car
	{
		public string RegistrationNumber { get; set; }

		public Brand Brand { get; set; }
		public int BrandId { get; set; }

		public string Model { get; set; }

		public User User { get; set; }
		public int UserId { get; set; }
	}
}
