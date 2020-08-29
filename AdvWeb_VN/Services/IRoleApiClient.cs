using AdvWeb_VN.ViewModels.Common;
using AdvWeb_VN.ViewModels.System.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvWeb_VN.WebApp.Services
{
    public interface IRoleApiClient
    {
        Task<ApiResult<List<RoleViewModel>>> GetAll();
    }
}