using AdvWeb_VN.Application.Catalog.Posts.Dtos;
using AdvWeb_VN.Application.Catalog.Posts.Dtos.Public;
using AdvWeb_VN.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdvWeb_VN.Application.Catalog.Posts
{
	public interface IPublicPostService
	{
		Task<PagedResult<PostViewModel>> GetAllCategoryId(GetPublicPostPagingRequest request);
	}
}
