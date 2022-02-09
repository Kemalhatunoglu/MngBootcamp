using Application.Constants;
using Application.Services.Repositories;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.OperationClaims.Commands.DeleteClaim
{
    public class DeleteOperationClaimCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand, IResult>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;

            public DeleteOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository)
            {
                _operationClaimRepository = operationClaimRepository;
            }

            public async Task<IResult> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
            {
                var claimToDelete = await _operationClaimRepository.GetAsync(x => x.Id == request.Id);
                await _operationClaimRepository.DeleteAsync(claimToDelete);

                return new SuccessResult(Message.SuccessDelete);
            }
        }
    }
}
