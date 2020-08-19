using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.ViewModels.Catalog.Posts
{
	public class PostCreateRequestValidator : AbstractValidator<PostCreateRequest>
	{
		public PostCreateRequestValidator()
		{
			RuleFor(x => x.PostName).NotEmpty().WithMessage("Tên bài viết bắt buộc phải có!");
			RuleFor(x => x.Contents).NotEmpty().WithMessage("Nội dung bắt buộc phải có!");
			RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Vui lòng chọn chuyên mục!");
		}
	}
}
