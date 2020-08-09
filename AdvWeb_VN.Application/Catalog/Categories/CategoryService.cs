﻿using AdvWeb_VN.Data.EF;
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

namespace AdvWeb_VN.Application.Catalog.Categories
{
	public class CategoryService : ICategoryService
	{
		private readonly AdvWebDbContext context;
		public CategoryService(AdvWebDbContext context)
		{
			this.context = context;
		}

		public async Task<ApiResult<bool>> Create(CategoryCreateRequest request)
		{
			var category = new Category()
			{
				CategoryName = request.CategoryName,
				CreateDate = DateTime.Now,
			};
			context.Categories.Add(category);
			var result = await context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Thêm chuyên mục thất bại");
			return new ApiSuccessResult<bool>();
		}

		public async Task<ApiResult<bool>> Delete(int categoryID)
		{
			var category = await context.Categories.FindAsync(categoryID);
			if (category == null) return new ApiErrorResult<bool>($"Không tìm thấy chuyên mục : {categoryID}");
			context.Categories.Remove(category);
			var result = await context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Xóa chuyên mục thất bại");
			return new ApiSuccessResult<bool>();
		}

		public async Task<List<CategoryViewModel>> GetAll()
		{
			var query = from p in context.Categories
						select p;

			var data = await query.Select(x => new CategoryViewModel()
			{
				CategoryID = x.CategoryID,
				CategoryName = x.CategoryName,
				CreateDate = x.CreateDate
			}).ToListAsync();

			return data;
		}

		public async Task<ApiResult<CategoryViewModel>> GetByID(int categoryID)
		{
			var category = await context.Categories.FindAsync(categoryID);
			if (category == null) return new ApiErrorResult<CategoryViewModel>("Không tìm thấy chuyên mục này!");
			var categoryVM = new CategoryViewModel()
			{
				CategoryID = category.CategoryID,
				CategoryName = category.CategoryName,
				CreateDate = category.CreateDate
			};

			return new ApiSuccessResult<CategoryViewModel>(categoryVM);
		}

		public async Task<ApiResult<bool>> Update(CategoryUpdateRequest request)
		{
			var category = await context.Categories.FindAsync(request.CategoryID);
			if (category == null) return new ApiErrorResult<bool>($"Không tìm thấy chuyên mục : {request.CategoryName}");

			category.CategoryName = request.CategoryName;
			var result = await context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Cập nhật bài viết thất bại");
			return new ApiSuccessResult<bool>();
		}
	}
}
