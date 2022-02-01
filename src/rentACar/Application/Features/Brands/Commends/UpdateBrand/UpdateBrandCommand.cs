using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
using MediatR;

namespace Application.Features.Brands.Commends.UpdateBrand
{
    public class UpdateBrandCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, IResult>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandBusinessRules _brandBusinessRules;
            public UpdateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandBusinessRules = brandBusinessRules;
            }

            public async Task<IResult> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
            {
                var isExistBrand = await _brandRepository.GetAsync(x => x.Id == request.Id);
                await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInserted(isExistBrand.Name);
                var mapperBrand = _mapper.Map<Brand>(isExistBrand);
                await _brandRepository.UpdateAsync(mapperBrand);

                return new SuccessResult("The update has been performed.");
            }
        }
    }
}
