using AdvWeb_VN.ViewModels.Catalog.Posts;
using AdvWeb_VN.ViewModels.Catalog.ProductImages;
using AdvWeb_VN.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvWeb_VN.WriterApp.Services
{
	public interface IPostApiClient
	{
		Task<ApiResult<PagedResult<PostViewModel>>> GetPostsPagings(Guid userID,GetManagePostPagingRequest request);

		Task<ApiResult<PostViewModel>> CreatePost(PostCreateRequest registerRequest);

		Task<ApiResult<bool>> UpdatePost(Guid userID, int id, PostUpdateRequest request);

		Task<ApiResult<PostViewModel>> GetByID(Guid userID, int id);

		Task<ApiResult<bool>> Delete(Guid userID, int id);
		Task<ApiResult<bool>> TagAssign(Guid userID, int id, TagAssignRequest request);
		Task<ApiResult<string>> AddImageByUrl(Guid userID, int id, PostImageCreateUrlRequest request);
		Task<ApiResult<bool>> UpdateContents(Guid userID, int id, PostUpdateContentsRequest request);
		Task<ApiResult<PostImageViewModel>> AddImageBase64(Guid userID, int postID, PostImageBase64CreateRequest request);
	}
}
