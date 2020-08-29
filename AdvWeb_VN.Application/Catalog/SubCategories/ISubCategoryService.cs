using AdvWeb_VN.ViewModels.Catalog.SubCategories;
using AdvWeb_VN.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdvWeb_VN.Application.Catalog.SubCategories
{
	public interface ISubCategoryService
	{
		Task<ApiResult<bool>> Create(SubCategoryCreateRequest request);
		Task<ApiResult<bool>> Update(SubCategoryUpdateRequest request);
		Task<ApiResult<bool>> Delete(int categoryID);
		Task<ApiResult<SubCategoryViewModel>> GetByID(int categoryID);
		Task<List<SubCategoryViewModel>> GetByCategoryID(int categoryID);
		Task<List<SubCategoryViewModel>> GetAll();
	}
}
