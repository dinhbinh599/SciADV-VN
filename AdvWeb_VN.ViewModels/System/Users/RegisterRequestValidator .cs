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
			RuleFor(x => x.UserName).NotEmpty().WithMessage("Tài khoản là bắt buộc");
			RuleFor(x => x.Password).NotEmpty().WithMessage("Mật khẩu là bắt buộc")
				.MinimumLength(8).WithMessage("Mật khẩu phải lớn hơn 8 kí tự");
			RuleFor(x => x.Email).NotEmpty().WithMessage("Email là bắt buộc")
				.EmailAddress().WithMessage("Vui lòng nhập Email");
			RuleFor(x => x).Custom((request, context) =>
			  {
				  if (request.Password != request.ConfirmPassWord)
					  context.AddFailure("Mật khẩu không khớp");
			  });
			RuleFor(x => x.Password).Matches("(?=^.{8,}$)(?=.*\\d)(?=.*[!@#$%^&*]+)(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$")
				.WithMessage("Mật khẩu phải chứa ít nhất 1 chữ in hoa, 1 chữ in thường và 1 kí tự đặc biệt");
			RuleFor(x => x.AvatarImage).NotEmpty().WithMessage("Vui lòng chọn ảnh đại diện");
		}
	}
}
