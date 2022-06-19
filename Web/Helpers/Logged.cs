using DataAccess.Model;
using System.Collections.Generic;

namespace Web.Helpers
{
	public class Logged
	{
		public static User User { get; set; }

		public static List<Service> Cart { get; set; } = new List<Service>();

		public static bool IsLogged()
		{
			if (Logged.User is not null)
			{
				return true;
			}

			return false;
		}
	}
}