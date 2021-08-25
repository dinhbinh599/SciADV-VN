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

namespace AdvWeb_VN.Application.Catalog.Categories
{
	public class CategoryService : ICategoryService
	{
		private readonly AdvWebDbContext _context;
		public CategoryService(AdvWebDbContext context)
		{
			_context = context;
		}

		public async Task<ApiResult<bool>> Create(CategoryCreateRequest request)
		{
			var category = new Category()
			{
				CategoryName = request.CategoryName,
				CreateDate = DateTime.Now,
			};
			_context.Categories.Add(category);
			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Thêm chuyên mục thất bại");
			return new ApiSuccessResult<bool>();
		}

		public async Task<ApiResult<bool>> Delete(int categoryID)
		{
			var category = await _context.Categories.FindAsync(categoryID);
			if (category == null) return new ApiErrorResult<bool>($"Không tìm thấy chuyên mục : {categoryID}");
			_context.Categories.Remove(category);
			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Xóa chuyên mục thất bại");
			return new ApiSuccessResult<bool>();
		}

		public async Task<List<CategoryViewModel>> GetAll()
		{
			var query = from p in _context.Categories
						select p;

			var data = await query.Select(x => new CategoryViewModel()
			{
				CategoryID = x.CategoryID,
				CategoryName = x.CategoryName,
				SubCount = x.SubCategories.Count,
				CreateDate = x.CreateDate
			}).ToListAsync();

			return data;
		}

		public async Task<ApiResult<CategoryViewModel>> GetByID(int categoryID)
		{
			var category = await _context.Categories.FindAsync(categoryID);
			var subs = await _context.SubCategories.Where(x => x.CategoryID.Equals(categoryID)).ToListAsync();
			if (category == null) return new ApiErrorResult<CategoryViewModel>("Không tìm thấy chuyên mục này!");
			var categoryVM = new CategoryViewModel()
			{
				CategoryID = category.CategoryID,
				CategoryName = category.CategoryName,
				SubCount = subs.Count,
				CreateDate = category.CreateDate
			};

			return new ApiSuccessResult<CategoryViewModel>(categoryVM);
		}

		public async Task<ApiResult<List<CategoryViewModel>>> GetFooterCategory()
		{
			var category = _context.Categories;

			var categoryVMs = await category.Select(x => new CategoryViewModel()
			{
				CategoryID = x.CategoryID,
				CategoryName = x.CategoryName,
				CreateDate = x.CreateDate,
				SubCount = x.SubCategories.Count,
				PostCount = _context.Posts.Where(p => p.CategoryID.Equals(x.CategoryID)).Count()
			}).Distinct().ToListAsync();

			return new ApiSuccessResult<List<CategoryViewModel>>(categoryVMs);
		}

		public async Task<ApiResult<List<CategoryMenuViewModel>>> GetMenuCategory()
		{
			var category = _context.Categories;

			var categoryMenuVM = await category.Select(x => new CategoryMenuViewModel()
			{
				CategoryID = x.CategoryID,
				CategoryName = x.CategoryName,
				CreateDate = x.CreateDate,
				SubCount = x.SubCategories.Count,
				SubCategoryAll = new SubCategoryMenuViewModel()
				{
					SubCategoryName = "All",
					Posts = _context.Posts
					.Where(p => p.CategoryID.Equals(x.CategoryID))
					.Select(p=>new PostViewModel() 
					{
						PostID = p.PostID,
						PostName = p.PostName,
						SubCategoryID = p.SubCategoryID,
						SubCategoryName = p.SubCategory.CategoryName,
						WriteTime = p.WriteTime,
						Thumbnail = p.Thumbnail
					}).OrderBy(x => x.WriteTime).Take(4).ToList()
				},
				SubCategories = x.SubCategories
					.Select(sc => new SubCategoryMenuViewModel()
					{
						SubCategoryID = sc.SubCategoryID,
						SubCategoryName = sc.CategoryName,
						CreateDate = sc.CreateDate,
						PostCount = sc.Posts.Count,
						Posts = sc.Posts
							.Select(p => new PostViewModel()
							{
								PostID = p.PostID,
								PostName = p.PostName,
								SubCategoryID = p.SubCategoryID,
								SubCategoryName = sc.CategoryName,
								WriteTime = p.WriteTime,
								Thumbnail = p.Thumbnail
							}).OrderBy(x => x.WriteTime).Take(4).ToList()
					}).ToList()
			}).ToListAsync();
			return new ApiSuccessResult<List<CategoryMenuViewModel>>(categoryMenuVM);
		}

		public async Task<ApiResult<bool>> Update(CategoryUpdateRequest request)
		{
			var category = await _context.Categories.FindAsync(request.CategoryID);
			if (category == null) return new ApiErrorResult<bool>($"Không tìm thấy chuyên mục : {request.CategoryName}");

			category.CategoryName = request.CategoryName;
			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Cập nhật chuyên mục thất bại");
			return new ApiSuccessResult<bool>();
		}
	}
}
