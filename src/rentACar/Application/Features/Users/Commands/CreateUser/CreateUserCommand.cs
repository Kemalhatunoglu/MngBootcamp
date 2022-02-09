using Application.Constants;
using Application.Features.Users.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<IDataResult<User>>
    {
        public UserCreateDto UserCreateDto { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, IDataResult<User>>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
            {
                _mapper = mapper;
                _userRepository = userRepository;
            }

            public async Task<IDataResult<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var mappedUser = _mapper.Map<User>(request);
                var userToAdd = await _userRepository.AddAsync(mappedUser);
                return new SuccessDataResult<User>(userToAdd, Message.SuccessCreate);
            }
        }
    }
}
