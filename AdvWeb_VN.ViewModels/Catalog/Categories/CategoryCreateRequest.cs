﻿using System;
using System.ComponentModel.DataAnnotations;

namespace AdvWeb_VN.ViewModels.Catalog.Categories
{
	public class CategoryCreateRequest
	{
		//public int CategoryID { set; get; }
		[Display(Name = "Tên chuyên mục" )]
		public string CategoryName { set; get; }
	}
}