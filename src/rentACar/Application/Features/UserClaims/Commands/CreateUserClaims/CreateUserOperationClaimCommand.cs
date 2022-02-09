using Application.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.UserClaims.Commands.CreateUserClaims
{
    public class CreateUserOperationClaimCommand : IRequest<IResult>
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

        public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, IResult>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;

            public CreateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                var mappedUserClaim = _mapper.Map<UserOperationClaim>(request);
                await _userOperationClaimRepository.AddAsync(mappedUserClaim);

                return new SuccessResult(Message.SuccessCreate);
            }
        }
    }
}
