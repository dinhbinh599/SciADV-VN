using System;

namespace AdvWeb_VN.Application.Catalog.Posts.Dtos
{
	public class PostViewModel
	{
		public string PostID { set; get; }
		public string PostName { set; get; }
		public string Contents { set; get; }
		public string Thumbnail { set; get; }
		public int View { set; get; }
		public int CategoryID { set; get; }
		public DateTime WriteTime { set; get; }

	}
}