using AdvWeb_VN.ViewModels.Catalog.Categories;
using AdvWeb_VN.ViewModels.Catalog.Posts;
using AdvWeb_VN.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvWeb_VN.WebApp.Models
{
	public class HeaderViewModel
	{
		public PagedResult<PostViewModel> PostHeaders { set; get; }
		public List<CategoryMenuViewModel> CategoryMenus { set; get; }
	}
}
