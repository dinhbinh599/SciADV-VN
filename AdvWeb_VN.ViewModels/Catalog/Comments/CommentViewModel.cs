using AdvWeb_VN.ViewModels.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdvWeb_VN.ViewModels.Catalog.Comments
{
	public class CommentViewModel
	{
		public int CommentID { set; get; }
		[Display(Name = "Tên")]
		public string Commentator { set; get; }
		[Display(Name = "Bình luận")]
		public string Commenter { set; get; }
		[Display(Name = "Thời gian bình luận")]
		public DateTime CommentTime { set; get; }
		public int PostID { set; get; }
		public int ParentID { set; get; }
		public string Avatar { set; get; }
		[Display(Name = "Lượt thích")]
		public int LikeCount { set; get; }
		[Display(Name = "Lượt không thích")]
		public int DislikeCount { set; get; }
		public bool IsManaged { set; get; }
		public bool IsView { set; get; }
		public bool IsOwner { set; get; }
		public bool IsOwnerPost { set; get; }
		public List<SubCommentViewModel> SubComments { set; get; }
	}
}