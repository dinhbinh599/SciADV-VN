using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.Data.Entities
{
	public class Category
	{
		public int CategoryID { set; get; }
		public string CategoryName { set; get; }
		public DateTime CreateDate { set; get; }
		public bool? IsShow { set; get; }
		public List<SubCategory> SubCategories { set; get; }
	}
}
