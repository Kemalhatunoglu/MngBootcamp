using Application.Services.Repositories;
using Domain.Dtos;

namespace Application.Services.OutService.Cars
{
    public class CarManager : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarManager(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public CarDetailDto GetCarDetail(int id)
        {
            var carDetail = _carRepository.GetCarDetailToRental(id);
            return carDetail;
        }
    }
}
