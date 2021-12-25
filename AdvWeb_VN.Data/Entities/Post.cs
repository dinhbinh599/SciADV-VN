using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.Data.Entities
{
	public class Post
	{
		public int PostID { set; get; }
		public string PostName { set; get; }
		public DateTime WriteTime { set; get; }
		public string Contents { set; get; }
		public string Thumbnail { set; get; }
		public int SubCategoryID { set; get; }
		public int CategoryID { set; get; }
		public Guid UserID { set; get; }
		public int View { set; get; }
		public User User { set; get; }
		public bool? IsShow { set; get; }
		public List<PostTag> PostTags { set; get; }
		public SubCategory SubCategory { set; get; }
		public List<Comment> Comments {set;get;}
		public List<PostImage> PostImages { set; get; }
	}
}
