using Application.Constants;
using Application.Services.OutService.RentalAdditionalServices;
using Application.Services.Repositories;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Rentals.Commands.DeleteRental
{
    public class DeleteRentalCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteRentalCommandHandler : IRequestHandler<DeleteRentalCommand, IResult>
        {
            private readonly IRentalRepository _rentalRepository;
            private readonly IRentalAdditionalService _rentalAdditionalService;

            public DeleteRentalCommandHandler(IRentalRepository rentalRepository, IRentalAdditionalService rentalAdditionalService)
            {
                _rentalRepository = rentalRepository;
                _rentalAdditionalService = rentalAdditionalService;
            }

            public async Task<IResult> Handle(DeleteRentalCommand request, CancellationToken cancellationToken)
            {
                var rentalToBeDeleted = await _rentalRepository.GetAsync(x => x.Id == request.Id);
                if (rentalToBeDeleted == null) return new ErrorResult(Message.ErrorDelete);
                await _rentalRepository.DeleteAsync(rentalToBeDeleted);

                await _rentalAdditionalService.DeleteAllRentalAdditionalServiceByRentalId(request.Id);
                return new SuccessResult(Message.SuccessDelete);
            }
        }
    }
}
