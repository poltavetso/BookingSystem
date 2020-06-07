using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
	public abstract class User
	{
		public User(int userId, string name, int userId1, string userType)
		{
			UserId = userId;
			Name = name;
			UserId1 = userId1;
			UserType = userType;
		}
		public int UserId { get; }
		public string Name { get; }
		public int UserId1 { get; }
		protected string UserType { get; }
	}
}
