using Application.Constants;
using Application.Features.AdditionalServices.Dtos;
using Application.Features.AdditionalServices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
using MediatR;

namespace Application.Features.AdditionalServices.Commands.CreateAdditionalServices
{
    public class CreateAdditionalServiceCommand : IRequest<IDataResult<AdditionalServiceCommandDto>>
    {
        public AdditionalServiceCommandDto AdditionalProperty { get; set; }

        public class CreateAdditionalServiceCommandHandler : IRequestHandler<CreateAdditionalServiceCommand, IDataResult<AdditionalServiceCommandDto>>
        {
            private readonly IAdditionalServiceRepository _additionalServiceRepository;
            private readonly IMapper _mapper;
            private readonly AdditionalServiceBusinessRules _additionalServiceBusinessRules;

            public CreateAdditionalServiceCommandHandler(IMapper mapper, IAdditionalServiceRepository additionalServiceRepository, AdditionalServiceBusinessRules additionalServiceBusinessRules)
            {
                _mapper = mapper;
                _additionalServiceRepository = additionalServiceRepository;
                _additionalServiceBusinessRules = additionalServiceBusinessRules;
            }

            public async Task<IDataResult<AdditionalServiceCommandDto>> Handle(CreateAdditionalServiceCommand request, CancellationToken cancellationToken)
            {
                await _additionalServiceBusinessRules.AdditionalServiceNameCanNotBeDuplicated(request.AdditionalProperty.Name);

                var mappedAdditionalService = _mapper.Map<AdditionalService>(request);
                var addToBeAdditionalService = await _additionalServiceRepository.AddAsync(mappedAdditionalService);
                var mappedDto = _mapper.Map<AdditionalServiceCommandDto>(addToBeAdditionalService);
                return new SuccessDataResult<AdditionalServiceCommandDto>(mappedDto, Message.SuccessCreate);
            }
        }
    }
}
