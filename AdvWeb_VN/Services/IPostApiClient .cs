using AdvWeb_VN.ViewModels.Catalog.Posts;
using AdvWeb_VN.ViewModels.Catalog.ProductImages;
using AdvWeb_VN.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvWeb_VN.WebApp.Services
{
	public interface IPostApiClient
	{
		Task<ApiResult<PagedResult<PostViewModel>>> GetPostsPagings(GetPublicPostPagingRequest request);
		Task<ApiResult<PostViewModel>> GetByID(string id);
		Task<ApiResult<List<PostViewModel>>> GetPopular();
		Task<ApiResult<PagedResult<PostViewModel>>> GetPostsPagingsCategory(GetPublicPostPagingRequest request);
	}
}
