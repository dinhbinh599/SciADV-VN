using System;

namespace AdvWeb_VN.ViewModels.Catalog.Comments
{
	public class CommentCreateRequest
	{
		public string CommentID { set; get; }
		public string Commentator { set; get; }
		public string Commenter { set; get; }
		public string PostID { set; get; }
		public string ParrentID { set; get; }
		public Guid UserID { set; get; }
	}
}