using AdvWeb_VN.Data.Entities;
using AdvWeb_VN.ViewModels.Catalog.SubCategories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.ViewModels.Catalog.Categories
{
	public class CategoryMenuViewModel : CategoryViewModel
	{
		public SubCategoryMenuViewModel SubCategoryAll { set; get; }
		public List<SubCategoryMenuViewModel> SubCategories { set; get; }
	}
}
