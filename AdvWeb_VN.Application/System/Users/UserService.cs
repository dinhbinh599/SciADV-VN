using AdvWeb_VN.Data.Entities;
using AdvWeb_VN.Utilities.Exceptions;
using AdvWeb_VN.ViewModels.System.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AdvWeb_VN.Application.System.Users
{
	public class UserService : IUserService
	{
		private readonly UserManager<User> userManager;
		private readonly SignInManager<User> signInManager;
		private readonly RoleManager<Role> roleManager;
		private readonly IConfiguration configuration;

		public UserService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, IConfiguration configuration)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.roleManager = roleManager;
			this.configuration = configuration;
		}

		public async Task<string> Authenticate(LoginRequest request)
		{
			var user = await userManager.FindByNameAsync(request.UserName);
			var roles = await userManager.GetRolesAsync(user);
			if (user == null) throw new AdvWebException("Username or Password is wrong");

			var result = await signInManager.PasswordSignInAsync(request.UserName, request.Password, request.RememberMe, true);
			if(!result.Succeeded) return null;

			var claims = new[]
			{
				new Claim(ClaimTypes.Email, user.Email),
				new Claim(ClaimTypes.Name, user.UserName),
				new Claim(ClaimTypes.Role, string.Join(";", roles))
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(configuration["Tokens:Issuer"],
				configuration["Tokens:Issuer"],
				claims,
				expires: DateTime.Now.AddHours(3),
				signingCredentials: creds);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		public async Task<bool> Register(RegisterRequest request)
		{
			var user = new User()
			{
				UserName = request.UserName,
				Email = request.Email,
				PhoneNumber = request.PhoneNumber
			};
			var result = await userManager.CreateAsync(user,request.Password);
			if (result.Succeeded) return true;
			return false;
		}
	}
}
