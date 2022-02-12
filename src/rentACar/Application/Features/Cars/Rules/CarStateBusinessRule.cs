using Application.Constants;
using Application.Features.Cars.Commends.UpdateCar;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities.Concete;

namespace Application.Features.Cars.Rules
{
    public class CarStateBusinessRule
    {
        private readonly ICarRepository _carRepository;

        public CarStateBusinessRule(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        private async Task<Car> GetCurrentCar(int id)
        {
            var currentCar = await _carRepository.GetAsync(c => c.Id == id);
            if (currentCar != null)
                return currentCar;
            else
                throw new BusinessException(Message.CarNotExists);
        }

        public async Task CheckIsCarAvailable(UpdateCarStateCommand request)
        {
            var car = await GetCurrentCar(request.Id);

            if (request.CarState == Domain.Enums.CarState.Rented && car.CarState == Domain.Enums.CarState.Maintenance)
                throw new BusinessException(Message.CarIsMaintenance);

            if (request.CarState == Domain.Enums.CarState.Maintenance && car.CarState == Domain.Enums.CarState.Rented)
                throw new BusinessException(Message.CarIsntMaintainIsRent);
        }

        public async Task CheckIsFinishKmGreaterThenStartKm(UpdateCarStateCommand request)
        {
            var car = await GetCurrentCar(request.Id);

            if (request.FinishKm > 0 && request.FinishKm < car.StartingKm)
                throw new BusinessException(Message.KmNotValid);
        }
    }
}
