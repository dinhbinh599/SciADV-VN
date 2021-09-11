using AdvWeb_VN.Data.Entities;
using AdvWeb_VN.ViewModels.Catalog.Comments;
using AdvWeb_VN.ViewModels.Catalog.Posts;
using AdvWeb_VN.ViewModels.Catalog.Tags;
using AdvWeb_VN.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvWeb_VN.WebApp.Models
{
	public class PostPageViewModel
	{
		public PostViewModel Post;
		public PagedResult<CommentViewModel> Comments;
		public CommentCreatePublicRequest CommentCreate;
	}
}
