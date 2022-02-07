using Application.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities.Concete;
using Domain.Enums;
using System.Text.RegularExpressions;

namespace Application.Features.Cars.Rules
{
    public class CarBusinessRules
    {
        private readonly ICarRepository _carRepository;

        public CarBusinessRules(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public void CarPlateMustBeUnique(string plate)
        {
            Regex regex = new("(0[1-9]|[1-7][0-9]|8[01])(([A-Z])(\\d{4,5})|([A-Z]{2})(\\d{3,4})|([A-Z]{3})(\\d{2}))");
            bool isCorrent = regex.IsMatch(plate);

            if (!isCorrent) throw new BusinessException(Message.ModelYearCheck);
        }

        public void ModelYearCanNotBeGreaterThanCurrentYear(short modelYear)
        {
            var currentYear = DateTime.Now.Year;
            if (modelYear > currentYear) throw new BusinessException(Message.ModelYearCheck);
        }

        public async Task CarCanNotBeMaintainWhenIsRented(int id)
        {
            Car? car = await _carRepository.GetAsync(c => c.Id == id);
            if (car!.CarState == CarState.Rented) throw new BusinessException(Message.CarIsntMaintainIsRent);
        }

        public async Task CarCanNotBeRentWhenIsInMaintenance(int carId)
        {
            Car? car = await _carRepository.GetAsync(c => c.Id == carId);
            if (car!.CarState == CarState.Maintenance) throw new BusinessException(Message.CarIsMaintenance);
        }
    }
}
