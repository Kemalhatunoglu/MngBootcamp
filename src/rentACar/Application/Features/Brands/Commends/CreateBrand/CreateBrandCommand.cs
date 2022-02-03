using Application.Constants;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
using MediatR;

namespace Application.Features.Brands.Commends.CreateBrand
{
    public class CreateBrandCommand : IRequest<IDataResult<Brand>>
    {
        public string Name { get; set; }

        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, IDataResult<Brand>>
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

            public async Task<IDataResult<Brand>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInserted(request.Name);
                Brand mappedBrand = _mapper.Map<Brand>(request);
                Brand brandToAdd = await _brandRepository.AddAsync(mappedBrand);
                return new SuccessDataResult<Brand>(brandToAdd, Message.SuccessCreate);
            }
        }

    }
}
//Cqrs de her şey domain nesnesi açısından gider. Bu işi yapacak domain nesnemize karşılık gelir.
//Mediatr Patternleri kullanır. Btk da C# dersini izle.
//Code Generater nedir.