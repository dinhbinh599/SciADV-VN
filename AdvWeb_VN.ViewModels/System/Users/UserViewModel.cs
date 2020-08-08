using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.ViewModels.System.Users
{
	public class UserViewModel
	{
		public Guid UserID { set; get; }
		public string UserName { set; get; }
		public string Email { set; get; }
		public string PhoneNumber { set; get; }
		public IList<string> Roles { get; set; }
	}
}
