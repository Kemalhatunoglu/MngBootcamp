using Application.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.OperationClaims.Commands.CreateClaim
{
    public class CreateOperationClaimCommand : IRequest<IResult>
    {
        public string ClaimName { get; set; }

        public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, IResult>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;

            public CreateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                var isClaimExists = _operationClaimRepository.GetListAsync(x => x.Name == request.ClaimName);

                if (isClaimExists != null) return new ErrorResult(Message.OperationClaimExists);

                var mappedClaim = _mapper.Map<OperationClaim>(request);
                await _operationClaimRepository.AddAsync(mappedClaim);
                return new SuccessResult(Message.SuccessCreate);
            }
        }
    }
}
