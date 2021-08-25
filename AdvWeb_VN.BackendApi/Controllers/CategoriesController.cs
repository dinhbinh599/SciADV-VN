using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvWeb_VN.Application.Catalog.Categories;
using AdvWeb_VN.ViewModels.Catalog.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvWeb_VN.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryService.GetAll();
            return Ok(categories);
        }

        [HttpGet("menu")]
        [AllowAnonymous]
        public async Task<IActionResult> GetMenuCategory()
        {
            var categories = await _categoryService.GetMenuCategory();
            return Ok(categories);
        }

        [HttpGet("footer")]
        [AllowAnonymous]
        public async Task<IActionResult> GetFooterCategory()
        {
            var categories = await _categoryService.GetFooterCategory();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByID(int id)
        {
            var result = await _categoryService.GetByID(id);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CategoryCreateRequest request)
        {
            var result = await _categoryService.Create(request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody]CategoryUpdateRequest request)
        {
            var result = await _categoryService.Update(request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.Delete(id);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }
    }
}