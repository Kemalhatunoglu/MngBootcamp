using Application.Constants;
using Application.Features.Fuel.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Fuel.Commends.UpdateFuel
{
    public class UpdateFuelCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateFuelCommandHandler : IRequestHandler<UpdateFuelCommand, IResult>
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

            public async Task<IResult> Handle(UpdateFuelCommand request, CancellationToken cancellationToken)
            {
                await _fuelBusinessRules.FuelNameCanNotBeDuplicatedWhenInserted(request.Name);

                var updateModelFuel = _mapper.Map<Domain.Entities.Concete.Fuel>(request);
                await _fuelRepository.UpdateAsync(updateModelFuel);
                return new SuccessResult(Message.SuccessUpdate);
            }
        }
    }
}
