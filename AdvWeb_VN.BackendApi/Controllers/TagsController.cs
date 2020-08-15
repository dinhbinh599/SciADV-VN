using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvWeb_VN.Application.Catalog.Tags;
using AdvWeb_VN.ViewModels.Catalog.Tags;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvWeb_VN.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tags = await _tagService.GetAll();
            return Ok(tags);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var result = await _tagService.GetByID(id);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]TagCreateRequest request)
        {
            var result = await _tagService.Create(request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody]TagUpdateRequest request)
        {
            var result = await _tagService.Update(request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _tagService.Delete(id);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }
    }
}