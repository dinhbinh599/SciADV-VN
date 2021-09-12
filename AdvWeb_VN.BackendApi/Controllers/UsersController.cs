using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AdvWeb_VN.Application.System.Users;
using AdvWeb_VN.Data.Entities;
using AdvWeb_VN.Utilities.Constants;
using AdvWeb_VN.ViewModels.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AdvWeb_VN.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = RoleInfo.Admin)]
    public class UsersController : ControllerBase
    {
        //var userID = new Guid(User.Claims.First(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
        //Đoạn Code trên lấy UserID hiện hành dựa vào JWT Token gửi từ Client lên
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody]LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.Authenticate(request);

            if (string.IsNullOrEmpty(result.ResultObj))
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Register([FromForm]RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.Register(request);

            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("paging")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllPaging([FromQuery]GetUserPagingRequest request)
        {
            var users = await _userService.GetUsersPaging(request);
            return Ok(users);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByID(Guid id)
        {
            var user = await _userService.GetByID(id);
            return Ok(user);
        }

        [HttpGet("current")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userID = new Guid(User.Claims.First(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
            var user = await _userService.GetCurrentUser(userID);
            return Ok(user);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var user = await _userService.GetByName(name);
            return Ok(user);
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update(Guid id,[FromForm]UserUpdateRequest request)
        {
            var result = await _userService.Update(id ,request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("update-authenticate")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateAuthenticate([FromForm]UserUpdateRequest request)
        {
            var userID = new Guid(User.Claims.First(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
            var result = await _userService.Update(userID, request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userService.Delete(id);
            if (result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("{id}/roles")]
        public async Task<IActionResult> RoleAssign(Guid id, [FromBody]RoleAssignRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.RoleAssign(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("{id}/roles/assign/{name}")]
        public async Task<IActionResult> RoleAssignByRoleName(Guid id, string name)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.RoleAssignByRoleName(id, name);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("{id}/roles/remove/{name}")]
        public async Task<IActionResult> RoleRemoveByRoleName(Guid id, string name)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.RoleRemoveByRoleName(id, name);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }
    }
}