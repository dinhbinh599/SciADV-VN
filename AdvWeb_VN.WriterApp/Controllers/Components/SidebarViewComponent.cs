using AdvWeb_VN.WriterApp.Models;
using AdvWeb_VN.WriterApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace eShopSolution.AdminApp.Controllers.Components
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IConfiguration _configuration;

        public SidebarViewComponent(IUserApiClient userApiClient, IConfiguration configuration)
        {
            _userApiClient = userApiClient;
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _userApiClient.GetByName(User.Identity.Name);
            var userCurrent = result.ResultObj;
            var sidebarViewModel = new SidebarViewModel()
            {
                Email = userCurrent.Email,
                PhoneNumber = userCurrent.PhoneNumber,
                UserName = userCurrent.UserName,
                Roles = userCurrent.Roles,
                AvatarImage = userCurrent.AvatarImage
            };

            return View("Default", sidebarViewModel);
        }
    }
}