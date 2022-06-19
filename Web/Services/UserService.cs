using DataAccess;
using DataAccess.Model;
using System;
using System.Linq;
using Web.Helpers;

namespace Web.Services
{
	public class UserService
	{
		private AutoProDbContext _dbContext;

		public UserService(AutoProDbContext dbContext)
		{
			this._dbContext = dbContext;
		}

		public User GetUser(string email) => this._dbContext.Users.FirstOrDefault(x => x.Email == email);

		public void Login(string email, string password)
		{
			if (this._dbContext.Users.Any(x => x.Email == email))
			{
				if (this._dbContext.Users.FirstOrDefault(x => x.Email == email).Password == password)
				{
					Logged.User = this._dbContext.Users.FirstOrDefault(x => x.Email == email);
				}
				else
				{
					throw new ArgumentException("Incorrect username or password");
				}
			}
			else
			{
				throw new ArgumentException("Incorrect username or password");
			}
		}

		public User Register(User user)
		{
			if(this.GetUser(user.Email) is null)
			{
				this._dbContext.Users.Add(user);
				this._dbContext.SaveChanges();
				return user;
			}

			throw new ArgumentException();
		}
	}
}