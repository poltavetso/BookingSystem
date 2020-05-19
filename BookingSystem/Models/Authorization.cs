using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingSystem.Models
{
	public class Authorization
	{
		private static Authorization _instance;

		private static IEnumerable<User> Users => (new UserContext().Users) ?? throw new NullReferenceException(nameof(IEnumerable<User>));

		private Authorization()
		{

		}

		public static Authorization GetInstance()
		{
			return _instance ?? (_instance = new Authorization());
		}

		public bool CheckUser(string login, string password)
		{
			return Users.Any(o => o.Login == login && o.Password == password);
		}
    }
}