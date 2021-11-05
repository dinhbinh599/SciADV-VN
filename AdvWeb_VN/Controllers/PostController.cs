using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvWeb_VN.Utilities.Settings;
using AdvWeb_VN.ViewModels.Catalog.Comments;
using AdvWeb_VN.ViewModels.Catalog.Posts;
using AdvWeb_VN.WebApp.Models;
using AdvWeb_VN.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AdvWeb_VN.WebApp.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostApiClient _postApiClient;
        private readonly IConfiguration _configuration;
        private readonly ICommentApiClient _commentApiClient;

        public PostController(IPostApiClient postApiClient, IConfiguration configuration, ICommentApiClient commentApiClient)
        {
            _postApiClient = postApiClient;
            _configuration = configuration;
            _commentApiClient = commentApiClient;
        }

        [HttpGet("{controller}/{name}-{id}")]
        public async Task<IActionResult> Index(int id, int pageIndex = 1, int pageSize = 10)
        {
            //Hiển thị nội dung bài viết
            //Hiển thị danh sách Comment

            ViewData["BaseAddress"] = _configuration["BaseAddress"];
            ViewData["Active"] = -1;
            ViewData["PostID"] = id;

            var request = new GetPublicPostPagingRequest()
            {
                Id = id,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            var addViewCount = await _postApiClient.AddViewCount(id);
            var resultPost = await _postApiClient.GetByID(id);
            var comments = await _commentApiClient.GetPagingByPostID(request);
            var postVM = new PostPageViewModel()
            {
                Post = resultPost.ResultObj,
                Comments = comments.ResultObj
            };
            return View(postVM);
        }

        [HttpGet("{controller}/nosidebar/{name}-{id}")]
        public async Task<IActionResult> nosidebar(int id, int pageIndex = 1, int pageSize = 10)
        {
            //Hiển thị nội dung bài viết
            //Hiển thị danh sách Comment

            ViewData["BaseAddress"] = _configuration["BaseAddress"];
            ViewData["Active"] = -1;
            ViewData["PostID"] = id;

            var request = new GetPublicPostPagingRequest()
            {
                Id = id,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            var addViewCount = await _postApiClient.AddViewCount(id);

            var resultPost = await _postApiClient.GetByID(id);
            var comments = await _commentApiClient.GetPagingByPostID(request);
            var postVM = new PostPageViewModel()
            {
                Post = resultPost.ResultObj,
                Comments = comments.ResultObj
            };
            return View(postVM);
        }

        [HttpPost]
		public async Task<IActionResult> CreateComment([FromForm]CommentCreatePublicRequest request)
		{
            //Khởi tạo Comment mới
            //Sau này có thể tách riêng thành Component

			if (!ModelState.IsValid)
				return View();

            UrlRewrite rewrite = new UrlRewrite();

            if (request.Commentator != "" && request.Commenter != "" && request.Commentator.Length <= 50 && request.Commenter.Length <= 250)
            {
                var result = await _commentApiClient.CreateComment(request);
                if (result.IsSuccessed)
                {
                    TempData["result"] = "Thêm bình luận thành công";
                    return RedirectToAction("Index" + "/" + rewrite.Rewrite(request.PostName) + request.PostID);
                }
            }
			ModelState.AddModelError("","Bình luận thất bại");
			return RedirectToAction("Index" + "/" + rewrite.Rewrite(request.PostName) + request.PostID);
		}
	}
}