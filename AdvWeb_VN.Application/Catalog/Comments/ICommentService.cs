using AdvWeb_VN.ViewModels.Catalog.Categories;
using AdvWeb_VN.ViewModels.Catalog.Comments;
using AdvWeb_VN.ViewModels.Catalog.Posts;
using AdvWeb_VN.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdvWeb_VN.Application.Catalog.Comments
{
	public interface ICommentService
	{
		Task<ApiResult<bool>> CreateCommentPublic(CommentCreatePublicRequest request);
		Task<ApiResult<bool>> CreateCommentManage(CommentCreateManageRequest request);
		Task<ApiResult<bool>> CreateCommentAuthenticate(CommentCreateManageRequest request);
		Task<ApiResult<bool>> AddCommentLike(int commentID);
		Task<ApiResult<bool>> AddCommentDislike(int commentID);
		Task<ApiResult<bool>> UpdateComment(CommentUpdateRequest request);
		Task<ApiResult<bool>> UpdateCommentAuthenticate(Guid id, CommentUpdateRequest request);
		Task<ApiResult<bool>> DeleteComment(int commentID);
		Task<ApiResult<CommentViewModel>> GetCommentByID(int commentID);
		Task<ApiResult<PagedResult<CommentViewModel>>> GetManagePagingByPostID(GetManageCommentPagingRequest request);
		Task<ApiResult<PagedResult<CommentViewModel>>> GetManagePagingByPostIDAuthenticate(Guid id,GetManageCommentPagingRequest request);
		Task<ApiResult<PagedResult<CommentViewModel>>> GetPagingByPostID(GetPublicPostPagingRequest request);
		Task<ApiResult<PagedResult<CommentViewModel>>> GetPagingNewComment(GetManageCommentPagingRequest request);
		Task<ApiResult<PagedResult<CommentViewModel>>> GetPagingNewCommentAuthenticate(Guid id,GetManageCommentPagingRequest request);
		Task<ApiResult<bool>> MarkViewComment(int commentID);
		Task<ApiResult<bool>> MarkViewCommentAuthenticate(Guid id,int commentID);
		Task<ApiResult<int>> GetNewCountAuthenticate(Guid id);
		Task<ApiResult<int>> GetNewCount();
		Task<List<CommentViewModel>> GetAll();
	}
}
