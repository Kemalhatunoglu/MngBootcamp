using FluentValidation;

namespace Application.Features.Authorizations.Commands.LoginCommand
{
    public class LoginUserValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserValidator()
        {
            RuleFor(p => p.Password).NotEmpty();
            RuleFor(e => e.Email).NotEmpty();
        }
    }
}
