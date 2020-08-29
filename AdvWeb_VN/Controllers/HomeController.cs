using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdvWeb_VN.Models;
using AdvWeb_VN.WebApp.Services;
using Microsoft.Extensions.Configuration;
using AdvWeb_VN.ViewModels.Catalog.Posts;

namespace AdvWeb_VN.Controllers
{
	public class HomeController : Controller
	{
		private readonly IPostApiClient _postApiClient;
		private readonly IConfiguration _configuration;
		private readonly ILogger<HomeController> _logger;

		public HomeController(IPostApiClient postApiClient, IConfiguration configuration, ILogger<HomeController> logger)
		{
			_postApiClient = postApiClient;
			_configuration = configuration;
			_logger = logger;
		}

		public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 10)
		{
			ViewData["Active"] = 0;
			var request = new GetPublicPostPagingRequest()
			{
				PageIndex = pageIndex,
				PageSize = pageSize
			};
			var data = await _postApiClient.GetPostsPagings(request);
			if (TempData["result"] != null)
			{
				ViewBag.SuccessMsg = TempData["result"];
			}
			return View(data.ResultObj);
		}
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
