using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.ViewModels.System.Users
{
	public class RegisterRequest
	{
		public string UserName { set; get; }
		public string Password { set; get; }
		public string ConfirmPassWord { set; get; }
		public string Email { set; get; }
		public string PhoneNumber { set; get; }
	}
}
