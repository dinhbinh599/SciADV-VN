using AdvWeb_VN.ViewModels.Catalog.Posts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.ViewModels.Catalog.Comments
{
	public class CommentUpdateRequestValidator : AbstractValidator<CommentUpdateRequest>
	{
		public CommentUpdateRequestValidator()
		{
			RuleFor(x => x.Commenter).NotEmpty().WithMessage("Bình luận bắt buộc phải có!");

		}
	}
}
