using System;
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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvWeb_VN.ManageApp.Controllers
{
	public class UserController : Controller
	{
		private readonly IUserClientApi _userClientApi;
		private readonly IConfiguration _configuration;

		public UserController(IUserClientApi userClientApi, IConfiguration configuration)
		{
			_userClientApi = userClientApi;
			_configuration = configuration;
		}


		// GET: /<controller>/
		[HttpGet]
		public async Task<IActionResult> Login()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Login(LoginRequest request)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);
			var result = await _userClientApi.Authenticate(request);
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
			//HttpContext.Session.SetString(SystemConstants.AppSettings.Token, result.ResultObj);
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
