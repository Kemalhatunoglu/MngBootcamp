using Application.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities.Concete;

namespace Application.Features.Rentals.Rules
{
    public class RentalBusinessRules
    {
        private readonly IRentalRepository _rentalRepository;

        public RentalBusinessRules(IRentalRepository rentalRepository, ICarRepository carRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public async Task RentalCanNotBeCreateWhenCarIsRented(int carId, DateTime StartDate, DateTime EndDate)
        {
            IPaginate<Rental> rentals = await _rentalRepository.GetListAsync(
                                            r => r.CarId == carId &&
                                                 r.EndDate >= StartDate &&
                                                 r.StartDate <= EndDate);
            if (rentals.Items.Any()) throw new BusinessException(Message.CarIsRented);
        }
    }
}
