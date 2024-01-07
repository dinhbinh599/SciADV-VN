using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvWeb_VN.ViewModels.Catalog.Posts;
using AdvWeb_VN.WebApp.Models;
using AdvWeb_VN.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AdvWeb_VN.WebApp.Controllers
{
    public class PostListController : Controller
    {
        private readonly IPostApiClient _postApiClient;
        private readonly IConfiguration _configuration;

        public PostListController(IPostApiClient postApiClient, IConfiguration configuration)
        {
            _postApiClient = postApiClient;
            _configuration = configuration;
        }

        [HttpGet("post-list")]
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            //Hiển thị danh sách bài viết toàn bộ được Paging
            //aka trang tìm kiếm bài viết

            ViewData["BaseAddress"] = _configuration["BaseAddress"];
            ViewData["Active"] = 99;
            var request = new GetPublicPostPagingRequestSearch()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var resultPost = await _postApiClient.GetPostsPagings(request);
            var postListVM = new PostListPageViewModel()
            {
                Posts = resultPost.ResultObj,
            };

            ViewBag.description = "Website của nhóm dịch Gero Saga, mục tiêu của nhóm là series Visual Novel mang tên Science Adventure (\"CHAOS; HEAD\", \"STEINS; GATE\", \"ROBOTICS; NOTES\"...) của 5pb./MAGES";
            ViewBag.keywords = "Visual Novel, Science Adventure, CHAOS; HEAD, STEINS; GATE, ROBOTICS; NOTES, MAGES, CHAO; CHILD";
            ViewBag.ogtype = "Website";
            ViewBag.ogtitle = "Blog | Gero Saga";
            //ViewBag.ogimage = ViewData["BaseAddress"] + "/user-content/" + resultPost.ResultObj.Items[0].Thumbnail;
            ViewBag.ogdescription = "Website của nhóm dịch Gero Saga, mục tiêu của nhóm là series Visual Novel mang tên Science Adventure (\"CHAOS; HEAD\", \"STEINS; GATE\", \"ROBOTICS; NOTES\"...) của 5pb./MAGES";
            ViewBag.ogurl = ViewData["PortalAddress"] + "/post-list";

            return View(postListVM);
        }
    }
}