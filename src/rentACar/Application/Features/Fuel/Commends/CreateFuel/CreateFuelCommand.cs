using Application.Constants;
using Application.Features.Fuel.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Fuel.Commends.CreateFuel
{
    public class CreateFuelCommand : IRequest<IDataResult<Domain.Entities.Concete.Fuel>>
    {
        public string Name { get; set; }

        public class CreateFuelCommandHandler : IRequestHandler<CreateFuelCommand, IDataResult<Domain.Entities.Concete.Fuel>>
        {
            private readonly IFuelRepository _fuelRepository;
            private readonly IMapper _mapper;
            private readonly FuelBusinessRules _fuelBusinessRules;

            public CreateFuelCommandHandler(FuelBusinessRules fuelBusinessRules, IMapper mapper, IFuelRepository fuelRepository)
            {
                _fuelBusinessRules = fuelBusinessRules;
                _mapper = mapper;
                _fuelRepository = fuelRepository;
            }

            public async Task<IDataResult<Domain.Entities.Concete.Fuel>> Handle(CreateFuelCommand request, CancellationToken cancellationToken)
            {
                await _fuelBusinessRules.FuelNameCanNotBeDuplicatedWhenInserted(request.Name);

                var mappedFuel = _mapper.Map<Domain.Entities.Concete.Fuel>(request);
                var fuelToAdd = await _fuelRepository.AddAsync(mappedFuel);
                return new SuccessDataResult<Domain.Entities.Concete.Fuel>(fuelToAdd, Message.SuccessCreate);
            }
        }
    }
}
