using System;
using System.Collections.Generic;
using DAL.Entities;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public UserContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
