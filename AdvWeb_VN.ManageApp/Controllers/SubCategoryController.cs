using System;
using System.Threading.Tasks;
using AdvWeb_VN.ManageApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using AdvWeb_VN.ViewModels.Catalog.Categories;
using AdvWeb_VN.ViewModels.Catalog.SubCategories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvWeb_VN.ManageApp.Controllers
{
	public class SubCategoryController : BaseController
	{
		private readonly ISubCategoryApiClient _subCategoryApiClient;
		private readonly IConfiguration _configuration;

		public SubCategoryController(ISubCategoryApiClient subCategoryApiClient, IConfiguration configuration)
		{
			_subCategoryApiClient = subCategoryApiClient;
			_configuration = configuration;
		}
		public async Task<IActionResult> Index()
		{
			var data = await _subCategoryApiClient.GetAll();
			return View(data);
		}

		// GET: /<controller>/
		

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			var result = await _subCategoryApiClient.GetByID(id);
			return View(result.ResultObj);
		}

		[HttpGet]
		public IActionResult Create()
		{
			ViewData["BaseAddress"] = _configuration["BaseAddress"];
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromForm]SubCategoryCreateRequest request)
		{
			if (!ModelState.IsValid)
				return View();

			var result = await _subCategoryApiClient.CreateCategory(request);
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
			ViewData["BaseAddress"] = _configuration["BaseAddress"];
			var result = await _subCategoryApiClient.GetByID(id);
			if (result.IsSuccessed)
			{
				var category = result.ResultObj;
				var updateRequest = new SubCategoryUpdateRequest()
				{
					SubCategoryID = category.CategoryID,
					SubCategoryName = category.SubCategoryName,
					CategoryName = category.CategoryName,
					CategoryID = category.CategoryID
				};
				return View(updateRequest);
			}
			return RedirectToAction("Error", "Home");
		}

		[HttpPost]
		public async Task<IActionResult> Edit([FromForm]SubCategoryUpdateRequest request)
		{
			if (!ModelState.IsValid)
				return View();

			var result = await _subCategoryApiClient.UpdateCategory(request.CategoryID, request);
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
			return View(new SubCategoryDeleteRequest()
			{
				CategoryID = id
			});
		}

		[HttpPost]
		public async Task<IActionResult> Delete(SubCategoryDeleteRequest request)
		{
			if (!ModelState.IsValid)
				return View();

			var result = await _subCategoryApiClient.Delete(request.CategoryID);
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
