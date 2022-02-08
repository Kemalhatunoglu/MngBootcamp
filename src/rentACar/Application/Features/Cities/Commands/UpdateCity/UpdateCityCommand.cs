using Application.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
using MediatR;

namespace Application.Features.Cities.Commands.UpdateCity
{
    public class UpdateCityCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, IResult>
        {
            private readonly ICityRepository _cityRepository;
            private readonly IMapper _mapper;

            public UpdateCityCommandHandler(IMapper mapper, ICityRepository cityRepository)
            {
                _mapper = mapper;
                _cityRepository = cityRepository;
            }

            public async Task<IResult> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
            {
                var updateModelCity = _mapper.Map<City>(request);
                await _cityRepository.UpdateAsync(updateModelCity);
                return new SuccessResult(Message.SuccessUpdate);
            }
        }
    }
}
