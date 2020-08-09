using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.ViewModels.Catalog.Categories
{
	public class CategoryCreateRequestValidator : AbstractValidator<CategoryCreateRequest>
	{
		public CategoryCreateRequestValidator()
		{
			RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Tên chuyên mục bắt buộc phải có!");
		}
	}
}
