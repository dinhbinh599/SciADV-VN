using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdvWeb_VN.ViewModels.Catalog.Posts
{
	public class PostViewModel
	{
		public int PostID { set; get; }

		[Display(Name = "Tên bài viết")]
		public string PostName { set; get; }

		[Display(Name = "Nội dung")]
		public string Contents { set; get; }
		public string Thumbnail { set; get; }

		[Display(Name = "Người viết")]
		public string UserName { set; get; }

		[Display(Name = "Lượt xem")]
		public int View { set; get; }

		[Display(Name = "Chuyên mục con")]
		public int SubCategoryID { set; get; }

		[Display(Name = "Chuyên mục con")]
		public string SubCategoryName { set; get; }

		[Display(Name = "Chuyên mục cha")]
		public int CategoryID { set; get; }

		[Display(Name = "Chuyên mục cha")]
		public string CategoryName { set; get; }

		[Display(Name = "Ngày viết")]
		public DateTime WriteTime { set; get; }
		public IList<string> Tags { set; get; }
	}
}