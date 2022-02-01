using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities.Concete;
using MediatR;

namespace Application.Features.Cars.Commends.CreateCar
{
    public class CreateCarCommand : IRequest<Car>
    {
        public int ModelId { get; set; }
        public int ColorId { get; set; }
        public string Plate { get; set; }
        public short ModelYear { get; set; }

        public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Car>
        {
            private readonly ICarRepository _carRepository;
            private readonly IMapper _mapper;
            private readonly CarBusinessRules _carBusinessRules;

            public CreateCarCommandHandler(CarBusinessRules carBusinessRules, IMapper mapper, ICarRepository carRepository)
            {
                _carBusinessRules = carBusinessRules;
                _mapper = mapper;
                _carRepository = carRepository;
            }

            public async Task<Car> Handle(CreateCarCommand request, CancellationToken cancellationToken)
            {
                _carBusinessRules.CarPlateMustBeUnique(request.Plate);
                _carBusinessRules.ModelYearCanNotBeGreaterThanCurrentYear(request.ModelYear);

                var mapperCar = _mapper.Map<Car>(request);
                var createdCar = await _carRepository.AddAsync(mapperCar);
                return createdCar;
            }
        }
    }
}
