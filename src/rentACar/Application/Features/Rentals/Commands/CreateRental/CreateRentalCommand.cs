using Application.Constants;
using Application.Features.Cars.Rules;
using Application.Features.Rentals.Rules;
using Application.Services.OutService.Cars;
using Application.Services.OutService.Invoices;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
using MediatR;

namespace Application.Features.Rentals.Commands.CreateRental
{
    public class CreateRentalCommand : IRequest<IDataResult<Rental>>
    {
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RentedCityId { get; set; }
        public int? DeliveryCityId { get; set; }
        public List<int>? AdditionalServiceIds { get; set; }

        public class CreateRentalCommandHandler : IRequestHandler<CreateRentalCommand, IDataResult<Rental>>
        {
            private readonly IRentalRepository _rentalRepository;
            private readonly IMapper _mapper;
            private readonly IInvoiceService _invoiceService;
            private readonly ICarService _carService;
            private readonly CarBusinessRules _carBusinessRules;
            private readonly RentalBusinessRules _rentalBusinessRules;

            public CreateRentalCommandHandler(IRentalRepository rentalRepository, IMapper mapper, CarBusinessRules carBusinessRules, RentalBusinessRules rentalBusinessRules, IInvoiceService invoiceService, ICarService carService)
            {
                _rentalRepository = rentalRepository;
                _mapper = mapper;
                _carBusinessRules = carBusinessRules;
                _rentalBusinessRules = rentalBusinessRules;
                _invoiceService = invoiceService;
                _carService = carService;
            }

            public async Task<IDataResult<Rental>> Handle(CreateRentalCommand request, CancellationToken cancellationToken)
            {
                var carDetailToRental = _carService.GetCarDetail(request.CarId);

                Rental mappedRental = _mapper.Map<Rental>(request);
                Rental rentalToAdd = await _rentalRepository.AddAsync(mappedRental);

                Invoice newInvoice = await _invoiceService.CreateInvoice(mappedRental, carDetailToRental.DailyPrice, null);
                await _invoiceService.AddInvoiceAsync(newInvoice);

                return new SuccessDataResult<Rental>(rentalToAdd, Message.SuccessCreate);
            }
        }
    }
}
