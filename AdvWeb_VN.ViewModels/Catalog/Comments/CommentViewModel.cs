using AdvWeb_VN.ViewModels.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdvWeb_VN.ViewModels.Catalog.Comments
{
	public class CommentViewModel
	{
		public int CommentID { set; get; }
		public string Commentator { set; get; }
		[Display(Name = "Bình luận")]
		public string Commenter { set; get; }
		public DateTime CommentTime { set; get; }
		public int PostID { set; get; }
		public int ParentID { set; get; }
		public string Avatar { set; get; }
		public int LikeCount { set; get; }
		public int DislikeCount { set; get; }
		public bool IsManaged { set; get; }
		public bool IsView { set; get; }
		public bool IsOwner { set; get; }
		public bool IsOwnerPost { set; get; }
		public List<SubCommentViewModel> SubComments { set; get; }
	}
}