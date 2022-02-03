using Application.Constants;
using Application.Features.Fuel.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Fuel.Queries
{
    public class GetFuelListQuery : IRequest<IDataResult<FuelListModel>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetFuelListQueryHandler : IRequestHandler<GetFuelListQuery, IDataResult<FuelListModel>>
        {
            readonly IFuelRepository _fuelRepository;
            private readonly IMapper _mapper;

            public GetFuelListQueryHandler(IFuelRepository fuelRepository, IMapper mapper)
            {
                _fuelRepository = fuelRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<FuelListModel>> Handle(GetFuelListQuery request, CancellationToken cancellationToken)
            {
                var fuels = await _fuelRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                    );
                var mappedFuel = _mapper.Map<FuelListModel>(fuels);

                return new SuccessDataResult<FuelListModel>(mappedFuel, Message.SuccessGet);
            }
        }
    }
}
