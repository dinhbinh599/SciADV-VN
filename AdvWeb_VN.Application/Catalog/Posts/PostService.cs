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
using System.Threading;
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

		public async Task<ApiResult<bool>> AddViewCount(int postID)
		{
			//Tăng lượt xem
			var post = await _context.Posts.FindAsync(postID);
			if (post == null) return new ApiErrorResult<bool>("Không tìm thấy bài viết này!");
			post.View += 1;
			await _context.SaveChangesAsync();
			return new ApiSuccessResult<bool>();
		}

		public async Task<ApiResult<int>> Create(PostCreateRequest request)
		{
			//Tạo bài viết mới
			//Lưu ảnh Thumbnail của bài viết vào Server

			var post = new Post()
			{
				PostName = request.PostName,
				Contents = request.Contents,
				Summary = request.Summary,
				View = 0,
				UserID = request.UserID,
				CategoryID = request.CategoryID,
				IsShow = request.IsShow,
				SubCategoryID = request.SubCategoryID,
				WriteTime = request.WriteTime.ToUniversalTime(),
			};

			if (request.ThumbnailFile != null)
			{
				post.PostImages = new List<PostImage>()
				{
					new PostImage()
					{
						//Caption = "Thumbnail image",
						DateCreated = DateTime.Now.ToUniversalTime(),
						FileSize = request.ThumbnailFile.Length,
						ImagePath = await this.SaveFile(request.ThumbnailFile),
						IsDefault = true
					}
				};
				post.Thumbnail = post.PostImages.FirstOrDefault().ImagePath;
			}
			_context.Posts.Add(post);
			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<int>("Thêm bài viết thất bại");
			return new ApiSuccessResult<int>(post.PostID);
		}

		public async Task<ApiResult<bool>> Delete(int postID)
		{
			//Xóa bài viết
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

		public async Task<ApiResult<PagedResult<PostViewModel>>> GetManagePagingByTagID(GetManagePostPagingRequest request)
		{
			//Lấy danh sách bài viết được Paging dựa vào TagID - Admin (hỗ trợ Tìm kiếm bằng keyword)
			var query = from p in _context.Posts
						join pic in _context.PostTags on p.PostID equals pic.PostID
						join e in _context.SubCategories on p.SubCategoryID equals e.SubCategoryID
						join k in _context.Categories on e.CategoryID equals k.CategoryID
						join c in _context.Tags on pic.TagID equals c.TagID
						join u in _context.Users on p.UserID equals u.Id
						select new { p, pic.TagID, k.CategoryName , c.TagName, e, u.UserName};

			if(!string.IsNullOrEmpty(request.Keyword))
			{
				query = query.Where(x => x.TagName.Contains(request.Keyword));
			}

			if(request.IDs != null && request.IDs.Count>0)
			{
				query = query.Where(x => request.IDs.Contains(x.TagID));
			}
			
			int totalRow = await query.CountAsync();

			var data = await query.OrderByDescending(x=>x.p.WriteTime).Skip((request.PageIndex - 1) * request.PageSize)
				.Take(request.PageSize)
				.Select(x => new PostViewModel()
				{
					PostID = x.p.PostID,
					PostName = x.p.PostName,
					WriteTime = x.p.WriteTime,
					View = x.p.View,
					Thumbnail = x.p.Thumbnail,
					//Contents = x.p.Contents,
					SubCategoryID = x.p.SubCategoryID,
					UserName = x.UserName,
					IsShow = x.p.IsShow,
					SubCategoryName = x.e.CategoryName,
					CategoryID = x.e.CategoryID,
					CategoryName = x.CategoryName
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

		public async Task<ApiResult<PostViewModel>> GetByID(int postID)
		{
			//Lấy thông tin của bài viết dựa vào ID
			var post = await _context.Posts.FindAsync(postID);
			if (post == null) return new ApiErrorResult<PostViewModel>("Không tìm thấy bài viết này!");
			var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == post.UserID);
			var tag = await GetTagsAsync(post);
			var subCategory = await _context.SubCategories.FirstOrDefaultAsync(x => x.SubCategoryID == post.SubCategoryID);
			var category = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryID == subCategory.CategoryID);
			var postViewModel = new PostViewModel()
			{
				PostID = post.PostID,
				PostName = post.PostName,
				WriteTime = post.WriteTime,
				View = post.View,
				IsShow = post.IsShow,
				Thumbnail = post.Thumbnail,
				Contents = post.Contents,
				Summary = post.Summary,
				SubCategoryID = post.SubCategoryID,
				UserName = user.UserName,
				SubCategoryName = subCategory.CategoryName,
				CategoryID = subCategory.CategoryID,
				CategoryName = category.CategoryName,
				Tags = tag
			};
			
			return new ApiSuccessResult<PostViewModel>(postViewModel);
		}

		public async Task<ApiResult<bool>> Update(int id, PostUpdateRequest request)
		{
			//Chỉnh sửa thông tin bài viết
			var post = await _context.Posts.FindAsync(id);
			if (post == null) return new ApiErrorResult<bool>($"Không tìm thấy bài viết : {request.PostID}");

			post.PostName = request.PostName;
			post.Contents = request.Contents;
			post.Summary = request.Summary;
			post.WriteTime = request.WriteTime.ToUniversalTime();
			post.SubCategoryID = request.SubCategoryID;
			post.CategoryID = request.CategoryID;
			post.IsShow = request.IsShow;
			if (request.ThumbnailFile != null)
			{
				var thumbnailFile = await _context.PostImages.FirstOrDefaultAsync(i => i.IsDefault == true && i.ImagePath == post.Thumbnail);
				if (thumbnailFile != null)
				{
					thumbnailFile.FileSize = request.ThumbnailFile.Length;
					thumbnailFile.ImagePath = await this.SaveFile(request.ThumbnailFile);
					post.Thumbnail = thumbnailFile.ImagePath;
					_context.PostImages.Update(thumbnailFile);
				}
			}
			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Cập nhật bài viết thất bại. Thông tin sai hoặc bài viết của bạn không thay đổi. Nếu muốn Edit với nhiều thông tin cũ hơn vui lòng thoát ra và chọn Edit lại.");
			return new ApiSuccessResult<bool>();
		}
		public async Task<List<PostViewModel>> GetAll()
		{
			//Lấy toàn bộ dữ liệu của bài viết
			var query = from p in _context.Posts
						select p;

			var data = await query.OrderByDescending(x=>x.WriteTime).Select(x => new PostViewModel()
			{
				PostID = x.PostID,
				PostName = x.PostName,
				WriteTime = x.WriteTime,
				View = x.View,
				Thumbnail = x.Thumbnail,
				//Contents = x.Contents,
				SubCategoryID = x.SubCategoryID,
				UserName = x.User.UserName,
				SubCategoryName = x.SubCategory.CategoryName
			}).ToListAsync();

			return data;
		}

		public async Task<ApiResult<List<PostViewModel>>> GetPopular()
		{

			var timeNow = DateTime.Now.ToUniversalTime();

			//Lấy danh sách Top 4 bài viết nhiều View nhất
			var postVMs = await _context.Posts.Where(x => x.IsShow == true 
			&& x.WriteTime.CompareTo(timeNow) < 0)
				.Select(x => new PostViewModel()
			{
				PostID = x.PostID,
				PostName = x.PostName,
				WriteTime = x.WriteTime,
				View = x.View,
				Thumbnail = x.Thumbnail,
				//Contents = x.Contents,
				SubCategoryID = x.SubCategoryID,
				UserName = x.User.UserName,
				SubCategoryName = x.SubCategory.CategoryName
			}).OrderByDescending(x=>x.View).Take(5).ToListAsync();

			return new ApiSuccessResult<List<PostViewModel>>(postVMs);
		}

		public async Task<ApiResult<PagedResult<PostViewModel>>> GetPublicPagingByTagID(GetPublicPostPagingRequest request)
		{

			var timeNow = DateTime.Now.ToUniversalTime();

			//Lấy danh sách bài viết được Paging dựa vào TagID - WebApp.
			var query = from p in _context.Posts
						join pic in _context.PostTags on p.PostID equals pic.PostID
						join c in _context.Tags on pic.TagID equals c.TagID
						join d in _context.Users on p.UserID equals d.Id
						join e in _context.SubCategories on p.SubCategoryID equals e.SubCategoryID
						join k in _context.Categories on e.CategoryID equals k.CategoryID
						select new { p, pic.TagID, d.UserName, e, k };

			if (request.Id.HasValue && request.Id.Value > 0)
			{
				query = query.Where(x => x.TagID == request.Id);
			}

			int totalRow = await query.CountAsync();

			var data = await query.Where(x => x.p.IsShow == true 
					&& x.p.WriteTime.CompareTo(timeNow) < 0)
				.OrderByDescending(x=>x.p.WriteTime).Skip((request.PageIndex - 1) * request.PageSize)
				.Take(request.PageSize)
				.Select(x => new PostViewModel()
				{
					PostID = x.p.PostID,
					PostName = x.p.PostName,
					WriteTime = x.p.WriteTime,
					View = x.p.View,
					Thumbnail = x.p.Thumbnail,
					//Contents = x.p.Contents,
					SubCategoryID = x.p.SubCategoryID,
					UserName = x.UserName,
					SubCategoryName = x.e.CategoryName,
					CategoryID = x.e.CategoryID,
					CategoryName = x.k.CategoryName
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

		public async Task<ApiResult<PagedResult<PostViewModel>>> GetPublicPagingByCategoryID(GetPublicPostPagingRequest request)
		{

			var timeNow = DateTime.Now.ToUniversalTime();

			//Lấy danh sách bài viết được Paging dựa vào CategoryID - Webapp
			var query = from c in _context.SubCategories
						join k in _context.Categories on c.CategoryID equals k.CategoryID
						join p in _context.Posts on c.SubCategoryID equals p.SubCategoryID
						join d in _context.Users on p.UserID equals d.Id
						select new { p, c, d.UserName, k };

			if (request.Id.HasValue && request.Id.Value > 0)
			{
				query = query.Where(x => x.c.CategoryID == request.Id);
			}

			int totalRow = await query.CountAsync();

			var data = await query.Where(x => x.p.IsShow == true 
				&& x.p.WriteTime.CompareTo(timeNow) < 0)
				.OrderByDescending(x=>x.p.WriteTime).Skip((request.PageIndex - 1) * request.PageSize)
				.Take(request.PageSize)
				.Select(x => new PostViewModel()
				{
					PostID = x.p.PostID,
					PostName = x.p.PostName,
					WriteTime = x.p.WriteTime,
					View = x.p.View,
					Thumbnail = x.p.Thumbnail,
					//Contents = x.p.Contents,
					SubCategoryID = x.p.SubCategoryID,
					UserName = x.UserName,
					SubCategoryName = x.c.CategoryName,
					CategoryID = x.c.CategoryID,
					CategoryName = x.k.CategoryName
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

		public async Task<ApiResult<PagedResult<PostViewModel>>> GetManagePagingByCategoryID(GetManagePostPagingRequest request)
		{
			//Lấy danh sách bài viết được Paging dựa vào CategoryID - Admin (hỗ trợ Tìm kiếm bằng keyword)
			var query = from sc in _context.SubCategories
						join k in _context.Categories on sc.CategoryID equals k.CategoryID
						join p in _context.Posts on sc.SubCategoryID equals p.SubCategoryID
						join d in _context.Users on p.UserID equals d.Id
						select new { p, sc, d.UserName, k };

			if (!string.IsNullOrEmpty(request.Keyword))
			{
				query = query.Where(x => x.k.CategoryName.Contains(request.Keyword)||x.p.PostName.Contains(request.Keyword));
			}

			if (request.ID != null && request.ID != 0)
			{
				query = query.Where(x => request.ID.Equals(x.k.CategoryID)||request.ID==x.p.PostID);
			}

			int totalRow = await query.CountAsync();

			var data = await query.OrderByDescending(x=>x.p.WriteTime).Skip((request.PageIndex - 1) * request.PageSize)
				.Take(request.PageSize)
				.Select(x => new PostViewModel()
				{
					PostID = x.p.PostID,
					PostName = x.p.PostName,
					WriteTime = x.p.WriteTime,
					View = x.p.View,
					Thumbnail = x.p.Thumbnail,
					IsShow = x.p.IsShow,
					//Contents = x.p.Contents,
					SubCategoryID = x.p.SubCategoryID,
					UserName = x.UserName,
					SubCategoryName = x.sc.CategoryName,
					CategoryID = x.sc.CategoryID,
					CategoryName = x.k.CategoryName
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

		public async Task<ApiResult<bool>> TagAssign(int id, TagAssignRequest request)
		{
			//Gắn Tag cho bài viết.
			//Gắn nhiều Tag một lúc.
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
			//Xóa Tag khỏi post
			//Xóa 1 loạt dựa vào tên Tag
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
			////Xóa Tag khỏi post
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
			//Thêm Tag vào bài viết
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
			//Kiểm tra xem Tag đã được gán vào bài viết chưa
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
			//Kiểm tra sự tồn tại của Tag
			var query = from c in _context.Tags where c.TagName.Equals(tagName)
						select c;
			var ls = await query.ToListAsync();
			if (ls.Count == 0) return false;
			return true;
		}

		public async Task<IList<string>> GetTagsAsync(Post post)
		{
			//Lấy toàn bộ Tag đã được gán trong bài viết
			var query = from c in _context.Posts
						join d in _context.PostTags on c.PostID equals d.PostID
						join e in _context.Tags on d.TagID equals e.TagID
						select new {c,e };
			var data = await query.Where(x => x.c.PostID.Equals(post.PostID))
				.Select(x=>x.e.TagName).ToListAsync();
			return data;
		}

		public async Task<int> AddImage(int postID, PostImageCreateRequest request)
		{
			//Lưu hình ảnh trong bài viết vào Server
			var postImage = new PostImage()
			{
				//Caption = request.Caption,
				DateCreated = DateTime.Now.ToUniversalTime(),
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
			//Lấy định dạng của File
			url = url.Split('?')[0];
			url = url.Split('/').Last();
			return url.Contains('.') ? url.Substring(url.LastIndexOf('.')) : "";
		}

		private async Task<ImageFileInfo> SaveFileUrl(string url, int postID)
		{
			//Trả về thông tin về file
			var fileName = $"{Guid.NewGuid()}{postID}{GetFileExtensionFromUrl(url)}";
			var fileSize =  await _storageService.SaveFileByUrlAsync(url, fileName);
			return new ImageFileInfo(fileName, fileSize);
		}

		public async Task<ApiResult<bool>> RemoveImage(int imageID)
		{
			//Xóa hình ảnh
			var postImage = await _context.PostImages.FindAsync(imageID);
			if (postImage == null) new ApiErrorResult<bool>($"Không thể tìm thấy hình ảnh {imageID}");
			_context.PostImages.Remove(postImage);
			await _context.SaveChangesAsync();
			return new ApiSuccessResult<bool>();
		}

		public async Task<ApiResult<bool>> UpdateImage(int imageID, PostImageUpdateRequest request)
		{
			//Chỉnh sửa hình ảnh
			var postImage = await _context.PostImages.FindAsync(imageID);
			if (postImage == null) return new ApiErrorResult<bool>($"Cannot find an image with id {imageID}");

			//postImage.Caption = request.Caption;
			postImage.DateCreated = DateTime.Now.ToUniversalTime();
			
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
			//Lấy thông tin hình ảnh dựa vào ID
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

		public async Task<List<PostImageViewModel>> GetListImages(int postID)
		{
			//Lấy toàn bộ danh sách hình ảnh trong bài viết
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

		public async Task<ApiResult<string>> AddImageByUrl(int postID, PostImageCreateUrlRequest request)
		{
			//Thêm đường dẫn hình ảnh vào bảng.
			var postImage = new PostImage()
			{
				//Caption = request.Caption,
				DateCreated = DateTime.Now.ToUniversalTime(),
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

		public async Task<ApiResult<bool>> UpdateImageContents(int postID, PostUpdateContentsRequest request)
		{
			//Chỉnh sửa nội dung bài viết
			var post = await _context.Posts.FindAsync(postID);
			if (post == null) return new ApiErrorResult<bool>($"Không tìm thấy bài viết : {postID}");
			post.Contents = request.Contents;
			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Cập nhật bài viết thất bại");
			return new ApiSuccessResult<bool>();
		}

		public async Task<ApiResult<bool>> UpdateAuthenticate(int id, Guid userID, PostUpdateRequest request)
		{
			//Chỉnh sửa bài viết cho Writer (Chỉ có thể sửa bài viết của chính mình)
			var post = await _context.Posts.Where(x=>x.PostID.Equals(id)&&x.UserID.Equals(userID)).FirstOrDefaultAsync();
			if (post == null) return new ApiErrorResult<bool>($"Không tìm thấy bài viết : {request.PostID}");

			post.PostName = request.PostName;
			post.Contents = request.Contents;
			post.WriteTime = request.WriteTime.ToUniversalTime();
			post.SubCategoryID = request.SubCategoryID;
			post.CategoryID = request.CategoryID;
			post.IsShow = request.IsShow;

			if (request.ThumbnailFile != null)
			{
				var thumbnailFile = await _context.PostImages.FirstOrDefaultAsync(i => i.IsDefault == true && i.ImagePath == post.Thumbnail);
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

		public async Task<ApiResult<bool>> DeleteAuthenticate(int postID, Guid userID)
		{
			//Xóa bài viết cho Writer (Chỉ có thể xóa bài viết của chính mình)

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

		public async Task<ApiResult<PostViewModel>> GetByIDAuthenticate(int postID, Guid userID)
		{
			var post = await _context.Posts.Where(x=>x.PostID.Equals(postID)&&x.UserID.Equals(userID)).FirstOrDefaultAsync();
			if (post == null) return new ApiErrorResult<PostViewModel>("Không tìm thấy bài viết này!");
			var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == post.UserID);
			var tag = await GetTagsAsync(post);
			var subCategory = await _context.SubCategories.FirstOrDefaultAsync(x => x.SubCategoryID == post.SubCategoryID);
			var category = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryID == subCategory.CategoryID);
			var postViewModel = new PostViewModel()
			{
				PostID = post.PostID,
				PostName = post.PostName,
				WriteTime = post.WriteTime,
				View = post.View,
				Thumbnail = post.Thumbnail,
				Contents = post.Contents,
				IsShow = post.IsShow,
				SubCategoryID = post.SubCategoryID,
				UserName = user.UserName,
				SubCategoryName = subCategory.CategoryName,
				CategoryID = subCategory.CategoryID,
				CategoryName = category.CategoryName,
				Tags = tag
			};

			return new ApiSuccessResult<PostViewModel>(postViewModel);
		}

		public async Task<ApiResult<PagedResult<PostViewModel>>> GetManagePagingByCategoryIDAuthenticate(Guid userID, GetManagePostPagingRequest request)
		{
			//Lấy danh sách bài viết theo CategoryID cho Writer (Chỉ có thể lấy những bài viết do mình đăng) 
			//(Hỗ trợ tìm kiếm bằng Keyword)

			var query = from c in _context.SubCategories
						join k in _context.Categories on c.CategoryID equals k.CategoryID
						join p in _context.Posts on c.SubCategoryID equals p.SubCategoryID
						join d in _context.Users on p.UserID equals d.Id
						select new { p, c, d.UserName, k };

			query = query.Where(x => x.p.UserID.Equals(userID));

			if (!string.IsNullOrEmpty(request.Keyword))
			{
				query = query.Where(x => x.c.CategoryName.Contains(request.Keyword) || x.p.PostName.Contains(request.Keyword));
			}

			if (request.ID != null)
			{
				query = query.Where(x => request.ID.Equals(x.p.SubCategoryID) || request.ID==x.p.PostID);
			}

			int totalRow = await query.CountAsync();

			var data = await query.OrderByDescending(x=>x.p.WriteTime).Skip((request.PageIndex - 1) * request.PageSize)
				.Take(request.PageSize)
				.Select(x => new PostViewModel()
				{
					PostID = x.p.PostID,
					PostName = x.p.PostName,
					WriteTime = x.p.WriteTime,
					View = x.p.View,
					Thumbnail = x.p.Thumbnail,
					Contents = x.p.Contents,
					IsShow = x.p.IsShow,
					SubCategoryID = x.p.SubCategoryID,
					UserName = x.UserName,
					SubCategoryName = x.c.CategoryName,
					CategoryID = x.c.CategoryID,
					CategoryName = x.k.CategoryName
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

		public async Task<ApiResult<string>> AddImageByUrlAuthenticate(int postID, Guid userID, PostImageCreateUrlRequest request)
		{
			//Thêm hình ảnh vào bài viết của Writer dựa vào Url (Chỉ có thể thêm vào bài viết của mình)
			var post = await _context.Posts.FindAsync(postID);
			if(!post.UserID.Equals(userID)) return new ApiErrorResult<string>("Bạn không có quyền!!!");

			var postImage = new PostImage()
			{
				//Caption = request.Caption,
				DateCreated = DateTime.Now.ToUniversalTime(),
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

		public async Task<ApiResult<bool>> UpdateImageContentsAuthenticate(int postID, Guid userID, PostUpdateContentsRequest request)
		{
			//Chỉnh sửa hình ảnh vào bài viết của Writer (Chỉ có thể thêm vào bài viết của mình)

			var post = await _context.Posts.FindAsync(postID);
			if (!post.UserID.Equals(userID)) return new ApiErrorResult<bool>("Bạn không có quyền!!!");
			if (post == null) return new ApiErrorResult<bool>($"Không tìm thấy bài viết : {postID}");
			post.Contents = request.Contents;
			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Cập nhật bài viết thất bại");
			return new ApiSuccessResult<bool>();
		}

		public async Task<int> AddImageAuthenticate(int postID, Guid userID, PostImageCreateRequest request)
		{
			//Thêm hình ảnh vào bài viết của Writer
			var post = await _context.Posts.FindAsync(postID);
			if (!post.UserID.Equals(userID)) throw new AdvWebException("Bạn không có quyền!!!");
			var postImage = new PostImage()
			{
				//Caption = request.Caption,
				DateCreated = DateTime.Now.ToUniversalTime(),
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

		public async Task<ApiResult<bool>> TagAssignAuthenticate(int postID, Guid userID, TagAssignRequest request)
		{
			//Gán Tag vào bài viết cho Writer
			//Chỉ có thể gán Tag vào bài viết của chính mình.

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

		public async Task<ApiResult<PagedResult<PostViewModel>>> GetPagingCategory(GetPublicPostPagingRequest request)
		{
			var timeNow = DateTime.Now.ToUniversalTime();

			var query = from c in _context.Categories
						join p in _context.Posts on c.CategoryID equals p.CategoryID
						join u in _context.Users on p.UserID equals u.Id
						join sc in _context.SubCategories on p.SubCategoryID equals sc.SubCategoryID
						select new { c, p, u.UserName, sc };

			if (request.Id.HasValue && request.Id.Value > 0)
			{
				query = query.Where(x => x.p.CategoryID.Equals(request.Id));
			}
			int totalRow = await query.CountAsync();

			var postVMs = await query.Where(x => x.p.IsShow == true
				&& x.p.WriteTime.CompareTo(timeNow) < 0)
				.Where(x => x.p.IsShow == true)
				.OrderByDescending(x=>x.p.WriteTime).Skip((request.PageIndex - 1) * request.PageSize)
				.Take(request.PageSize)
				.Select(x => new PostViewModel()
				{
					PostID = x.p.PostID,
					PostName = x.p.PostName,
					WriteTime = x.p.WriteTime,
					View = x.p.View,
					Thumbnail = x.p.Thumbnail,
					//Contents = x.p.Contents,
					SubCategoryID = x.p.SubCategoryID,
					UserName = x.UserName,
					SubCategoryName = x.sc.CategoryName,
					CategoryName = x.c.CategoryName,
					CategoryID = x.c.CategoryID
				}).ToListAsync();

			var pagedResult = new PagedResult<PostViewModel>()
			{
				Items = postVMs,
				PageIndex = request.PageIndex,
				PageSize = request.PageSize,
				TotalRecords = totalRow
			};
			return new ApiSuccessResult<PagedResult<PostViewModel>>(pagedResult);
		}

		public async Task<ApiResult<PagedResult<PostViewModel>>> GetManagePagingBySubCategoryID(GetManagePostPagingRequest request)
		{
			//Lấy danh sách bài viết được Paging dựa vào SubCategoryID - Admin (hỗ trợ Tìm kiếm bằng keyword)
			var query = from sc in _context.SubCategories
						join k in _context.Categories on sc.CategoryID equals k.CategoryID
						join p in _context.Posts on sc.SubCategoryID equals p.SubCategoryID
						join d in _context.Users on p.UserID equals d.Id
						select new { p, sc, d.UserName, k };

			if (!string.IsNullOrEmpty(request.Keyword))
			{
				query = query.Where(x => x.sc.CategoryName.Contains(request.Keyword) || x.p.PostName.Contains(request.Keyword));
			}

			if (request.ID != null)
			{
				query = query.Where(x => request.ID.Equals(x.k.CategoryID) || request.ID==x.p.PostID);
			}

			int totalRow = await query.CountAsync();

			var data = await query.OrderByDescending(x=>x.p.WriteTime).Skip((request.PageIndex - 1) * request.PageSize)
				.Take(request.PageSize)
				.Select(x => new PostViewModel()
				{
					PostID = x.p.PostID,
					PostName = x.p.PostName,
					WriteTime = x.p.WriteTime,
					View = x.p.View,
					Thumbnail = x.p.Thumbnail,
					IsShow = x.p.IsShow,
					//Contents = x.p.Contents,
					SubCategoryID = x.p.SubCategoryID,
					UserName = x.UserName,
					SubCategoryName = x.sc.CategoryName,
					CategoryID = x.sc.CategoryID,
					CategoryName = x.k.CategoryName
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

		public async Task<ApiResult<PagedResult<PostViewModel>>> GetPagingSubCategory(GetPublicPostPagingRequest request)
		{

			var timeNow = DateTime.Now.ToUniversalTime();

			//Lấy danh sách Paging cho WebApp dựa vào SubCategoryID
			var query = from c in _context.Categories
						join p in _context.Posts on c.CategoryID equals p.CategoryID
						join u in _context.Users on p.UserID equals u.Id
						join sc in _context.SubCategories on p.SubCategoryID equals sc.SubCategoryID
						select new { c, p, u.UserName, sc.CategoryName };

			var subCategory = await _context.SubCategories.FindAsync(request.Id);

			if (request.Id.HasValue && request.Id.Value > 0)
			{
				query = query.Where(x => x.p.SubCategory.CategoryName.Contains(subCategory.CategoryName));
			}

			int totalRow = await query.CountAsync();

			var postVMs = await query.Where(x => x.p.IsShow == true
				&& x.p.WriteTime.CompareTo(timeNow) < 0)
				.OrderByDescending(x=>x.p.WriteTime).Skip((request.PageIndex - 1) * request.PageSize)
				.Take(request.PageSize)
				.Select(x => new PostViewModel()
				{
					PostID = x.p.PostID,
					PostName = x.p.PostName,
					WriteTime = x.p.WriteTime,
					View = x.p.View,
					Thumbnail = x.p.Thumbnail,
					//Contents = x.p.Contents,
					SubCategoryID = x.p.SubCategoryID,
					UserName = x.UserName,
					SubCategoryName = x.CategoryName,
					CategoryName = x.c.CategoryName,
					CategoryID = x.c.CategoryID
				}).ToListAsync();

			var pagedResult = new PagedResult<PostViewModel>()
			{
				Items = postVMs,
				PageIndex = request.PageIndex,
				PageSize = request.PageSize,
				TotalRecords = totalRow
			};
			return new ApiSuccessResult<PagedResult<PostViewModel>>(pagedResult);
		}

		public async Task<ApiResult<PagedResult<PostViewModel>>> GetPagingTag(GetPublicPostPagingRequest request)
		{

			var timeNow = DateTime.Now.ToUniversalTime();

			//Lấy danh sách Paging cho WebApp dựa vào TagID
			var query = from p in _context.Posts
						join pic in _context.PostTags on p.PostID equals pic.PostID
						join sc in _context.SubCategories on p.SubCategoryID equals sc.SubCategoryID
						join c in _context.Categories on p.CategoryID equals c.CategoryID
						join t in _context.Tags on pic.TagID equals t.TagID
						join u in _context.Users on p.UserID equals u.Id
						select new { p, c, sc.CategoryName, u.UserName, pic.TagID };

			if (request.Id.HasValue && request.Id.Value > 0)
			{
				query = query.Where(x => x.TagID.Equals(request.Id));
			}
			int totalRow = await query.CountAsync();

			var postVMs = await query.Where(x => x.p.IsShow == true
				&& x.p.WriteTime.CompareTo(timeNow) < 0)
				.OrderByDescending(x=>x.p.WriteTime).Skip((request.PageIndex - 1) * request.PageSize)
				.Take(request.PageSize)
				.Select(x => new PostViewModel()
				{
					PostID = x.p.PostID,
					PostName = x.p.PostName,
					WriteTime = x.p.WriteTime,
					View = x.p.View,
					Thumbnail = x.p.Thumbnail,
					//Contents = x.p.Contents,
					SubCategoryID = x.p.SubCategoryID,
					UserName = x.UserName,
					SubCategoryName = x.CategoryName,
					CategoryName = x.c.CategoryName,
					CategoryID = x.c.CategoryID
				}).ToListAsync();

			var pagedResult = new PagedResult<PostViewModel>()
			{
				Items = postVMs,
				PageIndex = request.PageIndex,
				PageSize = request.PageSize,
				TotalRecords = totalRow
			};
			return new ApiSuccessResult<PagedResult<PostViewModel>>(pagedResult);
		}

		public async Task<ApiResult<PagedResult<PostViewModel>>> GetPagingTagByName(GetPublicPostPagingRequestSearch request)
		{
			var timeNow = DateTime.Now.ToUniversalTime();

			//Lấy danh sách Paging cho WebApp dựa vào tên Tag
			var query = from p in _context.Posts
						join pic in _context.PostTags on p.PostID equals pic.PostID
						join sc in _context.SubCategories on p.SubCategoryID equals sc.SubCategoryID
						join c in _context.Categories on p.CategoryID equals c.CategoryID
						join t in _context.Tags on pic.TagID equals t.TagID
						join u in _context.Users on p.UserID equals u.Id
						select new { p, c, sc.CategoryName, u.UserName, t.TagName };

			if (!string.IsNullOrEmpty(request.Keyword))
			{
				query = query.Where(x => x.TagName.Contains(request.Keyword));
			}

			int totalRow = await query.CountAsync();

			var postVMs = await query.Where(x => x.p.IsShow == true
				&& x.p.WriteTime.CompareTo(timeNow) < 0)
				.OrderByDescending(x=>x.p.WriteTime).Skip((request.PageIndex - 1) * request.PageSize)
				.Take(request.PageSize)
				.Select(x => new PostViewModel()
				{
					PostID = x.p.PostID,
					PostName = x.p.PostName,
					WriteTime = x.p.WriteTime,
					View = x.p.View,
					Thumbnail = x.p.Thumbnail,
					//Contents = x.p.Contents,
					SubCategoryID = x.p.SubCategoryID,
					UserName = x.UserName,
					SubCategoryName = x.CategoryName,
					CategoryName = x.c.CategoryName,
					CategoryID = x.c.CategoryID
				}).ToListAsync();

			var pagedResult = new PagedResult<PostViewModel>()
			{
				Items = postVMs,
				PageIndex = request.PageIndex,
				PageSize = request.PageSize,
				TotalRecords = totalRow
			};
			return new ApiSuccessResult<PagedResult<PostViewModel>>(pagedResult);
		}

		public async Task<ApiResult<PagedResult<PostViewModel>>> GetPaging(GetPublicPostPagingRequestSearch request,
			CancellationToken cancellationToken = default)
		{
			var timeNow = DateTime.Now.ToUniversalTime();

			//Lấy toàn bộ danh sách bài viết được Paging để hiển thị ở Blog - WebApp aka luôn trang tìm kiếm
			var query = from p in _context.Posts
						join sc in _context.SubCategories on p.SubCategoryID equals sc.SubCategoryID
						join c in _context.Categories on p.CategoryID equals c.CategoryID
						join u in _context.Users on p.UserID equals u.Id
						select new { p, c, sc.CategoryName, u.UserName };

			if(!string.IsNullOrEmpty(request.Keyword))
			{
				query = query.Where(x => x.p.PostName.Contains(request.Keyword));
			}

			int totalRow = await query.CountAsync(cancellationToken: cancellationToken);

			var postVMs = await query.Where(x => x.p.IsShow == true
				&& x.p.WriteTime.CompareTo(timeNow) < 0)
				.OrderByDescending(x=> x.p.WriteTime).Skip((request.PageIndex - 1) * request.PageSize)
				.Take(request.PageSize)
				.Select(x => new PostViewModel()
				{
					PostID = x.p.PostID,
					PostName = x.p.PostName,
					WriteTime = x.p.WriteTime,
					View = x.p.View,
					Thumbnail = x.p.Thumbnail,
					IsShow = x.p.IsShow,
					//Contents = x.p.Contents,
					SubCategoryID = x.p.SubCategoryID,
					UserName = x.UserName,
					SubCategoryName = x.CategoryName,
					CategoryName = x.c.CategoryName,
					CategoryID = x.c.CategoryID
				}).ToListAsync(cancellationToken: cancellationToken);

			var pagedResult = new PagedResult<PostViewModel>()
			{
				Items = postVMs,
				PageIndex = request.PageIndex,
				PageSize = request.PageSize,
				TotalRecords = totalRow
			};
			return new ApiSuccessResult<PagedResult<PostViewModel>>(pagedResult);
		}

	}
}
