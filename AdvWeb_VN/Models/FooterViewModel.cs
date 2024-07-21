using AdvWeb_VN.ViewModels.Catalog.Categories;
using AdvWeb_VN.ViewModels.Catalog.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvWeb_VN.WebApp.Models
{
	public class FooterViewModel
	{
		public List<CategoryViewModel> CategoryFooters { set; get; }
		public List<PostViewModel> PostFooters { set; get; }
		public List<string> Donors { get; set; }
	}
}
