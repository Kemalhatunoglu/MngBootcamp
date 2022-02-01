using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
using MediatR;

namespace Application.Features.Cars.Commends.UpdateCar
{
    public class UpdateCarCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public int ColorId { get; set; }
        public string Plate { get; set; }
        public short ModelYear { get; set; }

        public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, IResult>
        {
            private readonly ICarRepository _carRepository;
            private readonly IMapper _mapper;

            public UpdateCarCommandHandler(ICarRepository carRepository, IMapper mapper)
            {
                _carRepository = carRepository;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
            {
                var isExistBrand = await _carRepository.GetAsync(x => x.Id == request.Id);


                var mapperBrand = _mapper.Map<Car>(isExistBrand);

                await _carRepository.UpdateAsync(mapperBrand);

                return new SuccessResult("The update has been performed.");
            }
        }
    }
}
