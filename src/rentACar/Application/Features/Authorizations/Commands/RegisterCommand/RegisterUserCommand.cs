using Application.Constants;
using Application.Services.Repositories;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Authorizations.Commands.RegisterCommand
{
    public class RegisterUserCommand : IRequest<IResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, IResult>
        {
            private readonly IUserRepository _userRepository;

            public RegisterUserCommandHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<IResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                var isExistUser = await _userRepository.GetAsync(u => u.Email == request.Email);
                if (isExistUser != null) return new ErrorResult(Message.NameAlreadyExist);

                HashingHelper.CreatePasswordHash(request.Password, out var passwordSalt, out var passwordHash);
                var user = new User
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true
                };

                await _userRepository.AddAsync(user);
                return new SuccessResult(Message.UserRegistered);
            }
        }
    }
}
