using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvWeb_VN.Application.Catalog.Posts;
using AdvWeb_VN.Application.Catalog.Posts.Dtos;
using AdvWeb_VN.ViewModels.Catalog.Posts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvWeb_VN.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPublicPostService publicPostService;
        private readonly IManagePostService managePostService;

        public PostController(IPublicPostService publicPostService, IManagePostService managePostService)
        {
            this.publicPostService = publicPostService;
            this.managePostService = managePostService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts = await publicPostService.GetAll();
            return Ok(posts);
        }

        [HttpGet("public-paging")]
        public async Task<IActionResult> Get([FromQuery]GetPublicPostPagingRequest request)
        {
            var posts = await publicPostService.GetAllByTagId(request);
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(string id)
        {
            var posts = await managePostService.GetByID(id);
            if (posts == null) return BadRequest("Cannot find a post");
            return Ok(posts);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]PostCreateRequest request)
        {
            var postID = await managePostService.Create(request);
            if(postID == "") return BadRequest();
            var post = await managePostService.GetByID(postID);
            return CreatedAtAction(nameof(GetByID),new { PostID = postID },post);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm]PostUpdateRequest request)
        {
            var result = await managePostService.Update(request);
            if (result == 0) return BadRequest();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await managePostService.Delete(id);
            if (result == 0) return BadRequest();
            return Ok();
        }
    }
}