﻿using AdvWeb_VN.Application.Catalog.Posts.Dtos;
using AdvWeb_VN.Application.Catalog.Posts.Dtos.Public;
using AdvWeb_VN.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.Application.Catalog.Posts
{
	public class PublicPostService : IPublicPostService
	{
		public PagedResult<PostViewModel> GetAllCategoryId(GetPublicPostPagingRequest request)
		{
			throw new NotImplementedException();
		}
	}
}
