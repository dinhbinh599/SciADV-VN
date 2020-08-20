using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvWeb_VN.Application.Catalog.Posts;
using AdvWeb_VN.ViewModels.Catalog.Posts;
using AdvWeb_VN.ViewModels.Catalog.ProductImages;
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
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts = await _postService.GetAll();
            return Ok(posts);
        }

        [HttpGet("paging-tagid")]
        public async Task<IActionResult> GetAllPagingByTagID([FromQuery]GetManagePostPagingRequest request)
        {
            var posts = await _postService.GetAllPagingTagID(request);
            return Ok(posts);
        }

        [HttpGet("paging-categoryid")]
        public async Task<IActionResult> GetAllPagingByCategoryID([FromQuery]GetManagePostPagingRequest request)
        {
            var posts = await _postService.GetAllPagingCategoryID(request);
            return Ok(posts);
        }

        [HttpGet("{userID}/paging-categoryid")]
        public async Task<IActionResult> GetAllPagingByCategoryID(Guid userID,[FromQuery]GetManagePostPagingRequest request)
        {
            var posts = await _postService.GetAllPagingCategoryIDAuthenticate(userID, request);
            return Ok(posts);
        }

        [HttpGet("public-paging-tagid")]
        public async Task<IActionResult> GetByTagID([FromQuery]GetPublicPostPagingRequest request)
        {
            var posts = await _postService.GetAllByTagID(request);
            return Ok(posts);
        }

        [HttpGet("public-paging-categoryid")]
        public async Task<IActionResult> GetByCategoryID([FromQuery]GetPublicPostPagingRequest request)
        {
            var posts = await _postService.GetAllByCategoryID(request);
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(string id)
        {
            var result = await _postService.GetByID(id);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("{userID}/{id}")]
        public async Task<IActionResult> GetByID(Guid userID,string id)
        {
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
        public async Task<IActionResult> Update(string id, [FromForm]PostUpdateRequest request)
        {
            var result = await _postService.Update(id,request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("{userID}/{id}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update(Guid userID, string id,[FromForm]PostUpdateRequest request)
        {
            var result = await _postService.UpdateAuthenticate(id, userID, request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("{id}/contents")]
        public async Task<IActionResult> UpdateContents(string id, [FromBody]PostUpdateContentsRequest request)
        {
            var result = await _postService.UpdateImageContents(id, request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("{userID}/{id}/contents")]
        public async Task<IActionResult> UpdateContents(Guid userID, string id, [FromBody]PostUpdateContentsRequest request)
        {
            var result = await _postService.UpdateImageContentsAuthenticate(id, userID, request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("view/{id}")]
        public async Task<IActionResult> AddViewCount(string id)
        {
            var result = await _postService.AddViewCount(id);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _postService.Delete(id);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("{userID}/{id}")]
        public async Task<IActionResult> Delete(Guid userID, string id)
        {
            var result = await _postService.DeleteAuthenticate(id, userID);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("{id}/tags")]
        public async Task<IActionResult> TagAssign(string id, [FromBody]TagAssignRequest request)
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
        public async Task<IActionResult> TagAssign(Guid userID, string id, [FromBody]TagAssignRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _postService.TagAssignAuthenticate(id, userID, request);
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

            var result = await _postService.TagAssignByTagName(id, name);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("{id}/roles/remove/{name}")]
        public async Task<IActionResult> TagRemoveByTagName(string id, string name)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _postService.TagRemoveByTagName(id, name);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        //Images
        [HttpPost("{postId}/images")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateImage(string postId, [FromForm]PostImageCreateRequest request)
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
        public async Task<IActionResult> CreateImage(Guid userID, string postId, [FromForm]PostImageCreateRequest request)
        {
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
        public async Task<IActionResult> CreateImageByUrl(string postId, [FromBody]PostImageCreateUrlRequest request)
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
        public async Task<IActionResult> CreateImageByUrl(Guid userID, string postId, [FromBody]PostImageCreateUrlRequest request)
        {
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
        public async Task<IActionResult> GetImageByPostId(string postID)
        {
            var image = await _postService.GetListImages(postID);
            if (image == null) return BadRequest("Cannot find post");
            return Ok(image);
        }
    }
}