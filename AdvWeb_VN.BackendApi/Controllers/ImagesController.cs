using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvWeb_VN.Application.Catalog.Categories;
using AdvWeb_VN.Application.Catalog.ProductImages;
using AdvWeb_VN.Utilities.Constants;
using AdvWeb_VN.ViewModels.Catalog.Categories;
using AdvWeb_VN.ViewModels.Catalog.Posts;
using AdvWeb_VN.ViewModels.Catalog.ProductImages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvWeb_VN.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ImagesController : ControllerBase
    {
        private readonly IProductImageService _imageService;

        public ImagesController(IProductImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet("paging")]
        [Authorize(Roles = RoleInfo.Admin)]
        public async Task<IActionResult> GetManagerPaging([FromQuery] GetManagePostPagingRequest request)
        {
            var images = await _imageService.GetImagesPaging(request);
            return Ok(images);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] PostImageCreateRequest request)
        {
            var result = await _imageService.Create(request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("assign")]
        public async Task<IActionResult> ImageAssign(ImageAssignRequest request)
        {
            var result = await _imageService.ImageAssign(request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ImageUnassignAll(int id)
        {
            var result = await _imageService.ImageUnassignAll(id);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }
    }
}