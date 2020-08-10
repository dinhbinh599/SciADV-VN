using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvWeb_VN.Application.Catalog.Comments;
using AdvWeb_VN.ViewModels.Catalog.Comments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvWeb_VN.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService commentService;

        public CommentsController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var comments = await commentService.GetAll();
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(string id)
        {
            var result = await commentService.GetByID(id);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("parrent/{id}")]
        public async Task<IActionResult> GetByParrentID(string id)
        {
            var comments = await commentService.GetByParrentID(id);
            return Ok(comments);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CommentCreateRequest request)
        {
            var result = await commentService.Create(request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm]CommentUpdateRequest request)
        {
            var result = await commentService.Update(request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await commentService.Delete(id);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }
    }
}