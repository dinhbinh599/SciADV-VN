using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

using AdvWeb_VN.Data.EF;
using AdvWeb_VN.Data.Entities;

namespace AdvWeb_VN.WebApp.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
