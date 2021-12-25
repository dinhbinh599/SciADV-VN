using System;
using System.ComponentModel.DataAnnotations;

namespace AdvWeb_VN.ViewModels.Catalog.SubCategories
{
	public class SubCategoryCreateRequest
	{
		//public int CategoryID { set; get; }
		[Display(Name = "Tên chuyên mục con" )]
		public string CategoryName { set; get; }
		[Display(Name = "Tên chuyên mục cha")]
		public int CategoryID { set; get; }
		[Display(Name = "Hiển thị")]
		public bool IsShow { set; get; }
	}
}