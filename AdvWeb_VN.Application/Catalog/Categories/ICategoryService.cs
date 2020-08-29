using AdvWeb_VN.ViewModels.Catalog.Categories;
using AdvWeb_VN.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdvWeb_VN.Application.Catalog.Categories
{
	public interface ICategoryService
	{
		Task<ApiResult<bool>> Create(CategoryCreateRequest request);
		Task<ApiResult<bool>> Update(CategoryUpdateRequest request);
		Task<ApiResult<bool>> Delete(int categoryID);
		Task<ApiResult<CategoryViewModel>> GetByID(int categoryID);
		Task<ApiResult<List<CategoryMenuViewModel>>> GetMenuCategory();
		Task<ApiResult<List<CategoryViewModel>>> GetFooterCategory();
		Task<List<CategoryViewModel>> GetAll();
	}
}
