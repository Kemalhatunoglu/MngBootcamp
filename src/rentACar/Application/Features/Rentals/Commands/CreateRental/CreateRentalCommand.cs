using Application.Constants;
using Application.Features.Cars.Rules;
using Application.Features.Rentals.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Rentals.Commands.CreateRental
{
    public class CreateRentalCommand : IRequest<IDataResult<Rental>>
    {
        public int CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public CarState CarState { get; set; }
        public DateTime? MaintainStartDate { get; set; }
        public DateTime? MaintainEndDate { get; set; }

        public class CreateRentalCommandHandler : IRequestHandler<CreateRentalCommand, IDataResult<Rental>>
        {
            private readonly IRentalRepository _rentalRepository;
            private readonly IMapper _mapper;
            private readonly CarBusinessRules _carBusinessRules;
            private readonly RentalBusinessRules _rentalBusinessRules;

            public CreateRentalCommandHandler(IRentalRepository rentalRepository, IMapper mapper, CarBusinessRules carBusinessRules, RentalBusinessRules rentalBusinessRules)
            {
                _rentalRepository = rentalRepository;
                _mapper = mapper;
                _carBusinessRules = carBusinessRules;
                _rentalBusinessRules = rentalBusinessRules;
            }

            public async Task<IDataResult<Rental>> Handle(CreateRentalCommand request, CancellationToken cancellationToken)
            {
                await _rentalBusinessRules.RentalCanNotBeCreateWhenCarIsRented(request.CarId, request.StartDate, request.EndDate);
                await _carBusinessRules.CarCanNotBeRentWhenIsInMaintenance(request.CarId);

                Rental mappedRental = _mapper.Map<Rental>(request);
                Rental rentalToAdd = await _rentalRepository.AddAsync(mappedRental);
                return new SuccessDataResult<Rental>(rentalToAdd, Message.SuccessCreate);
            }
        }
    }
}
