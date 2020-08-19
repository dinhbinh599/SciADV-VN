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
using AdvWeb_VN.ViewModels.Catalog.Tags;
using AdvWeb_VN.ViewModels.Common.Tags;

namespace AdvWeb_VN.Application.Catalog.Tags
{
	public class TagService : ITagService
	{
		private readonly AdvWebDbContext _context;
		public TagService(AdvWebDbContext context)
		{
			_context = context;
		}

		public async Task<ApiResult<bool>> Create(TagCreateRequest request)
		{
			var tag = new Tag()
			{
				TagName = request.TagName,
			};
			_context.Tags.Add(tag);
			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Thêm Tag thất bại");
			return new ApiSuccessResult<bool>();
		}

		public async Task<ApiResult<bool>> Delete(int tagID)
		{
			var tag = await _context.Tags.FindAsync(tagID);
			if (tag == null) return new ApiErrorResult<bool>($"Không tìm thấy Tag : {tag.TagName}");
			_context.Tags.Remove(tag);
			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Xóa Tag thất bại");
			return new ApiSuccessResult<bool>();
		}

		public async Task<ApiResult<List<TagViewModel>>> GetAll()
		{
			var query = from p in _context.Tags
						select p;

			var data = await query.Select(x => new TagViewModel()
			{
				TagID = x.TagID,
				TagName = x.TagName,
				PostCount = x.PostTags.Count
			}).ToListAsync();

			return new ApiSuccessResult<List<TagViewModel>>(data);
		}

		public async Task<ApiResultSelect2<List<TagViewModelSelect2>>> GetAllSelect2()
		{
			var query = from p in _context.Tags
						select p;

			var data = await query.Select(x => new TagViewModelSelect2()
			{
				id = x.TagID,
				text = x.TagName,
				selected = false
			}).ToListAsync();

			return new ApiSuccessResultSelect2<List<TagViewModelSelect2>>(data);
		}

		public async Task<ApiResult<TagViewModel>> GetByID(int tagID)
		{
			var tag = await _context.Tags.FindAsync(tagID);
			var posts = await _context.PostTags.Where(x => x.TagID.Equals(tagID)).ToListAsync();
			if (tag == null) return new ApiErrorResult<TagViewModel>("Không tìm thấy chuyên mục này!");
			var tagVM = new TagViewModel()
			{
				TagID = tag.TagID,
				TagName = tag.TagName,
				PostCount = posts.Count
			};

			return new ApiSuccessResult<TagViewModel>(tagVM);
		}

		public async Task<ApiResult<bool>> Update(TagUpdateRequest request)
		{
			var tag = await _context.Tags.FindAsync(request.TagID);
			if (tag == null) return new ApiErrorResult<bool>($"Không tìm thấy Tag : {request.TagName}");

			tag.TagName = request.TagName;
			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Cập nhật Tag thất bại");
			return new ApiSuccessResult<bool>();
		}
	}
}
