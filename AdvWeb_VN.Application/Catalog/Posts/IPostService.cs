﻿using AdvWeb_VN.Application.Catalog.Posts.Dtos;
using AdvWeb_VN.ViewModels.Catalog.Posts;
using AdvWeb_VN.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdvWeb_VN.Application.Catalog.Posts
{
	public interface IPostService
	{
		Task<ApiResult<string>> Create(PostCreateRequest request);

		Task<ApiResult<bool>> Update(PostUpdateRequest request);

		Task<ApiResult<bool>> Delete(string postId);

		Task<ApiResult<bool>> AddViewCount(string postId);
		Task<ApiResult<PostViewModel>> GetByID(string postID);
		Task<PagedResult<PostViewModel>> GetAllPaging(GetManagePostPagingRequest request);
		Task<PagedResult<PostViewModel>> GetAllByTagID(GetPublicPostPagingRequest request);
		Task<PagedResult<PostViewModel>> GetAllByCategoryID(GetPublicPostPagingRequest request);
		Task<List<PostViewModel>> GetAll();
	}
}
