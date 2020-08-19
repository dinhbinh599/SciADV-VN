using System;
using System.ComponentModel.DataAnnotations;

namespace AdvWeb_VN.ViewModels.Catalog.Tags
{
	public class TagCreateRequest
	{
		//public int CategoryID { set; get; }
		[Display(Name = "Tên Tag")]
		public string TagName { set; get; }
	}
}