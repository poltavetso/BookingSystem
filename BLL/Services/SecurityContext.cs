using System;
using System.Collections.Generic;
using System.Text;
using CCL.Security.Identity;

namespace BLL.Services
{
	public static class SecurityContext
	{
		static User _user = null;
		public static User GetUser()
		{
			return _user;
		}
		public static void SetUser(User user)
		{
			_user = user;
		}
	}
}
