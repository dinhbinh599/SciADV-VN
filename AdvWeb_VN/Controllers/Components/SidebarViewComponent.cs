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

        public SidebarViewComponent(ITagApiClient tagApiClient, IConfiguration configuration)
        {
            _tagApiClient = tagApiClient;
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var tagRequest = new GetTagPagingRequest()
            {
                PageIndex = 1,
                PageSize = 10
            };
            var resultTag = await _tagApiClient.GetTagsPagings(tagRequest);
            var sidebarViewModel = new SidebarViewModel()
            {
                Tags = resultTag.ResultObj
            };
            return View("Default", sidebarViewModel);
        }
    }
}