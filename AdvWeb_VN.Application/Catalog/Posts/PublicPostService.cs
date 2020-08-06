﻿using AdvWeb_VN.Application.Catalog.Posts.Dtos;
using AdvWeb_VN.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AdvWeb_VN.ViewModels.Common;
using AdvWeb_VN.ViewModels.Catalog.Posts;

namespace AdvWeb_VN.Application.Catalog.Posts
{
	public class PublicPostService : IPublicPostService
	{
		private readonly AdvWebDbContext context;
		public PublicPostService(AdvWebDbContext context)
		{
			this.context = context;
		}

		public async Task<List<PostViewModel>> GetAll()
		{
			var query = from p in context.Posts
						join pt in context.Comments on p.PostID equals pt.PostID
						join pic in context.PostTags on p.PostID equals pic.PostID
						join c in context.Tags on pic.TagID equals c.TagID
						select new { p, pt, pic };

			var data = await query.Select(x => new PostViewModel()
				{
					PostID = x.p.PostID,
					PostName = x.p.PostName,
					WriteTime = x.p.WriteTime,
					View = x.p.View,
					Thumbnail = x.p.Thumbnail,
					Contents = x.p.Contents,
					CategoryID = x.p.CategoryID
				}).ToListAsync();
	
			return data;
		}

		public async Task<PagedResult<PostViewModel>> GetAllCategoryId(GetPublicPostPagingRequest request)
		{
			var query = from p in context.Posts
						join pt in context.Comments on p.PostID equals pt.PostID
						join pic in context.PostTags on p.PostID equals pic.PostID
						join c in context.Tags on pic.TagID equals c.TagID
						select new { p, pt, pic };
			
			if (request.TagId.HasValue&&request.TagId.Value>0)
			{
				query = query.Where(x => x.pic.TagID == request.TagId);
			}

			int totalRow = await query.CountAsync();

			var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
				.Take(request.PageSize)
				.Select(x => new PostViewModel()
				{
					PostID = x.p.PostID,
					PostName = x.p.PostName,
					WriteTime = x.p.WriteTime,
					View = x.p.View,
					Thumbnail = x.p.Thumbnail,
					Contents = x.p.Contents,
					CategoryID = x.p.CategoryID
				}).ToListAsync();
			var pagedResult = new PagedResult<PostViewModel>()
			{
				TotalRecord = totalRow,
				Items = data
			};
			return pagedResult;
		}
	}
}
