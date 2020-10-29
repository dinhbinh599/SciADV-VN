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
    public class CategoryController : Controller
    {
        private readonly IPostApiClient _postApiClient;
        private readonly ITagApiClient _tagApiClient;
        private readonly IConfiguration _configuration;

        public CategoryController(IPostApiClient postApiClient, ITagApiClient tagApiClient, IConfiguration configuration)
        {
            _postApiClient = postApiClient;
            _tagApiClient = tagApiClient;
            _configuration = configuration;
        }

        [HttpGet("{controller}/category-{id}")]
        public async Task<IActionResult> Index(int id, int pageIndex = 1, int pageSize = 11)
        {
            ViewData["BaseAddress"] = _configuration["BaseAddress"];
            ViewData["Active"] = id;
            var request = new GetPublicPostPagingRequest()
            {
                Id = id,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var resultPost = await _postApiClient.GetPostsPagingsCategory(request);
            var resultTag = await _tagApiClient.GetAllByCategoryID(request.Id.GetValueOrDefault(1));
            var categoryVM = new CategoryPageViewModel()
            {
                Posts = resultPost.ResultObj,
                Tags = resultTag.ResultObj
            };
            return View(categoryVM);
        }
    }
}