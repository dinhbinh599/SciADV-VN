using AdvWeb_VN.ViewModels.Catalog.Categories;
using AdvWeb_VN.ViewModels.Catalog.Posts;
using AdvWeb_VN.ViewModels.Catalog.Tags;
using AdvWeb_VN.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvWeb_VN.WebApp.Models
{
	public class HomePageViewModel
	{
		public PagedResult<PostViewModel> Posts;
		public List<CategoryMenuViewModel> CategoryMenus { set; get; }
		//public PagedResult<TagViewModel> Tags;
	}
}
