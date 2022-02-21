using Application.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Dtos;
using MediatR;

namespace Application.Features.Cars.Queries
{
    public class GetCarsDetailQuery : IRequest<IDataResult<CarDetailDto>>
    {
        public int Id { get; set; }

        public class GetCarsDetailQueryHandler : IRequestHandler<GetCarsDetailQuery, IDataResult<CarDetailDto>>
        {
            private readonly ICarRepository _carRepository;
            private readonly IMapper _mapper;

            public GetCarsDetailQueryHandler(IMapper mapper, ICarRepository carRepository)
            {
                _mapper = mapper;
                _carRepository = carRepository;
            }

            public async Task<IDataResult<CarDetailDto>> Handle(GetCarsDetailQuery request, CancellationToken cancellationToken)
            {
                var response = _carRepository.GetCarDetailToRental(request.Id);
                return new SuccessDataResult<CarDetailDto>(response, Message.SuccessGet);
            }
        }
    }
}
