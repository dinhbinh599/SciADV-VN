using AdvWeb_VN.ViewModels.Catalog.Tags;
using AdvWeb_VN.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdvWeb_VN.Application.Catalog.Tags
{
	public interface ITagService
	{
		Task<ApiResult<bool>> Create(TagCreateRequest request);
		Task<ApiResult<bool>> Update(TagUpdateRequest request);
		Task<ApiResult<bool>> Delete(int tagID);
		Task<ApiResult<TagViewModel>> GetByID(int tagID);
		Task<ApiResult<List<TagViewModel>>> GetAll();
		Task<ApiResult<PagedResult<TagViewModel>>> GetAllPagingTagID(GetTagPagingRequest request);
		Task<ApiResult<List<TagViewModel>>> GetAllByCategoryID(int categoryID);
	}
}
