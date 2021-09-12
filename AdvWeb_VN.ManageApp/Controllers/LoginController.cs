﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AdvWeb_VN.ManageApp.Services;
using AdvWeb_VN.Utilities.Constants;
using AdvWeb_VN.ViewModels.System.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

namespace AdvWeb_VN.ManageApp.Controllers
{
    public class LoginController : Controller
    {
		private readonly IUserApiClient _userApiClient;
		private readonly IConfiguration _configuration;

		public LoginController(IUserApiClient userApiClient, IConfiguration configuration)
		{
			_userApiClient = userApiClient;
			_configuration = configuration;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			//Thoát ra khỏi đăng nhập hiện hành và hiển thị trang Login
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Index(LoginRequest request)
		{		
			//Kiểm tra tên đăng nhập và mật khẩu, nếu đúng thì lưu lại JWT Token để dùng sau này.
			if (!ModelState.IsValid) return BadRequest(ModelState);
			var result = await _userApiClient.Authenticate(request);
			if (result.ResultObj == null)
			{
				ModelState.AddModelError("", result.Message);
				return View();
			}
			var userPrincipal = this.ValidateToken(result.ResultObj);
			var authProperties = new AuthenticationProperties
			{
				ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
				IsPersistent = false
			};
			HttpContext.Session.SetString(SystemConstants.AppSettings.Token, result.ResultObj);
			await HttpContext.SignInAsync(
						CookieAuthenticationDefaults.AuthenticationScheme,
						userPrincipal,
						authProperties);

			return RedirectToAction("Index", "Home");
		}

		private ClaimsPrincipal ValidateToken(string jwtToken)
		{
			IdentityModelEventSource.ShowPII = true;

			SecurityToken validatedToken;
			TokenValidationParameters validationParameters = new TokenValidationParameters();

			validationParameters.ValidateLifetime = true;

			validationParameters.ValidAudience = _configuration["Tokens:Issuer"];
			validationParameters.ValidIssuer = _configuration["Tokens:Issuer"];
			validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));

			ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);

			return principal;
		}
	}
}