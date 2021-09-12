using AdvWeb_VN.ViewModels.Catalog.Categories;
using AdvWeb_VN.ViewModels.Common;
using AdvWeb_VN.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvWeb_VN.WebApp.Services
{
	public interface ICategoryApiClient
	{
		Task<ApiResult<List<CategoryMenuViewModel>>> GetMenuCategory();
		Task<ApiResult<List<CategoryViewModel>>> GetFooterCategory();
	}
}
