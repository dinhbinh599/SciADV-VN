using AdvWeb_VN.ViewModels.Catalog.Tags;
using AdvWeb_VN.ViewModels.Common;
using AdvWeb_VN.ViewModels.Common.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvWeb_VN.ManageApp.Services
{
	public interface ITagApiClient
	{
		Task<ApiResult<bool>> CreateTag(TagCreateRequest createRequest);

		Task<ApiResult<bool>> UpdateTag(int id, TagUpdateRequest request);

		Task<ApiResult<TagViewModel>> GetByID(int id);
		Task<ApiResult<List<TagViewModel>>> GetAll();
		Task<ApiResult<bool>> Delete(int id);
	}
}
