using AdvWeb_VN.ManageApp.Models;
using AdvWeb_VN.ManageApp.Services;
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
        private readonly ICommentApiClient _commentApiClient;

        public SidebarViewComponent(IUserApiClient userApiClient, IConfiguration configuration, ICommentApiClient commentApiClient)
        {
            _userApiClient = userApiClient;
            _configuration = configuration;
            _commentApiClient = commentApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userResult = await _userApiClient.GetByName(User.Identity.Name);
            var userCurrent = userResult.ResultObj;

            var commentResult = await _commentApiClient.GetNewCount();
            var commentCount = commentResult.ResultObj;


            var sidebarViewModel = new SidebarViewModel()
            {
                UserID = userCurrent.UserID,
                Email = userCurrent.Email,
                PhoneNumber = userCurrent.PhoneNumber,
                UserName = userCurrent.UserName,
                Roles = userCurrent.Roles,
                AvatarImage = userCurrent.AvatarImage,
                NewCommentCount = commentCount
            };

            return View("Default", sidebarViewModel);
        }
    }
}