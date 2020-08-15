using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdvWeb_VN.ManageApp.Models;
using Microsoft.AspNetCore.Authorization;
using AdvWeb_VN.ManageApp.Services;
using Microsoft.Extensions.Configuration;

namespace AdvWeb_VN.ManageApp.Controllers
{
	[Authorize]
	public class HomeController : BaseController
	{
		private readonly ILogger<HomeController> _logger;
		
		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public async Task<IActionResult> Index()
		{
			return View();
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
