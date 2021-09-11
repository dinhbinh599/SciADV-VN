using AdvWeb_VN.ViewModels.Catalog.Categories;
using AdvWeb_VN.ViewModels.Catalog.Comments;
using AdvWeb_VN.ViewModels.Catalog.Posts;
using AdvWeb_VN.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvWeb_VN.WebApp.Services
{
	public interface ICommentApiClient
	{
		Task<ApiResult<PagedResult<CommentViewModel>>> GetPagingByPostID(GetPublicPostPagingRequest request);
		Task<ApiResult<bool>> CreateComment(CommentCreatePublicRequest createRequest);
	}
}
