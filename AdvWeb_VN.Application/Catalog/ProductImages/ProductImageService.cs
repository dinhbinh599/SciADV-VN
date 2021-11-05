using AdvWeb_VN.Data.EF;
using AdvWeb_VN.Data.Entities;
using AdvWeb_VN.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdvWeb_VN.Utilities.Dtos;
using AdvWeb_VN.Utilities.Settings;
using AdvWeb_VN.ViewModels.Common;
using AdvWeb_VN.ViewModels.Catalog.Posts;
using AdvWeb_VN.Application.Catalog.Posts;
using AdvWeb_VN.ViewModels.Catalog.Categories;
using AdvWeb_VN.ViewModels.Catalog.Tags;
using AdvWeb_VN.ViewModels.Catalog.SubCategories;
using AdvWeb_VN.ViewModels.Catalog.ProductImages;

namespace AdvWeb_VN.Application.Catalog.ProductImages
{
	public class ProductImageService : IProductImageService
	{
		private readonly AdvWebDbContext _context;
		public ProductImageService(AdvWebDbContext context)
		{
			_context = context;
		}

		public async Task<ApiResult<PagedResult<PostImageViewModel>>> GetImagesPaging(GetManagePostPagingRequest request)
		{
			var query = _context.PostImages;


			int totalRow = await query.CountAsync();

			var postImageVMs = await query.OrderByDescending(x => x.DateCreated).Skip((request.PageIndex - 1) * request.PageSize)
				.Take(request.PageSize)
				.Select(x => new PostImageViewModel()
				{
					ImagePath = x.ImagePath,
					FileSize = x.FileSize,
					ID = x.ID,
					DateCreated = x.DateCreated,
					Caption = x.Caption
				}).ToListAsync();

			var pagedResult = new PagedResult<PostImageViewModel>()
			{
				Items = postImageVMs,
				PageIndex = request.PageIndex,
				PageSize = request.PageSize,
				TotalRecords = totalRow
			};
			return new ApiSuccessResult<PagedResult<PostImageViewModel>>(pagedResult);


		}
	}
}
