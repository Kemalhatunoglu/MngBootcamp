using Application.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.OperationClaims.Commands.UpdateClaim
{
    public class UpdateOperationClaimCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, IResult>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;

            public UpdateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                var isOperationClaimExists = await _operationClaimRepository.GetAsync(u => u.Id == request.Id);

                if (isOperationClaimExists == null) return new ErrorResult(Message.ErrorUpdate);
                var updateModelToOperationClaim = _mapper.Map<OperationClaim>(request);
                await _operationClaimRepository.UpdateAsync(isOperationClaimExists);
                return new SuccessResult(Message.SuccessUpdate);
            }
        }
    }
}