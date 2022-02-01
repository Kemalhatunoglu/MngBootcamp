using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities.Concete;
using MediatR;

namespace Application.Features.Brands.Commends.CreateBrand
{
    public class CreateBrandCommand : IRequest<Brand>
    {
        public string Name { get; set; }

        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, Brand>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandBusinessRules _brandBusinessRules;

            public CreateBrandCommandHandler(IBrandRepository brandRepository, BrandBusinessRules brandBusinessRules, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandBusinessRules = brandBusinessRules;
            }

            public async Task<Brand> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInserted(request.Name);
                var mapperBrand = _mapper.Map<Brand>(request);
                var createdBrand = await _brandRepository.AddAsync(mapperBrand);
                return createdBrand;
            }
        }

    }
}
//Cqrs de her şey domain nesnesi açısından gider. Bu işi yapacak domain nesnemize karşılık gelir.
//Mediatr Patternleri kullanır. Btk da C# dersini izle.
//Code Generater nedir.