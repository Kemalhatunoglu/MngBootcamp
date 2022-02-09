using Application.Constants;
using Application.Services.Repositories;
using Core.Security.Entities;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.UserClaims.Commands.UpdateUserClaims
{
    public class UpdateUserOperationClaimCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int[] OperationClaimId { get; set; }

        public class UpdateUserOperationClaimCommandHandler : IRequestHandler<UpdateUserOperationClaimCommand, IResult>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;

            public UpdateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<IResult> Handle(UpdateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                var userList = request.OperationClaimId.Select(x => new UserOperationClaim() { OperationClaimId = x, UserId = request.UserId }).ToList();

                userList.ForEach(async x =>
                {
                    await _userOperationClaimRepository.UpdateAsync(x);
                });

                return new SuccessResult(Message.SuccessUpdate);
            }
        }
    }
}
