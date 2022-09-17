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
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using AdvWeb_VN.Application.Common;

namespace AdvWeb_VN.Application.Catalog.ProductImages
{
	public class ProductImageService : IProductImageService
	{
		private readonly AdvWebDbContext _context;
		private readonly IStorageService _storageService;
		private const string USER_CONTENT_FOLDER_NAME = "user-content";
		public ProductImageService(AdvWebDbContext context, IStorageService storageService)
		{
			_context = context;
			_storageService = storageService;
		}

		public async Task<ApiResult<string>> Create(PostImageCreateRequest request)
		{
			if (request.ImageFile != null)
			{
				var imagePath = await this.SaveFile(request.ImageFile);
				imagePath = USER_CONTENT_FOLDER_NAME + "/" + imagePath;
				return new ApiSuccessResult<string>(imagePath);
			}
			return new ApiErrorResult<string>("Không tạo hình ảnh được");
		}

		private async Task<string> SaveFile(IFormFile file)
		{
			var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
			var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
			await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
			return fileName;
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

		public async Task<ApiResult<bool>> ImageAssign(ImageAssignRequest request)
		{
			//Gắn Image cho bài viết.
			//Gắn nhiều Image một lúc.
			foreach (var postImage in request.postImages)
			{
                if (!_context.PostImages.Any(x => x.ImagePath == postImage.ImagePath))
                {
                    _context.PostImages.Add(new PostImage()
                    {
                        ImagePath = postImage.ImagePath,
                        PostID = postImage.PostID,
                        Caption = postImage.Caption,
                        DateCreated = DateTime.Now,
						IsDefault = false,
                        FileSize = postImage.FileSize
                    });
                }
            }
            var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Thêm hình ảnh thất bại.");
			return new ApiSuccessResult<bool>();
		}

        public async Task<ApiResult<bool>> ImageUnassignAll(int postId)
        {
            _context.PostImages.RemoveRange(_context.PostImages.Where(x => x.PostID == postId));
			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Xóa hình ảnh thất bại.");
            return new ApiSuccessResult<bool>();
        }
    }
}
