using System;
using System.Threading.Tasks;
using AdvWeb_VN.Utilities.Constants;
using AdvWeb_VN.ViewModels.Common;
using AdvWeb_VN.ViewModels.System.Users;
using AdvWeb_VN.WriterApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvWeb_VN.WriterApp.Controllers
{
	public class UserController : BaseController
	{
		private readonly IUserApiClient _userApiClient;
		private readonly IConfiguration _configuration;

		public UserController(IUserApiClient userApiClient, IConfiguration configuration)
		{
			_userApiClient = userApiClient;
			_configuration = configuration;
		}


		// GET: /<controller>/
		

		[HttpGet]
		public async Task<IActionResult> Details()
		{
			var result = await _userApiClient.GetCurrentUser();
			return View(result.ResultObj);
		}

		[HttpGet]
		public async Task<IActionResult> Edit()
		{
			ViewData["BaseAddress"] = _configuration["BaseAddress"];
			var result = await _userApiClient.GetCurrentUser();
			if (result.IsSuccessed)
			{
				var user = result.ResultObj;
				var updateRequest = new UserUpdateRequest()
				{
					ID = user.UserID,
					Email = user.Email,
					PhoneNumber = user.PhoneNumber,
					AvatarImagePath = user.AvatarImage
				};
				return View(updateRequest);
			}
			return RedirectToAction("Error", "Home");
		}

		[HttpPost]
		[Consumes("multipart/form-data")]
		public async Task<IActionResult> Edit([FromForm]UserUpdateRequest request)
		{
			if (!ModelState.IsValid)
				return View();

			var result = await _userApiClient.UpdateUser(request.ID, request);
			if (result.IsSuccessed)
			{
				TempData["result"] = "Cập nhật người dùng thành công";
				return RedirectToAction("Index", "Home");
			}

			ModelState.AddModelError("", result.Message);
			return View(request);
		}

	}
}
