using AdvWeb_VN.WebApp.Models;
using AdvWeb_VN.WebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace AdvWeb_VN.WebApp.Controllers.Components
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly ICategoryApiClient _categoryApiClient; 
        private readonly IPostApiClient _postApiClient;
        private readonly IConfiguration _configuration;

        public FooterViewComponent(ICategoryApiClient categoryApiClient, IPostApiClient postApiClient, IConfiguration configuration)
        {
            _categoryApiClient = categoryApiClient;
            _postApiClient = postApiClient;
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var resultCategory = await _categoryApiClient.GetFooterCategory();
            var categories = resultCategory.ResultObj;

            var resultPost = await _postApiClient.GetPopular();
            var posts = resultPost.ResultObj;

            var footerViewModel = new FooterViewModel()
            {
                CategoryFooters = categories,
                PostFooters = posts
            };

            return View("Default", footerViewModel);
        }
    }
}