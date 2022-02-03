using Application.Constants;
using Application.Features.Cars.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Cars.Queries
{
    public class GetCarListQuery : IRequest<IDataResult<CarListModel>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetCarListQueryHandler : IRequestHandler<GetCarListQuery, IDataResult<CarListModel>>
        {
            private readonly ICarRepository _carRepository;
            private readonly IMapper _mapper;

            public GetCarListQueryHandler(IMapper mapper, ICarRepository carRepository)
            {
                _mapper = mapper;
                _carRepository = carRepository;
            }

            public async Task<IDataResult<CarListModel>> Handle(GetCarListQuery request, CancellationToken cancellationToken)
            {
                var cars = await _carRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                    );
                var mappedCars = _mapper.Map<CarListModel>(cars);

                return new SuccessDataResult<CarListModel>(mappedCars, Message.SuccessGet);
            }
        }
    }
}
