using Application.Constants;
using Application.Services.Repositories;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Cities.Commands.DeleteCity
{
    public class DeleteCityCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, IResult>
        {
            private readonly ICityRepository _cityRepository;

            public DeleteCityCommandHandler(ICityRepository cityRepository)
            {
                _cityRepository = cityRepository;
            }

            public async Task<IResult> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
            {
                var cityToBeDeleted = await _cityRepository.GetAsync(x => x.Id == request.Id);
                if (cityToBeDeleted == null) return new ErrorResult(Message.ErrorDelete);
                await _cityRepository.DeleteAsync(cityToBeDeleted);
                return new SuccessResult(Message.SuccessDelete);
            }
        }
    }
}
