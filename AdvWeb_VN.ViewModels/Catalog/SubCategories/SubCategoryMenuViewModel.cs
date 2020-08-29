using AdvWeb_VN.Data.Entities;
using AdvWeb_VN.ViewModels.Catalog.Posts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.ViewModels.Catalog.SubCategories
{
	public class SubCategoryMenuViewModel : SubCategoryViewModel
	{
		public List<PostViewModel> Posts { set; get; }
	}
}
