using AdvWeb_VN.ViewModels.Catalog.Posts;
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
            ViewData["BaseAddress"] = _configuration["BaseAddress"];
            ViewData["AdminAddress"] = _configuration["AdminAddress"];

            //Load dữ liệu hiển thị ở Menu
            var resultCategory = await _categoryApiClient.GetMenuCategory();
            var categories = resultCategory.ResultObj;

            //Load dữ liệu 1 vài bài viết để hiển thị ở NEWS
            var resultPost = await _postApiClient.GetPostsPagingsByCategoryID(new GetPublicPostPagingRequest()
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