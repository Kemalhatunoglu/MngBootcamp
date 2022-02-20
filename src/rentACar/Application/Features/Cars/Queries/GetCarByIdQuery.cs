using Application.Constants;
using Application.Features.Cars.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Cars.Queries
{
    public class GetCarByIdQuery : IRequest<IDataResult<CarCommandDto>>
    {
        public int Id { get; set; }

        public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, IDataResult<CarCommandDto>>
        {
            private readonly ICarRepository _carRepository;
            private readonly IMapper _mapper;

            public GetCarByIdQueryHandler(IMapper mapper, ICarRepository carRepository)
            {
                _mapper = mapper;
                _carRepository = carRepository;
            }

            public async Task<IDataResult<CarCommandDto>> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
            {
                var response = await _carRepository.GetAsync(car => car.Id == request.Id);
                if (response.Id < 0) return new ErrorDataResult<CarCommandDto>(Message.ErrorGet);

                var mappedCars = _mapper.Map<CarCommandDto>(response);
                return new SuccessDataResult<CarCommandDto>(mappedCars, Message.SuccessGet);
            }
        }
    }
}
