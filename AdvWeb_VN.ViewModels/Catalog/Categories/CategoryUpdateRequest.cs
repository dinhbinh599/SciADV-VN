using System;
using System.ComponentModel.DataAnnotations;

namespace AdvWeb_VN.ViewModels.Catalog.Categories
{
	public class CategoryUpdateRequest
	{
		public int CategoryID { set; get; }
		[Display(Name = "Tên chuyên mục")]
		public string CategoryName { set; get; }
	}
}