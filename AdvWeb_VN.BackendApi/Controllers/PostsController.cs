using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvWeb_VN.Application.Catalog.Posts;
using AdvWeb_VN.Application.Catalog.Posts.Dtos;
using AdvWeb_VN.ViewModels.Catalog.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvWeb_VN.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PostsController : ControllerBase
    {
        private readonly IPostService postService;

        public PostsController(IPostService postService)
        {
            this.postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts = await postService.GetAll();
            return Ok(posts);
        }

        [HttpGet("paging-tagid")]
        public async Task<IActionResult> GetByTagID([FromQuery]GetPublicPostPagingRequest request)
        {
            var posts = await postService.GetAllByTagID(request);
            return Ok(posts);
        }

        [HttpGet("paging-categoryid")]
        public async Task<IActionResult> GetByCategoryID([FromQuery]GetPublicPostPagingRequest request)
        {
            var posts = await postService.GetAllByCategoryID(request);
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(string id)
        {
            var result = await postService.GetByID(id);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]PostCreateRequest request)
        {
            var result = await postService.Create(request);
            if (!result.IsSuccessed) return BadRequest(result);
            var post = await postService.GetByID(result.ResultObj);
            return CreatedAtAction(nameof(GetByID), new { PostID = result.ResultObj }, post.ResultObj);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm]PostUpdateRequest request)
        {
            var result = await postService.Update(request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AddViewCount(string id)
        {
            var result = await postService.AddViewCount(id);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await postService.Delete(id);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }
    }
}