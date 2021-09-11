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

		Task<ApiResult<bool>> UpdatePost(int id, PostUpdateRequest request);

		Task<ApiResult<PostViewModel>> GetByID(int id);

		Task<ApiResult<bool>> Delete(int id);
		Task<ApiResult<bool>> TagAssign(int id, TagAssignRequest request);
		Task<ApiResult<string>> AddImageByUrl(int id, PostImageCreateUrlRequest request);
		Task<ApiResult<bool>> UpdateContents(int id, PostUpdateContentsRequest request);
		Task<ApiResult<PostImageViewModel>> AddImageBase64(int postID, PostImageBase64CreateRequest request);
	}
}
