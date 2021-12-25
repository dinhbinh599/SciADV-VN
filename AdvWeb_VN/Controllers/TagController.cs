using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvWeb_VN.ViewModels.Catalog.Posts;
using AdvWeb_VN.ViewModels.Catalog.Tags;
using AdvWeb_VN.WebApp.Models;
using AdvWeb_VN.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AdvWeb_VN.WebApp.Controllers
{
    public class TagController : Controller
    {
        private readonly IPostApiClient _postApiClient;
        private readonly ITagApiClient _tagApiClient;
        private readonly IConfiguration _configuration;

        public TagController(IPostApiClient postApiClient, ITagApiClient tagApiClient, IConfiguration configuration)
        {
            _postApiClient = postApiClient;
            _tagApiClient = tagApiClient;
            _configuration = configuration;
        }

        [HttpGet("{controller}/{name}-{id}")]
        public async Task<IActionResult> Index(string name, int id, int pageIndex = 1, int pageSize = 10)
        {
            //Hiển thị danh sách bài viết theo Tag
            //Hiển thị danh sách Tag ngẫu nhiên

            ViewData["BaseAddress"] = _configuration["BaseAddress"];
            ViewData["Active"] = 0;
            var postRequest = new GetPublicPostPagingRequest()
            {
                Id = id,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            var tagRequest = new GetTagPagingRequest()
            {
                PageIndex = 1,
                PageSize = 10
            };

            var resultPost = await _postApiClient.GetPostsPagingsTag(postRequest);
            var resultTag = await _tagApiClient.GetTagsPagings(tagRequest);

            name = name + " | Gero Saga";
            var tagVM = new TagPageViewModel()
            {
                TagName = name,
                Posts = resultPost.ResultObj,
                Tags = resultTag.ResultObj
            };

            ViewBag.description = "Website của nhóm dịch Gero Saga, mục tiêu của nhóm là series Visual Novel mang tên Science Adventure (\"CHAOS; HEAD\", \"STEINS; GATE\", \"ROBOTICS; NOTES\"...) của 5pb./MAGES";
            ViewBag.keywords = "Visual Novel, Science Adventure, " + name;
            ViewBag.ogtype = "Website";
            ViewBag.ogtitle = name;
            ViewBag.ogimage = ViewData["BaseAddress"] + "/user-content/" + resultPost.ResultObj.Items[0].Thumbnail;
            ViewBag.ogdescription = "Website của nhóm dịch Gero Saga, mục tiêu của nhóm là series Visual Novel mang tên Science Adventure (\"CHAOS; HEAD\", \"STEINS; GATE\", \"ROBOTICS; NOTES\"...) của 5pb./MAGES";
            ViewBag.ogurl = ViewData["PortalAddress"] + "/tag/name-" + id;

            return View(tagVM);
        }

        [HttpGet("{controller}/{name}")]
        public async Task<IActionResult> Index(string name, int pageIndex = 1, int pageSize = 11)
        {
            ViewData["BaseAddress"] = _configuration["BaseAddress"];
            ViewData["Active"] = 0;
            var postRequest = new GetPublicPostPagingRequestSearch()
            {
                Keyword = name,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            var tagRequest = new GetTagPagingRequest()
            {
                PageIndex = 1,
                PageSize = 10
            };

            name = name + " | Gero Saga";


            var resultPost = await _postApiClient.GetPostsPagingsTagByName(postRequest);
            var resultTag = await _tagApiClient.GetTagsPagings(tagRequest);
            var tagVM = new TagPageViewModel()
            {
                TagName = name + " | Gero Saga",
                Posts = resultPost.ResultObj,
                Tags = resultTag.ResultObj
            };

            ViewBag.description = "Website của nhóm dịch Gero Saga, mục tiêu của nhóm là series Visual Novel mang tên Science Adventure (\"CHAOS; HEAD\", \"STEINS; GATE\", \"ROBOTICS; NOTES\"...) của 5pb./MAGES";
            ViewBag.keywords = "Visual Novel, Science Adventure, " + name;
            ViewBag.ogtype = "Website";
            ViewBag.ogtitle = name + " | Gero Saga";
            ViewBag.ogimage = ViewData["BaseAddress"] + "/user-content/" + resultPost.ResultObj.Items[0].Thumbnail;
            ViewBag.ogdescription = "Website của nhóm dịch Gero Saga, mục tiêu của nhóm là series Visual Novel mang tên Science Adventure (\"CHAOS; HEAD\", \"STEINS; GATE\", \"ROBOTICS; NOTES\"...) của 5pb./MAGES";
            ViewBag.ogurl = ViewData["PortalAddress"] + "/tag/" + name;

            return View(tagVM);
        }
    }
}