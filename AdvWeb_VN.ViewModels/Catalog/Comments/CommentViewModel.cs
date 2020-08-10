using System;

namespace AdvWeb_VN.ViewModels.Catalog.Categories
{
	public class CommentViewModel
	{
		public string CommentID { set; get; }
		public string Commentator { set; get; }
		public string Commenter { set; get; }
		public DateTime CommentTime { set; get; }
		public string PostName { set; get; }
		public string ParrentID { set; get; }
	}
}