using System;
using System.Collections.Generic;

namespace AdvWeb_VN.ViewModels.Catalog.Posts
{
	public class PostViewModel
	{
		public string PostID { set; get; }
		public string PostName { set; get; }
		public string Contents { set; get; }
		public string Thumbnail { set; get; }
		public string UserName { set; get; }
		public int View { set; get; }
		public int CategoryID { set; get; }
		public string CategoryName { set; get; }
		public DateTime WriteTime { set; get; }
		public IList<string> Tags { set; get; }

	}
}