using Application.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Dtos;
using MediatR;

namespace Application.Features.Cars.Queries
{
    public class GetAllCarsDetailQuery : IRequest<IDataResult<List<CarDetailDto>>>
    {

        public class GetAllCarsDetailQueryHandler : IRequestHandler<GetAllCarsDetailQuery, IDataResult<List<CarDetailDto>>>
        {
            private readonly ICarRepository _carRepository;
            private readonly IMapper _mapper;

            public GetAllCarsDetailQueryHandler(IMapper mapper, ICarRepository carRepository)
            {
                _mapper = mapper;
                _carRepository = carRepository;
            }

            public async Task<IDataResult<List<CarDetailDto>>> Handle(GetAllCarsDetailQuery request, CancellationToken cancellationToken)
            {
                var response = await _carRepository.GetAllCarDetailToRental();
                return new SuccessDataResult<List<CarDetailDto>>(response, Message.SuccessGet);
            }
        }
    }
}