using AdvWeb_VN.ViewModels.Catalog.Categories;
using AdvWeb_VN.ViewModels.Catalog.Posts;
using AdvWeb_VN.ViewModels.Catalog.ProductImages;
using AdvWeb_VN.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdvWeb_VN.Application.Catalog.ProductImages
{
	public interface IProductImageService
	{
		Task<ApiResult<PagedResult<PostImageViewModel>>> GetImagesPaging(GetManagePostPagingRequest request);
	}
}
