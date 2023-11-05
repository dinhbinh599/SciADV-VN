using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvWeb_VN.Application.Catalog.Comments;
using AdvWeb_VN.Utilities.Constants;
using AdvWeb_VN.ViewModels.Catalog.Comments;
using AdvWeb_VN.ViewModels.Catalog.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvWeb_VN.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentsController : ControllerBase
    {
        //var userID = new Guid(User.Claims.First(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
        //Đoạn Code trên lấy UserID hiện hành dựa vào JWT Token gửi từ Client lên
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        [Authorize(Roles = RoleInfo.Admin)]
        public async Task<IActionResult> Get()
        {
            var comments = await _commentService.GetAll();
            return Ok(comments);
        }

        [HttpGet("new-count")]
        [Authorize(Roles = RoleInfo.Admin)]
        public async Task<IActionResult> GetNewCount()
        {
            var result = await _commentService.GetNewCount();
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("new-count-authenticate")]
        public async Task<IActionResult> GetNewCountAuthenticate()
        {
            var userID = new Guid(User.Claims.First(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
            var result = await _commentService.GetNewCountAuthenticate(userID);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("new")]
        [Authorize(Roles = RoleInfo.Admin)]
        public async Task<IActionResult> GetNew([FromQuery]GetManageCommentPagingRequest request)
        {
            var comments = await _commentService.GetPagingNewComment(request);
            return Ok(comments);
        }

        [HttpGet("new-authenticate")]
        public async Task<IActionResult> GetNewAuthenticate([FromQuery]GetManageCommentPagingRequest request)
        {
            var userID = new Guid(User.Claims.First(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
            var comments = await _commentService.GetPagingNewCommentAuthenticate(userID, request);
            return Ok(comments);
        }

        [HttpGet("comment/{id}")]
        public async Task<IActionResult> GetCommentByID(int id)
        {
            var result = await _commentService.GetCommentByID(id);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("post")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByPostID([FromQuery]GetPublicPostPagingRequest request)
        {
            var comments = await _commentService.GetPagingByPostID(request);
            return Ok(comments);
        }

        [HttpGet("post-manage")]
        [Authorize(Roles = RoleInfo.Admin)]
        public async Task<IActionResult> GetManagePagingByPostID([FromQuery]GetManageCommentPagingRequest request)
        {
            var comments = await _commentService.GetManagePagingByPostID(request);
            return Ok(comments);
        }

        [HttpGet("post-manage-authenticate")]
        public async Task<IActionResult> GetManagePagingByPostIDAuthenticate([FromQuery]GetManageCommentPagingRequest request)
        {
            var userID = new Guid(User.Claims.First(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
            var comments = await _commentService.GetManagePagingByPostIDAuthenticate(userID,request);
            return Ok(comments);
        }

        [HttpPost("comment-public")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateCommentPublic([FromBody]CommentCreatePublicRequest request)
        {
            //var result = await _commentService.CreateCommentPublic(request);
            //if (!result.IsSuccessed) return BadRequest(result);
            //return Ok(result);
            return BadRequest();
        }

        [HttpPost("comment-manage")]
        [Authorize(Roles = RoleInfo.Admin)]
        public async Task<IActionResult> CreateCommentManage([FromBody]CommentCreateManageRequest request)
        {
            var result = await _commentService.CreateCommentManage(request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("comment-authenticate")]
        public async Task<IActionResult> CreateCommentAuthenticate([FromBody]CommentCreateManageRequest request)
        {
            var result = await _commentService.CreateCommentAuthenticate(request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }


        [HttpPut("update-comment/{id}")]
        [Authorize(Roles = RoleInfo.Admin)]
        public async Task<IActionResult> UpdateComment([FromBody]CommentUpdateRequest request)
        {
            var result = await _commentService.UpdateComment(request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("update-comment-authenticate/{id}")]
        public async Task<IActionResult> UpdateCommentAuthenticate([FromBody]CommentUpdateRequest request)
        {
            var userID = new Guid(User.Claims.First(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
            var result = await _commentService.UpdateCommentAuthenticate(userID,request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }


        [HttpDelete("comment/{id}")]
        [Authorize(Roles = RoleInfo.Admin)]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var result = await _commentService.DeleteComment(id);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }


        [HttpPut("comment-like/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> AddCommentLike(int id)
        {
            var result = await _commentService.AddCommentLike(id);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("comment-dislike/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> AddCommentDislike(int id)
        {
            var result = await _commentService.AddCommentDislike(id);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("comment-view/{id}")]
        [Authorize(Roles = RoleInfo.Admin)]
        public async Task<IActionResult> MarkViewComment([FromBody]int id)
        {
            var result = await _commentService.MarkViewComment(id);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }


        [HttpPut("comment-view-authenticate/{id}")]
        public async Task<IActionResult> MarkViewCommentAuthenticate([FromBody]int id)
        {
            var userID = new Guid(User.Claims.First(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
            var result = await _commentService.MarkViewCommentAuthenticate(userID, id);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

    }
}