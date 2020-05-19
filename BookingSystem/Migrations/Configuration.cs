using BookingSystem.Models;

namespace BookingSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookingSystem.Models.UserContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BookingSystem.Models.UserContext";
        }

        protected override void Seed(BookingSystem.Models.UserContext context)
        {
	        context.Users.Add(new User()
	        {
                Login = "Admin",
                Password = "Admin",
                Email = "olya@gmail.com",
                IsAdmin = true
	        });
        }
    }
}
