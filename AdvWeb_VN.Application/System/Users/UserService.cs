﻿using AdvWeb_VN.Data.Entities;
using AdvWeb_VN.Utilities.Exceptions;
using AdvWeb_VN.ViewModels.Common;
using AdvWeb_VN.ViewModels.System.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AdvWeb_VN.Application.System.Users
{
	public class UserService : IUserService
	{ 
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		private readonly RoleManager<Role> _roleManager;
		private readonly IConfiguration _configuration;

		public UserService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, IConfiguration configuration)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
			_configuration = configuration;
		}

		public async Task<ApiResult<string>> Authenticate(LoginRequest request)
		{
			var user = await _userManager.FindByNameAsync(request.UserName);
			if (user == null) return new ApiErrorResult<string>("Username or Password is wrong");
			
			var roles = await _userManager.GetRolesAsync(user);
			var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, request.RememberMe, true);
			if(!result.Succeeded) return new ApiErrorResult<string>("Tên đăng nhập hoặc mật khẩu không đúng");

			var claims = new[]
			{
				new Claim(ClaimTypes.Email, user.Email),
				new Claim(ClaimTypes.Name, user.UserName),
				new Claim(ClaimTypes.Role, string.Join(";", roles))
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(_configuration["Tokens:Issuer"],
				_configuration["Tokens:Issuer"],
				claims,
				expires: DateTime.Now.AddHours(3),
				signingCredentials: creds);

			var tokenOut = new JwtSecurityTokenHandler().WriteToken(token);
			return new ApiSuccessResult<string>(tokenOut);
		}

		public async Task<ApiResult<bool>> Delete(Guid id)
		{
			var user = await _userManager.FindByIdAsync(id.ToString());
			if (user == null)
			{
				return new ApiErrorResult<bool>("User không tồn tại");
			}
			var reult = await _userManager.DeleteAsync(user);
			if (reult.Succeeded)
				return new ApiSuccessResult<bool>();

			return new ApiErrorResult<bool>("Xóa không thành công");
		}

		public async Task<ApiResult<UserViewModel>> GetByID(Guid id)
		{
			var user = await _userManager.FindByIdAsync(id.ToString());
			if (user == null) return new ApiErrorResult<UserViewModel>("User không tồn tại");
			var roles = await _userManager.GetRolesAsync(user);
			var userVm = new UserViewModel()
			{
				Email = user.Email,
				PhoneNumber = user.PhoneNumber,
				UserID = user.Id,
				UserName = user.UserName,
				Roles = roles
			};
			return new ApiSuccessResult<UserViewModel>(userVm);
		}

		public async Task<ApiResult<PagedResult<UserViewModel>>> GetUsersPaging(GetUserPagingRequest request)
		{
			var query = _userManager.Users;
			if (!string.IsNullOrEmpty(request.Keyword))
			{
				query = query.Where(x => x.UserName.Contains(request.Keyword) 
				|| x.PhoneNumber.Contains(request.Keyword) 
				|| x.Email.Contains(request.Keyword));
			}

			int totalRow = await query.CountAsync();
			var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
				.Take(request.PageSize)
				.Select(x => new UserViewModel()
				{
					UserID = x.Id,
					UserName = x.UserName,
					Email = x.Email,
					PhoneNumber = x.PhoneNumber
				}).ToListAsync();
			var pagedResult = new PagedResult<UserViewModel>()
			{
				TotalRecord = totalRow,
				Items = data
			};
			return new ApiSuccessResult<PagedResult<UserViewModel>>(pagedResult);
		}

		public async Task<ApiResult<bool>> Register(RegisterRequest request)
		{
			var user = await _userManager.FindByNameAsync(request.UserName);
			if (user != null) return new ApiErrorResult<bool>("Tài khoản đã tồn tại");

			user = await _userManager.FindByNameAsync(request.Email);
			if (user != null) return new ApiErrorResult<bool>("Email đã tồn tại");

			user = await _userManager.FindByNameAsync(request.PhoneNumber);
			if (user != null) return new ApiErrorResult<bool>("Số điện thoại đã tồn tại");

			user = new User()
			{
				UserName = request.UserName,
				Email = request.Email,
				PhoneNumber = request.PhoneNumber
			};
			var result = await _userManager.CreateAsync(user, request.Password);
			if (result.Succeeded) return new ApiSuccessResult<bool>();
			return new ApiErrorResult<bool>("Đăng ký không thành công");
		}

		public async Task<ApiResult<bool>> RoleRemoveByRoleName(Guid id, string roleName)
		{
			var user = await _userManager.FindByIdAsync(id.ToString());
			if (user == null) return new ApiErrorResult<bool>("Tài khoản không tồn tại");
			if (!await _roleManager.RoleExistsAsync(roleName)) return new ApiErrorResult<bool>("Role không tồn tại");
			if (await _userManager.IsInRoleAsync(user, roleName) == true)
			{
				await _userManager.RemoveFromRoleAsync(user, roleName);
			}
			return new ApiSuccessResult<bool>();
		}

		public async Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request)
		{
			var user = await _userManager.FindByIdAsync(id.ToString());
			if (user == null) return new ApiErrorResult<bool>("Tài khoản không tồn tại");
			var removedRoles = request.Roles.Where(x => x.Selected == false).Select(x => x.Name).ToList();
			foreach (var roleName in removedRoles)
			{
				if (await _userManager.IsInRoleAsync(user, roleName) == true)
				{
					await _userManager.RemoveFromRoleAsync(user, roleName);
				}
			}
			await _userManager.RemoveFromRolesAsync(user, removedRoles);

			var addedRoles = request.Roles.Where(x => x.Selected).Select(x => x.Name).ToList();
			foreach (var roleName in addedRoles)
			{
				if (await _userManager.IsInRoleAsync(user, roleName) == false)
				{
					await _userManager.AddToRoleAsync(user, roleName);
				}
			}

			return new ApiSuccessResult<bool>();
		}

		public async Task<ApiResult<bool>> RoleAssignByRoleName(Guid id, string roleName)
		{
			var user = await _userManager.FindByIdAsync(id.ToString());
			if (user == null) return new ApiErrorResult<bool>("Tài khoản không tồn tại");
			if(!await _roleManager.RoleExistsAsync(roleName)) return new ApiErrorResult<bool>("Role không tồn tại");
			if (await _userManager.IsInRoleAsync(user, roleName) == false)
			{
				await _userManager.AddToRoleAsync(user, roleName);
			}
			else { return new ApiErrorResult<bool>($"User này đã tồn tại role {roleName}"); }
			return new ApiSuccessResult<bool>();
		}

		public async Task<ApiResult<bool>> Update(Guid id,UserUpdateRequest request)
		{
			if (await _userManager.Users.AnyAsync(x => x.Email == request.Email && x.Id != id))
			{
				return new ApiErrorResult<bool>("Emai đã tồn tại");
			}
			var user = await _userManager.FindByIdAsync(id.ToString());
			user.Email = request.Email;
			user.PhoneNumber = request.PhoneNumber;

			var result = await _userManager.UpdateAsync(user);
			if (result.Succeeded)
			{
				return new ApiSuccessResult<bool>();
			}
			return new ApiErrorResult<bool>("Cập nhật không thành công");
		}
	}
}
