using AdvWeb_VN.ViewModels.Common;
using AdvWeb_VN.ViewModels.Common.Tags;
using AdvWeb_VN.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdvWeb_VN.Application.System.Users
{
	public interface IUserService
	{
		public Task<ApiResult<string>> Authenticate(LoginRequest request);
		public Task<ApiResult<bool>> Register(RegisterRequest request);
		public Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest request);
		public Task<ApiResult<bool>> Delete(Guid id);
		public Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request);
		public Task<ApiResult<bool>> RoleAssignByRoleName(Guid id, string roleName);
		public Task<ApiResult<bool>> RoleRemoveByRoleName(Guid id, string roleName);
		public Task<ApiResult<PagedResult<UserViewModel>>> GetUsersPaging (GetUserPagingRequest request);
		public Task<ApiResult<UserViewModel>> GetByID(Guid id);
		public Task<ApiResult<UserViewModel>> GetByName(string name);
	}
}
