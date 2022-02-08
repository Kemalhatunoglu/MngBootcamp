using Application.Constants;
using Application.Features.Rentals.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
using Domain.Enums;
using MediatR;

namespace Application.Features.Rentals.Commands.UpdateRental
{
    public class UpdateRentalCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public CarState CarState { get; set; }
        public DateTime? MaintainStartDate { get; set; }
        public DateTime? MaintainEndDate { get; set; }
        public int? DeliveryCityId { get; set; }
        public double? FinishKm { get; set; }

        public class UpdateRentalCommandHandler : IRequestHandler<UpdateRentalCommand, IResult>
        {
            private readonly IRentalRepository _rentalRepository;
            private readonly ICarRepository _carRepository;
            private readonly IMapper _mapper;
            private readonly RentalBusinessRules _rentalBusinessRules;

            public UpdateRentalCommandHandler(IMapper mapper, IRentalRepository rentalRepository, RentalBusinessRules rentalBusinessRules, ICarRepository carRepository)
            {
                _mapper = mapper;
                _rentalRepository = rentalRepository;
                _rentalBusinessRules = rentalBusinessRules;
                _carRepository = carRepository;
            }

            public async Task<IResult> Handle(UpdateRentalCommand request, CancellationToken cancellationToken)
            {
                await _rentalBusinessRules.DeliveryCityIsSameCity(request);
                if (request.ReturnDate != null)
                {
                    var rentCar = new Car { FinishKm = request.FinishKm };
                    await _carRepository.UpdateAsync(rentCar);
                }
                var updateModelRental = _mapper.Map<Rental>(request);
                await _rentalRepository.UpdateAsync(updateModelRental);
                return new SuccessResult(Message.SuccessUpdate);
            }
        }
    }
}
