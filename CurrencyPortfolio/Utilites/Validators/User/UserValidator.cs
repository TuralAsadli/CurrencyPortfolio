using BL.DTOs.UserDTOs;
using FluentValidation;

namespace CurrencyPortfolio.Utilites.Validators.User
{
    public class UserValidator : AbstractValidator<CreateUserDTO>
    {
        public UserValidator()
        {
            RuleFor(UserName => UserName.UserName)
            .NotEmpty().WithMessage("UserName cannot be empty.")
            .Length(3, 25).WithMessage("Name must be between 3 and 25 characters");


            RuleFor(Email => Email.Email)
            .NotEmpty().WithMessage("Email cannot be empty.")
            .EmailAddress().WithMessage("Write correct Email");

            RuleFor(p => p.Password).NotEmpty().WithMessage("Your password cannot be empty")
                    .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                    .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
                    .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                    .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                    .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.");

            RuleFor(cp => cp.ConfirmPassword).Equal(cp => cp.Password).WithMessage("Password mismatch");
        }
    }
}
