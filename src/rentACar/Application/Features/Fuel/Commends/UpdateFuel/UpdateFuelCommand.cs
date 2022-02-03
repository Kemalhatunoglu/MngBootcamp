using Application.Features.Fuel.Dtos;
using Application.Features.Fuel.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Fuel.Commends.UpdateFuel
{
    public class UpdateFuelCommand : IRequest<FuelUpdateDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateFuelCommandHandler : IRequestHandler<UpdateFuelCommand, FuelUpdateDto>
        {
            private readonly IFuelRepository _fuelRepository;
            private readonly IMapper _mapper;
            private readonly FuelBusinessRules _fuelBusinessRules;

            public UpdateFuelCommandHandler(IMapper mapper, FuelBusinessRules fuelBusinessRules, IFuelRepository fuelRepository)
            {
                _mapper = mapper;
                _fuelBusinessRules = fuelBusinessRules;
                _fuelRepository = fuelRepository;
            }

            public async Task<FuelUpdateDto> Handle(UpdateFuelCommand request, CancellationToken cancellationToken)
            {
                var existFuel = await _fuelRepository.GetAsync(f => f.Id == request.Id);
                if (existFuel == null) throw new Exception("Fuel update referance exception");

                await _fuelBusinessRules.FuelNameCanNotBeDuplicatedWhenInserted(request.Name);
                var updateFuelModel = _mapper.Map<Domain.Entities.Concete.Fuel>(request);
                await _fuelRepository.UpdateAsync(updateFuelModel);
                var mappedReturnFuelDto = _mapper.Map<FuelUpdateDto>(updateFuelModel);
                return mappedReturnFuelDto;
            }
        }
    }
}
