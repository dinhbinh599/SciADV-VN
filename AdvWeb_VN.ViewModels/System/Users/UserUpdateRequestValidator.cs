using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.ViewModels.System.Users
{
	public class UserUpdateRequestValidator : AbstractValidator<UserUpdateRequest>
	{
		public UserUpdateRequestValidator()
		{
			RuleFor(x => x.Email).NotEmpty().WithMessage("Email bắt buộc phải có")
				.EmailAddress().WithMessage("Sai định dạng Email");
			RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Số điện thoại bắt buộc phải có");
		}
	}
}
