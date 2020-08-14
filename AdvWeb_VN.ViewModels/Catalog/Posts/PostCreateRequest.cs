using Microsoft.AspNetCore.Http;
using System;

namespace AdvWeb_VN.ViewModels.Catalog.Posts
{
	public class PostCreateRequest
	{
		//public string PostID { set; get; }
		public string PostName { set; get; }
		public string Contents { set; get; }
		public string Thumbnail { set; get; }
		public int CategoryID { set; get; }
		public bool IsDefault { get; set; }
		public IFormFile ThumbnailFile { get; set; }
		public Guid UserID { get; set; }
	}
}