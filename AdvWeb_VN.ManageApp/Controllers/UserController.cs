using System;
using System.Threading.Tasks;
using AdvWeb_VN.ManageApp.Services;
using AdvWeb_VN.Utilities.Constants;
using AdvWeb_VN.ViewModels.Common;
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
		private readonly IRoleApiClient _roleApiClient;

		public UserController(IUserApiClient userApiClient, IConfiguration configuration, IRoleApiClient roleApiClient)
		{
			_userApiClient = userApiClient;
			_configuration = configuration;
			_roleApiClient = roleApiClient;
		}

		public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
		{
			ViewData["BaseAddress"] = _configuration["BaseAddress"];
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
			ViewData["BaseAddress"] = _configuration["BaseAddress"];
			var result = await _userApiClient.GetByID(id);
			return View(result.ResultObj);
		}

		[HttpGet]
		public IActionResult Create()
		{
			ViewData["BaseAddress"] = _configuration["BaseAddress"];
			return View();
		}

		[HttpPost]
		[Consumes("multipart/form-data")]
		public async Task<IActionResult> Create([FromForm]RegisterRequest request)
		{
			ViewData["BaseAddress"] = _configuration["BaseAddress"];
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
			ViewData["BaseAddress"] = _configuration["BaseAddress"];
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
			ViewData["BaseAddress"] = _configuration["BaseAddress"];
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
			ViewData["BaseAddress"] = _configuration["BaseAddress"];
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

		[HttpGet]
		public async Task<IActionResult> RoleAssign(Guid id)
		{
			ViewData["BaseAddress"] = _configuration["BaseAddress"];
			var roleAssignRequest = await GetRoleAssignRequest(id);
			return View(roleAssignRequest);
		}

		[HttpPost]
		public async Task<IActionResult> RoleAssign(RoleAssignRequest request)
		{
			ViewData["BaseAddress"] = _configuration["BaseAddress"];
			//Gán Role cho User
			if (!ModelState.IsValid)
				return View();

			var result = await _userApiClient.RoleAssign(request.ID, request);

			if (result.IsSuccessed)
			{
				TempData["result"] = "Cập nhật quyền thành công";
				return RedirectToAction("Index");
			}

			ModelState.AddModelError("", result.Message);
			var roleAssignRequest = await GetRoleAssignRequest(request.ID);

			return View(roleAssignRequest);
		}

		private async Task<RoleAssignRequest> GetRoleAssignRequest(Guid id)
		{
			//Lấy danh sách Role đã được gán vào User
			var userObj = await _userApiClient.GetByID(id);
			var roleObj = await _roleApiClient.GetAll();
			var roleAssignRequest = new RoleAssignRequest();
			foreach (var role in roleObj.ResultObj)
			{
				roleAssignRequest.Roles.Add(new SelectItem()
				{
					ID = role.RoleID.ToString(),
					Name = role.Name,
					Selected = userObj.ResultObj.Roles.Contains(role.Name)
				});
			}
			return roleAssignRequest;
		}
	}
}

