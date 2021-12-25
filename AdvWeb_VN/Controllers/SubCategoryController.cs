﻿using System;
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
    public class SubCategoryController : Controller
    {
        private readonly IPostApiClient _postApiClient;
        private readonly ITagApiClient _tagApiClient;
        private readonly IConfiguration _configuration;

        public SubCategoryController(IPostApiClient postApiClient, ITagApiClient tagApiClient, IConfiguration configuration)
        {
            _postApiClient = postApiClient;
            _tagApiClient = tagApiClient;
            _configuration = configuration;
        }

        [HttpGet("{controller}/subcategory-{id}")]
        public async Task<IActionResult> Index(int id, int pageIndex = 1, int pageSize = 10)
        {
            //Hiển thị danh sách bài viết theo SubCategoryID
            //Hiển thị danh sách Tag có trong SubCategory đấy

            ViewData["BaseAddress"] = _configuration["BaseAddress"];
            ViewData["Active"] = 0;
            var request = new GetPublicPostPagingRequest()
            {
                Id = id,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            string subcategoryName = "Chuyên mục";
            var resultPost = await _postApiClient.GetPostsPagingsSubCategory(request);
            var resultTag = await _tagApiClient.GetAllByCategoryID(request.Id.GetValueOrDefault(1));

            if (resultPost.ResultObj.TotalRecords > 0) subcategoryName = resultPost.ResultObj.Items[0].SubCategoryName + " | Gero Saga";

            var subCategoryVM = new CategoryPageViewModel()
            {
                CategoryName = subcategoryName,
                Posts = resultPost.ResultObj,
                Tags = resultTag.ResultObj
            };

            ViewBag.description = "Website của nhóm dịch Gero Saga, mục tiêu của nhóm là series Visual Novel mang tên Science Adventure (\"CHAOS; HEAD\", \"STEINS; GATE\", \"ROBOTICS; NOTES\"...) của 5pb./MAGES";
            ViewBag.keywords = "Visual Novel, Science Adventure, " + subcategoryName;
            ViewBag.ogtype = "Website";
            ViewBag.ogtitle = subcategoryName;
            ViewBag.ogimage = ViewData["BaseAddress"] + "/user-content/" + resultPost.ResultObj.Items[0].Thumbnail;
            ViewBag.ogdescription = "Website của nhóm dịch Gero Saga, mục tiêu của nhóm là series Visual Novel mang tên Science Adventure (\"CHAOS; HEAD\", \"STEINS; GATE\", \"ROBOTICS; NOTES\"...) của 5pb./MAGES";
            ViewBag.ogurl = ViewData["PortalAddress"] + "/subcategory-/" + id;

            return View(subCategoryVM);
        }
    }
}