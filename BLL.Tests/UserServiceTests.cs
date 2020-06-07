using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.Tests.Services.Impl;
using BLL.Tests.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using Xunit;
using Moq;
using DAL.Repositories.Interfaces;

namespace BLL.Tests
{
	public class UserServiceTests
	{
		[Fact]
		public void Ctor_InputNull_ThrowArgumentNullException()
		{
			// Arrange
			//IUnitOfWork nullUnitOfWork = null;​

			IUnitOfWork nullUnitOfWork = null;

			// Act
			// Assert
			Assert.Throws<ArgumentNullException>(
				() => new UserService(nullUnitOfWork)
			);
		}

		[Fact]
		public void GetUsers_UserIsAdmin_ThrowMethodAccessException()
		{
			// Arrange
			User user = new Admin(1, "test", 1);
			SecurityContext.SetUser(user);
			var mockUnitOfWork = new Mock<IUnitOfWork>();
			IUserService userService = new UserService(mockUnitOfWork.Object);
			// Act
			// Assert
			Assert.Throws<MethodAccessException>(() => userService.GetUsers(0));
		}

		[Fact]
		public void GetUsers_UserFromDAL_CorrectMappingToUserDTO()
		{
			// Arrange
			User user = new Director(1, "test", 1);
			SecurityContext.SetUser(user);
			var streetService = GetUserService();
			// Act
			var actualStreetDto = streetService.GetUsers(0).First();
			
			// Assert
			Assert.True(
				actualStreetDto.ID == 1
				&& actualStreetDto.Name == "testN"
				&& actualStreetDto.Director == "testD"
			);
		}
		
		IUserService GetUserService()
		{
			var mockContext = new Mock<IUnitOfWork>();
			var expectedUser = new DAL.Entities.User()
			{
				Id = 1,
				Login = "testN"
			};
			var mockDbSet = new Mock<IUserRepository>();
			mockDbSet
				.Setup(z =>
					z.Find(
						It.IsAny<Func<DAL.Entities.User, bool>>(),
						It.IsAny<int>(),
						It.IsAny<int>()))
				.Returns(
					new List<DAL.Entities.User>() { expectedUser }
				);
			mockContext
				.Setup(context =>
					context.Users)
				.Returns(mockDbSet.Object);
			
			IUserService streetService = new UserService(mockContext.Object);
			
			return streetService;
		}
    }
}
