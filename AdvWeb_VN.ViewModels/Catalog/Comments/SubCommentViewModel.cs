using System;
using System.ComponentModel.DataAnnotations;

namespace AdvWeb_VN.ViewModels.Catalog.Comments
{
	public class SubCommentViewModel
	{
		public int SubCommentID { set; get; }

		[Display(Name = "Tên")]
		public string Commentator { set; get; }

		[Display(Name = "Bình luận")]
		public string Commenter { set; get; }

		[Display(Name = "Thời gian")]
		public DateTime CommentTime { set; get; }

		public int PostID { set; get; }
		public string Avatar { set; get; }
		public int ParentID { set; get; }

		[Display(Name = "Lượt thích")]
		public int LikeCount { set; get; }
		public bool IsView { set; get; }

		[Display(Name = "Lượt không thích")]
		public int DislikeCount { set; get; }
		public bool IsManaged { set; get; }
		public bool IsOwner { set; get; }
		public bool IsOwnerPost { set; get; }

	}
}