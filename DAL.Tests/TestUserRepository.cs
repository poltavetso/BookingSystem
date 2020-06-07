using DAL.Entities;
using DAL.Repositories.Impl;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DAL.Tests
{
	public class TestUserRepository : BaseRepository<User>
	{
		public TestUserRepository(DbContext context)
			: base(context)
		{
		}
	}
}
