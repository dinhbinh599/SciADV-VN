using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdvWeb_VN.ViewModels.System.Users
{
	public class UserViewModel
	{
		public Guid UserID { set; get; }

		[Display(Name = "Tài khoản")]
		public string UserName { set; get; }
		public string Email { set; get; }

		[Display(Name = "Số điện thoại")]
		public string PhoneNumber { set; get; }

		[Display(Name = "Ảnh đại diện")]
		public string AvatarImage { set; get; }
		public IList<string> Roles { get; set; }
	}
}
