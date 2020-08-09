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
using AdvWeb_VN.Application.Catalog.Categories;
using AdvWeb_VN.ViewModels.Catalog.Tags;

namespace AdvWeb_VN.Application.Catalog.Tags
{
	public class TagService : ITagService
	{
		private readonly AdvWebDbContext context;
		public TagService(AdvWebDbContext context)
		{
			this.context = context;
		}

		public async Task<ApiResult<bool>> Create(TagCreateRequest request)
		{
			var tag = new Tag()
			{
				TagName = request.TagName,
			};
			context.Tags.Add(tag);
			var result = await context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Thêm Tag thất bại");
			return new ApiSuccessResult<bool>();
		}

		public async Task<ApiResult<bool>> Delete(int tagID)
		{
			var tag = await context.Tags.FindAsync(tagID);
			if (tag == null) return new ApiErrorResult<bool>($"Không tìm thấy Tag : {tag.TagName}");
			context.Tags.Remove(tag);
			var result = await context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Xóa Tag thất bại");
			return new ApiSuccessResult<bool>();
		}

		public async Task<List<TagViewModel>> GetAll()
		{
			var query = from p in context.Tags
						select p;

			var data = await query.Select(x => new TagViewModel()
			{
				TagID = x.TagID,
				TagName = x.TagName
			}).ToListAsync();

			return data;
		}

		public async Task<ApiResult<TagViewModel>> GetByID(int tagID)
		{
			var tag = await context.Tags.FindAsync(tagID);
			if (tag == null) return new ApiErrorResult<TagViewModel>("Không tìm thấy chuyên mục này!");
			var tagVM = new TagViewModel()
			{
				TagID = tag.TagID,
				TagName = tag.TagName
			};

			return new ApiSuccessResult<TagViewModel>(tagVM);
		}

		public async Task<ApiResult<bool>> Update(TagUpdateRequest request)
		{
			var tag = await context.Tags.FindAsync(request.TagID);
			if (tag == null) return new ApiErrorResult<bool>($"Không tìm thấy Tag : {request.TagName}");

			tag.TagName = request.TagName;
			var result = await context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Cập nhật Tag thất bại");
			return new ApiSuccessResult<bool>();
		}
	}
}
