﻿using AdvWeb_VN.ViewModels.Catalog.Posts;
using AdvWeb_VN.WebApp.Models;
using AdvWeb_VN.WebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace AdvWeb_VN.WebApp.Controllers.Components
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly ICategoryApiClient _categoryApiClient; 
        private readonly IPostApiClient _postApiClient;
        private readonly IConfiguration _configuration;

        public HeaderViewComponent(ICategoryApiClient categoryApiClient, IPostApiClient postApiClient, IConfiguration configuration)
        {
            _categoryApiClient = categoryApiClient;
            _postApiClient = postApiClient;
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var resultCategory = await _categoryApiClient.GetMenuCategory();
            var categories = resultCategory.ResultObj;

            var resultPost = await _postApiClient.GetPostsPagings(new GetPublicPostPagingRequest()
            {
                PageIndex = 1,
                PageSize = 5
            });

            var posts = resultPost.ResultObj;

            var headerViewModel = new HeaderViewModel()
            {
                CategoryMenus = categories,
                PostHeaders = posts
            };

            return View("Default", headerViewModel);
        }
    }
}