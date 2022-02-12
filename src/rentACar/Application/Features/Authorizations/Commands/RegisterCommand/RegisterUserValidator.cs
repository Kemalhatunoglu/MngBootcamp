using Application.Constants;
using FluentValidation;

namespace Application.Features.Authorizations.Commands.RegisterCommand
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserValidator()
        {
            RuleFor(p => p.UserForRegister.Password).NotEmpty();
            RuleFor(p => p.UserForRegister.Password).MinimumLength(6).WithMessage(Message.PasswordLength);
            RuleFor(p => p.UserForRegister.Email).NotEmpty().EmailAddress();
        }
    }
}
