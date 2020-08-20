using AdvWeb_VN.ViewModels.Catalog.Categories;
using AdvWeb_VN.ViewModels.Common;
using AdvWeb_VN.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvWeb_VN.ManageApp.Services
{
	public interface ICategoryApiClient
	{
		Task<ApiResult<bool>> CreateCategory(CategoryCreateRequest createRequest);

		Task<ApiResult<bool>> UpdateCategory(int id, CategoryUpdateRequest request);

		Task<ApiResult<CategoryViewModel>> GetByID(int id);
		Task<List<CategoryViewModel>> GetAll();
		Task<ApiResult<bool>> Delete(int id);
	}
}
