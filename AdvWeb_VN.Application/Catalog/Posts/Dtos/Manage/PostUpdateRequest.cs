﻿using System;

namespace AdvWeb_VN.Application.Catalog.Posts.Dtos.Manage
{
	public class PostUpdateRequest
	{
		public string PostID { set; get; }
		public string PostName { set; get; }
		public DateTime WriteTime { set; get; }
		public string Contents { set; get; }
		public string Thumbnail { set; get; }
		public int CategoryID { set; get; }
	}
}