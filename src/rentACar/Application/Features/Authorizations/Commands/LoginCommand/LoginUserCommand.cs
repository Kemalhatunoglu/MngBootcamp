using Application.Constants;
using Application.Features.Authorizations.Rules;
using Application.Services.Repositories;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Jwt;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Authorizations.Commands.LoginCommand
{
    public class LoginUserCommand : IRequest<IDataResult<AccessToken>>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, IDataResult<AccessToken>>
        {
            private readonly IUserRepository _userRepository;
            private readonly ITokenHelper _tokenHelper;
            private readonly AuthBusinessRules _authBusinessRules;

            public LoginUserCommandHandler(ITokenHelper tokenHelper, IUserRepository userRepository, AuthBusinessRules authBusinessRules)
            {
                _tokenHelper = tokenHelper;
                _userRepository = userRepository;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<IDataResult<AccessToken>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetAsync(u => u.Email == request.Email);
                await _authBusinessRules.UserEmailShouldBeExists(request.Email);
                await _authBusinessRules.UserPasswordShouldBeMatch(user.Id, request.Password);

                List<OperationClaim> claims = _userRepository.GetClaims(user);
                AccessToken accessToken = await _tokenHelper.CreateTokenAsync(user, claims);

                accessToken.Claims = claims.Select(x => x.Name).ToList();

                return new SuccessDataResult<AccessToken>(accessToken, Message.SuccessfulLogin);
            }
        }
    }
}
