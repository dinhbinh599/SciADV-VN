using AdvWeb_VN.ViewModels.Catalog.Posts;
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

		Task<ApiResult<bool>> Update(PostUpdateRequest request);

		Task<ApiResult<bool>> Delete(string postID);

		Task<ApiResult<bool>> AddViewCount(string postID);
		Task<ApiResult<PostViewModel>> GetByID(string postID);
		Task<PagedResult<PostViewModel>> GetAllPagingTagID(GetManagePostPagingRequest request);
		Task<PagedResult<PostViewModel>> GetAllPagingCategoryID(GetManagePostPagingRequest request);
		Task<PagedResult<PostViewModel>> GetAllByTagID(GetPublicPostPagingRequest request);
		Task<PagedResult<PostViewModel>> GetAllByCategoryID(GetPublicPostPagingRequest request);
		Task<List<PostViewModel>> GetAll();
		public Task<ApiResult<bool>> TagAssign(string postID, TagAssignRequest request);
		public Task<ApiResult<bool>> TagAssignByTagName(string postID, string tagName);
		public Task<ApiResult<bool>> TagRemoveByTagName(string postID, string tagName);
	}
}
