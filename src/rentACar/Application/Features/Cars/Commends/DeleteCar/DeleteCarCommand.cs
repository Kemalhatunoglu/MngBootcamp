using Application.Services.Repositories;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Cars.Commends.DeleteCar
{
    public class DeleteCarCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, IResult>
        {
            private readonly ICarRepository _carRepository;

            public DeleteCarCommandHandler(ICarRepository carRepository)
            {
                _carRepository = carRepository;
            }

            public async Task<IResult> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
            {
                var deleteCar = await _carRepository.GetAsync(c => c.Id == request.Id);
                if (deleteCar != null)
                {
                    await _carRepository.DeleteAsync(deleteCar);
                    return new SuccessResult();
                }
                return new ErrorResult();
            }
        }
    }
}
