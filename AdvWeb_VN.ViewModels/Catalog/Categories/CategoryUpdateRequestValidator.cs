using AdvWeb_VN.ViewModels.Catalog.Posts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.ViewModels.Catalog.Categories
{
	public class CategoryUpdateRequestValidator : AbstractValidator<CategoryUpdateRequest>
	{
		public CategoryUpdateRequestValidator()
		{
			RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Tên bài viết bắt buộc phải có!");
		}
	}
}
