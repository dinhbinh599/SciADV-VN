using System;

namespace AdvWeb_VN.ViewModels.Catalog.Comments
{
	public class SubCommentViewModel
	{
		public int SubCommentID { set; get; }
		public string Commentator { set; get; }
		public string Commenter { set; get; }
		public DateTime CommentTime { set; get; }
		public int PostID { set; get; }
		public string Avatar { set; get; }
		public int ParentID { set; get; }
		public int LikeCount { set; get; }
		public bool IsView { set; get; }
		public int DislikeCount { set; get; }
		public bool IsManaged { set; get; }
		public bool IsOwner { set; get; }
		public bool IsOwnerPost { set; get; }

	}
}