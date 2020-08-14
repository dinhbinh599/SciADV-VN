using System;
using System.Threading.Tasks;
using AdvWeb_VN.ManageApp.Services;
using AdvWeb_VN.Utilities.Constants;
using AdvWeb_VN.ViewModels.System.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvWeb_VN.ManageApp.Controllers
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
		public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
		{
			var request = new GetUserPagingRequest()
			{
				Keyword = keyword,
				PageIndex = pageIndex,
				PageSize = pageSize
			};
			var data = await _userApiClient.GetUsersPagings(request);
			ViewBag.Keyword = keyword;
			if (TempData["result"] != null)
			{
				ViewBag.SuccessMsg = TempData["result"];
			}
			return View(data.ResultObj);
		}

		// GET: /<controller>/
		

		[HttpGet]
		public async Task<IActionResult> Details(Guid id)
		{
			var result = await _userApiClient.GetByID(id);
			return View(result.ResultObj);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[Consumes("multipart/form-data")]
		public async Task<IActionResult> Create([FromForm]RegisterRequest request)
		{
			if (!ModelState.IsValid)
				return View();

			var result = await _userApiClient.RegisterUser(request);
			if (result.IsSuccessed)
			{
				TempData["result"] = "Thêm mới người dùng thành công";
				return RedirectToAction("Index");
			}

			ModelState.AddModelError("", result.Message);
			return View(request);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			var result = await _userApiClient.GetByID(id);
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
				return RedirectToAction("Index");
			}

			ModelState.AddModelError("", result.Message);
			return View(request);
		}

		[HttpGet]
		public IActionResult Delete(Guid id)
		{
			return View(new UserDeleteRequest()
			{
				Id = id
			});
		}

		[HttpPost]
		public async Task<IActionResult> Delete(UserDeleteRequest request)
		{
			if (!ModelState.IsValid)
				return View();

			var result = await _userApiClient.Delete(request.Id);
			if (result.IsSuccessed)
			{
				TempData["result"] = "Xóa người dùng thành công";
				return RedirectToAction("Index");
			}

			ModelState.AddModelError("", result.Message);
			return View(request);
		}
	}
}
