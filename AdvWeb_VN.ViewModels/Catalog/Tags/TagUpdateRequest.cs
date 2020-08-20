using System;
using System.ComponentModel.DataAnnotations;

namespace AdvWeb_VN.ViewModels.Catalog.Tags
{
	public class TagUpdateRequest
	{
		public int TagID { set; get; }
		[Display(Name = "Tên Tag")]
		public string TagName { set; get; }
	}
}