using AdvWeb_VN.ViewModels.Catalog.SubCategories;
using AdvWeb_VN.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvWeb_VN.ManageApp.Services
{
	public interface ISubCategoryApiClient
	{
		Task<ApiResult<bool>> CreateCategory(SubCategoryCreateRequest createRequest);

		Task<ApiResult<bool>> UpdateCategory(int id, SubCategoryUpdateRequest request);

		Task<ApiResult<SubCategoryViewModel>> GetByID(int id);
		Task<List<SubCategoryViewModel>> GetAll();
		Task<ApiResult<bool>> Delete(int id);
	}
}
