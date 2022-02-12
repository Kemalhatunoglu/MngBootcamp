using Application.Constants;
using Application.Features.Authorizations.Rules;
using Application.Services.Repositories;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.Jwt;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Authorizations.Commands.RegisterCommand
{
    public class RegisterUserCommand : IRequest<IDataResult<AccessToken>>
    {
        public UserForRegisterDto UserForRegister { get; set; }

        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, IDataResult<AccessToken>>
        {
            private readonly IUserRepository _userRepository;
            private readonly ITokenHelper _tokenHelper;
            private readonly AuthBusinessRules _authBusinessRules;

            public RegisterUserCommandHandler(IUserRepository userRepository, ITokenHelper tokenHelper, AuthBusinessRules authBusinessRules)
            {
                _userRepository = userRepository;
                _tokenHelper = tokenHelper;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<IDataResult<AccessToken>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                await _authBusinessRules.UserEmailShouldBeNotExists(request.UserForRegister.Email);

                HashingHelper.CreatePasswordHash(request.UserForRegister.Password, out var passwordSalt, out var passwordHash);

                var user = new User
                {
                    FirstName = request.UserForRegister.FirstName,
                    LastName = request.UserForRegister.LastName,
                    Email = request.UserForRegister.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true
                };

                User createdUser = await _userRepository.AddAsync(user);

                List<OperationClaim> claims = _userRepository.GetClaims(createdUser);
                AccessToken accessToken = await _tokenHelper.CreateTokenAsync(createdUser, claims);
                accessToken.Claims = claims.Select(x => x.Name).ToList();

                return new SuccessDataResult<AccessToken>(accessToken, Message.UserRegistered);
            }
        }
    }
}
