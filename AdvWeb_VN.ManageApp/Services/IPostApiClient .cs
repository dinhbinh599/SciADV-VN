using AdvWeb_VN.ViewModels.Catalog.Posts;
using AdvWeb_VN.ViewModels.Catalog.ProductImages;
using AdvWeb_VN.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvWeb_VN.ManageApp.Services
{
	public interface IPostApiClient
	{
		Task<ApiResult<PagedResult<PostViewModel>>> GetPostsPagings(GetManagePostPagingRequest request);

		Task<ApiResult<PostViewModel>> CreatePost(PostCreateRequest registerRequest);

		Task<ApiResult<bool>> UpdatePost(string id, PostUpdateRequest request);

		Task<ApiResult<PostViewModel>> GetByID(string id);

		Task<ApiResult<bool>> Delete(string id);
		Task<ApiResult<bool>> TagAssign(string id, TagAssignRequest request);
		Task<ApiResult<string>> AddImageByUrl(string id, PostImageCreateUrlRequest request);
		Task<ApiResult<bool>> UpdateContents(string id, PostUpdateContentsRequest request);
		Task<ApiResult<PostImageViewModel>> AddImageBase64(string postID, PostImageBase64CreateRequest request);
	}
}
