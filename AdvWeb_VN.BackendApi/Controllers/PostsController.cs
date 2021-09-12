using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvWeb_VN.Application.Catalog.Posts;
using AdvWeb_VN.Application.System.Users;
using AdvWeb_VN.Data.Entities;
using AdvWeb_VN.Utilities.Constants;
using AdvWeb_VN.ViewModels.Catalog.Posts;
using AdvWeb_VN.ViewModels.Catalog.ProductImages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AdvWeb_VN.BackendApi.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostsController : ControllerBase
    {
        //var userID = new Guid(User.Claims.First(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
        //Đoạn Code trên lấy UserID hiện hành dựa vào JWT Token gửi từ Client lên
        private readonly IPostService _postService;
        private readonly IUserService _userService;

        public PostsController(IPostService postService, IUserService userService)
        {
            _postService = postService;
            _userService = userService;
        }


        [HttpGet]
        [Authorize(Roles = RoleInfo.Admin)]
        public async Task<IActionResult> Get()
        {
            var posts = await _postService.GetAll();
            return Ok(posts);
        }

        [HttpGet("public-paging")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPaging([FromQuery]GetPublicPostPagingRequestSearch request)
        {
            var posts = await _postService.GetPaging(request);
            return Ok(posts);
        }

        [HttpGet("popular")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPopular()
        {
            var posts = await _postService.GetPopular();
            return Ok(posts);
        }

        [HttpGet("paging-tagid")]
        [Authorize(Roles = RoleInfo.Admin)]
        public async Task<IActionResult> GetManagePagingByTagID([FromQuery]GetManagePostPagingRequest request)
        {
            var posts = await _postService.GetManagePagingByTagID(request);
            return Ok(posts);
        }

        [HttpGet("paging-subcategoryid")]
        [Authorize(Roles = RoleInfo.Admin)]
        public async Task<IActionResult> GetManagePagingBySubCategoryID([FromQuery]GetManagePostPagingRequest request)
        {
            var posts = await _postService.GetManagePagingBySubCategoryID(request);
            return Ok(posts);
        }

        [HttpGet("paging-categoryid")]
        [Authorize(Roles = RoleInfo.Admin)]
        public async Task<IActionResult> GetManagePagingByCategoryID([FromQuery]GetManagePostPagingRequest request)
        {
            var posts = await _postService.GetManagePagingByCategoryID(request);
            return Ok(posts);
        }

        [HttpGet("public-paging-category")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPagingCategory([FromQuery]GetPublicPostPagingRequest request)
        {
            var posts = await _postService.GetPagingCategory(request);
            return Ok(posts);
        }

        [HttpGet("public-paging-subcategory")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPagingSubCategory([FromQuery]GetPublicPostPagingRequest request)
        {
            var posts = await _postService.GetPagingSubCategory(request);
            return Ok(posts);
        }

        [HttpGet("public-paging-tag")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPagingTag([FromQuery]GetPublicPostPagingRequest request)
        {
            var posts = await _postService.GetPagingTag(request);
            return Ok(posts);
        }

        [HttpGet("{userID}/paging-categoryid")]
        public async Task<IActionResult> GetManagePagingByCategoryIDAuthenticate([FromQuery]GetManagePostPagingRequest request)
        {
            var userID = new Guid(User.Claims.First(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
            var posts = await _postService.GetManagePagingByCategoryIDAuthenticate(userID, request);
            return Ok(posts);
        }

        [HttpGet("public-paging-tagname")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPagingTagByName([FromQuery]GetPublicPostPagingRequestSearch request)
        {
            var posts = await _postService.GetPagingTagByName(request);
            return Ok(posts);
        }

        [HttpGet("public-paging-tagid")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByTagID([FromQuery]GetPublicPostPagingRequest request)
        {
            var posts = await _postService.GetPublicPagingByTagID(request);
            return Ok(posts);
        }

        [HttpGet("public-paging-categoryid")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByCategoryID([FromQuery]GetPublicPostPagingRequest request)
        {
            var posts = await _postService.GetPublicPagingByCategoryID(request);
            return Ok(posts);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByID(int id)
        {
            var result = await _postService.GetByID(id);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("{userID}/{id}")]
        public async Task<IActionResult> GetByIDAuthenticate(int id)
        {
            var userID = new Guid(User.Claims.First(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
            var result = await _postService.GetByIDAuthenticate(id, userID);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm]PostCreateRequest request)
        {
            var result = await _postService.Create(request);
            if (!result.IsSuccessed) return BadRequest(result);
            var post = await _postService.GetByID(result.ResultObj);
            //return CreatedAtAction(nameof(GetByID), new { PostID = result.ResultObj }, post.ResultObj);
            return Ok(post);
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        [Authorize(Roles = RoleInfo.Admin)]
        public async Task<IActionResult> Update(int id, [FromForm]PostUpdateRequest request)
        {
            var result = await _postService.Update(id,request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("{userID}/{id}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateAuthenticate(int id,[FromForm]PostUpdateRequest request)
        {
            var userID = new Guid(User.Claims.First(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
            var result = await _postService.UpdateAuthenticate(id, userID, request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("{id}/contents")]
        [Authorize(Roles = RoleInfo.Admin)]
        public async Task<IActionResult> UpdateContents(int id, [FromBody]PostUpdateContentsRequest request)
        {
            var result = await _postService.UpdateImageContents(id, request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("{userID}/{id}/contents")]
        public async Task<IActionResult> UpdateContentsAuthenticate(int id, [FromBody]PostUpdateContentsRequest request)
        {
            var userID = new Guid(User.Claims.First(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
            var result = await _postService.UpdateImageContentsAuthenticate(id, userID, request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("view/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> AddViewCount(int id)
        {
            var result = await _postService.AddViewCount(id);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = RoleInfo.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _postService.Delete(id);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("{userID}/{id}")]
        public async Task<IActionResult> DeleteAuthenticate(int id)
        {
            var userID = new Guid(User.Claims.First(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
            var result = await _postService.DeleteAuthenticate(id, userID);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("{id}/tags")]
        [Authorize(Roles = RoleInfo.Admin)]
        public async Task<IActionResult> TagAssign(int id, [FromBody]TagAssignRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _postService.TagAssign(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("{userID}/{id}/tags")]
        public async Task<IActionResult> TagAssignAuthenticate(int id, [FromBody]TagAssignRequest request)
        {
            var userID = new Guid(User.Claims.First(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _postService.TagAssignAuthenticate(id, userID, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        //Images
        [HttpPost("{postId}/images")]
        [Consumes("multipart/form-data")]
        [Authorize(Roles = RoleInfo.Admin)]
        public async Task<IActionResult> CreateImage(int postId, [FromForm]PostImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imageId = await _postService.AddImage(postId, request);
            if (imageId == 0)
                return BadRequest();

            var image = await _postService.GetImageByID(imageId);

            return Ok(image);
        }

        [HttpPost("{userID}/{postId}/images")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateImageAuthenticate(int postId, [FromForm]PostImageCreateRequest request)
        {
            var userID = new Guid(User.Claims.First(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imageId = await _postService.AddImageAuthenticate(postId, userID, request);
            if (imageId == 0)
                return BadRequest();

            var image = await _postService.GetImageByID(imageId);

            return Ok(image);
        }

        [HttpPost("{postId}/images/url")]
        [Authorize(Roles = RoleInfo.Admin)]
        public async Task<IActionResult> CreateImageByUrl(int postId, [FromBody]PostImageCreateUrlRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _postService.AddImageByUrl(postId, request);
            if (!result.IsSuccessed) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("{userID}/{postId}/images/url")]
        public async Task<IActionResult> CreateImageByUrlAuthenticate(int postId, [FromBody]PostImageCreateUrlRequest request)
        {
            var userID = new Guid(User.Claims.First(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _postService.AddImageByUrlAuthenticate(postId, userID, request);
            if (!result.IsSuccessed) return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("{postId}/images/{imageId}")]
        public async Task<IActionResult> UpdateImage(int imageId, [FromForm]PostImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _postService.UpdateImage(imageId, request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("{postID}/images/{imageId}")]
        public async Task<IActionResult> RemoveImage(int imageId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _postService.RemoveImage(imageId);
            if (result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("{postID}/images/{imageId}")]
        public async Task<IActionResult> GetImageById(int imageId)
        {
            var image = await _postService.GetImageByID(imageId);
            if (image == null) return BadRequest("Cannot find Image");
            return Ok(image);
        }

        [HttpGet("{postID}/images")]
        public async Task<IActionResult> GetImageByPostId(int postID)
        {
            var image = await _postService.GetListImages(postID);
            if (image == null) return BadRequest("Cannot find post");
            return Ok(image);
        }
    }
}