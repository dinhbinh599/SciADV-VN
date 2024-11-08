using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdvWeb_VN.Models;
using AdvWeb_VN.WebApp.Services;
using Microsoft.Extensions.Configuration;
using AdvWeb_VN.ViewModels.Catalog.Posts;
using AdvWeb_VN.WebApp.Models;

namespace AdvWeb_VN.WebApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly IPostApiClient _postApiClient;
		private readonly ICategoryApiClient _categoryApiClient;
		private readonly IConfiguration _configuration;
		private readonly ILogger<HomeController> _logger;

		public HomeController(IPostApiClient postApiClient, ICategoryApiClient categoryApiClient, IConfiguration configuration, ILogger<HomeController> logger)
		{
			_postApiClient = postApiClient;
			_categoryApiClient = categoryApiClient;
			_configuration = configuration;
			_logger = logger;
		}

		public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 10)
		{
			//Load dữ liệu để hiển thị ở trang chủ
			ViewData["Active"] = 0;
			ViewData["BaseAddress"] = _configuration["BaseAddress"];

			var postRequest = new GetPublicPostPagingRequestSearch()
			{
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			var resultCategory = await _categoryApiClient.GetMenuCategory();
			var resultPost = await _postApiClient.GetPostsPagings(postRequest);

			var homeVM = new HomePageViewModel()
			{
				Posts = resultPost.ResultObj,
				CategoryMenus = resultCategory.ResultObj
			};

			ViewBag.description = "Website của nhóm dịch Gero Saga, mục tiêu của nhóm là series Visual Novel mang tên Science Adventure (\"CHAOS; HEAD\", \"STEINS; GATE\", \"ROBOTICS; NOTES\"...) của 5pb./MAGES";
			ViewBag.keywords = "Visual Novel, Science Adventure, CHAOS; HEAD, STEINS; GATE, ROBOTICS; NOTES, MAGES, CHAO; CHILD";
			ViewBag.ogtype = "Website";
			ViewBag.ogtitle = "Gero Saga";
			ViewBag.ogimage = ViewData["BaseAddress"] + "/user-content/" + resultPost.ResultObj.Items[0].Thumbnail;
			ViewBag.ogdescription = "Website của nhóm dịch Gero Saga, mục tiêu của nhóm là series Visual Novel mang tên Science Adventure (\"CHAOS; HEAD\", \"STEINS; GATE\", \"ROBOTICS; NOTES\"...) của 5pb./MAGES";
			ViewBag.ogurl = ViewData["PortalAddress"];

			if (TempData["result"] != null)
			{
				ViewBag.SuccessMsg = TempData["result"];
			}
			return View(homeVM);
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
