using AdvWeb_VN.Application.Catalog.Posts.Dtos;
using AdvWeb_VN.Application.Catalog.Posts.Dtos.Manage;
using AdvWeb_VN.Application.Dtos;
using AdvWeb_VN.Data.EF;
using AdvWeb_VN.Data.Entities;
using AdvWeb_VN.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AdvWeb_VN.Application.Catalog.Posts
{
	public class ManagePostService : IManagePostService
	{
		private readonly AdvWebDbContext context;

		public ManagePostService(AdvWebDbContext context)
		{
			this.context = context;
		}

		public async Task AddViewCount(int postId)
		{
			var post = await context.Posts.FindAsync(postId);
			post.View += 1;
			await context.SaveChangesAsync();
		}

		public async Task<int> Create(PostCreateRequest request)
		{
			var post = new Post()
			{
				PostID = "",
				PostName = request.PostName,
				Thumbnail = request.Thumbnail,
				Contents = request.Contents,
				View = 0,
				WriteTime = DateTime.Now,
			};
			context.Posts.Add(post);
			return await context.SaveChangesAsync();
		}

		public async Task<int> Delete(int postId)
		{
			var post = await context.Posts.FindAsync(postId);
			if (post == null) throw new AdvWebException($"Cannot find a Post : {postId}");
			context.Posts.Remove(post);
			return await context.SaveChangesAsync();
		}

		public async Task<PagedResult<PostViewModel>> GetAllPaging(GetManagePostPagingRequest request)
		{
			var query = from p in context.Posts
						join pt in context.Comments on p.PostID equals pt.PostID
						join pic in context.PostTags on p.PostID equals pic.PostID
						join c in context.Tags on pic.TagID equals c.TagID
						select new { p, pt, pic };
			if(!string.IsNullOrEmpty(request.KeyWord))
			{
				query = query.Where(x => x.pt.Commenter.Contains(request.KeyWord));
			}
			if(request.TagIds.Count>0)
			{
				query = query.Where(x => request.TagIds.Contains(x.pic.TagID));
			}
			
			int totalRow = await query.CountAsync();

			var data = query.Skip((request.PageIndex - 1) * request.PageSize)
				.Take(request.PageSize)
				.Select(x => new PostViewModel()
				{
					PostID = x.p.PostID,
					PostName = x.p.PostName,
					WriteTime = x.p.WriteTime,
					View = x.p.View,
					Thumbnail = x.p.Thumbnail,
					Contents = x.p.Contents
				}).ToListAsync();
			var pagedResult = new PagedResult<PostViewModel>()
			{
				
			};
			return pagedResult;
		}

		public async Task<int> Update(PostUpdateRequest request)
		{
			var post = await context.Posts.FindAsync(request.PostID);
			if (post == null) throw new AdvWebException($"Cannot find a Post : {request.PostID}");
			post.PostName = request.PostName;
			post.Thumbnail = request.Thumbnail;
			post.Contents = request.Contents;
			post.WriteTime = DateTime.Now;
			post.CategoryID = request.CategoryID;
			return await context.SaveChangesAsync();
		}
	}
}
