using Application.Constants;
using Application.Features.Rentals.Commands.UpdateRental;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities.Concete;

namespace Application.Features.Rentals.Rules
{
    public class RentalBusinessRules
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IInvoiceRepository _invoiceRepository;

        public RentalBusinessRules(IRentalRepository rentalRepository, ICarRepository carRepository, IInvoiceRepository invoiceRepository)
        {
            _rentalRepository = rentalRepository;
            _invoiceRepository = invoiceRepository;
        }

        public async Task RentalCanNotBeCreateWhenCarIsRented(int carId, DateTime StartDate, DateTime EndDate)
        {
            IPaginate<Rental> rentals = await _rentalRepository.GetListAsync(
                                            r => r.CarId == carId &&
                                                 r.EndDate >= StartDate &&
                                                 r.StartDate <= EndDate);
            if (rentals.Items.Any()) throw new BusinessException(Message.CarIsRented);
        }

        public async Task DeliveryCityIsSameCity(UpdateRentalCommand request)
        {
            var rentalRequest = await _rentalRepository.GetAsync(x => x.Id == request.Id);

            if (request.DeliveryCityId != rentalRequest.RentedCityId)
            {
                var rentalInvoice = await _invoiceRepository.GetAsync(x => x.CustomerId == request.CustomerId);
                rentalInvoice.TotalFee += 500;
                await _invoiceRepository.UpdateAsync(rentalInvoice);

                rentalRequest.RentedCityId = (int)request.DeliveryCityId;
                await _rentalRepository.UpdateAsync(rentalRequest);
            }
        }
    }
}
