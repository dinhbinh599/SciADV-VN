using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.ViewModels.Catalog.Comments
{
	public class CommentCreatePublicRequestValidator : AbstractValidator<CommentCreatePublicRequest>
	{
		public CommentCreatePublicRequestValidator()
		{
			RuleFor(x => x.Commentator).NotEmpty().WithMessage("Tên bắt buộc phải có!");
			RuleFor(x => x.Commenter).NotEmpty().WithMessage("Bình luận bắt buộc phải có!");
			RuleFor(x => x.PostID).NotEmpty().WithMessage("Bài viết bắt buộc phải có!");
			RuleFor(x => x.Commentator).MaximumLength(50).WithMessage("Tên không được vượt quá 50 kí tự!");
			RuleFor(x => x.Commenter).MaximumLength(1000).WithMessage("Bình luận không được vượt quá 200 kí tự!");
		}
	}
}
