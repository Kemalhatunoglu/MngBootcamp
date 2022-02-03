using Application.Constants;
using Application.Services.Repositories;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Fuel.Commends.DeleteFuel
{
    public class DeleteFuelCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteFuelCommandHandler : IRequestHandler<DeleteFuelCommand, IResult>
        {
            private readonly IFuelRepository _fuelRepository;

            public DeleteFuelCommandHandler(IFuelRepository fuelRepository)
            {
                _fuelRepository = fuelRepository;
            }

            public async Task<IResult> Handle(DeleteFuelCommand request, CancellationToken cancellationToken)
            {
                var fuelToBeDeleted = await _fuelRepository.GetAsync(f => f.Id == request.Id);

                if (fuelToBeDeleted == null) return new ErrorResult(Message.ErrorDelete);

                await _fuelRepository.DeleteAsync(fuelToBeDeleted);
                return new SuccessResult(Message.SuccessDelete);
            }
        }
    }
}
