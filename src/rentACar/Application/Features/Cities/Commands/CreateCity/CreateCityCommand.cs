using Application.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
using MediatR;

namespace Application.Features.Cities.Commands.CreateCity
{
    public class CreateCityCommand : IRequest<IDataResult<City>>
    {
        public string Name { get; set; }

        public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, IDataResult<City>>
        {
            private readonly ICityRepository _cityRepository;
            private readonly IMapper _mapper;

            public CreateCityCommandHandler(IMapper mapper, ICityRepository cityRepository)
            {
                _mapper = mapper;
                _cityRepository = cityRepository;
            }

            public async Task<IDataResult<City>> Handle(CreateCityCommand request, CancellationToken cancellationToken)
            {
                var mappedCity = _mapper.Map<City>(request);
                var cityToAdd = await _cityRepository.AddAsync(mappedCity);
                return new SuccessDataResult<City>(cityToAdd, Message.SuccessCreate);
            }
        }
    }
}
