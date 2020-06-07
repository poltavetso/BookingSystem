using System;
using System.Collections.Generic;
using System.Text;
using DAL.EF;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace DAL.Tests
{
	public class BaseRepositoryUnitTests
	{
		[Fact]
		public void Create_InputUsersInstance_CalledAddMethodOfDBSetWithUsersInstance()
		{
			// Arrange
			DbContextOptions opt = new DbContextOptionsBuilder<UserContext>()
				.Options;
			var mockContext = new Mock<UserContext>(opt);
			var mockDbSet = new Mock<DbSet<User>>();
			mockContext
				.Setup(context =>
					context.Set<User>(
					))
				.Returns(mockDbSet.Object);
			var repository = new TestUserRepository(mockContext.Object);
			User expectedUsers = new Mock<User>().Object;
			//Act
			repository.Create(expectedUsers);
			// Assert
			mockDbSet.Verify(
				dbSet => dbSet.Add(
					expectedUsers
				), Times.Once());
		}

		[Fact]
		public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
		{
			// Arrange
			DbContextOptions opt = new DbContextOptionsBuilder<UserContext>()
				.Options;
			var mockContext = new Mock<UserContext>(opt);
			var mockDbSet = new Mock<DbSet<User>>();
			mockContext
				.Setup(context =>
					context.Set<User>(
					))
				.Returns(mockDbSet.Object);
			var repository = new TestUserRepository(mockContext.Object);
			User expectedUser = new User() { Id = 1 };
			mockDbSet.Setup(mock => mock.Find(expectedUser.Id))
				.Returns(expectedUser);
			//Act
			repository.Delete(expectedUser.Id);
			// Assert
			mockDbSet.Verify(
				dbSet => dbSet.Find(
					expectedUser.Id
				), Times.Once());
			mockDbSet.Verify(
				dbSet => dbSet.Remove(
					expectedUser
				), Times.Once());
		}
	}
}
