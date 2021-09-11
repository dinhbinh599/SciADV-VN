﻿using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace AdvWeb_VN.ViewModels.Catalog.Posts
{
	public class PostUpdateRequest : PostUpdateViewModel
	{
		public int PostID { set; get; }

		[Display(Name = "Tên bài viết")]
		public string PostName { set; get; }

		[Display(Name = "Nội dung")]
		public string Contents { set; get; }

		[Display(Name = "Thumbnail")]
		public string Thumbnail { set; get; }

		[Display(Name = "Thumbnail")]
		public IFormFile ThumbnailFile { get; set; }
		[Display(Name = "Chuyên mục cha")]
		public int CategoryID { set; get; }
		[Display(Name = "Chuyên mục con")]
		public int SubCategoryID { set; get; }
		[Display(Name = "Tên chuyên mục con")]
		public string SubCategoryName { set; get; }
		[Display(Name = "Tên chuyên mục cha")]
		public string CategoryName { set; get; }
	}
}