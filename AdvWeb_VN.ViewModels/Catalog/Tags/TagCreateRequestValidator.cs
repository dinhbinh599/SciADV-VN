using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.ViewModels.Catalog.Tags
{
	public class TagCreateRequestValidator : AbstractValidator<TagCreateRequest>
	{
		public TagCreateRequestValidator()
		{
			RuleFor(x => x.TagName).NotEmpty().WithMessage("Tên chuyên mục bắt buộc phải có!");
		}
	}
}
