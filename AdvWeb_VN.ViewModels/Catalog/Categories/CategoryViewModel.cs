using System;
using System.ComponentModel.DataAnnotations;

namespace AdvWeb_VN.ViewModels.Catalog.Categories
{
	public class CategoryViewModel
	{
		public int CategoryID { set; get; }

		[Display(Name = "Tên Chuyên Mục")]
		public string CategoryName { set; get; }

		[Display(Name = "Số Bài Viết")]
		public int PostCount { set; get; }

		[Display(Name = "Ngày Tạo")]
		public DateTime CreateDate { set; get; }

	}
}