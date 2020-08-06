using System;

namespace AdvWeb_VN.ViewModels.Catalog.Posts
{
	public class PostUpdateRequest
	{
		public string PostID { set; get; }
		public string PostName { set; get; }
		public string Contents { set; get; }
		public string Thumbnail { set; get; }
		public int CategoryID { set; get; }
	}
}