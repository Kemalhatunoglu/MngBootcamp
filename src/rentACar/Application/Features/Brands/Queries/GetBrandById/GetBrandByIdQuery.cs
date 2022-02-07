using Application.Constants;
using Application.Services.Repositories;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
using MediatR;

namespace Application.Features.Brands.Queries.GetBrandById
{
    public class GetBrandByIdQuery : IRequest<IDataResult<Brand>>
    {
        public int Id { get; set; }

        public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, IDataResult<Brand>>
        {
            private readonly IBrandRepository _brandRepository;

            public GetBrandByIdQueryHandler(IBrandRepository brandRepository)
            {
                _brandRepository = brandRepository;
            }

            public async Task<IDataResult<Brand>> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
            {
                Brand response = await _brandRepository.GetAsync(brand => brand.Id == request.Id);
                if (response.Id < 0) return new ErrorDataResult<Brand>(Message.ErrorGet);

                return new SuccessDataResult<Brand>(response, Message.SuccessGet);
            }
        }
    }
}
