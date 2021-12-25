using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.Data.Entities
{
	public class SubCategory
	{
		public int SubCategoryID { set; get; }
		public string CategoryName { set; get; }
		public DateTime CreateDate { set; get; }
		public int CategoryID { set; get; }
		public bool? IsShow { set; get; }
		public Category Category { set; get; }
		public List<Post> Posts { set; get; }
	}
}
