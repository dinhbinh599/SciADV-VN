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
using AdvWeb_VN.ViewModels.Catalog.ProductImages;
using AdvWeb_VN.Application.Common;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Net.Http;
using AdvWeb_VN.Application.Catalog.Tags;
using AdvWeb_VN.ViewModels.Catalog.Tags;

namespace AdvWeb_VN.Application.Catalog.Posts
{
	public class PostService : IPostService
	{
		private readonly AdvWebDbContext _context;
		private readonly IStorageService _storageService;
		private readonly ITagService _tagService;

		public PostService(AdvWebDbContext context, IStorageService storageService, ITagService tagService)
		{
			_context = context;
			_storageService = storageService;
			_tagService = tagService;
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
				SplitResult splitResult = new SplitResult();
				var posts = await query2.ToListAsync<Post>();
				splitResult = new Split().GetID(posts.FirstOrDefault().PostID, category.CategoryName.Length);
				var max = splitResult.Number;
				foreach (var item in posts)
				{
					splitResult = new Split().GetID(item.PostID, category.CategoryName.Length);
					if (splitResult.Number > max) max = splitResult.Number;
				}
				PostID = splitResult.name + (max + 1);
			}
			else
			{
				PostID = category.CategoryName + "1";
			}
			var post = new Post()
			{
				PostID = PostID,
				PostName = request.PostName,
				Contents = request.Contents,
				View = 0,
				UserID = request.UserID,
				CategoryID = request.CategoryID,
				WriteTime = DateTime.Now,
			};
			if (request.ThumbnailFile != null)
			{
				post.PostImages = new List<PostImage>()
				{
					new PostImage()
					{
						//Caption = "Thumbnail image",
						DateCreated = DateTime.Now,
						FileSize = request.ThumbnailFile.Length,
						ImagePath = await this.SaveFile(request.ThumbnailFile),
						IsDefault = true
					}
				};
				post.Thumbnail = post.PostImages.FirstOrDefault().ImagePath;
			}
			_context.Posts.Add(post);
			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<string>("Thêm bài viết thất bại");
			return new ApiSuccessResult<string>(PostID);
		}

		public async Task<ApiResult<bool>> Delete(string postID)
		{
			var post = await _context.Posts.FindAsync(postID);
			if (post == null) return new ApiErrorResult<bool>($"Không tìm thấy bài viết : {postID}");
			var images = _context.PostImages.Where(i => i.PostID == postID);
			foreach (var image in images)
			{
				await _storageService.DeleteFileAsync(image.ImagePath);
			}
			_context.Posts.Remove(post);
			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Xóa bài viết thất bại");
			return new ApiSuccessResult<bool>();
		}

		public async Task<ApiResult<PagedResult<PostViewModel>>> GetAllPagingTagID(GetManagePostPagingRequest request)
		{
			var query = from p in _context.Posts
						join pic in _context.PostTags on p.PostID equals pic.PostID
						join e in _context.Categories on p.CategoryID equals e.CategoryID
						join c in _context.Tags on pic.TagID equals c.TagID
						join u in _context.Users on p.UserID equals u.Id
						select new { p, pic, c, e, u};

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
				TotalRecords = totalRow,
				PageIndex = request.PageIndex,
				PageSize = request.PageSize,
				Items = data
			};
			return new ApiSuccessResult<PagedResult<PostViewModel>>(pagedResult);
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

		public async Task<ApiResult<bool>> Update(string id,PostUpdateRequest request)
		{
			var post = await _context.Posts.FindAsync(id);
			if (post == null) return new ApiErrorResult<bool>($"Không tìm thấy bài viết : {request.PostID}");
			
			post.PostName = request.PostName;
			post.Contents = request.Contents;
			post.WriteTime = DateTime.Now;
			post.CategoryID = request.CategoryID;
			if (request.ThumbnailFile != null)
			{
				var thumbnailFile = await _context.PostImages.FirstOrDefaultAsync(i => i.IsDefault == true && i.PostID == request.PostID);
				if (thumbnailFile != null)
				{
					thumbnailFile.FileSize = request.ThumbnailFile.Length;
					thumbnailFile.ImagePath = await this.SaveFile(request.ThumbnailFile);
					post.Thumbnail = thumbnailFile.ImagePath;
					_context.PostImages.Update(thumbnailFile);
				}
			}
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

		public async Task<ApiResult<PagedResult<PostViewModel>>> GetAllByTagID(GetPublicPostPagingRequest request)
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
				TotalRecords = totalRow,
				PageSize = request.PageSize,
				PageIndex = request.PageIndex,
				Items = data
			};
			return new ApiSuccessResult<PagedResult<PostViewModel>>(pagedResult);
		}

		public async Task<ApiResult<PagedResult<PostViewModel>>> GetAllByCategoryID(GetPublicPostPagingRequest request)
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
				TotalRecords = totalRow,
				PageIndex = request.PageIndex,
				PageSize = request.PageSize,
				Items = data
			};
			return new ApiSuccessResult<PagedResult<PostViewModel>>(pagedResult);
		}

		public async Task<ApiResult<PagedResult<PostViewModel>>> GetAllPagingCategoryID(GetManagePostPagingRequest request)
		{
			var query = from c in _context.Categories
						join p in _context.Posts on c.CategoryID equals p.CategoryID
						join d in _context.Users on p.UserID equals d.Id
						select new { p, c, d };

			if (!string.IsNullOrEmpty(request.Keyword))
			{
				query = query.Where(x => x.c.CategoryName.Contains(request.Keyword)||x.p.PostName.Contains(request.Keyword));
			}

			if (request.ID != null)
			{
				query = query.Where(x => request.ID.Equals(x.p.CategoryID)||request.ID.ToString().Contains(x.p.PostID));
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
				TotalRecords = totalRow,
				PageSize = request.PageSize,
				PageIndex = request.PageIndex,
				Items = data
			};
			return new ApiSuccessResult<PagedResult<PostViewModel>>(pagedResult);
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
			//await RemoveFromTagAsync(post, removedTags);

			var addedTags = request.Tags.Where(x => x.Selected).Select(x => new {x.ID ,x.Name }).ToList();
			foreach (var tag in addedTags)
			{
				if (tag.ID.Equals("0")) await _tagService.Create(new TagCreateRequest
				{
					TagName = tag.Name
				});

				if (await IsInTagAsync(post, tag.Name) == false)
				{
					await AddToTagAsync(post, tag.Name);
				}
			}
			
			return new ApiSuccessResult<bool>();
		}

		public async Task RemoveFromTagAsync(Post post, List<string> tagNames)
		{
			foreach (var tagName in tagNames)
			{
				if (await IsInTagAsync(post, tagName) == true)
				{
					await RemoveFromTagAsync(post, tagName);
				}
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

		public async Task<int> AddImage(string postID, PostImageCreateRequest request)
		{
			var postImage = new PostImage()
			{
				//Caption = request.Caption,
				DateCreated = DateTime.Now,
				PostID = postID,
				IsDefault = false
			};

			if (request.ImageFile != null)
			{
				postImage.ImagePath = await this.SaveFile(request.ImageFile);
				postImage.FileSize = request.ImageFile.Length;
			}
			_context.PostImages.Add(postImage);
			await _context.SaveChangesAsync();
			return postImage.ID;
		}
		private async Task<string> SaveFile(IFormFile file)
		{
			var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
			var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
			await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
			return fileName;
		}

		public static string GetFileExtensionFromUrl(string url)
		{
			url = url.Split('?')[0];
			url = url.Split('/').Last();
			return url.Contains('.') ? url.Substring(url.LastIndexOf('.')) : "";
		}

		private async Task<ImageFileInfo> SaveFileUrl(string url, string postID)
		{
			var fileName = $"{Guid.NewGuid()}{postID}{GetFileExtensionFromUrl(url)}";
			var fileSize =  await _storageService.SaveFileByUrlAsync(url, fileName);
			return new ImageFileInfo(fileName, fileSize);
		}

		public async Task<ApiResult<bool>> RemoveImage(int imageID)
		{
			var postImage = await _context.PostImages.FindAsync(imageID);
			if (postImage == null) new ApiErrorResult<bool>($"Cannot find an image with id {imageID}");
			_context.PostImages.Remove(postImage);
			await _context.SaveChangesAsync();
			return new ApiSuccessResult<bool>();
		}

		public async Task<ApiResult<bool>> UpdateImage(int imageID, PostImageUpdateRequest request)
		{
			var postImage = await _context.PostImages.FindAsync(imageID);
			if (postImage == null) return new ApiErrorResult<bool>($"Cannot find an image with id {imageID}");

			//postImage.Caption = request.Caption;
			postImage.DateCreated = DateTime.Now;
			
			if (request.ImageFile != null)
			{
				postImage.ImagePath = await this.SaveFile(request.ImageFile);
				postImage.FileSize = request.ImageFile.Length;
			}
			_context.PostImages.Update(postImage);
			await _context.SaveChangesAsync();
			return new ApiSuccessResult<bool>();
		}

		public async Task<ApiResult<PostImageViewModel>> GetImageByID(int imageID)
		{
			var image = await _context.PostImages.FindAsync(imageID);
			if (image == null) return new ApiErrorResult<PostImageViewModel>($"Cannot find an image with id {imageID}");

			var viewModel = new PostImageViewModel()
			{
				//Caption = image.Caption,
				DateCreated = image.DateCreated,
				FileSize = image.FileSize,
				ID = image.ID,
				ImagePath = image.ImagePath,
				PostID = image.PostID,
			};
			return new ApiSuccessResult<PostImageViewModel>(viewModel);
		}

		public async Task<List<PostImageViewModel>> GetListImages(string postID)
		{
			return await _context.PostImages.Where(x => x.PostID == postID)
				.Select(i => new PostImageViewModel()
				{
					//Caption = i.Caption,
					DateCreated = i.DateCreated,
					FileSize = i.FileSize,
					ID = i.ID,
					ImagePath = i.ImagePath,
					PostID = i.PostID
				}).ToListAsync();
		}

		public async Task<ApiResult<string>> AddImageByUrl(string postID, PostImageCreateUrlRequest request)
		{
			var postImage = new PostImage()
			{
				//Caption = request.Caption,
				DateCreated = DateTime.Now,
				PostID = postID,
				IsDefault = false
			};

			if (request.ImageUrl != null)
			{
				var imageFileInfo = await SaveFileUrl(request.ImageUrl, postID);
				postImage.ImagePath = imageFileInfo.FileName;
				postImage.FileSize = imageFileInfo.FileSize;
			}
			_context.PostImages.Add(postImage);
			await _context.SaveChangesAsync();
			return new ApiSuccessResult<string>(postImage.ImagePath);
		}

		public async Task<ApiResult<bool>> UpdateImageContents(string postID, PostUpdateContentsRequest request)
		{
			var post = await _context.Posts.FindAsync(postID);
			if (post == null) return new ApiErrorResult<bool>($"Không tìm thấy bài viết : {postID}");
			post.Contents = request.Contents;
			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Cập nhật bài viết thất bại");
			return new ApiSuccessResult<bool>();
		}

		public async Task<ApiResult<bool>> UpdateAuthenticate(string id, Guid userID, PostUpdateRequest request)
		{
			var post = await _context.Posts.Where(x=>x.PostID.Equals(id)&&x.UserID.Equals(userID)).FirstOrDefaultAsync();
			if (post == null) return new ApiErrorResult<bool>($"Không tìm thấy bài viết : {request.PostID}");

			post.PostName = request.PostName;
			post.Contents = request.Contents;
			post.WriteTime = DateTime.Now;
			post.CategoryID = request.CategoryID;

			if (request.ThumbnailFile != null)
			{
				var thumbnailFile = await _context.PostImages.FirstOrDefaultAsync(i => i.IsDefault == true && i.PostID == request.PostID);
				if (thumbnailFile != null)
				{
					thumbnailFile.FileSize = request.ThumbnailFile.Length;
					thumbnailFile.ImagePath = await this.SaveFile(request.ThumbnailFile);
					post.Thumbnail = thumbnailFile.ImagePath;
					_context.PostImages.Update(thumbnailFile);
				}
			}
			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Cập nhật bài viết thất bại");
			return new ApiSuccessResult<bool>();
		}

		public async Task<ApiResult<bool>> DeleteAuthenticate(string postID, Guid userID)
		{
			var post = await _context.Posts.Where(x=>x.PostID.Equals(postID) &&x.UserID.Equals(userID)).FirstOrDefaultAsync();
			if (post == null) return new ApiErrorResult<bool>($"Không tìm thấy bài viết : {postID}");
			var images = _context.PostImages.Where(i => i.PostID == postID);
			foreach (var image in images)
			{
				await _storageService.DeleteFileAsync(image.ImagePath);
			}
			_context.Posts.Remove(post);
			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Xóa bài viết thất bại");
			return new ApiSuccessResult<bool>();
		}

		public async Task<ApiResult<PostViewModel>> GetByIDAuthenticate(string postID, Guid userID)
		{
			var post = await _context.Posts.Where(x=>x.PostID.Equals(postID)&&x.UserID.Equals(userID)).FirstOrDefaultAsync();
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

		public async Task<ApiResult<PagedResult<PostViewModel>>> GetAllPagingCategoryIDAuthenticate(Guid userID, GetManagePostPagingRequest request)
		{
			var query = from c in _context.Categories
						join p in _context.Posts on c.CategoryID equals p.CategoryID
						join d in _context.Users on p.UserID equals d.Id
						select new { p, c, d };

			query = query.Where(x => x.p.UserID.Equals(userID));

			if (!string.IsNullOrEmpty(request.Keyword))
			{
				query = query.Where(x => x.c.CategoryName.Contains(request.Keyword) || x.p.PostName.Contains(request.Keyword));
			}

			if (request.ID != null)
			{
				query = query.Where(x => request.ID.Equals(x.p.CategoryID) || request.ID.ToString().Contains(x.p.PostID));
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
				TotalRecords = totalRow,
				PageSize = request.PageSize,
				PageIndex = request.PageIndex,
				Items = data
			};
			return new ApiSuccessResult<PagedResult<PostViewModel>>(pagedResult);
		}

		public async Task<ApiResult<string>> AddImageByUrlAuthenticate(string postID, Guid userID, PostImageCreateUrlRequest request)
		{
			var post = await _context.Posts.FindAsync(postID);
			if(!post.UserID.Equals(userID)) return new ApiErrorResult<string>("Bạn không có quyền!!!");

			var postImage = new PostImage()
			{
				//Caption = request.Caption,
				DateCreated = DateTime.Now,
				PostID = postID,
				IsDefault = false
			};

			if (request.ImageUrl != null)
			{
				var imageFileInfo = await SaveFileUrl(request.ImageUrl, postID);
				postImage.ImagePath = imageFileInfo.FileName;
				postImage.FileSize = imageFileInfo.FileSize;
			}
			_context.PostImages.Add(postImage);
			await _context.SaveChangesAsync();
			return new ApiSuccessResult<string>(postImage.ImagePath);
		}

		public async Task<ApiResult<bool>> UpdateImageContentsAuthenticate(string postID, Guid userID, PostUpdateContentsRequest request)
		{
			var post = await _context.Posts.FindAsync(postID);
			if (!post.UserID.Equals(userID)) return new ApiErrorResult<bool>("Bạn không có quyền!!!");
			if (post == null) return new ApiErrorResult<bool>($"Không tìm thấy bài viết : {postID}");
			post.Contents = request.Contents;
			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Cập nhật bài viết thất bại");
			return new ApiSuccessResult<bool>();
		}

		public async Task<int> AddImageAuthenticate(string postID, Guid userID, PostImageCreateRequest request)
		{
			var post = await _context.Posts.FindAsync(postID);
			if (!post.UserID.Equals(userID)) throw new AdvWebException("Bạn không có quyền!!!");
			var postImage = new PostImage()
			{
				//Caption = request.Caption,
				DateCreated = DateTime.Now,
				PostID = postID,
				IsDefault = false
			};

			if (request.ImageFile != null)
			{
				postImage.ImagePath = await this.SaveFile(request.ImageFile);
				postImage.FileSize = request.ImageFile.Length;
			}
			_context.PostImages.Add(postImage);
			await _context.SaveChangesAsync();
			return postImage.ID;
		}

		public async Task<ApiResult<bool>> TagAssignAuthenticate(string postID, Guid userID, TagAssignRequest request)
		{
			var post = await _context.Posts.Where(x=>x.PostID.Equals(postID)&&x.UserID.Equals(userID)).FirstOrDefaultAsync();
			if (post == null) return new ApiErrorResult<bool>("Bài viết không tồn tại");
			var removedTags = request.Tags.Where(x => x.Selected == false).Select(x => x.Name).ToList();
			foreach (var tagName in removedTags)
			{
				if (await IsInTagAsync(post, tagName) == true)
				{
					await RemoveFromTagAsync(post, tagName);
				}
			}
			//await RemoveFromTagAsync(post, removedTags);

			var addedTags = request.Tags.Where(x => x.Selected).Select(x => new { x.ID, x.Name }).ToList();
			foreach (var tag in addedTags)
			{
				if (tag.ID.Equals("0")) await _tagService.Create(new TagCreateRequest
				{
					TagName = tag.Name
				});

				if (await IsInTagAsync(post, tag.Name) == false)
				{
					await AddToTagAsync(post, tag.Name);
				}
			}

			return new ApiSuccessResult<bool>();
		}
	}
}
