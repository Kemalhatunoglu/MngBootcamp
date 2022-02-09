using Application.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, IResult>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public UpdateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
            {
                _mapper = mapper;
                _userRepository = userRepository;
            }

            public async Task<IResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var updateModelUser = _mapper.Map<User>(request);
                await _userRepository.UpdateAsync(updateModelUser);
                return new SuccessResult(Message.SuccessUpdate);
            }
        }
    }
}
