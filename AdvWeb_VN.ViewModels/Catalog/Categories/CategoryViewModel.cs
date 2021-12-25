using System;
using System.ComponentModel.DataAnnotations;

namespace AdvWeb_VN.ViewModels.Catalog.Categories
{
	public class CategoryViewModel
	{
		public int CategoryID { set; get; }

		[Display(Name = "Tên Chuyên Mục")]
		public string CategoryName { set; get; }

		[Display(Name = "Số chuyên mục con")]
		public int SubCount { set; get; }
		[Display(Name = "Số bài viết con")]
		public int PostCount { set; get; }

		[Display(Name = "Ngày Tạo")]
		public DateTime CreateDate { set; get; }
		[Display(Name = "Hiển thị")]
		public bool? IsShow { set; get; }

	}
}