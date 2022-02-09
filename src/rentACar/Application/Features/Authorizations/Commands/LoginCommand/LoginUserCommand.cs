using Application.Constants;
using Application.Services.Repositories;
using Core.Security.Hashing;
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

            public LoginUserCommandHandler(ITokenHelper tokenHelper, IUserRepository userRepository)
            {
                _tokenHelper = tokenHelper;
                _userRepository = userRepository;
            }

            public async Task<IDataResult<AccessToken>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetAsync(u => u.Email == request.Email);
                if (user == null) return new ErrorDataResult<AccessToken>(Message.UserNotFound);
                if (!HashingHelper.VerifyPasswordHash(request.Password, user.PasswordSalt, user.PasswordHash))
                    return new ErrorDataResult<AccessToken>(Message.PasswordError);

                var claims = _userRepository.GetClaims(user);

                var accessToken = _tokenHelper.CreateToken(user, claims);
                accessToken.Claims = claims.Select(x => x.Name).ToList();

                return new SuccessDataResult<AccessToken>(accessToken, Message.SuccessfulLogin);
            }
        }
    }
}
