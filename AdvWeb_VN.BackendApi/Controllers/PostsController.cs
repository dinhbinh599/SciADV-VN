using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvWeb_VN.Application.Catalog.Posts;
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
        public async Task<IActionResult> GetAllPagingByTagID([FromQuery]GetManagePostPagingRequest request)
        {
            var products = await postService.GetAllPagingTagID(request);
            return Ok(products);
        }

        [HttpGet("paging-categoryid")]
        public async Task<IActionResult> GetAllPagingByCategoryID([FromQuery]GetManagePostPagingRequest request)
        {
            var products = await postService.GetAllPagingCategoryID(request);
            return Ok(products);
        }

        [HttpGet("public-paging-tagid")]
        public async Task<IActionResult> GetByTagID([FromQuery]GetPublicPostPagingRequest request)
        {
            var posts = await postService.GetAllByTagID(request);
            return Ok(posts);
        }

        [HttpGet("public-paging-categoryid")]
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

        [HttpPut("{id}/tags")]
        public async Task<IActionResult> TagAssign(string id, [FromForm]TagAssignRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await postService.TagAssign(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("{id}/tags/assign/{name}")]
        public async Task<IActionResult> TagAssignByTagName(string id, string name)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await postService.TagAssignByTagName(id, name);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("{id}/roles/remove/{name}")]
        public async Task<IActionResult> TagRemoveByTagName(string id, string name)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await postService.TagRemoveByTagName(id, name);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }
    }
}