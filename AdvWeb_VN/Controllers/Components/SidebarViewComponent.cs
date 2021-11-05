using AdvWeb_VN.ViewModels.Catalog.Tags;
using AdvWeb_VN.WebApp.Models;
using AdvWeb_VN.WebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace AdvWeb_VN.WebApp.Controllers.Components
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly ITagApiClient _tagApiClient;
        private readonly IConfiguration _configuration;
        private readonly IPostApiClient _postApiClient;

        public SidebarViewComponent(ITagApiClient tagApiClient, IConfiguration configuration, IPostApiClient postApiClient)
        {
            _tagApiClient = tagApiClient;
            _configuration = configuration;
            _postApiClient = postApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewData["BaseAddress"] = _configuration["BaseAddress"];

            //Load dữ liệu để hiển thị tại SideBar: Tag,...
            var tagRequest = new GetTagPagingRequest()
            {
                PageIndex = 1,
                PageSize = 10
            };
            var resultTag = await _tagApiClient.GetTagsPagings(tagRequest);
            var resultPost = await _postApiClient.GetPopular();

            var sidebarViewModel = new SidebarViewModel()
            {
                Tags = resultTag.ResultObj,
                Posts = resultPost.ResultObj
            };
            return View("Default", sidebarViewModel);
        }
    }
}