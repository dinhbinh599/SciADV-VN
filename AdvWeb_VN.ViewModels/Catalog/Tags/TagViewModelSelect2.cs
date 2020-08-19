using System;
using System.ComponentModel.DataAnnotations;

namespace AdvWeb_VN.ViewModels.Catalog.Tags
{
	public class TagViewModelSelect2
	{
		public int id { set; get; }

		[Display(Name ="Tên Tag")]
		public string text { set; get; }
		public bool selected { set; get; }
	}
}