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

		public async Task<ApiResult<bool>> Create(CommentCreateRequest request)
		{
			var query = from li in _context.Posts
						where li.PostID.Equals(request.PostID)
						select li;
			var list = await query.ToListAsync<Post>();
			if (list.Count == 0) return new ApiErrorResult<bool>($"Không tìm thấy bài viết : {request.PostID}");

			var query2 = from c in _context.Comments
						 where c.PostID.Equals(request.PostID)
						 select c;

			string CommentID = "";
			string Commentator = "";
			Post post = query.FirstOrDefault<Post>();
			if (query2.Count() > 0)
			{
				Comment commentLast = query2.ToList<Comment>().Last();
				SplitResult splitResult = new Split().GetID(commentLast.CommentID, post.PostID.Length+1);
				CommentID = splitResult.name + (splitResult.Number + 1);
			}
			else
			{
				CommentID = post.PostID + "-1";
			}

			if(request.Commentator == null && request.UserID == Guid.Empty)
			{
				Commentator = "Unknown";
			}
			else if(request.UserID != Guid.Empty)
			{
				var user = await _context.Users.FirstOrDefaultAsync(x => x.Id.Equals(request.UserID));
				if (user == null) return new ApiErrorResult<bool>($"Không tìm thấy User : {request.UserID}");
				Commentator = user.UserName;
			}
			else
			{
				Commentator = request.Commentator;
			}
			var comment = new Comment()
			{
				CommentID = CommentID,
				Commentator = Commentator,
				Commenter = request.Commenter,
				CommentTime = DateTime.Now,
				PostID = request.PostID,
				ParrentID = request.ParrentID,
				UserID = request.UserID
			};

			_context.Comments.Add(comment);
			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Thêm bình luận thất bại");
			return new ApiSuccessResult<bool>();
		}

		public async Task<ApiResult<bool>> Delete(string commentID)
		{
			var comment = await _context.Comments.FindAsync(commentID);
			if (comment == null) return new ApiErrorResult<bool>($"Không tìm thấy bình luận : {commentID}");
			_context.Comments.Remove(comment);
			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Xóa bình luận thất bại");
			return new ApiSuccessResult<bool>();
		}

		public async Task<List<CommentViewModel>> GetAll()
		{
			var query = from p in _context.Comments
						join c in _context.Posts on p.PostID equals c.PostID
						select new { p, c};

			var data = await query.Select(x => new CommentViewModel()
			{
				CommentID = x.p.CommentID,
				Commentator = x.p.Commentator,
				Commenter = x.p.Commenter,
				CommentTime = x.p.CommentTime,
				PostName = x.c.PostName,
				ParrentID = x.p.ParrentID
			}).ToListAsync();

			return data;
		}

		public async Task<ApiResult<CommentViewModel>> GetByID(string commentID)
		{
			var comment = await _context.Comments.FindAsync(commentID);
			if (comment == null) return new ApiErrorResult<CommentViewModel>("Không tìm thấy bình luận này!");
			var post = await _context.Posts.FirstOrDefaultAsync(x => x.PostID.Equals(comment.PostID));
			var commentVM = new CommentViewModel()
			{
				CommentID = comment.CommentID,
				Commentator = comment.Commentator,
				Commenter = comment.Commenter,
				CommentTime = comment.CommentTime,
				PostName = post.PostName,
				ParrentID = comment.ParrentID
			};

			return new ApiSuccessResult<CommentViewModel>(commentVM);
		}

		public async Task<List<CommentViewModel>> GetByParrentID(string parrentID)
		{
			var query = from p in _context.Comments
						join d in _context.Posts on p.PostID equals d.PostID
						select new { p, d};
			var comments = await query.Where(x => x.p.ParrentID.Equals(parrentID))
				.Select(x=>new CommentViewModel()
				{
					CommentID = x.p.CommentID,
					Commentator = x.p.Commentator,
					Commenter = x.p.Commenter,
					CommentTime = x.p.CommentTime,
					PostName = x.d.PostName,
					ParrentID = x.p.ParrentID
				}).ToListAsync();
			return comments;
		}

		public async Task<ApiResult<bool>> Update(CommentUpdateRequest request)
		{
			var comment = await _context.Comments.FindAsync(request.CommentID);
			if (comment == null) return new ApiErrorResult<bool>($"Không tìm thấy bình luận : {request.CommentID}");

			comment.Commenter = request.Commenter;
			var result = await _context.SaveChangesAsync();
			if (result == 0) return new ApiErrorResult<bool>("Cập nhật bình luận thất bại");
			return new ApiSuccessResult<bool>();
		}
	}
}
