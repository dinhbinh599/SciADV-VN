using System;
using System.Threading.Tasks;
using AdvWeb_VN.ManageApp.Services;
using AdvWeb_VN.Utilities.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using AdvWeb_VN.ViewModels.Catalog.Categories;
using AdvWeb_VN.ViewModels.Catalog.Posts;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvWeb_VN.ManageApp.Controllers
{
	public class GalleryController : BaseController
	{
		private readonly IProductImageApiClient _imageApiClient;
		private readonly IConfiguration _configuration;

		public GalleryController(IProductImageApiClient imageApiClient, IConfiguration configuration)
		{
			_imageApiClient = imageApiClient;
			_configuration = configuration;
		}
		public async Task<IActionResult> Index(string keyword, int id = 1, int pageIndex = 1, int pageSize = 8)
		{
			//Hiển thị hình ảnh Paging.
			ViewData["BaseAddress"] = _configuration["BaseAddress"];
			ViewData["PortalAddress"] = _configuration["PortalAddress"];

			var request = new GetManagePostPagingRequest()
			{
				ID = id,
				Keyword = keyword,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			var data = await _imageApiClient.GetImagesPaging(request);
			return View(data.ResultObj);
		}

		// GET: /<controller>/
	}
}
