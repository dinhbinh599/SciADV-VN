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
			//Hiển thị toàn bộ chuyên mục ra.
			//Thường thì phải Paging nhưng số lượng ít thì show hết ra cho rồi
			var data = await _categoryApiClient.GetAll();
			return View(data);
		}

		// GET: /<controller>/
		

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			//Lấy thông tin chi tiết của chuyên mục
			var result = await _categoryApiClient.GetByID(id);
			return View(result.ResultObj);
		}

		[HttpGet]
		public IActionResult Create()
		{
			//Dẫn hướng đến trang tạo chuyên mục mới
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromForm]CategoryCreateRequest request)
		{
			//Khởi tạo chuyên mục mới nếu request gửi lên đầy đủ
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
			//Dẫn hướng đến trang chỉnh sửa, trước đó là lấy thông tin cũ để hiển thị
			var result = await _categoryApiClient.GetByID(id);
			if (result.IsSuccessed)
			{
				var category = result.ResultObj;

				var updateRequest = new CategoryUpdateRequest()
				{
					CategoryID = category.CategoryID,
					CategoryName = category.CategoryName,
					IsShow = category.IsShow ?? false
				};
				return View(updateRequest);
			}
			return RedirectToAction("Error", "Home");
		}

		[HttpPost]
		public async Task<IActionResult> Edit([FromForm]CategoryUpdateRequest request)
		{
			//Chỉnh sửa thông tin chuyên mục nếu request gửi lên từ Form đầy đủ
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
			//Dẫn hướng đến trang xác nhận xóa chuyên mục
			return View(new CategoryDeleteRequest()
			{
				CategoryID = id
			});
		}

		[HttpPost]
		public async Task<IActionResult> Delete(CategoryDeleteRequest request)
		{
			//Xóa nếu request gửi lên đầy đủ
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
