using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.Data.Entities
{
	public class User : IdentityUser<Guid>
	{
		//public List<Comment> Comments { set; get; }
		public List<Post> Posts { set; get; }
	}
}
