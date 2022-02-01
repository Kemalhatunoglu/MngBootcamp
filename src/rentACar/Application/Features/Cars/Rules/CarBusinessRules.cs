using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
            Regex regex = new Regex("(0[1-9]|[1-7][0-9]|8[01])(([A-Z])(\\d{4,5})|([A-Z]{2})(\\d{3,4})|([A-Z]{3})(\\d{2}))");
            bool isCorrent = regex.IsMatch(plate);

            if (!isCorrent)
                throw new BusinessException("Plate format is not correct.");
        }

        public void ModelYearCanNotBeGreaterThanCurrentYear(short modelYear)
        {
            var currentYear = DateTime.Now.Year;
            if (modelYear > currentYear)
                throw new BusinessException("Model year cannot be greater than today");
        }

    }
}
