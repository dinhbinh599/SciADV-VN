using AdvWeb_VN.ViewModels.Catalog.Comments;
using AdvWeb_VN.ViewModels.Catalog.Posts;
using AdvWeb_VN.ViewModels.Catalog.Tags;
using AdvWeb_VN.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvWeb_VN.ManageApp.Services
{
	public interface ICommentApiClient
	{
		Task<ApiResult<PagedResult<CommentViewModel>>> GetCommentsPagingsByPostID(GetManageCommentPagingRequest request);
		Task<ApiResult<bool>> CreateComment(CommentCreateManageRequest createRequest);
		Task<ApiResult<bool>> DeleteComment(int id);
		Task<ApiResult<bool>> AddCommentLike(int commentID);
		Task<ApiResult<bool>> AddCommentDislike(int commentID);
		Task<ApiResult<CommentViewModel>> GetCommentByID(int id);
		Task<ApiResult<bool>> UpdateComment(int id, CommentUpdateRequest request);
		Task<ApiResult<PagedResult<CommentViewModel>>> GetNewCommentsPagings(GetManageCommentPagingRequest request);
		Task<ApiResult<int>> GetNewCount();
		Task<ApiResult<bool>> MarkViewComment(int commentID);
	}
}
