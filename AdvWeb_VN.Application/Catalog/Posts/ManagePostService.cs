using AdvWeb_VN.Application.Catalog.Posts.Dtos;
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

namespace AdvWeb_VN.Application.Catalog.Posts
{
	public class ManagePostService : IManagePostService
	{
		private readonly AdvWebDbContext context;

		public ManagePostService(AdvWebDbContext context)
		{
			this.context = context;
		}

		public async Task AddViewCount(string postId)
		{
			var post = await context.Posts.FindAsync(postId);
			post.View += 1;
			await context.SaveChangesAsync();
		}

		public async Task<string> Create(PostCreateRequest request)
		{
			var query = from li in context.Categories
						where li.CategoryID.Equals(request.CategoryID)
						select li;

			if (query == null) throw new AdvWebException($"Cannot find a Category : {request.CategoryID}");
			
			var query2 = from c in context.Posts
						 where c.CategoryID.Equals(request.CategoryID)
						 select c;

			string PostID = "";
			Category category = query.FirstOrDefault<Category>();
			if (query2.Count() > 0)
			{
				Post lastPost = query2.ToList<Post>().Last();
				SplitResult splitResult = new Split().GetID(lastPost.PostID, category.CategoryName.Length);
				PostID = splitResult.CategoryName + (splitResult.Number + 1);
			}
			else
			{
				PostID = category.CategoryName + "1";
			}
			var post = new Post()
			{
				PostID = PostID,
				PostName = request.PostName,
				Thumbnail = request.Thumbnail,
				Contents = request.Contents,
				View = 0,
				UserID = request.UserID,
				CategoryID = request.CategoryID,
				WriteTime = DateTime.Now,
			};
			context.Posts.Add(post);
			await context.SaveChangesAsync();
			return PostID;
		}

		public async Task<int> Delete(string postId)
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
					CategoryID = x.p.CategoryID,
					UserName = x.p.User.UserName
				}).ToListAsync();
			var pagedResult = new PagedResult<PostViewModel>()
			{
				TotalRecord = totalRow,
				Items = data
			};
			return pagedResult;
		}

		public async Task<PostViewModel> GetByID(string postID)
		{
			var post = await context.Posts.FindAsync(postID);
			var user = await context.Users.FirstOrDefaultAsync(x => x.Id == post.UserID);
			
			var postViewModel = new PostViewModel()
			{
				PostID = post.PostID,
				PostName = post.PostName,
				WriteTime = post.WriteTime,
				View = post.View,
				Thumbnail = post.Thumbnail,
				Contents = post.Contents,
				CategoryID = post.CategoryID,
				UserName = user.UserName
			};
			
			return postViewModel;
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
			/*string PostID = "";
			if (!post.CategoryID.Equals(request.CategoryID))
			{
				post.CategoryID = request.CategoryID;
				var query = from li in context.Categories
							where li.CategoryID.Equals(request.CategoryID)
							select li;

				var query2 = from c in context.Posts
							 where c.CategoryID.Equals(request.CategoryID)
							 select c;

				Category category = query.FirstOrDefault<Category>();
				if (query2.Count() > 0)
				{
					Post lastPost = query2.ToList<Post>().Last();
					SplitResult splitResult = new Split().GetID(lastPost.PostID, category.CategoryName.Length);
					PostID = splitResult.CategoryName + (splitResult.Number + 1);
				}
				else
				{
					PostID = category.CategoryName + "1";
				}
			}
			post.PostID = PostID;*/
			return await context.SaveChangesAsync();
		}
	}
}
