using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using AdvWeb_VN.Models;
using AdvWeb_VN.Data.EF;

namespace AdvWeb_VN.Controllers
{
	public class HomeController : Controller
	{
		private readonly AdvWebDbContext _context;

		public HomeController(AdvWebDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
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
