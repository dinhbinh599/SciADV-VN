using System;
using System.Threading.Tasks;
using AdvWeb_VN.ManageApp.Services;
using AdvWeb_VN.Utilities.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using AdvWeb_VN.ViewModels.Catalog.Categories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvWeb_VN.ManageApp.Controllers
{
	public class CategoryController : BaseController
	{
		private readonly ICategoryApiClient _categoryApiClient;
		private readonly IConfiguration _configuration;

		public CategoryController(ICategoryApiClient categoryApiClient, IConfiguration configuration)
		{
			_categoryApiClient = categoryApiClient;
			_configuration = configuration;
		}
		public async Task<IActionResult> Index()
		{
			var data = await _categoryApiClient.GetAll();
			return View(data);
		}

		// GET: /<controller>/
		

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			var result = await _categoryApiClient.GetByID(id);
			return View(result.ResultObj);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromForm]CategoryCreateRequest request)
		{
			if (!ModelState.IsValid)
				return View();

			var result = await _categoryApiClient.CreateCategory(request);
			if (result.IsSuccessed)
			{
				TempData["result"] = "Thêm chuyên mục thành công";
				return RedirectToAction("Index");
			}

			ModelState.AddModelError("", result.Message);
			return View(request);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var result = await _categoryApiClient.GetByID(id);
			if (result.IsSuccessed)
			{
				var category = result.ResultObj;
				var updateRequest = new CategoryUpdateRequest()
				{
					CategoryID = category.CategoryID,
					CategoryName = category.CategoryName
				};
				return View(updateRequest);
			}
			return RedirectToAction("Error", "Home");
		}

		[HttpPost]
		public async Task<IActionResult> Edit([FromForm]CategoryUpdateRequest request)
		{
			if (!ModelState.IsValid)
				return View();

			var result = await _categoryApiClient.UpdateCategory(request.CategoryID, request);
			if (result.IsSuccessed)
			{
				TempData["result"] = "Cập nhật chuyên mục thành công";
				return RedirectToAction("Index");
			}

			ModelState.AddModelError("", result.Message);
			return View(request);
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			return View(new CategoryDeleteRequest()
			{
				CategoryID = id
			});
		}

		[HttpPost]
		public async Task<IActionResult> Delete(CategoryDeleteRequest request)
		{
			if (!ModelState.IsValid)
				return View();

			var result = await _categoryApiClient.Delete(request.CategoryID);
			if (result.IsSuccessed)
			{
				TempData["result"] = "Xóa chuyên mục thành công";
				return RedirectToAction("Index");
			}

			ModelState.AddModelError("", result.Message);
			return View(request);
		}
	}
}
