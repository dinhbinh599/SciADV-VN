using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvWeb_VN.Application.Catalog.Categories;
using AdvWeb_VN.ViewModels.Catalog.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvWeb_VN.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await categoryService.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var result = await categoryService.GetByID(id);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CategoryCreateRequest request)
        {
            var result = await categoryService.Create(request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm]CategoryUpdateRequest request)
        {
            var result = await categoryService.Update(request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await categoryService.Delete(id);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }
    }
}