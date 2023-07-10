using BL.Commands.Users;
using FluentValidation;

namespace CurrencyApi.Utilites.Validations.UserValidation
{
    public class CreateUserValidation : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidation()
        {
            RuleFor(user => user.UserName).NotEmpty().WithMessage("User Name can't be empty")
                .MinimumLength(6).WithMessage("Your password length must be at least 6.")
                .MaximumLength(25).WithMessage("Your password length must not exceed 25.");

            RuleFor(Email => Email.Email)
            .NotEmpty().WithMessage("Email cannot be empty.")
            .EmailAddress().WithMessage("Write correct Email");

            RuleFor(p => p.Password).NotEmpty().WithMessage("Your password cannot be empty")
                    .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                    .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
                    .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                    .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                    .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.");

            RuleFor(user => user.CondirmPassword).NotEmpty().WithMessage("Your password cannot be empty")
                .Equal(user => user.Password).WithMessage("Password does not match");


        }
    }
}
