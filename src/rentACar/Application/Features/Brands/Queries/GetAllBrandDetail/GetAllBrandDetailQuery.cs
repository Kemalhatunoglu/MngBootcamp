using Application.Constants;
using Application.Services.Repositories;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Dtos;
using MediatR;

namespace Application.Features.Brands.Queries.GetAllBrandDetail
{
    public class GetAllBrandDetailQuery : IRequest<IDataResult<List<BrandDetailDto>>>
    {

        public class GetAllBrandDetailQueryHandler : IRequestHandler<GetAllBrandDetailQuery, IDataResult<List<BrandDetailDto>>>
        {
            private readonly IBrandRepository _brandRepository;

            public GetAllBrandDetailQueryHandler(IBrandRepository brandRepository)
            {
                _brandRepository = brandRepository;
            }

            public async Task<IDataResult<List<BrandDetailDto>>> Handle(GetAllBrandDetailQuery request, CancellationToken cancellationToken)
            {
                var response = await _brandRepository.GetAllBrandDetail();

                return new SuccessDataResult<List<BrandDetailDto>>(response, Message.SuccessGet);
            }
        }
    }
}
