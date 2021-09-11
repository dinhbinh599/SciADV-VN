using System;

namespace AdvWeb_VN.ViewModels.Catalog.Comments
{
	public class CommentUpdateRequest
	{
		public int CommentID { set; get; }
		public string Commenter { set; get; }
		public int PostID { set; get; }
	}
}