using Application.Constants;
using Application.Features.AdditionalServices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
using MediatR;

namespace Application.Features.AdditionalServices.Commands.UpdateAdditionalServices
{
    public class UpdateAdditionalServiceCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float DailyPrice { get; set; }
        public int Count { get; set; }

        public class UpdateAdditionalServiceCommandHandler : IRequestHandler<UpdateAdditionalServiceCommand, IResult>
        {
            private readonly IAdditionalServiceRepository _additionalServiceRepository;
            private readonly IMapper _mapper;
            private readonly AdditionalServiceBusinessRules _additionalServiceBusinessRules;

            public UpdateAdditionalServiceCommandHandler(AdditionalServiceBusinessRules additionalServiceBusinessRules, IAdditionalServiceRepository additionalServiceRepository, IMapper mapper)
            {
                _additionalServiceBusinessRules = additionalServiceBusinessRules;
                _additionalServiceRepository = additionalServiceRepository;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(UpdateAdditionalServiceCommand request, CancellationToken cancellationToken)
            {
                await _additionalServiceBusinessRules.AdditionalServiceNameCanNotBeDuplicated(request.Name);

                AdditionalService updateModelAdditionalService = _mapper.Map<AdditionalService>(request);
                await _additionalServiceRepository.UpdateAsync(updateModelAdditionalService);
                return new SuccessResult(Message.SuccessUpdate);
            }
        }
    }
}
