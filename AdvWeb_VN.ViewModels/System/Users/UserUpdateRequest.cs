using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdvWeb_VN.ViewModels.System.Users
{
	public class UserUpdateRequest
	{
		public Guid ID { set; get; }
		[Display(Name = "Địa chỉ Email")]
		public string Email { set; get; }

		[Display(Name = "Số điện thoại")]
		public string PhoneNumber { set; get; }
		public string AvatarImagePath { set; get; }
		public IFormFile AvatarImage { set; get; }
	}
}
