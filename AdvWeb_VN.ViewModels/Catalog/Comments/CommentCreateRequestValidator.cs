using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.ViewModels.Catalog.Comments
{
	public class CommentCreateRequestValidator : AbstractValidator<CommentCreateRequest>
	{
		public CommentCreateRequestValidator()
		{
			RuleFor(x => x.Commenter).NotEmpty().WithMessage("Bình luận bắt buộc phải có!");
			RuleFor(x => x.PostID).NotEmpty().WithMessage("Bài viết bắt buộc phải có!");
		}
	}
}
