using Application.Constants;
using Application.Features.Cars.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Cars.Queries
{
    public class GetCarListByCityIdQuery : IRequest<IDataResult<CarCommandDto>>
    {
        public int CityId { get; set; }

        public class GetCarListByCityIdQueryHandler : IRequestHandler<GetCarListByCityIdQuery, IDataResult<CarCommandDto>>
        {
            private readonly ICarRepository _carRepository;
            private readonly IMapper _mapper;

            public GetCarListByCityIdQueryHandler(IMapper mapper, ICarRepository carRepository)
            {
                _mapper = mapper;
                _carRepository = carRepository;
            }

            public async Task<IDataResult<CarCommandDto>> Handle(GetCarListByCityIdQuery request, CancellationToken cancellationToken)
            {
                var response = await _carRepository.GetAsync(car => car.CityId == request.CityId);
                if (response.Id < 0) return new ErrorDataResult<CarCommandDto>(Message.ErrorGet);

                var mappedCars = _mapper.Map<CarCommandDto>(response);
                return new SuccessDataResult<CarCommandDto>(mappedCars, Message.SuccessGet);
            }
        }
    }
}
