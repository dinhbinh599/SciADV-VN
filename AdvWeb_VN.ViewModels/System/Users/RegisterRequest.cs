using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdvWeb_VN.ViewModels.System.Users
{
	public class RegisterRequest
	{
		[Display(Name = "Tài khoản")]
		public string UserName { set; get; }

		[Display(Name = "Mật khẩu")]
		[DataType(DataType.Password)]
		public string Password { set; get; }

		[Display(Name = "Xác nhận mật khẩu")]
		[DataType(DataType.Password)]
		public string ConfirmPassWord { set; get; }

		[Display(Name = "Địa chỉ Email")]
		public string Email { set; get; }

		[Display(Name = "Số điện thoại")]
		public string PhoneNumber { set; get; }
		public IFormFile AvatarImage { set; get; }
	}
}
