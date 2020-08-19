using System;
using System.ComponentModel.DataAnnotations;

namespace AdvWeb_VN.ViewModels.Catalog.Tags
{
	public class TagViewModel
	{
		public int TagID { set; get; }

		[Display(Name ="Tên Tag")]
		public string TagName { set; get; }

		[Display(Name = "Số Bài Viết")]
		public int PostCount { set; get; }
	}
}