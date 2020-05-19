using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookingSystem.Models
{
	public class UserContext : DbContext
	{
		public UserContext()
			: base("ConnectionString")
		{ }

		public DbSet<User> Users { get; set; }
	}
}