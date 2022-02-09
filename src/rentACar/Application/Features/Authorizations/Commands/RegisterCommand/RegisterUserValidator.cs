using Application.Constants;
using FluentValidation;

namespace Application.Features.Authorizations.Commands.RegisterCommand
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserValidator()
        {
            RuleFor(p => p.Password).NotEmpty();
            RuleFor(p => p.Password).MinimumLength(6).WithMessage(Message.PasswordLength);
            RuleFor(p => p.Email).NotEmpty().EmailAddress();
        }
    }
}
