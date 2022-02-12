using FluentValidation;

namespace Application.Features.Authorizations.Commands.LoginCommand
{
    public class LoginUserValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserValidator()
        {
            RuleFor(p => p.UserForLogin.Password).NotEmpty();
            RuleFor(e => e.UserForLogin.Email).NotEmpty();
        }
    }
}
