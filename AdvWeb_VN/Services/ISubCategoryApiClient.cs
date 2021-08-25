using AdvWeb_VN.ViewModels.Catalog.SubCategories;
using AdvWeb_VN.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvWeb_VN.WebApp.Services
{
	public interface ISubCategoryApiClient
	{
		Task<ApiResult<SubCategoryViewModel>> GetByID(int id);
		Task<List<SubCategoryViewModel>> GetAll();
	}
}
