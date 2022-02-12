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
    public class UpdateCarStateCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public CarState CarState { get; set; }
        public double? FinishKm { get; set; }
        public int? CityId { get; set; }

        public class UpdateCarStateCommandHandler : IRequestHandler<UpdateCarStateCommand, IResult>
        {
            private readonly ICarRepository _carRepository;
            private readonly IMapper _mapper;
            private readonly CarStateBusinessRule _carStateBusinessRule;

            public UpdateCarStateCommandHandler(ICarRepository carRepository, IMapper mapper, CarStateBusinessRule carStateBusinessRule)
            {
                _carRepository = carRepository;
                _mapper = mapper;
                _carStateBusinessRule = carStateBusinessRule;
            }

            public async Task<IResult> Handle(UpdateCarStateCommand request, CancellationToken cancellationToken)
            {
                await _carStateBusinessRule.CheckIsCarAvailable(request);
                await _carStateBusinessRule.CheckIsFinishKmGreaterThenStartKm(request);

                Car currentCar = await _carRepository.GetAsync(c => c.Id == request.Id);
                currentCar.CarState = request.CarState;

                if (request.FinishKm > 0)
                {
                    currentCar.StartingKm = (double)request.FinishKm;
                    currentCar.CityId = (int)request.CityId;
                }

                await _carRepository.UpdateAsync(currentCar);
                return new SuccessResult(Message.SuccessStateUpdate);
            }
        }
    }
}
