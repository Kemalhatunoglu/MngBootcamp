using Application.Constants;
using Application.Features.FindeksCredits.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
using Domain.Enums;
using MediatR;

namespace Application.Features.FindeksCredits.Command.CreateFindeksCredit
{
    public class CreateFindeksCreditCommand : IRequest<IDataResult<FindeksCredit>>
    {
        public int CustomerId { get; set; }
        public float Score { get; set; }
        public CustomerType CustomerType { get; set; }
        public float? FindeksRate { get; set; } = 100;

        public class CreateFindeksCreditCommandHandler : IRequestHandler<CreateFindeksCreditCommand, IDataResult<FindeksCredit>>
        {
            private readonly IFindeksCreditRepository _findeksCreditRepository;
            private readonly IMapper _mapper;
            private readonly FindeksCreditBusinessRules _findeksCreditBusinessRules;

            public CreateFindeksCreditCommandHandler(FindeksCreditBusinessRules findeksCreditBusinessRules, IMapper mapper, IFindeksCreditRepository findeksCreditRepository)
            {
                _findeksCreditBusinessRules = findeksCreditBusinessRules;
                _mapper = mapper;
                _findeksCreditRepository = findeksCreditRepository;
            }

            public async Task<IDataResult<FindeksCredit>> Handle(CreateFindeksCreditCommand request, CancellationToken cancellationToken)
            {
                var mappedFindeksCredit = _mapper.Map<FindeksCredit>(request);
                var findeksCreditToAdd = await _findeksCreditRepository.AddAsync(mappedFindeksCredit);
                return new SuccessDataResult<FindeksCredit>(findeksCreditToAdd,Message.SuccessCreate);
            }
        }
    }
}
