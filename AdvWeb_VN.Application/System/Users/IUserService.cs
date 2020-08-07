using AdvWeb_VN.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdvWeb_VN.Application.System.Users
{
	public interface IUserService
	{
		public Task<string> Authenticate(LoginRequest request);
		public Task<bool> Register(RegisterRequest request);
	}
}
