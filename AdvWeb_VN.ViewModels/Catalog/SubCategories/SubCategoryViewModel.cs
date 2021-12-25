using System;
using System.ComponentModel.DataAnnotations;

namespace AdvWeb_VN.ViewModels.Catalog.SubCategories
{
	public class SubCategoryViewModel
	{
		public int SubCategoryID { set; get; }

		[Display(Name = "Tên Chuyên Mục Con")]
		public string SubCategoryName { set; get; }
		public int CategoryID { set; get; }
		[Display(Name = "Tên Chuyên Mục Cha")]
		public string CategoryName { set; get; }

		[Display(Name = "Số Bài Viết")]
		public int PostCount { set; get; }

		[Display(Name = "Ngày Tạo")]
		public DateTime CreateDate { set; get; }
		[Display(Name = "Hiển thị")]
		public bool? IsShow { set; get; }

	}
}