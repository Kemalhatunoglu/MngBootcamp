using Application.Constants;
using Application.Features.FindeksCredits.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
using Domain.Enums;
using MediatR;

namespace Application.Features.FindeksCredits.Command.UpdateFindeksCredit
{
    public class UpdateFindeksCreditCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public float Score { get; set; }
        public CustomerType CustomerType { get; set; }
        public float? FindeksRate { get; set; }

        public class UpdateFindeksCreditCommandHandler : IRequestHandler<UpdateFindeksCreditCommand, IResult>
        {
            private readonly IFindeksCreditRepository _findeksCreditRepository;
            private readonly IMapper _mapper;
            private readonly FindeksCreditBusinessRules _findeksCreditBusinessRules;

            public UpdateFindeksCreditCommandHandler(FindeksCreditBusinessRules findeksCreditBusinessRules, IMapper mapper, IFindeksCreditRepository findeksCreditRepository)
            {
                _findeksCreditBusinessRules = findeksCreditBusinessRules;
                _mapper = mapper;
                _findeksCreditRepository = findeksCreditRepository;
            }

            public async Task<IResult> Handle(UpdateFindeksCreditCommand request, CancellationToken cancellationToken)
            {
                await _findeksCreditBusinessRules.FindeksCreditMustBeEnough(request.Id);
                var mappedFindeksCredit = _mapper.Map<FindeksCredit>(request);
                await _findeksCreditRepository.UpdateAsync(mappedFindeksCredit);
                return new SuccessResult(Message.SuccessUpdate);
            }
        }
    }

}
