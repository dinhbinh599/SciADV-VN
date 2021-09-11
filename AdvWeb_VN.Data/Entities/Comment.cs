using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.Data.Entities
{
	public class Comment
	{
		public int CommentID { set; get; }
		public string Commentator { set; get; }
		public string Commenter { set; get; }
		public DateTime CommentTime { set; get; }
		public int PostID { set; get; }
		public int ParentID { set; get; }
		public bool IsManaged { set; get; }
		public bool IsView { set; get; }
		public int LikeCount { set; get; }
		public int DislikeCount { set; get; }
		public Guid UserID { set; get; }
		public Post Post { set; get; }
		//public User User { set; get; }
	}
}
