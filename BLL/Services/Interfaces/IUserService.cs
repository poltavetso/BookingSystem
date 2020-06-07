using System;
using System.Collections.Generic;
using System.Text;
using BLL.Tests.DTO;

namespace BLL.Tests.Services.Interfaces
{
	public interface IUserService
	{
		IEnumerable<UserDTO> GetUsers(int page);
	}
}
