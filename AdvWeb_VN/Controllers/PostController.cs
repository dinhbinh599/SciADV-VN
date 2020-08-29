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
    public class PostController : Controller
    {
        private readonly IPostApiClient _postApiClient;
        private readonly IConfiguration _configuration;

        public PostController(IPostApiClient postApiClient, IConfiguration configuration)
        {
            _postApiClient = postApiClient;
            _configuration = configuration;
        }

        [HttpGet("{controller}/{id}")]
        public async Task<IActionResult> Index(string id)
        {
            ViewData["BaseAddress"] = _configuration["BaseAddress"];
            ViewData["Active"] = -1;
            var result = await _postApiClient.GetByID(id);
            return View(result.ResultObj);
        }
    }
}