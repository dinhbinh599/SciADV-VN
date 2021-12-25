using System;
using System.ComponentModel.DataAnnotations;

namespace AdvWeb_VN.ViewModels.Catalog.SubCategories
{
	public class SubCategoryUpdateRequest
	{
		public int SubCategoryID { set; get; }
		[Display(Name = "Tên chuyên mục con")]
		public string SubCategoryName { set; get; }
		[Display(Name = "Tên chuyên mục cha")]
		public int CategoryID { set; get; }
		[Display(Name = "Tên chuyên mục cha")]
		public string CategoryName { set; get; }
		[Display(Name = "Hiển thị")]
		public bool IsShow { set; get; }
	}
}