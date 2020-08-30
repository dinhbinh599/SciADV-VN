using AdvWeb_VN.ViewModels.Catalog.Tags;
using AdvWeb_VN.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvWeb_VN.WebApp.Services
{
	public interface ITagApiClient
	{
		Task<ApiResult<PagedResult<TagViewModel>>> GetTagsPagings(GetTagPagingRequest request);
		Task<ApiResult<TagViewModel>> GetByID(int id);
		Task<ApiResult<List<TagViewModel>>> GetAll();
		Task<ApiResult<List<TagViewModel>>> GetAllByCategoryID(int categoryID);
	}
}
