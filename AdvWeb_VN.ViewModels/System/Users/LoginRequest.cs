using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdvWeb_VN.ViewModels.System.Users
{
	public class LoginRequest
	{
		[Display(Name = "Tài khoản")]
		public string UserName { set; get; }

		[Display(Name = "Mật khẩu")]
		public string Password { set; get; }

		[Display(Name = "Ghi nhớ đăng nhập")]
		public bool RememberMe { set; get; }
	}
}
