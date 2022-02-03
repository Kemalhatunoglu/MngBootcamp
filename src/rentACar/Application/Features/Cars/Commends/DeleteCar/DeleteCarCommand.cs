using Application.Services.Repositories;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Cars.Commends.DeleteCar
{
    public class DeleteCarCommand : IRequest<NoContent>
    {
        public int Id { get; set; }

        public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, NoContent>
        {
            private readonly ICarRepository _carRepository;

            public DeleteCarCommandHandler(ICarRepository carRepository)
            {
                _carRepository = carRepository;
            }

            public async Task<NoContent> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
            {
                var deleteCar = await _carRepository.GetAsync(c => c.Id == request.Id);
                if (deleteCar != null)
                {
                    await _carRepository.DeleteAsync(deleteCar);
                    return new NoContent();
                }
                return new NoContent();
            }
        }
    }
}
