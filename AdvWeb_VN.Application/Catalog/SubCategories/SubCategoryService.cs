﻿using AdvWeb_VN.Data.EF;
using AdvWeb_VN.Data.Entities;
using AdvWeb_VN.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdvWeb_VN.ViewModels.Common;
using AdvWeb_VN.ViewModels.Catalog.SubCategories;

namespace AdvWeb_VN.Application.Catalog.SubCategories
{
	public class SubCategoryService : ISubCategoryService
	{
		private readonly AdvWebDbContext _context;
		public SubCategoryService(AdvWebDbContext context)
		{
			_context = context;
		}

		public async Task<ApiResult<bool>> Create(SubCategoryCreateRequest request)
		{
			//Tạo chuyên mục con mới (Admin Only)
			var category = new SubCategory()
			{
				CategoryName = request.CategoryName,
				CreateDate = DateTime.Now.ToUniversalTime(),
				IsShow = request.IsShow,
				CategoryID = request.CategoryID
			};
			_context.SubCategories.Add(category);
			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Thêm chuyên mục thất bại");
			return new ApiSuccessResult<bool>();
		}

		public async Task<ApiResult<bool>> Delete(int categoryID)
		{
			//Xóa chuyên mục con (Admin Only)
			var category = await _context.SubCategories.FindAsync(categoryID);
			if (category == null) return new ApiErrorResult<bool>($"Không tìm thấy chuyên mục : {categoryID}");
			_context.SubCategories.Remove(category);
			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Xóa chuyên mục thất bại");
			return new ApiSuccessResult<bool>();
		}

		public async Task<List<SubCategoryViewModel>> GetAll()
		{
			//Lấy danh sách toàn bộ chuyên mục con
			var query = from p in _context.SubCategories
						join c in _context.Categories on p.CategoryID equals c.CategoryID
						select new { p, c };

			var data = await query.Select(x => new SubCategoryViewModel()
			{
				SubCategoryID = x.p.SubCategoryID,
				SubCategoryName = x.p.CategoryName,
				CategoryName = x.c.CategoryName,
				PostCount = x.p.Posts.Count,
				IsShow = x.p.IsShow,
				CreateDate = x.p.CreateDate,
				CategoryID = x.c.CategoryID
			}).ToListAsync();

			return data;
		}

		public async Task<List<SubCategoryViewModel>> GetByCategoryID(int categoryID)
		{
			var query = from p in _context.SubCategories
						join c in _context.Categories on p.CategoryID equals c.CategoryID
						select new { p, c };

			query = query.Where(x => x.p.CategoryID.Equals(categoryID));

			var data = await query.Select(x => new SubCategoryViewModel()
			{
				SubCategoryID = x.p.SubCategoryID,
				SubCategoryName = x.p.CategoryName,
				CategoryName = x.c.CategoryName,
				PostCount = x.p.Posts.Count,
				CreateDate = x.p.CreateDate,
				IsShow = x.p.IsShow,
				CategoryID = x.c.CategoryID
			}).ToListAsync();

			return data;
		}

		public async Task<ApiResult<SubCategoryViewModel>> GetByID(int categoryID)
		{
			//Lấy thông tin chuyên mục con dựa vào ID
			var subCategory = await _context.SubCategories.FindAsync(categoryID);
			var posts = await _context.Posts.Where(x => x.SubCategoryID.Equals(categoryID)).ToListAsync();
			var category = (await _context.Categories.Where(x=>x.CategoryID.Equals(subCategory.CategoryID)).ToListAsync()).FirstOrDefault();
			if (subCategory == null) return new ApiErrorResult<SubCategoryViewModel>("Không tìm thấy chuyên mục này!");
			var categoryVM = new SubCategoryViewModel()
			{
				SubCategoryID = subCategory.SubCategoryID,
				SubCategoryName = subCategory.CategoryName,
				CategoryName = category.CategoryName,
				PostCount = posts.Count,
				IsShow = subCategory.IsShow,
				CategoryID = category.CategoryID,
				CreateDate = subCategory.CreateDate
			};

			return new ApiSuccessResult<SubCategoryViewModel>(categoryVM);
		}


		public async Task<ApiResult<bool>> Update(SubCategoryUpdateRequest request)
		{
			//Chỉnh sửa thông tin chuyên mục con (Admin Only)
			var category = await _context.SubCategories.FindAsync(request.SubCategoryID);
			if (category == null) return new ApiErrorResult<bool>($"Không tìm thấy chuyên mục : {request.CategoryName}");

			category.CategoryName = request.SubCategoryName;
			category.CategoryID = request.CategoryID;
			category.IsShow = request.IsShow;

			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Cập nhật chuyên mục thất bại");
			return new ApiSuccessResult<bool>();
		}
	}
}
