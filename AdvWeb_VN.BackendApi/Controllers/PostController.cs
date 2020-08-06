using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvWeb_VN.Application.Catalog.Posts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvWeb_VN.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPublicPostService publicPostService;

        public PostController(IPublicPostService publicPostService)
        {
            this.publicPostService = publicPostService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts = await publicPostService.GetAll();
            return Ok(posts);
        }
    }
}