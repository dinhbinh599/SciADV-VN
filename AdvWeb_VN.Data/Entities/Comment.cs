using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.Data.Entities
{
	public class Comment
	{
		public string CommentID { set; get; }
		public string Commentator { set; get; }
		public string Commenter { set; get; }
		public DateTime CommentTime { set; get; }
		public string PostID { set; get; }
		public Guid UserID { set; get; }
		public Post Post { set; get; }
		//public User User { set; get; }
	}
}
