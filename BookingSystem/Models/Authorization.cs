using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingSystem.Models
{
	public class UserSystem
	{
		private static UserSystem _instance;
		private static IEnumerable<User> _users;
		private static UserContext _userContext;
		private static IEnumerable<User> Users => _users ?? (_users = UserContext.Users);
		private static UserContext UserContext => _userContext ?? (_userContext = new UserContext());

		private UserSystem()
		{
			
		}

		public static UserSystem GetInstance()
		{
			return _instance ?? (_instance = new UserSystem());
		}

		public User GetUser(string login, string password)
		{
			return Users.FirstOrDefault(o => o.Login == login && o.Password == password);
		}

		public bool CheckLogin(string login)
		{
			return Users.Any(o => o.Login == login);
		}

		public bool CheckEmail(string email)
		{
			return Users.Any(o => o.Email == email);
		}

		public bool NewUsers(User user)
		{
			UserContext.Users.Add(user);
			return UserContext.SaveChanges() > 0;
		}
	}
}