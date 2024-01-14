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
using AdvWeb_VN.Application.Catalog.Posts;
using AdvWeb_VN.ViewModels.Catalog.Categories;
using AdvWeb_VN.Application.Catalog.Categories;
using AdvWeb_VN.ViewModels.Catalog.Comments;
using Microsoft.AspNetCore.Identity;

namespace AdvWeb_VN.Application.Catalog.Comments
{
	public class CommentService : ICommentService
	{
		private readonly AdvWebDbContext _context;

		public CommentService(AdvWebDbContext context)
		{
			_context = context;
		}

		public async Task<ApiResult<bool>> CreateCommentManage(CommentCreateManageRequest request)
		{
			//Thêm bình luận mới cho Admin (luôn hiển thị màu riêng). 
			//Đồng thời mặc định đánh dấu luôn là đã đọc với mọi Admin.

			string Commentator = "";
			if(request.UserID != Guid.Empty)
			{
				var user = await _context.Users.FirstOrDefaultAsync(x => x.Id.Equals(request.UserID));
				if (user == null) return new ApiErrorResult<bool>($"Không tìm thấy User : {request.UserID}");
				Commentator = user.UserName;
			}

			var comment = new Comment()
			{
				Commentator = Commentator,
				Commenter = request.Commenter,
				CommentTime = DateTime.Now.ToUniversalTime(),
				PostID = request.PostID,
				UserID = request.UserID,
				ParentID = request.ParentID,
				IsManaged = true,
				IsView = true
			};

			_context.Comments.Add(comment);
			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Thêm bình luận thất bại");
			return new ApiSuccessResult<bool>();
		}

		public async Task<ApiResult<bool>> CreateCommentAuthenticate(CommentCreateManageRequest request)
		{
			//Thêm bình luận mới cho Writer (hiển thị màu riêng với người đã viết bài). 
			//Đồng thời đánh dấu chưa đọc cho Comment cũ nếu Writer không viết bài thêm SubComment mới.
			//Mặc định cho Writer viết bài khi viết Comment sẽ luôn là đã đọc

			bool isManaged = false;
			string Commentator = "";
			if (request.UserID != Guid.Empty)
			{
				var user = await _context.Users.FirstOrDefaultAsync(x => x.Id.Equals(request.UserID));
				if (user == null) return new ApiErrorResult<bool>($"Không tìm thấy User : {request.UserID}");
				Commentator = user.UserName;
			}

			if (_context.Posts.Where(x => x.PostID.Equals(request.PostID) && x.UserID.Equals(request.UserID)).Count() > 0)
			{
				isManaged = true;
			}
			else
			{
				if (request.ParentID != 0)
				{
					var parentComment = await _context.Comments.Where(x => x.CommentID.Equals(request.ParentID)).FirstAsync();
					parentComment.IsView = false;
				}
			}
			var comment = new Comment()
			{
				Commentator = Commentator,
				Commenter = request.Commenter,
				CommentTime = DateTime.Now.ToUniversalTime(),
				PostID = request.PostID,
				UserID = request.UserID,
				ParentID = request.ParentID,
				IsManaged = isManaged,
				IsView = true
			};

			_context.Comments.Add(comment);
			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Thêm bình luận thất bại");
			return new ApiSuccessResult<bool>();
		}

		public async Task<ApiResult<bool>> CreateCommentPublic(CommentCreatePublicRequest request)
		{
			//Thêm bình luận mới cho người đọc.
			//Đồng thời đánh dấu chưa đọc cho Comment cũ nếu người đọc thêm SubComment mới.

			if (request.Commentator != "" && request.Commenter != "" && request.Commentator.Length <= 50 && request.Commenter.Length <= 250)
			{

				var comment = new Comment()
				{
					Commentator = request.Commentator,
					Commenter = request.Commenter,
					CommentTime = DateTime.Now.ToUniversalTime(),
					ParentID = request.ParentID,
					PostID = request.PostID,
					IsManaged = false
				};

				_context.Comments.Add(comment);

				if (request.ParentID != 0)
				{
					var parentComment = await _context.Comments.Where(x => x.CommentID.Equals(request.ParentID)).FirstAsync();
					parentComment.IsView = false;
				}

				var result = await _context.SaveChangesAsync();
				if (result == 0) return new ApiErrorResult<bool>("Thêm bình luận thất bại");
				return new ApiSuccessResult<bool>();
			}
			return new ApiErrorResult<bool>("Thêm bình luận thất bại");
		}
		public async Task<ApiResult<bool>> DeleteComment(int commentID)
		{
			//Xóa Comment
			var comment = await _context.Comments.FindAsync(commentID);
			if (comment == null) return new ApiErrorResult<bool>($"Không tìm thấy bình luận : {commentID}");
			_context.Comments.Remove(comment);

			//var comments = _context.Comments.Where(x => x.ParentID.Equals(commentID));
			//_context.Comments.RemoveRange(comments);

			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Xóa bình luận thất bại");
			return new ApiSuccessResult<bool>();
		}
		public async Task<List<CommentViewModel>> GetAll()
		{
			//Lấy danh sách toàn bộ Comment
			var query = from p in _context.Comments
						join c in _context.Posts on p.PostID equals c.PostID
						select new { p, c};

			var data = await query.OrderByDescending(x=>x.p.CommentTime).Select(x => new CommentViewModel()
			{
				CommentID = x.p.CommentID,
				Commentator = x.p.Commentator,
				Commenter = x.p.Commenter,
				CommentTime = x.p.CommentTime,
				PostID = x.c.PostID,
			}).OrderByDescending(x=>x.CommentTime).ToListAsync();

			return data;
		}

		public async Task<ApiResult<CommentViewModel>> GetByID(int commentID)
		{
			//Lấy danh sách Comment dựa vào ID
			var comment = await _context.Comments.FindAsync(commentID);
			if (comment == null) return new ApiErrorResult<CommentViewModel>("Không tìm thấy bình luận này!");
			var post = await _context.Posts.FirstOrDefaultAsync(x => x.PostID.Equals(comment.PostID));
			var commentVM = new CommentViewModel()
			{
				CommentID = comment.CommentID,
				Commentator = comment.Commentator,
				Commenter = comment.Commenter,
				IsView = comment.IsView,
				ParentID = comment.ParentID,
				CommentTime = comment.CommentTime,
				PostID = post.PostID,
			};

			return new ApiSuccessResult<CommentViewModel>(commentVM);
		}

		public async Task<ApiResult<PagedResult<CommentViewModel>>> GetManagePagingByPostID(GetManageCommentPagingRequest request)
		{
			//Lấy danh sách Comment cho Admin .
			//(Toàn bộ các bài viết và có thể sửa xóa tùy ý, tìm kiếm bằng keyword,...)
			//Sắp xếp dữ liệu hiển thị kiểu phân tầng
			//Lấy theo ID của bài viết

			var comments = _context.Comments.Where(x=>x.ParentID.Equals(0));

			if (request.ID != null)
			{
				comments = comments.Where(x => x.PostID.Equals(request.ID));
			}

			if (!string.IsNullOrEmpty(request.Keyword))
			{
				comments = comments.Where(x => (x.Commenter.Contains(request.Keyword)));
			}

			int totalRow = await comments.CountAsync();

			var data = await comments.OrderByDescending(x=>x.CommentTime).Skip((request.PageIndex - 1) * request.PageSize)
				.Take(request.PageSize)
				.Select(x => new CommentViewModel()
				{
					CommentID = x.CommentID,
					Commentator = x.Commentator,
					Commenter = x.Commenter,
					CommentTime = x.CommentTime,
					IsManaged = x.IsManaged,
					PostID = x.PostID,
					IsView = x.IsView,
					LikeCount = x.LikeCount,
					Avatar = _context.Users.FirstOrDefault(u=>u.Id.Equals(x.UserID)).Avatar,
					DislikeCount = x.DislikeCount,
					SubComments = _context.Comments.Where(p => p.ParentID.Equals(x.CommentID))
									.Select(p => new SubCommentViewModel()
									{
										SubCommentID = p.CommentID,
										Commentator = p.Commentator,
										Commenter = p.Commenter,
										CommentTime = p.CommentTime,
										IsManaged = p.IsManaged,
										PostID = p.PostID,
										IsView = p.IsView,
										Avatar = _context.Users.FirstOrDefault(u => u.Id.Equals(p.UserID)).Avatar,
										ParentID = p.CommentID,
										LikeCount = p.LikeCount,
										DislikeCount = p.DislikeCount,
									}).ToList()
				}).ToListAsync();
			var pagedResult = new PagedResult<CommentViewModel>()
			{
				TotalRecords = totalRow,
				PageIndex = request.PageIndex,
				PageSize = request.PageSize,
				Items = data
			};
			return new ApiSuccessResult<PagedResult<CommentViewModel>>(pagedResult);
		}

		public async Task<ApiResult<PagedResult<CommentViewModel>>> GetPagingByPostID(GetPublicPostPagingRequest request)
		{
			//Lấy danh sách Comment cho WebApp .
			//Sắp xếp dữ liệu hiển thị kiểu phân tầng.
			// Lấy theo ID của bài viết.
			var comments = _context.Comments.Where(x => x.ParentID.Equals(0));

			int totalRow = await comments.Where(x => x.PostID.Equals(request.Id)).CountAsync();
			
			var data = await comments.Where(x => x.PostID.Equals(request.Id)).OrderByDescending(x => x.CommentTime)
				.Skip((request.PageIndex - 1) * request.PageSize)
				.Take(request.PageSize)
				.Select(x => new CommentViewModel()
				{
					CommentID = x.CommentID,
					Commentator = x.Commentator,
					Commenter = x.Commenter,
					CommentTime = x.CommentTime,
					IsManaged = x.IsManaged,
					LikeCount = x.LikeCount,
					Avatar = _context.Users.FirstOrDefault(u => u.Id.Equals(x.UserID)).Avatar,
					PostID = x.PostID,
					IsView = x.IsView,
					DislikeCount = x.DislikeCount,
					SubComments = _context.Comments.Where(p => p.ParentID.Equals(x.CommentID))
									.Select(p => new SubCommentViewModel() {
										SubCommentID = p.CommentID,
										Commentator = p.Commentator,
										Commenter = p.Commenter,
										CommentTime = p.CommentTime,
										IsManaged = p.IsManaged,
										Avatar = _context.Users.FirstOrDefault(u => u.Id.Equals(p.UserID)).Avatar,
										PostID = p.PostID,
										IsView = p.IsView,
										LikeCount = p.LikeCount,
										DislikeCount = p.DislikeCount,
									}).ToList()
				}).ToListAsync();
			var pagedResult = new PagedResult<CommentViewModel>()
			{
				TotalRecords = totalRow,
				PageIndex = request.PageIndex,
				PageSize = request.PageSize,
				Items = data
			};
			return new ApiSuccessResult<PagedResult<CommentViewModel>>(pagedResult);
		}

		public async Task<ApiResult<bool>> UpdateComment(CommentUpdateRequest request)
		{
			//Chỉnh sửa Comment
			var comment = await _context.Comments.FindAsync(request.CommentID);
			if (comment == null) return new ApiErrorResult<bool>($"Không tìm thấy bình luận : {request.CommentID}");

			comment.Commenter = request.Commenter;
			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Cập nhật bình luận thất bại");
			return new ApiSuccessResult<bool>();
		}
		public async Task<ApiResult<CommentViewModel>> GetCommentByID(int commentID)
		{
			//Lấy thông tin Comment theo ID
			var comment = await _context.Comments.FindAsync(commentID);
			if (comment == null) return new ApiErrorResult<CommentViewModel>("Không tìm thấy bình luận này!");
			var commentVM = new CommentViewModel()
			{
				CommentID = comment.CommentID,
				Commentator = comment.Commentator,
				Commenter = comment.Commenter,
				CommentTime = comment.CommentTime,
				IsManaged = comment.IsManaged
			};

			return new ApiSuccessResult<CommentViewModel>(commentVM);
		}

		public async Task<ApiResult<bool>> UpdateCommentAuthenticate(Guid id,CommentUpdateRequest request)
		{
			//Chỉnh sửa Comment cho Writer.
			//Chỉ có thể sửa Comment của chính mình.
			var comment = await _context.Comments
				.Where(x=>(x.CommentID.Equals(request.CommentID))&&(x.UserID.Equals(id)))
				.FirstAsync();

			if (comment == null) return new ApiErrorResult<bool>($"Không tìm thấy bình luận : {request.CommentID}");
			comment.Commenter = request.Commenter;
			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Cập nhật bình luận thất bại");
			return new ApiSuccessResult<bool>();
		}

		public async Task<ApiResult<PagedResult<CommentViewModel>>> GetManagePagingByPostIDAuthenticate(Guid id,GetManageCommentPagingRequest request)
		{
			//Lấy danh sách Comment cho Writer .
			//Sắp xếp dữ liệu hiển thị kiểu phân tầng.
			//Lấy theo ID của bài viết.
			//Chỉ có thể sửa Comment của chính mình.
			var comments = _context.Comments.Where(x => (x.ParentID.Equals(0)));

			if (request.ID != null)
			{
				comments = comments.Where(x => x.PostID.Equals(request.ID));
			}

			if (!string.IsNullOrEmpty(request.Keyword))
			{
				comments = comments.Where(x => (x.Commenter.Contains(request.Keyword)));
			}
			
			var isOwnerPost = (await _context.Posts.FindAsync(request.ID)).UserID.Equals(id);

			int totalRow = await comments.CountAsync();

			var data = await comments.OrderByDescending(x=>x.CommentTime).Skip((request.PageIndex - 1) * request.PageSize)
				.Take(request.PageSize)
				.Select(x => new CommentViewModel()
				{
					CommentID = x.CommentID,
					Commentator = x.Commentator,
					Commenter = x.Commenter,
					CommentTime = x.CommentTime,
					IsManaged = x.IsManaged,
					LikeCount = x.LikeCount,
					IsView = x.IsView,
					PostID = x.PostID,
					IsOwnerPost = isOwnerPost,
					Avatar = _context.Users.FirstOrDefault(u => u.Id.Equals(x.UserID)).Avatar,
					DislikeCount = x.DislikeCount,
					IsOwner = (x.UserID.Equals(id)) ? true : false,
					SubComments = _context.Comments.Where(p => p.ParentID.Equals(x.CommentID))
									.Select(p => new SubCommentViewModel()
									{
										SubCommentID = p.CommentID,
										Commentator = p.Commentator,
										Commenter = p.Commenter,
										CommentTime = p.CommentTime,
										IsManaged = p.IsManaged,
										PostID = p.PostID,
										IsView = p.IsView,
										IsOwnerPost = isOwnerPost,
										Avatar = _context.Users.FirstOrDefault(u => u.Id.Equals(p.UserID)).Avatar,
										LikeCount = p.LikeCount,
										IsOwner = (p.UserID.Equals(id)) ? true : false,
										DislikeCount = p.DislikeCount,
									}).ToList()
				}).ToListAsync();


			var pagedResult = new PagedResult<CommentViewModel>()
			{
				TotalRecords = totalRow,
				PageIndex = request.PageIndex,
				PageSize = request.PageSize,
				Items = data
			};
			return new ApiSuccessResult<PagedResult<CommentViewModel>>(pagedResult);
		}

		public async Task<ApiResult<PagedResult<CommentViewModel>>> GetPagingNewComment(GetManageCommentPagingRequest request)
		{
			//Lấy danh sách các bình luận mới (Được đánh dấu chưa đọc) cho Admin (toàn bộ).
			//Hiện tại chỉ hỗ trợ tìm kiếm theo nội dung ở Comment Cha.
			//Lấy ở toàn bộ các bài viết

			var comments = _context.Comments.Where(x => x.ParentID.Equals(0));

			if (!string.IsNullOrEmpty(request.Keyword))
			{
				comments = comments.Where(x => (x.Commenter.Contains(request.Keyword)));
			}

			comments = comments.Where(x => x.IsView == false);

			int totalRow = await comments.CountAsync();

			var data = await comments.OrderByDescending(x=>x.CommentTime).Skip((request.PageIndex - 1) * request.PageSize)
				.Take(request.PageSize)
				.Select(x => new CommentViewModel()
				{
					CommentID = x.CommentID,
					Commentator = x.Commentator,
					Commenter = x.Commenter,
					CommentTime = x.CommentTime,
					IsManaged = x.IsManaged,
					IsView = false,
					LikeCount = x.LikeCount,
					Avatar = _context.Users.FirstOrDefault(u => u.Id.Equals(x.UserID)).Avatar,
					PostID = x.PostID,
					DislikeCount = x.DislikeCount,
					SubComments = _context.Comments.Where(p => p.ParentID.Equals(x.CommentID))
									.Select(p => new SubCommentViewModel()
									{
										SubCommentID = p.CommentID,
										Commentator = p.Commentator,
										Commenter = p.Commenter,
										CommentTime = p.CommentTime,
										IsManaged = p.IsManaged,
										Avatar = _context.Users.FirstOrDefault(u => u.Id.Equals(p.UserID)).Avatar,
										PostID = p.PostID,
										IsView = false,
										LikeCount = p.LikeCount,
										DislikeCount = p.DislikeCount,
									}).ToList()
				}).ToListAsync();
			var pagedResult = new PagedResult<CommentViewModel>()
			{
				TotalRecords = totalRow,
				PageIndex = request.PageIndex,
				PageSize = request.PageSize,
				Items = data
			};
			return new ApiSuccessResult<PagedResult<CommentViewModel>>(pagedResult);
		}

		public async Task<ApiResult<int>> GetNewCount()
		{
			//Lấy số bình luận mới (Được đánh dấu chưa đọc) cho Admin (Toàn bộ).
			var comments = _context.Comments.Where(x => x.ParentID.Equals(0));

			comments = comments.Where(x => x.IsView == false);

			int totalRow = await comments.CountAsync();

			return new ApiSuccessResult<int>(totalRow);
		}

		public async Task<ApiResult<bool>> AddCommentLike(int commentID)
		{
			//Thêm lượt thích cho Comment
			var comment = await _context.Comments.FindAsync(commentID);
			if (comment == null) return new ApiErrorResult<bool>($"Không tìm thấy bình luận : {commentID}");
			comment.LikeCount = comment.LikeCount + 1;
			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Cập nhật bình luận thất bại");
			return new ApiSuccessResult<bool>();
		}

		public async Task<ApiResult<bool>> AddCommentDislike(int commentID)
		{
			//Thêm lượt không thích cho Comment
			var comment = await _context.Comments.FindAsync(commentID);
			if (comment == null) return new ApiErrorResult<bool>($"Không tìm thấy bình luận : {commentID}");
			comment.DislikeCount = comment.DislikeCount + 1;
			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Cập nhật bình luận thất bại");
			return new ApiSuccessResult<bool>();
		}
		public async Task<ApiResult<bool>> MarkViewComment(int commentID)
		{
			//Đánh dấu đã đọc Comment cho Admin (được đánh dấu toàn bộ)
			var comment = await _context.Comments.FindAsync(commentID);
			if (comment == null) return new ApiErrorResult<bool>($"Không tìm thấy bình luận : {commentID}");
			comment.IsView = true;
			
			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Cập nhật bình luận thất bại");
			return new ApiSuccessResult<bool>();
		}

		public async Task<ApiResult<PagedResult<CommentViewModel>>> GetPagingNewCommentAuthenticate(Guid id, GetManageCommentPagingRequest request)
		{
			//Lấy danh sách các bình luận mới (Được đánh dấu chưa đọc) cho Writer.
			//Hiện tại chỉ hỗ trợ tìm kiếm theo nội dung ở Comment Cha.
			//Chỉ lấy ở các bài viết do Writer này đăng.

			var query = from c in _context.Comments
						join p in _context.Posts on c.PostID equals p.PostID
						join u in _context.Users on p.UserID equals u.Id
						select new { c, u.Id };

			query = query.Where(x => (x.c.ParentID.Equals(0)));

			query = query.Where(x => (x.c.IsView == false));

			query = query.Where(x => x.Id.Equals(id));

			if (!string.IsNullOrEmpty(request.Keyword))
			{
				query = query.Where(x => (x.c.Commenter.Contains(request.Keyword)));
			}

			int totalRow = await query.CountAsync();

			var data = await query.OrderByDescending(x=>x.c.CommentTime).Skip((request.PageIndex - 1) * request.PageSize)
				.Take(request.PageSize)
				.Select(x => new CommentViewModel()
				{
					CommentID = x.c.CommentID,
					Commentator = x.c.Commentator,
					Commenter = x.c.Commenter,
					CommentTime = x.c.CommentTime,
					IsManaged = x.c.IsManaged,
					IsView = false,
					LikeCount = x.c.LikeCount,
					PostID = x.c.PostID,
					IsOwnerPost = true,
					IsOwner = (x.c.UserID.Equals(id)),
					DislikeCount = x.c.DislikeCount,
					SubComments = _context.Comments.Where(p => p.ParentID.Equals(x.c.CommentID))
									.Select(p => new SubCommentViewModel()
									{
										SubCommentID = p.CommentID,
										Commentator = p.Commentator,
										Commenter = p.Commenter,
										CommentTime = p.CommentTime,
										IsManaged = p.IsManaged,
										PostID = p.PostID,
										IsView = false,
										IsOwner = (p.UserID.Equals(id)) ? true : false,
										IsOwnerPost = true,
										ParentID = p.CommentID,
										LikeCount = p.LikeCount,
										DislikeCount = p.DislikeCount,
									}).ToList()
				}).ToListAsync();
			var pagedResult = new PagedResult<CommentViewModel>()
			{
				TotalRecords = totalRow,
				PageIndex = request.PageIndex,
				PageSize = request.PageSize,
				Items = data
			};
			return new ApiSuccessResult<PagedResult<CommentViewModel>>(pagedResult);
		}

		public async Task<ApiResult<bool>> MarkViewCommentAuthenticate(Guid id, int commentID)
		{
			//Đánh dấu đã đọc Comment cho Writer (chỉ được đánh dấu ở các Comment thuộc bài viết do Writer đăng)

			var comment = await _context.Comments.FindAsync(commentID);
			if (comment == null) return new ApiErrorResult<bool>($"Không tìm thấy bình luận : {commentID}");
			comment.IsView = true;

			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Cập nhật bình luận thất bại");
			return new ApiSuccessResult<bool>();
		}

		public async Task<ApiResult<int>> GetNewCountAuthenticate(Guid id)
		{
			//Lấy số bình luận mới (Được đánh dấu chưa đọc) cho Writer (chỉ ở các bài viết do Writer này đăng).

			var query = from c in _context.Comments
						join p in _context.Posts on c.PostID equals p.PostID
						join u in _context.Users on p.UserID equals u.Id
						select new { c, u.Id };

			query = query.Where(x => (x.c.ParentID.Equals(0)));

			query = query.Where(x => (x.c.IsView == false));

			query = query.Where(x => x.Id.Equals(id));


			int totalRow = await query.CountAsync();

			return new ApiSuccessResult<int>(totalRow);
		}
	}
}
