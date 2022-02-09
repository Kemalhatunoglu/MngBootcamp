using Application.Constants;
using Application.Services.Repositories;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, IResult>
        {
            private readonly IUserRepository _userRepository;

            public DeleteUserCommandHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<IResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                var userToBeDeleted = await _userRepository.GetAsync(b => b.Id == request.Id);

                if (userToBeDeleted == null) return new ErrorResult(Message.ErrorDelete);

                await _userRepository.DeleteAsync(userToBeDeleted);
                return new SuccessResult(Message.SuccessDelete);
            }
        }
    }
}
