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
	public class PostService : IPostService
	{
		private readonly AdvWebDbContext context;
		public PostService(AdvWebDbContext context)
		{
			this.context = context;
		}

		public async Task<ApiResult<bool>> AddViewCount(string postId)
		{
			var post = await context.Posts.FindAsync(postId);
			if (post == null) return new ApiErrorResult<bool>("Không tìm thấy bài viết này!");
			post.View += 1;
			await context.SaveChangesAsync();
			return new ApiSuccessResult<bool>();
		}

		public async Task<ApiResult<string>> Create(PostCreateRequest request)
		{
			var query = from li in context.Categories
						where li.CategoryID.Equals(request.CategoryID)
						select li;
			var list = await query.ToListAsync<Category>();
			if (list.Count == 0) return new ApiErrorResult<string>($"Không tìm thấy chuyên mục : {request.CategoryID}");
			
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
			var result = await context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<string>("Thêm bài viết thất bại");
			return new ApiSuccessResult<string>(PostID);
		}

		public async Task<ApiResult<bool>> Delete(string postId)
		{
			var post = await context.Posts.FindAsync(postId);
			if (post == null) return new ApiErrorResult<bool>($"Không tìm thấy bài viết : {postId}");
			context.Posts.Remove(post);
			var result = await context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Xóa bài viết thất bại");
			return new ApiSuccessResult<bool>();
		}

		public async Task<PagedResult<PostViewModel>> GetAllPaging(GetManagePostPagingRequest request)
		{
			var query = from p in context.Posts
						join pt in context.Comments on p.PostID equals pt.PostID
						join pic in context.PostTags on p.PostID equals pic.PostID
						join c in context.Tags on pic.TagID equals c.TagID
						select new { p, pt, pic };
			if(!string.IsNullOrEmpty(request.Keyword))
			{
				query = query.Where(x => x.pt.Commenter.Contains(request.Keyword));
			}
			if(request.TagIds != null && request.TagIds.Count>0)
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
					UserName = x.p.User.UserName,
					CategoryName = x.p.Category.CategoryName
				}).ToListAsync();
			var pagedResult = new PagedResult<PostViewModel>()
			{
				TotalRecord = totalRow,
				Items = data
			};
			return pagedResult;
		}

		public async Task<ApiResult<PostViewModel>> GetByID(string postID)
		{
			var post = await context.Posts.FindAsync(postID);
			if (post == null) return new ApiErrorResult<PostViewModel>("Không tìm thấy bài viết này!");
			var user = await context.Users.FirstOrDefaultAsync(x => x.Id == post.UserID);
			var category = await context.Categories.FirstOrDefaultAsync(x => x.CategoryID == post.CategoryID);
			var postViewModel = new PostViewModel()
			{
				PostID = post.PostID,
				PostName = post.PostName,
				WriteTime = post.WriteTime,
				View = post.View,
				Thumbnail = post.Thumbnail,
				Contents = post.Contents,
				CategoryID = post.CategoryID,
				UserName = user.UserName,
				CategoryName = category.CategoryName
			};
			
			return new ApiSuccessResult<PostViewModel>(postViewModel);
		}

		public async Task<ApiResult<bool>> Update(PostUpdateRequest request)
		{
			var post = await context.Posts.FindAsync(request.PostID);
			if (post == null) return new ApiErrorResult<bool>($"Không tìm thấy bài viết : {request.PostID}");
			
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
			var result = await context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Cập nhật bài viết thất bại");
			return new ApiSuccessResult<bool>();
		}
		public async Task<List<PostViewModel>> GetAll()
		{
			var query = from p in context.Posts
						select p;

			var data = await query.Select(x => new PostViewModel()
			{
				PostID = x.PostID,
				PostName = x.PostName,
				WriteTime = x.WriteTime,
				View = x.View,
				Thumbnail = x.Thumbnail,
				Contents = x.Contents,
				CategoryID = x.CategoryID,
				UserName = x.User.UserName,
				CategoryName = x.Category.CategoryName
			}).ToListAsync();

			return data;
		}

		public async Task<PagedResult<PostViewModel>> GetAllByTagID(GetPublicPostPagingRequest request)
		{
			var query = from p in context.Posts
						join pic in context.PostTags on p.PostID equals pic.PostID
						join c in context.Tags on pic.TagID equals c.TagID
						join d in context.Users on p.UserID equals d.Id
						join e in context.Categories on p.CategoryID equals e.CategoryID
						select new { p, pic, d, e };

			if (request.Id.HasValue && request.Id.Value > 0)
			{
				query = query.Where(x => x.pic.TagID == request.Id);
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
					UserName = x.d.UserName,
					CategoryName = x.e.CategoryName
				}).ToListAsync();
			var pagedResult = new PagedResult<PostViewModel>()
			{
				TotalRecord = totalRow,
				Items = data
			};
			return pagedResult;
		}

		public async Task<PagedResult<PostViewModel>> GetAllByCategoryID(GetPublicPostPagingRequest request)
		{
			var query = from c in context.Categories
						join p in context.Posts on c.CategoryID equals p.CategoryID
						join d in context.Users on p.UserID equals d.Id
						select new { p, c, d };

			if (request.Id.HasValue && request.Id.Value > 0)
			{
				query = query.Where(x => x.c.CategoryID == request.Id);
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
					UserName = x.d.UserName,
					CategoryName = x.c.CategoryName
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
