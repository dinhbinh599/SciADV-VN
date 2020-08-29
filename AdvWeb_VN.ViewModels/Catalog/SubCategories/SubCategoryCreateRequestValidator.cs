using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.ViewModels.Catalog.SubCategories
{
	public class SubCategoryCreateRequestValidator : AbstractValidator<SubCategoryCreateRequest>
	{
		public SubCategoryCreateRequestValidator()
		{
			RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Tên chuyên mục bắt buộc phải có!");
			RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Tên chuyên mục cha bắt buộc phải có!");
		}
	}
}
