using AdvWeb_VN.ViewModels.Catalog.Posts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.ViewModels.Catalog.Tags
{
	public class TagUpdateRequestValidator : AbstractValidator<TagUpdateRequest>
	{
		public TagUpdateRequestValidator()
		{
			RuleFor(x => x.TagName).NotEmpty().WithMessage("Tên bài viết bắt buộc phải có!");
		}
	}
}
