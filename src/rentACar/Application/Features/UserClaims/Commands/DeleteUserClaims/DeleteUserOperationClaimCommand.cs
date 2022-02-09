using Application.Constants;
using Application.Services.Repositories;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.UserClaims.Commands.DeleteUserClaims
{
    public class DeleteUserOperationClaimCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand, IResult>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;

            public DeleteUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<IResult> Handle(DeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                var entityToDelete = await _userOperationClaimRepository.GetAsync(x => x.UserId == request.Id);
                await _userOperationClaimRepository.DeleteAsync(entityToDelete);
                return new SuccessResult(Message.SuccessDelete);
            }
        }
    }
}
