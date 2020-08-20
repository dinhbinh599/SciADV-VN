using AdvWeb_VN.ViewModels.Common;
using AdvWeb_VN.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvWeb_VN.WriterApp.Services
{
	public interface IUserApiClient
	{
		public Task<ApiResult<string>> Authenticate(LoginRequest request);
		Task<ApiResult<bool>> UpdateUser(Guid id, UserUpdateRequest request);
		Task<ApiResult<UserViewModel>> GetByID(Guid id);
		Task<ApiResult<UserViewModel>> GetByName(string name);
		Task<ApiResult<bool>> Delete(Guid id);
	}
}
