﻿using AdvWeb_VN.Application.Common;
using AdvWeb_VN.Data.EF;
using AdvWeb_VN.Data.Entities;
using AdvWeb_VN.Utilities.Exceptions;
using AdvWeb_VN.ViewModels.Common;
using AdvWeb_VN.ViewModels.System.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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
		private readonly IStorageService _storageService;
		private readonly AdvWebDbContext _context;

		public UserService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, IConfiguration configuration, IStorageService storageService, AdvWebDbContext context)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
			_configuration = configuration;
			_storageService = storageService;
			_context = context;
		}

		private async Task<string> SaveFile(IFormFile file)
		{
			//Lưu file hình ảnh Avatar của User
			var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
			var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
			await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
			return fileName;
		}

		public async Task<ApiResult<string>> Authenticate(LoginRequest request)
		{
			//Xác thực người dùng và trả về JWT Token để đăng nhập và xác thực sau này.
			var user = await _userManager.FindByNameAsync(request.UserName);
			if (user == null) return new ApiErrorResult<string>("Tên đăng nhập hoặc mật khẩu không đúng");
			
			var roles = await _userManager.GetRolesAsync(user);
			var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, request.RememberMe, true);
			if(!result.Succeeded) return new ApiErrorResult<string>("Tên đăng nhập hoặc mật khẩu không đúng");

			List<Claim> info = new List<Claim>();
			info.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
			info.Add(new Claim(ClaimTypes.Email, user.Email));
			info.Add(new Claim(ClaimTypes.Name, user.UserName));
			foreach (var item in roles)
			{
				info.Add(new Claim(ClaimTypes.Role, item));
			}
			var claims = info.ToArray();

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(_configuration["Tokens:Issuer"],
				_configuration["Tokens:Issuer"],
				claims,
				expires: DateTime.Now.ToUniversalTime().AddHours(3),
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
			//Lấy dữ liệu người dùng từ ID
			var user = await _userManager.FindByIdAsync(id.ToString());
			if (user == null) return new ApiErrorResult<UserViewModel>("User không tồn tại");
			var roles = await _userManager.GetRolesAsync(user);
			var userVm = new UserViewModel()
			{
				Email = user.Email,
				PhoneNumber = user.PhoneNumber,
				UserName = user.UserName,
				Roles = roles,
				AvatarImage = user.Avatar
			};
			return new ApiSuccessResult<UserViewModel>(userVm);
		}

		public async Task<ApiResult<PagedResult<UserViewModel>>> GetUsersPaging(GetUserPagingRequest request)
		{
			//Lấy về danh sách Paging của người dùng dựa vào từ khóa
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
				TotalRecords = totalRow,
				PageIndex = request.PageIndex,
				PageSize = request.PageSize,
				Items = data
			};
			return new ApiSuccessResult<PagedResult<UserViewModel>>(pagedResult);
		}

		public async Task<ApiResult<bool>> Register(RegisterRequest request)
		{
			//Thêm người dùng mới (Chỉ dùng cho Admin)
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

			//Lưu File Avatar và trả về đường dẫn. Nếu không có hình mặc định là File có sẵn
			if (request.AvatarImage != null)
			{
				user.Avatar = await this.SaveFile(request.AvatarImage);
			}
			else
			{
				user.Avatar = "user-icon.jpg";
			}
			var result = await _userManager.CreateAsync(user, request.Password);
			if (result.Succeeded) return new ApiSuccessResult<bool>();
			return new ApiErrorResult<bool>("Đăng ký không thành công");
		}

		public async Task<ApiResult<bool>> RoleRemoveByRoleName(Guid id, string roleName)
		{
			//Xóa Role dựa vào tên Role
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
			//Gán Role cho người dùng
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
			//Gán Role cho người dùng dựa vào tên Role
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
			//Thay đổi thông tin người dùng
			if (await _userManager.Users.AnyAsync(x => x.Email == request.Email && x.Id != id))
			{
				return new ApiErrorResult<bool>("Emai đã tồn tại");
			}
			var user = await _userManager.FindByIdAsync(id.ToString());
			user.Email = request.Email;
			user.PhoneNumber = request.PhoneNumber;
			if (request.AvatarImage != null)
			{
				user.Avatar = await this.SaveFile(request.AvatarImage);
			}
			var result = await _userManager.UpdateAsync(user);
			if (result.Succeeded)
			{
				return new ApiSuccessResult<bool>();
			}
			return new ApiErrorResult<bool>("Cập nhật không thành công");
		}

		public async Task<ApiResult<UserViewModel>> GetByName(string name)
		{
			//Lấy thông tin người dùng dựa vào tên người dùng
			var user = await _userManager.FindByNameAsync(name);
			if (user == null) return new ApiErrorResult<UserViewModel>("Người dùng không tồn tại");
			var roles = await _userManager.GetRolesAsync(user);
			var userVm = new UserViewModel()
			{
				Email = user.Email,
				PhoneNumber = user.PhoneNumber,
				UserID = user.Id,
				UserName = user.UserName,
				Roles = roles,
				AvatarImage = user.Avatar
			};
			return new ApiSuccessResult<UserViewModel>(userVm);
		}

		public async Task<bool> IsPostOwner(Guid id, int postID)
		{
			//Kiểm tra người dùng có phải người đăng bài hay không
			var post = await _context.Posts.FirstOrDefaultAsync(x => x.PostID.Equals(postID));
			if (id == post.UserID) return true;
			return false;
		}

		public async Task<ApiResult<UserViewModel>> GetCurrentUser(Guid id)
		{
			//Lấy về thông tin của người dùng đang đăng nhập
			var user = await _userManager.FindByIdAsync(id.ToString());
			if (user == null) return new ApiErrorResult<UserViewModel>("User không tồn tại");
			var roles = await _userManager.GetRolesAsync(user);
			var userVm = new UserViewModel()
			{
				Email = user.Email,
				PhoneNumber = user.PhoneNumber,
				UserID = user.Id,
				UserName = user.UserName,
				Roles = roles,
				AvatarImage = user.Avatar
			};
			return new ApiSuccessResult<UserViewModel>(userVm);
		}
	}
}
