using System;
using System.Threading.Tasks;
using AdvWeb_VN.ManageApp.Services;
using AdvWeb_VN.Utilities.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using AdvWeb_VN.ViewModels.Catalog.Tags;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvWeb_VN.ManageApp.Controllers
{
	public class TagController : BaseController
	{
		private readonly ITagApiClient _tagApiClient;
		private readonly IConfiguration _configuration;

		public TagController(ITagApiClient tagApiClient, IConfiguration configuration)
		{
			_tagApiClient = tagApiClient;
			_configuration = configuration;
		}
		public async Task<IActionResult> Index()
		{
			var data = await _tagApiClient.GetAll();
			return View(data);
		}

		// GET: /<controller>/


		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			var result = await _tagApiClient.GetByID(id);
			return View(result.ResultObj);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromForm]TagCreateRequest request)
		{
			if (!ModelState.IsValid)
				return View();

			var result = await _tagApiClient.CreateTag(request);
			if (result.IsSuccessed)
			{
				TempData["result"] = "Thêm Tag thành công";
				return RedirectToAction("Index");
			}

			ModelState.AddModelError("", result.Message);
			return View(request);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var result = await _tagApiClient.GetByID(id);
			if (result.IsSuccessed)
			{
				var category = result.ResultObj;
				var updateRequest = new TagUpdateRequest()
				{
					TagID = category.TagID,
					TagName = category.TagName
				};
				return View(updateRequest);
			}
			return RedirectToAction("Error", "Home");
		}

		[HttpPost]
		public async Task<IActionResult> Edit([FromForm]TagUpdateRequest request)
		{
			if (!ModelState.IsValid)
				return View();

			var result = await _tagApiClient.UpdateTag(request.TagID, request);
			if (result.IsSuccessed)
			{
				TempData["result"] = "Cập nhật Tag thành công";
				return RedirectToAction("Index");
			}

			ModelState.AddModelError("", result.Message);
			return View(request);
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			return View(new TagDeleteRequest()
			{
				TagID = id
			});
		}

		[HttpPost]
		public async Task<IActionResult> Delete(TagDeleteRequest request)
		{
			if (!ModelState.IsValid)
				return View();

			var result = await _tagApiClient.Delete(request.TagID);
			if (result.IsSuccessed)
			{
				TempData["result"] = "Xóa Tag thành công";
				return RedirectToAction("Index");
			}

			ModelState.AddModelError("", result.Message);
			return View(request);
		}
	}
}
