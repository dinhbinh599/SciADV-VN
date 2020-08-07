using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.ViewModels.System.Users
{
	public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
	{
		public RegisterRequestValidator()
		{
			RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required");
			RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required")
				.MinimumLength(6).WithMessage("Password is at least 6 characters");
			RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
				.EmailAddress().WithMessage("Email is wrong");
			RuleFor(x => x).Custom((request, context) =>
			  {
				  if (request.Password != request.ConfirmPassWord)
					  context.AddFailure("Confirm password is not match");
			  });
		}
	}
}
