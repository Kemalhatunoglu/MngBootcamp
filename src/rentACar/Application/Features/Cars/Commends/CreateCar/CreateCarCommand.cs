using Application.Constants;
using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
using Domain.Enums;
using MediatR;

namespace Application.Features.Cars.Commends.CreateCar
{
    public class CreateCarCommand : IRequest<IDataResult<CarCommandDto>>
    {
        public int ModelId { get; set; }
        public int ColorId { get; set; }
        public int CityId { get; set; }
        public string Plate { get; set; }
        public short ModelYear { get; set; }
        public CarState CarState { get; set; }
        public double StartingKm { get; set; }

        public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, IDataResult<CarCommandDto>>
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

            public async Task<IDataResult<CarCommandDto>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
            {
                await _carBusinessRules.CarPlateMustBeUnique(request.Plate);
                await _carBusinessRules.ModelYearCanNotBeGreaterThanCurrentYear(request.ModelYear);

                Car mappedCar = _mapper.Map<Car>(request);
                Car carToAdd = await _carRepository.AddAsync(mappedCar);
                var mapToDto = _mapper.Map<CarCommandDto>(carToAdd);
                return new SuccessDataResult<CarCommandDto>(mapToDto, Message.SuccessCreate);
            }
        }
    }
}
