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
		Task<ApiResult<int>> Create(PostCreateRequest request);
		Task<ApiResult<bool>> Update(int id,PostUpdateRequest request);
		Task<ApiResult<bool>> UpdateAuthenticate(int id, Guid userID, PostUpdateRequest request);
		Task<ApiResult<bool>> Delete(int postID);
		Task<ApiResult<bool>> DeleteAuthenticate(int postID, Guid userID);
		Task<ApiResult<bool>> AddViewCount(int postID);
		Task<ApiResult<PostViewModel>> GetByID(int postID);
		Task<ApiResult<PostViewModel>> GetByIDAuthenticate(int postID, Guid userID);
		Task<ApiResult<PagedResult<PostViewModel>>> GetManagePagingByTagID(GetManagePostPagingRequest request);
		Task<ApiResult<PagedResult<PostViewModel>>> GetManagePagingByCategoryID(GetManagePostPagingRequest request);
		Task<ApiResult<PagedResult<PostViewModel>>> GetManagePagingByCategoryIDAuthenticate(Guid userID, GetManagePostPagingRequest request);
		Task<ApiResult<PagedResult<PostViewModel>>> GetPublicPagingByTagID(GetPublicPostPagingRequest request);
		Task<ApiResult<PagedResult<PostViewModel>>> GetPublicPagingByCategoryID(GetPublicPostPagingRequest request);
		Task<ApiResult<PagedResult<PostViewModel>>> GetManagePagingBySubCategoryID(GetManagePostPagingRequest request);
		Task<List<PostViewModel>> GetAll();
		Task<ApiResult<List<PostViewModel>>> GetPopular();
		Task<ApiResult<bool>> TagAssign(int postID, TagAssignRequest request);
		Task<ApiResult<bool>> TagAssignAuthenticate(int postID, Guid userID, TagAssignRequest request);
		Task<int> AddImage(int postID, PostImageCreateRequest request);
		Task<int> AddImageAuthenticate(int postID, Guid userID, PostImageCreateRequest request);
		Task<ApiResult<string>> AddImageByUrl(int postID, PostImageCreateUrlRequest request);
		Task<ApiResult<string>> AddImageByUrlAuthenticate(int postID, Guid userID, PostImageCreateUrlRequest request);
		Task<ApiResult<bool>> RemoveImage(int imageID);
		Task<ApiResult<bool>> UpdateImage(int imageID, PostImageUpdateRequest request);
		Task<ApiResult<PostImageViewModel>> GetImageByID(int imageID);
		Task<List<PostImageViewModel>> GetListImages(int postID);
		Task<ApiResult<bool>> UpdateImageContents(int postID, PostUpdateContentsRequest request);
		Task<ApiResult<bool>> UpdateImageContentsAuthenticate(int postID, Guid userID, PostUpdateContentsRequest request);
		Task<ApiResult<PagedResult<PostViewModel>>> GetPagingCategory(GetPublicPostPagingRequest request);
		Task<ApiResult<PagedResult<PostViewModel>>> GetPagingSubCategory(GetPublicPostPagingRequest request);
		Task<ApiResult<PagedResult<PostViewModel>>> GetPagingTag(GetPublicPostPagingRequest request);
		Task<ApiResult<PagedResult<PostViewModel>>> GetPagingTagByName(GetPublicPostPagingRequestSearch request);
		Task<ApiResult<PagedResult<PostViewModel>>> GetPaging(GetPublicPostPagingRequestSearch request);
	}
}
