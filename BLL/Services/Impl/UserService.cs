using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BLL.Services;
using BLL.Tests.DTO;
using BLL.Tests.Services.Interfaces;
using CCL.Security.Identity;
using DAL.UnitOfWork;

namespace BLL.Tests.Services.Impl
{
	public class UserService
		: IUserService
	{
		private readonly IUnitOfWork _database;
		private int pageSize = 10;

		public UserService(
			IUnitOfWork unitOfWork)
		{
			if (unitOfWork == null)
			{
				throw new ArgumentNullException(nameof(unitOfWork));
			}

			_database = unitOfWork;
		}

		/// <exception cref="MethodAccessException"></exception>
		public IEnumerable<UserDTO> GetUsers(int pageNumber)
		{
			var user = SecurityContext.GetUser();
			var userType = user.GetType();
			if (userType != typeof(Director) &&
			    userType != typeof(Accountant))
			{
				throw new MethodAccessException();
			}

			var osbbId = user.UserId;
			var streetsEntities =
				_database
					.Users
					.Find(z => z.Id == osbbId, pageNumber, pageSize);
			var mapper =
				new MapperConfiguration(
					cfg => cfg.CreateMap<User, UserDTO>()
				).CreateMapper();
			var streetsDto =
				mapper
					.Map<IEnumerable<DAL.Entities.User>, List<UserDTO>>(
						streetsEntities);
			return streetsDto;
		}
	}
}
