using AdvWeb_VN.ViewModels.Catalog.Posts;
using AdvWeb_VN.ViewModels.Catalog.ProductImages;
using AdvWeb_VN.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdvWeb_VN.Application.Catalog.Posts
{
	public interface IPostService
	{
		Task<ApiResult<string>> Create(PostCreateRequest request);
		Task<ApiResult<bool>> Update(string id,PostUpdateRequest request);
		Task<ApiResult<bool>> UpdateAuthenticate(string id, Guid userID, PostUpdateRequest request);
		Task<ApiResult<bool>> Delete(string postID);
		Task<ApiResult<bool>> DeleteAuthenticate(string postID, Guid userID);
		Task<ApiResult<bool>> AddViewCount(string postID);
		Task<ApiResult<PostViewModel>> GetByID(string postID);
		Task<ApiResult<PostViewModel>> GetByIDAuthenticate(string postID, Guid userID);
		Task<ApiResult<PagedResult<PostViewModel>>> GetAllPagingByTagID(GetManagePostPagingRequest request);
		Task<ApiResult<PagedResult<PostViewModel>>> GetAllPagingByCategoryID(GetManagePostPagingRequest request);
		Task<ApiResult<PagedResult<PostViewModel>>> GetAllPagingByCategoryIDAuthenticate(Guid userID,GetManagePostPagingRequest request);
		Task<ApiResult<PagedResult<PostViewModel>>> GetAllByTagID(GetPublicPostPagingRequest request);
		Task<ApiResult<PagedResult<PostViewModel>>> GetAllByCategoryID(GetPublicPostPagingRequest request);
		Task<ApiResult<PagedResult<PostViewModel>>> GetAllPagingBySubCategoryID(GetManagePostPagingRequest request);
		Task<List<PostViewModel>> GetAll();
		Task<ApiResult<List<PostViewModel>>> GetPopular();
		Task<ApiResult<bool>> TagAssign(string postID, TagAssignRequest request);
		Task<ApiResult<bool>> TagAssignAuthenticate(string postID, Guid userID, TagAssignRequest request);
		Task<int> AddImage(string postID, PostImageCreateRequest request);
		Task<int> AddImageAuthenticate(string postID, Guid userID, PostImageCreateRequest request);
		Task<ApiResult<string>> AddImageByUrl(string postID, PostImageCreateUrlRequest request);
		Task<ApiResult<string>> AddImageByUrlAuthenticate(string postID, Guid userID, PostImageCreateUrlRequest request);
		Task<ApiResult<bool>> RemoveImage(int imageID);
		Task<ApiResult<bool>> UpdateImage(int imageID, PostImageUpdateRequest request);
		Task<ApiResult<PostImageViewModel>> GetImageByID(int imageID);
		Task<List<PostImageViewModel>> GetListImages(string postID);
		Task<ApiResult<bool>> UpdateImageContents(string postID, PostUpdateContentsRequest request);
		Task<ApiResult<bool>> UpdateImageContentsAuthenticate(string postID, Guid userID, PostUpdateContentsRequest request);
		Task<ApiResult<PagedResult<PostViewModel>>> GetPagingCategory(GetPublicPostPagingRequest request);
		Task<ApiResult<PagedResult<PostViewModel>>> GetPagingSubCategory(GetPublicPostPagingRequest request);
		Task<ApiResult<PagedResult<PostViewModel>>> GetPagingTag(GetPublicPostPagingRequest request);
		Task<ApiResult<PagedResult<PostViewModel>>> GetPagingTagByName(GetPublicPostPagingRequestSearch request);
		Task<ApiResult<PagedResult<PostViewModel>>> GetPaging(GetPublicPostPagingRequest request);
	}
}
