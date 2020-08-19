﻿using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace AdvWeb_VN.ViewModels.Catalog.Posts
{
	public class PostCreateRequest : PostCreateViewModel
	{
		//public string PostID { set; get; }
		[Display(Name ="Tên bài viết")]
		public string PostName { set; get; }

		[Display(Name = "Nội dung")]
		public string Contents { set; get; }

		[Display(Name = "Chuyên mục")]
		public int CategoryID { set; get; }

		[Display(Name = "Thumbnail")]
		public IFormFile ThumbnailFile { get; set; }
		public Guid UserID { get; set; }
	}
}