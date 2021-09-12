using System;
using System.Threading.Tasks;
using AdvWeb_VN.Utilities.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using AdvWeb_VN.ViewModels.Catalog.Tags;
using AdvWeb_VN.ViewModels.Catalog.Comments;
using System.Security.Claims;
using AdvWeb_VN.WriterApp.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvWeb_VN.WriterApp.Controllers
{
	public class CommentController : BaseController
	{
		private readonly ICommentApiClient _commentApiClient;
		private readonly IConfiguration _configuration;
		private readonly IUserApiClient _userApiClient;

		public CommentController(ICommentApiClient commentApiClient, IConfiguration configuration, IUserApiClient userApiClient)
		{
			_commentApiClient = commentApiClient;
			_configuration = configuration;
			_userApiClient = userApiClient;
		}

		public async Task<IActionResult> Index(string keyword, int id = 0, int pageIndex = 1, int pageSize = 10)
		{
			//Sử dụng chung 1 View cho hiển thị danh sách Comment Theo Post ID và hiển thị danh sách Comment mới (chưa đọc)
			//Nếu id = 0 (không truyền ID) thì hiển thị Comment chưa đọc
			var result = await _userApiClient.GetCurrentUser();
			var userCurrent = result.ResultObj;
			var request = new GetManageCommentPagingRequest()
			{
				ID = id,
				Keyword = keyword,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			ViewData["PostID"] = id;
			ViewData["PageSize"] = pageSize;

			ViewBag.Keyword = keyword;
			ViewBag.ID = id;

			if (userCurrent.AvatarImage != null)
			{
				ViewData["Avatar"] = userCurrent.AvatarImage;
			}
			else
			{
				ViewData["Avatar"] = "user-icon.jpg";
			}

			if (id == 0)
			{
				var newComment = await _commentApiClient.GetNewCommentsPagings(request);
				return View(newComment.ResultObj);
			}

			var data = await _commentApiClient.GetCommentsPagingsByPostID(request);


			if (TempData["result"] != null)
			{
				ViewBag.SuccessMsg = TempData["result"];
			}
			return View(data.ResultObj);
		}

		// GET: /<controller>/

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateComment([FromForm]CommentCreateManageRequest request)
		{
			if (!ModelState.IsValid)
				return View();

			var userID = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));

			var createRequest = new CommentCreateManageRequest()
			{
				Commenter = request.Commenter,
				PostID = request.PostID,
				ParentID = request.ParentID,
				UserID = userID
			};
			var result = await _commentApiClient.CreateComment(createRequest);
			if (result.IsSuccessed)
			{
				TempData["result"] = "Thêm bình luận thành công";
				return RedirectToAction("Index", new { id = request.CurrentID });
			}

			ModelState.AddModelError("", "Bình luận thất bại");
			return RedirectToAction("Index", new { id = request.CurrentID });
		}


		[HttpGet]
		public async Task<IActionResult> EditComment(int id, int postID)
		{
			var result = await _commentApiClient.GetCommentByID(id);
			if (result.IsSuccessed)
			{
				var comment = result.ResultObj;
				var updateRequest = new CommentUpdateRequest()
				{
					CommentID = comment.CommentID,
					Commenter = comment.Commenter,
					PostID = postID
				};
				return View(updateRequest);
			}
			return RedirectToAction("Error", "Home");
		}


		[HttpPost]
		public async Task<IActionResult> EditComment([FromForm]CommentUpdateRequest request)
		{
			if (!ModelState.IsValid)
				return View();

			var result = await _commentApiClient.UpdateComment(request.CommentID, request);
			if (result.IsSuccessed)
			{
				TempData["result"] = "Cập nhật thành công";
				return RedirectToAction("Index", new { id = request.PostID });
			}

			ModelState.AddModelError("", result.Message);
			return View(request);
		}

		[HttpGet("[controller]/mark-comment-read")]
		public async Task<IActionResult> MarkViewComment(int id, int currentID)
		{
			if (!ModelState.IsValid)
				return RedirectToAction("Index", new { id = currentID });

			var result = await _commentApiClient.MarkViewComment(id);
			if (result.IsSuccessed)
			{
				TempData["result"] = "Thành công";
				return RedirectToAction("Index", new { id = currentID });
			}

			ModelState.AddModelError("", result.Message);
			return RedirectToAction("Index", new { id = currentID });
		}

		[HttpGet("[controller]/add-comment-like")]
		public async Task<IActionResult> AddCommentLike(int commentID, int currentID)
		{
			if (!ModelState.IsValid)
				return RedirectToAction("Index", new { id = currentID });

			var result = await _commentApiClient.AddCommentDislike(commentID);
			if (result.IsSuccessed)
			{
				TempData["result"] = "Cập nhật thành công";
				return RedirectToAction("Index", new { id = currentID });
			}

			ModelState.AddModelError("", result.Message);
			return RedirectToAction("Index", new { id = currentID });
		}

		[HttpGet("[controller]/add-comment-dislike")]
		public async Task<IActionResult> AddCommentDisLike(int commentID, int currentID)
		{
			if (!ModelState.IsValid)
				return RedirectToAction("Index", new { id = currentID });

			var result = await _commentApiClient.AddCommentDislike(commentID);
			if (result.IsSuccessed)
			{
				TempData["result"] = "Cập nhật thành công";
				return RedirectToAction("Index", new { id = currentID });
			}

			ModelState.AddModelError("", result.Message);
			return RedirectToAction("Index", new { id = currentID });
		}
	}
}
