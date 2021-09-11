using System;

namespace AdvWeb_VN.ViewModels.Catalog.Comments
{
	public class CommentCreatePublicRequest
	{
		//public int CommentID { set; get; }
		public string Commentator { set; get; }
		public string Commenter { set; get; }
		public int ParentID { set; get; }
		public int PostID { set; get; }
	}
}