using AdvWeb_VN.ViewModels.Catalog.Categories;
using AdvWeb_VN.ViewModels.Catalog.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvWeb_VN.ViewModels.Catalog.Posts
{
	public class PostUpdateViewModel  
	{
		public List<CategoryViewModel> Categories { set; get; }
		public TagAssignRequest TagAssignRequest { set; get; } 
	}
}
