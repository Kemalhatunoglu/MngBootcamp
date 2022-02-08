using Application.Constants;
using Application.Features.Cities.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Cities.Queries.GetListCities
{
    public class GetCityListQuery : IRequest<IDataResult<CityListModel>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetCityListQueryHandler : IRequestHandler<GetCityListQuery, IDataResult<CityListModel>>
        {
            private readonly ICityRepository _cityRepository;
            private readonly IMapper _mapper;

            public GetCityListQueryHandler(ICityRepository cityRepository, IMapper mapper)
            {
                _cityRepository = cityRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<CityListModel>> Handle(GetCityListQuery request, CancellationToken cancellationToken)
            {
                var cities = await _cityRepository.GetListAsync(
                   index: request.PageRequest.Page,
                   size: request.PageRequest.PageSize
                   );

                var mappedBrand = _mapper.Map<CityListModel>(cities);
                return new SuccessDataResult<CityListModel>(mappedBrand, Message.SuccessGet);
            }
        }
    }
}
