using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvWeb_VN.ViewModels.Catalog.Posts;
using AdvWeb_VN.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AdvWeb_VN.WebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IPostApiClient _postApiClient;
        private readonly IConfiguration _configuration;

        public CategoryController(IPostApiClient postApiClient, IConfiguration configuration)
        {
            _postApiClient = postApiClient;
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
            var result = await _postApiClient.GetPostsPagingsCategory(request);

            return View(result.ResultObj);
        }
    }
}