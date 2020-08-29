using AdvWeb_VN.ViewModels.Catalog.Posts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.ViewModels.Catalog.SubCategories
{
	public class SubCategoryUpdateRequestValidator : AbstractValidator<SubCategoryUpdateRequest>
	{
		public SubCategoryUpdateRequestValidator()
		{
			RuleFor(x => x.SubCategoryName).NotEmpty().WithMessage("Tên chuyên mục bắt buộc phải có!");
		}
	}
}
