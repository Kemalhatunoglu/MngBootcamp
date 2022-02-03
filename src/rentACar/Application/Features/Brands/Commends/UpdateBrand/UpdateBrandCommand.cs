using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities.Concete;
using MediatR;

namespace Application.Features.Brands.Commends.UpdateBrand
{
    public class UpdateBrandCommand : IRequest<BrandUpdateDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, BrandUpdateDto>
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

            public async Task<BrandUpdateDto> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
            {
                var existBrand = _brandRepository.GetAsync(x => x.Id == request.Id).Result;
                if (existBrand == null) throw new Exception("Brand referance exception");

                await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInserted(request.Name);
                var updateModelBrand = _mapper.Map<Brand>(request);
                await _brandRepository.UpdateAsync(updateModelBrand);

                var mappedReturnBrandDto = _mapper.Map<BrandUpdateDto>(updateModelBrand);
                return mappedReturnBrandDto;

            }
        }
    }
}
