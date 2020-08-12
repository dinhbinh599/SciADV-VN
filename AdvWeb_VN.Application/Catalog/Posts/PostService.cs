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
		private readonly AdvWebDbContext _context;
		public PostService(AdvWebDbContext context)
		{
			_context = context;
		}

		public async Task<ApiResult<bool>> AddViewCount(string postID)
		{
			var post = await _context.Posts.FindAsync(postID);
			if (post == null) return new ApiErrorResult<bool>("Không tìm thấy bài viết này!");
			post.View += 1;
			await _context.SaveChangesAsync();
			return new ApiSuccessResult<bool>();
		}

		public async Task<ApiResult<string>> Create(PostCreateRequest request)
		{
			var query = from li in _context.Categories
						where li.CategoryID.Equals(request.CategoryID)
						select li;
			var list = await query.ToListAsync<Category>();
			if (list.Count == 0) return new ApiErrorResult<string>($"Không tìm thấy chuyên mục : {request.CategoryID}");
			
			var query2 = from c in _context.Posts
						 where c.CategoryID.Equals(request.CategoryID)
						 select c;

			string PostID = "";
			Category category = query.FirstOrDefault<Category>();
			if (query2.Count() > 0)
			{
				Post lastPost = query2.ToList<Post>().Last();
				SplitResult splitResult = new Split().GetID(lastPost.PostID, category.CategoryName.Length);
				PostID = splitResult.name + (splitResult.Number + 1);
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
			_context.Posts.Add(post);
			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<string>("Thêm bài viết thất bại");
			return new ApiSuccessResult<string>(PostID);
		}

		public async Task<ApiResult<bool>> Delete(string postID)
		{
			var post = await _context.Posts.FindAsync(postID);
			if (post == null) return new ApiErrorResult<bool>($"Không tìm thấy bài viết : {postID}");
			_context.Posts.Remove(post);
			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Xóa bài viết thất bại");
			return new ApiSuccessResult<bool>();
		}

		public async Task<PagedResult<PostViewModel>> GetAllPagingTagID(GetManagePostPagingRequest request)
		{
			var query = from p in _context.Posts
						join pt in _context.Comments on p.PostID equals pt.PostID
						join pic in _context.PostTags on p.PostID equals pic.PostID
						join e in _context.Categories on p.CategoryID equals e.CategoryID
						join c in _context.Tags on pic.TagID equals c.TagID
						join u in _context.Users on p.UserID equals u.Id
						select new { p, pt, pic, c, e, u};

			if(!string.IsNullOrEmpty(request.Keyword))
			{
				query = query.Where(x => x.c.TagName.Contains(request.Keyword));
			}
			if(request.IDs != null && request.IDs.Count>0)
			{
				query = query.Where(x => request.IDs.Contains(x.pic.TagID));
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
					UserName = x.u.UserName,
					CategoryName = x.e.CategoryName
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
			var post = await _context.Posts.FindAsync(postID);
			if (post == null) return new ApiErrorResult<PostViewModel>("Không tìm thấy bài viết này!");
			var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == post.UserID);
			var tag = await GetTagsAsync(post);
			var category = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryID == post.CategoryID);
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
				CategoryName = category.CategoryName,
				Tags = tag
			};
			
			return new ApiSuccessResult<PostViewModel>(postViewModel);
		}

		public async Task<ApiResult<bool>> Update(PostUpdateRequest request)
		{
			var post = await _context.Posts.FindAsync(request.PostID);
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
				var query = from li in _context.Categories
							where li.CategoryID.Equals(request.CategoryID)
							select li;

				var query2 = from c in _context.Posts
							 where c.CategoryID.Equals(request.CategoryID)
							 select c;

				Category category = query.FirstOrDefault<Category>();
				if (query2.Count() > 0)
				{
					Post lastPost = query2.ToList<Post>().Last();
					SplitResult splitResult = new Split().GetID(lastPost.PostID, category.CategoryName.Length);
					PostID = splitResult.name + (splitResult.Number + 1);
				}
				else
				{
					PostID = category.CategoryName + "1";
				}
			}
			post.PostID = PostID;*/
			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Cập nhật bài viết thất bại");
			return new ApiSuccessResult<bool>();
		}
		public async Task<List<PostViewModel>> GetAll()
		{
			var query = from p in _context.Posts
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
			var query = from p in _context.Posts
						join pic in _context.PostTags on p.PostID equals pic.PostID
						join c in _context.Tags on pic.TagID equals c.TagID
						join d in _context.Users on p.UserID equals d.Id
						join e in _context.Categories on p.CategoryID equals e.CategoryID
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
			var query = from c in _context.Categories
						join p in _context.Posts on c.CategoryID equals p.CategoryID
						join d in _context.Users on p.UserID equals d.Id
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

		public async Task<PagedResult<PostViewModel>> GetAllPagingCategoryID(GetManagePostPagingRequest request)
		{
			var query = from c in _context.Categories
						join p in _context.Posts on c.CategoryID equals p.CategoryID
						join d in _context.Users on p.UserID equals d.Id
						select new { p, c, d };

			if (!string.IsNullOrEmpty(request.Keyword))
			{
				query = query.Where(x => x.c.CategoryName.Contains(request.Keyword));
			}

			/*if (request.ID != null)
			{
				query = query.Where(x => request.ID.Equals(x.p.CategoryID));
			}*/

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

		public async Task<ApiResult<bool>> TagAssignByTagName(string postID, string tagName)
		{
			var post = await _context.Posts.FindAsync(postID);
			if (post == null) return new ApiErrorResult<bool>("Bài viết không tồn tại");
			if (!await TagExistsAsync(tagName)) return new ApiErrorResult<bool>("Tag không tồn tại");
			if (await IsInTagAsync(post, tagName) == false)
			{
				await AddToTagAsync(post, tagName);
			}
			else { return new ApiErrorResult<bool>($"Bài viết này đã tồn tại Tag {tagName}"); }
			return new ApiSuccessResult<bool>();
		}

		public async Task<ApiResult<bool>> TagAssign(string id, TagAssignRequest request)
		{
			var post = await _context.Posts.FindAsync(id);
			if (post == null) return new ApiErrorResult<bool>("Bài viết không tồn tại");
			var removedTags = request.Tags.Where(x => x.Selected == false).Select(x => x.Name).ToList();
			foreach (var tagName in removedTags)
			{
				if (await IsInTagAsync(post, tagName) == true)
				{
					await RemoveFromTagAsync(post, tagName);
				}
			}
			await RemoveFromTagAsync(post, removedTags);

			var addedTags = request.Tags.Where(x => x.Selected).Select(x => x.Name).ToList();
			foreach (var tagName in addedTags)
			{
				if (await IsInTagAsync(post, tagName) == false)
				{
					await AddToTagAsync(post, tagName);
				}
			}

			return new ApiSuccessResult<bool>();
		}

		public async Task<ApiResult<bool>> TagRemoveByTagName(string postID, string tagName)
		{
			var post = await _context.Posts.FindAsync(postID);
			if (post == null) return new ApiErrorResult<bool>("Bài viết không tồn tại");
			if (!await TagExistsAsync(tagName)) return new ApiErrorResult<bool>("Tag không tồn tại");
			if (await IsInTagAsync(post, tagName) == true)
			{
				await RemoveFromTagAsync(post, tagName);
			}
			else { return new ApiErrorResult<bool>($"Bài viết này không tồn tại Tag {tagName}"); }
			return new ApiSuccessResult<bool>();
		}

		public async Task RemoveFromTagAsync(Post post, List<string> tagNames)
		{
			foreach (var tagName in tagNames)
			{
				await RemoveFromTagAsync(post, tagName);
			}
		}

		public async Task RemoveFromTagAsync(Post post, string tagName)
		{
			var query = from c in _context.Tags
						where c.TagName.Equals(tagName)
						select c;
			var tag = await query.FirstOrDefaultAsync();

			var postTag = _context.PostTags.Where(x=>x.PostID.Equals(post.PostID) && x.TagID.Equals(tag.TagID)).FirstOrDefault();

			_context.Remove(postTag);
			await _context.SaveChangesAsync();
		}

		public async Task AddToTagAsync(Post post, string tagName)
		{
			var query = from c in _context.Tags
						where c.TagName.Equals(tagName)
						select c;
			var tag = await query.FirstOrDefaultAsync();
			var postTag = new PostTag()
			{
				PostID = post.PostID,
				TagID = tag.TagID
			};
			_context.PostTags.Add(postTag);
			await _context.SaveChangesAsync();
		}
		public async Task<bool> IsInTagAsync(Post post, string tagName)
		{
			var query = from c in _context.Tags
						join d in _context.PostTags on c.TagID equals d.TagID
						select new { c, d};
			query = query.Where(x => x.c.TagName.Equals(tagName) && x.d.PostID.Equals(post.PostID));
			var ls = await query.ToListAsync();
			if (ls.Count == 0) return false;
			return true;
		}
		public async Task<bool> TagExistsAsync(string tagName)
		{
			var query = from c in _context.Tags where c.TagName.Equals(tagName)
						select c;
			var ls = await query.ToListAsync();
			if (ls.Count == 0) return false;
			return true;
		}

		public async Task<IList<string>> GetTagsAsync(Post post)
		{
			var query = from c in _context.Posts
						join d in _context.PostTags on c.PostID equals d.PostID
						join e in _context.Tags on d.TagID equals e.TagID
						select new {c,e };
			var data = await query.Where(x => x.c.PostID.Equals(post.PostID))
				.Select(x=>x.e.TagName).ToListAsync();
			return data;
		}
	}
}
