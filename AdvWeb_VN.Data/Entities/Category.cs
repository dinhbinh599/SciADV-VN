using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.Data.Entities
{
	public class Category
	{
		public string CategoryID { set; get; }
		public string CategoryName { set; get; }
		public DateTime CreateDate { set; get; }
		public List<Post> Posts { set; get; }
	}
}
