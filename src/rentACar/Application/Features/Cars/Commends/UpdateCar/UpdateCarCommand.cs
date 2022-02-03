using Application.Constants;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
using Domain.Enums;
using MediatR;

namespace Application.Features.Cars.Commends.UpdateCar
{
    public class UpdateCarCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public int ColorId { get; set; }
        public string Plate { get; set; }
        public short ModelYear { get; set; }
        public CarState CarState { get; set; }
        public DateTime? MaintainStartDate { get; set; }
        public DateTime? MaintainEndDate { get; set; }


        public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, IResult>
        {
            private readonly ICarRepository _carRepository;
            private readonly IMapper _mapper;
            private readonly CarBusinessRules _carBusinessRules;

            public UpdateCarCommandHandler(ICarRepository carRepository, IMapper mapper, CarBusinessRules carBusinessRules)
            {
                _carRepository = carRepository;
                _mapper = mapper;
                _carBusinessRules = carBusinessRules;
            }

            public async Task<IResult> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
            {
                Car mappedCar = _mapper.Map<Car>(request);
                await _carRepository.UpdateAsync(mappedCar);
                return new SuccessResult(Message.SuccessUpdate);
            }
        }
    }
}
